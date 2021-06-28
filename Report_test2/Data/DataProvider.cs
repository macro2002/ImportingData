using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using Report_test2.Data;
using System.Data;
using NpgsqlTypes;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Report_test.Data
{
    class DataProvider
    {    
        private NpgsqlConnection db;
        string exe_name = Path.GetFileName(Application.ExecutablePath);

        public DataProvider()
        {
            string Connection = string.Format("Database={0};Host={1};Port={2};Username={3};Password={4};SSL=True;", Config.Database, Config.Host, Config.Port, Config.Username, Config.Password);
            db = new NpgsqlConnection(Connection);
        }

        public void ReadConfiguration()
        {
            if (File.Exists(Application.StartupPath + @"\" + exe_name.Substring(0, exe_name.Length - 4) + ".ini")) { }
            else
            {
                StreamWriter textFile = new StreamWriter(exe_name.Substring(0, exe_name.Length - 4) + ".ini");
                textFile.WriteLine("[Connection]");
                textFile.WriteLine("Database=none");
                textFile.WriteLine("Host=localhost");
                textFile.WriteLine("Port=5433");
                textFile.WriteLine("Username=sa");
                textFile.WriteLine("Password=password");
                textFile.WriteLine("Timeout=300");
                textFile.WriteLine("");
                textFile.WriteLine("[Settings]");
                textFile.WriteLine("OrgId=0");
                textFile.WriteLine("Function=ExportTo1C");
                textFile.Close();
            }

            INIManager manager = new INIManager(Application.StartupPath + @"\" + exe_name.Substring(0, exe_name.Length - 4) + ".ini");
            Config.Database = manager.GetPrivateString("Connection", "Database");
            Config.Host = manager.GetPrivateString("Connection", "Host");
            Config.Port = Convert.ToInt32(manager.GetPrivateString("Connection", "Port"));
            Config.Username = manager.GetPrivateString("Connection", "Username");
            Config.Password = manager.GetPrivateString("Connection", "Password");
            Config.Timeout = Convert.ToInt32(manager.GetPrivateString("Connection", "Timeout"));

            Config.OrgId = Convert.ToInt32(manager.GetPrivateString("Settings", "OrgId"));
            Config.Function = manager.GetPrivateString("Settings", "Function");
        }

        public void SaveConfiguration(string Database, string Host, int Port, string Username, string Passowrd, int Timeout, int OrgId, string Function)
        {
            File.Delete(exe_name.Substring(0, exe_name.Length - 4) + ".ini");

            StreamWriter textFile = new StreamWriter(exe_name.Substring(0, exe_name.Length - 4) + ".ini");
            textFile.WriteLine("[Connection]");
            textFile.WriteLine("Database=" + Database);
            textFile.WriteLine("Host=" + Host);
            textFile.WriteLine("Port=" + Port);
            textFile.WriteLine("Username=" + Username);
            textFile.WriteLine("Password=" + Passowrd);
            textFile.WriteLine("Timeout=" + Timeout);
            textFile.WriteLine("");
            textFile.WriteLine("[Settings]");
            textFile.WriteLine("OrgId=" + OrgId);
            textFile.WriteLine("Function=" + Function);
            textFile.Close();
        }

        public void GreatDBF(DateTime dateStart, DateTime dateEnd)
        {
            if (Config.Host == "localhost")
            {
                int num = (int)MessageBox.Show("Подключение к серверу не настроено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }

            else
            {
                db.Open();

                string connect = string.Format("SELECT * FROM \"dozmorov\".\"{0}\"(@OrgId,@DateStart,@DateEnd)", Config.Function);
                NpgsqlCommand command = new NpgsqlCommand(connect, db);
                command.Parameters.Add("@OrgId", NpgsqlDbType.Integer).Value = Config.OrgId;
                command.Parameters.Add("@DateStart", NpgsqlDbType.Timestamp).Value = dateStart;
                command.Parameters.Add("@DateEnd", NpgsqlDbType.Timestamp).Value = dateEnd;
                command.CommandTimeout = Config.Timeout;
                NpgsqlDataReader reader = command.ExecuteReader();

                List<ExportTo1C> ExportList = new List<ExportTo1C>();
                while (reader.Read())
                {
                    string place2;
                    string building_name2;
                    string hall_name2;
                    string show_name2;

                    if (!reader.IsDBNull(18)) { place2 = reader.GetString(18); }
                    else { place2 = "Данные отсутствуют"; }
                    if (!reader.IsDBNull(19)) { building_name2 = reader.GetString(19); }
                    else { building_name2 = "Данные отсутствуют"; }
                    if (!reader.IsDBNull(20)) { hall_name2 = reader.GetString(20); }
                    else { hall_name2 = "Данные отсутствуют"; }
                    if (!reader.IsDBNull(21)) { show_name2 = reader.GetString(21); }
                    else { show_name2 = "Данные отсутствуют"; }
                    ExportList.Add(
                        new ExportTo1C()
                        {
                            operation_type = reader.GetInt32(0),
                            operation_date = reader.GetDateTime(1),
                            ticket_type = reader.GetInt32(2),
                            ticket_id = reader.GetInt32(3),
                            blank_seria = reader.GetString(4),
                            blank_number = reader.GetInt32(5),
                            pay_type_id = reader.GetInt32(6),
                            price_nominal = reader.GetDouble(7),
                            price = reader.GetDouble(8),
                            cashbox_name = reader.GetString(9),
                            operator_id = reader.GetInt32(10),
                            operator_name = reader.GetString(11),
                            order_id = reader.GetInt32(12),
                            customer_name = reader.GetString(13),
                            event_date = reader.GetDateTime(14),
                            event_id = reader.GetInt32(15),
                            place_id = reader.GetInt32(16),
                            show_id = reader.GetInt32(17),
                            place = place2,
                            building_name = building_name2,
                            hall_name = hall_name2,
                            show_name = show_name2
                        });
                }

                if (File.Exists(Application.StartupPath + "/" + exe_name.Substring(0, exe_name.Length - 4) + "/" + "Export.dbf"))
                {
                    File.Delete(Application.StartupPath + "/" + exe_name.Substring(0, exe_name.Length - 4) + "/" + "Export.dbf");
                }

                DirectoryInfo di = Directory.CreateDirectory(Application.StartupPath + "/" + exe_name.Substring(0, exe_name.Length - 4));
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/" + exe_name.Substring(0, exe_name.Length - 4) + ";Extended Properties=dBASE IV;User ID=Admin;Password=");
                con.Open();

                OleDbCommand create = con.CreateCommand();
                create.CommandText = string.Format("CREATE TABLE Export.dbf(operation_type numeric(8), o_date date, ticket_type numeric(8), ticket_id numeric(8), blank_seria char(254), blank_number numeric(8), pay_type_id numeric(8), price_nominal numeric(8), price numeric(8), cashbox_name char(254), operator_id numeric(8), operator_name char(254), order_id numeric(8), customer_name char(254), event_date date, event_id numeric(8), place_id numeric(8), show_id numeric(8), place char(254), building_name char(254), hall_name char(254), show_name char(254));");
                create.ExecuteNonQuery();

                foreach (var item in ExportList)
                {
                    OleDbCommand insert = con.CreateCommand();
                    insert.CommandText = string.Format("INSERT INTO Export.dbf (operation_type, o_date, ticket_type, ticket_id, blank_seria, blank_number, pay_type_id, price_nominal, price, cashbox_name, operator_id, operator_name, order_id, customer_name, event_date, event_id, place_id, show_id, place, building_name, hall_name, show_name) VALUES (operation_type, o_date, ticket_type, ticket_id, blank_seria, blank_number, pay_type_id, price_nominal, price, cashbox_name, operator_id, operator_name, order_id, customer_name, event_date, event_id, place_id, show_id, place, building_name, hall_name, show_name);");
                    insert.Parameters.Add("@operation_type", OleDbType.Integer).Value = item.operation_type;
                    insert.Parameters.Add("@o_date", OleDbType.Date).Value = item.operation_date;
                    insert.Parameters.Add("@ticket_type", OleDbType.Integer).Value = item.ticket_type;
                    insert.Parameters.Add("@ticket_id", OleDbType.Integer).Value = item.ticket_id;
                    insert.Parameters.Add("@blank_seria", OleDbType.Char).Value = item.blank_seria;
                    insert.Parameters.Add("@blank_number", OleDbType.Integer).Value = item.blank_number;
                    insert.Parameters.Add("@pay_type_id", OleDbType.Integer).Value = item.pay_type_id;
                    insert.Parameters.Add("@price_nominal", OleDbType.Double).Value = item.price_nominal;
                    insert.Parameters.Add("@price", OleDbType.Double).Value = item.price;
                    insert.Parameters.Add("@cashbox_name", OleDbType.Char).Value = item.cashbox_name;
                    insert.Parameters.Add("@operator_id", OleDbType.Integer).Value = item.operator_id;
                    insert.Parameters.Add("@operator_name", OleDbType.Char).Value = item.operator_name;
                    insert.Parameters.Add("@order_id", OleDbType.Integer).Value = item.order_id;
                    insert.Parameters.Add("@customer_name", OleDbType.Char).Value = item.customer_name;
                    insert.Parameters.Add("@event_date", OleDbType.Date).Value = item.event_date;
                    insert.Parameters.Add("@event_id", OleDbType.Integer).Value = item.event_id;
                    insert.Parameters.Add("@place_id", OleDbType.Integer).Value = item.place_id;
                    insert.Parameters.Add("@show_id", OleDbType.Integer).Value = item.show_id;
                    insert.Parameters.Add("@place", OleDbType.Char).Value = item.place;
                    insert.Parameters.Add("@building_name", OleDbType.Char).Value = item.building_name;
                    insert.Parameters.Add("@hall_name", OleDbType.Char).Value = item.hall_name;
                    insert.Parameters.Add("@show_name", OleDbType.Char).Value = item.show_name;
                    insert.ExecuteNonQuery();
                }
                int num2 = (int)MessageBox.Show("Экспорт завершен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }  
        }
    }
}
