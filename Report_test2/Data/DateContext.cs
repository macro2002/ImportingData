using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Report_test2.Data
{
    static class Config
    {
        public static string Database { get; set; }
        public static string Host { get; set; }
        public static int Port { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int Timeout { get; set; }
        public static int OrgId { get; set; }
        public static string Function { get; set; }
    } 

    public class ExportTo1C
    {
        public int operation_type { get; set; }
        public DateTime operation_date { get; set; }
        public int ticket_type { get; set; }
        public int ticket_id { get; set; }
        public string blank_seria { get; set; }
        public int blank_number { get; set; }
        public int pay_type_id { get; set; }
        public Double price_nominal { get; set; }
        public Double price { get; set; }
        public string cashbox_name { get; set; }
        public int operator_id { get; set; }
        public string operator_name { get; set; }
        public int order_id { get; set; }
        public string customer_name { get; set; }
        public DateTime event_date { get; set; }
        public int event_id { get; set; }
        public int place_id { get; set; }
        public int show_id { get; set; }
        public string place { get; set; }
        public string building_name { get; set; }
        public string hall_name { get; set; }
        public string show_name { get; set; }
    }
}
