using Export1c;
using Report_test.Data;
using Report_test2.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Report_test2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public delegate void ExportHandler();
        DataProvider data = new DataProvider();


        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Form1()
        {
            InitializeComponent();
            DateStart.Format = DateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            DateStart.CustomFormat = DateEnd.CustomFormat = " ";
            DateEnd.Enabled = false;
            Report.Enabled = false;
            StatusExport.Text = "Готов";

            data.ReadConfiguration();
        }

        private void DateStart_ValueChanged(object sender, EventArgs e)
        {
            DateStart.CustomFormat = "d MMM yyyy";
            DateEnd.MinDate = DateStart.Value;
            DateEnd.Enabled = true;
        }

        private void DateEnd_ValueChanged(object sender, EventArgs e)
        {
            DateEnd.CustomFormat = "d MMM yyyy";
            Report.Enabled = true;
        }

        private void Report_Click(object sender, EventArgs e)
        {
            StatusExport.Text = "Экспортируется";

            DateStart.Format = DateEnd.Format = DateTimePickerFormat.Custom;
            DateStart.CustomFormat = DateEnd.CustomFormat = " ";
            DateStart.Enabled = false;
            DateEnd.Enabled = false;
            Report.Enabled = false;

            ExportHandler handler = new ExportHandler(Export);
            IAsyncResult resultObj = handler.BeginInvoke(new AsyncCallback(AsyncCompleted), "Асинхронный вызов");
        }

        private void Export()
        {
            DataProvider data = new DataProvider();
            try
            {
                data.GreatDBF(DateStart.Value, DateEnd.Value);
            }
            catch (WebException)
            {
                int num = (int)MessageBox.Show("Сервер не доступен, повторите позднее", "Ошибка подключения!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void AsyncCompleted(IAsyncResult resObj)
        {         
            StatusExport.Text = "Готов";
            BeginInvoke(new Action(delegate () {
                DateStart.Value = DateEnd.Value = DateTime.Now;
                DateStart.CustomFormat = DateEnd.CustomFormat = " ";
                DateStart.Enabled = true;
            }));
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration conf = new Configuration();
            conf.ShowDialog();
        }


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DateStart = new System.Windows.Forms.DateTimePicker();
            this.DateEnd = new System.Windows.Forms.DateTimePicker();
            this.Report = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.StatusExport = new System.Windows.Forms.ToolStripStatusLabel();
            this.About = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DateStart
            // 
            this.DateStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateStart.Location = new System.Drawing.Point(5, 30);
            this.DateStart.Name = "DateStart";
            this.DateStart.Size = new System.Drawing.Size(200, 22);
            this.DateStart.TabIndex = 1;
            this.DateStart.ValueChanged += new System.EventHandler(this.DateStart_ValueChanged);
            // 
            // DateEnd
            // 
            this.DateEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateEnd.Location = new System.Drawing.Point(210, 30);
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.Size = new System.Drawing.Size(200, 22);
            this.DateEnd.TabIndex = 2;
            this.DateEnd.ValueChanged += new System.EventHandler(this.DateEnd_ValueChanged);
            // 
            // Report
            // 
            this.Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Report.Location = new System.Drawing.Point(420, 29);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(120, 23);
            this.Report.TabIndex = 3;
            this.Report.Text = "Экспорт";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // status
            // 
            this.status.AutoSize = false;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusExport,
            this.About});
            this.status.Location = new System.Drawing.Point(0, 56);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(544, 22);
            this.status.SizingGrip = false;
            this.status.TabIndex = 4;
            this.status.Text = "statusStrip1";
            // 
            // StatusExport
            // 
            this.StatusExport.AutoSize = false;
            this.StatusExport.Name = "StatusExport";
            this.StatusExport.Size = new System.Drawing.Size(100, 17);
            // 
            // About
            // 
            this.About.AutoSize = false;
            this.About.Margin = new System.Windows.Forms.Padding(170, 3, 0, 2);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(260, 17);
            this.About.Text = "ООО «Городские Зрелищные Кассы» v1.0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.оПрограммеToolStripMenuItem.Text = "Выход";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 78);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.DateEnd);
            this.Controls.Add(this.DateStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экспорт в 1С";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DateStart;
        private System.Windows.Forms.DateTimePicker DateEnd;
        private System.Windows.Forms.Button Report;
        private StatusStrip status;
        private ToolStripStatusLabel StatusExport;
        private ToolStripStatusLabel About;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

