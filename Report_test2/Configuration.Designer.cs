using Report_test.Data;
using Report_test2.Data;
using System;
using System.Windows.Forms;

namespace Export1c
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        DataProvider data = new DataProvider();

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Configuration()
        {
            InitializeComponent();

            txtDataBase.Text = Config.Database;
            txtHost.Text = Config.Host;
            txtPort.Text = Config.Port.ToString();
            txtUsername.Text = Config.Username;
            txtPassowrd.Text = Config.Password;
            txtTimeout.Text = Config.Timeout.ToString();
            txtOrgId.Text = Config.OrgId.ToString();
            txtFunction.Text = Config.Function;

            Save.Enabled = false;
        }

        public void Key(object sender, KeyEventArgs e)
        {
            if (txtDataBase.Text != Config.Database ||
                txtHost.Text != Config.Host ||
                txtPort.Text != Config.Port.ToString() ||
                txtUsername.Text != Config.Username ||
                txtPassowrd.Text != Config.Password ||
                txtTimeout.Text != Config.Timeout.ToString() ||
                txtOrgId.Text != Config.OrgId.ToString() ||
                txtFunction.Text != Config.Function)
            {
                Save.Enabled = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            data.SaveConfiguration(txtDataBase.Text, txtHost.Text, Convert.ToInt32(txtPort.Text), txtUsername.Text, txtPassowrd.Text, Convert.ToInt32(txtTimeout.Text), Convert.ToInt32(txtOrgId.Text), txtFunction.Text);
            int num = (int)MessageBox.Show("Настройки сохранены!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            Close();
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassowrd = new System.Windows.Forms.Label();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblOrgId = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassowrd = new System.Windows.Forms.TextBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtOrgId = new System.Windows.Forms.TextBox();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.Cansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl.Location = new System.Drawing.Point(70, 5);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(220, 20);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Настройка подключения";
            // 
            // lblDataBase
            // 
            this.lblDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDataBase.Location = new System.Drawing.Point(5, 30);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(140, 16);
            this.lblDataBase.TabIndex = 1;
            this.lblDataBase.Text = "База данных";
            this.lblDataBase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHost
            // 
            this.lblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHost.Location = new System.Drawing.Point(5, 55);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(140, 16);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Адрес";
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPort
            // 
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPort.Location = new System.Drawing.Point(5, 80);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(140, 16);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Порт";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUsername.Location = new System.Drawing.Point(5, 105);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(140, 16);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Пользователь";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPassowrd
            // 
            this.lblPassowrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPassowrd.Location = new System.Drawing.Point(5, 130);
            this.lblPassowrd.Name = "lblPassowrd";
            this.lblPassowrd.Size = new System.Drawing.Size(140, 16);
            this.lblPassowrd.TabIndex = 5;
            this.lblPassowrd.Text = "Пароль";
            this.lblPassowrd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTimeout
            // 
            this.lblTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeout.Location = new System.Drawing.Point(5, 155);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(140, 16);
            this.lblTimeout.TabIndex = 6;
            this.lblTimeout.Text = "Время подключения";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblOrgId
            // 
            this.lblOrgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrgId.Location = new System.Drawing.Point(5, 180);
            this.lblOrgId.Name = "lblOrgId";
            this.lblOrgId.Size = new System.Drawing.Size(140, 16);
            this.lblOrgId.TabIndex = 7;
            this.lblOrgId.Text = "ID  Организации";
            this.lblOrgId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFunction
            // 
            this.lblFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFunction.Location = new System.Drawing.Point(5, 205);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(140, 16);
            this.lblFunction.TabIndex = 8;
            this.lblFunction.Text = "Функция вызова";
            this.lblFunction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(145, 26);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(195, 20);
            this.txtDataBase.TabIndex = 10;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(145, 51);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(195, 20);
            this.txtHost.TabIndex = 11;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(145, 76);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(195, 20);
            this.txtPort.TabIndex = 12;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(145, 101);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(195, 20);
            this.txtUsername.TabIndex = 13;
            // 
            // txtPassowrd
            // 
            this.txtPassowrd.Location = new System.Drawing.Point(145, 126);
            this.txtPassowrd.Name = "txtPassowrd";
            this.txtPassowrd.Size = new System.Drawing.Size(195, 20);
            this.txtPassowrd.TabIndex = 14;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(145, 151);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(100, 20);
            this.txtTimeout.TabIndex = 15;
            // 
            // txtOrgId
            // 
            this.txtOrgId.Location = new System.Drawing.Point(145, 176);
            this.txtOrgId.Name = "txtOrgId";
            this.txtOrgId.Size = new System.Drawing.Size(100, 20);
            this.txtOrgId.TabIndex = 16;
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(145, 201);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(195, 20);
            this.txtFunction.TabIndex = 17;
            this.txtFunction.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Key);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(183, 227);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 18;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cansel
            // 
            this.Cansel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cansel.Location = new System.Drawing.Point(264, 227);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(75, 23);
            this.Cansel.TabIndex = 19;
            this.Cansel.Text = "Отменить";
            this.Cansel.UseVisualStyleBackColor = true;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cansel;
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.ControlBox = false;
            this.Controls.Add(this.Cansel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.txtFunction);
            this.Controls.Add(this.txtOrgId);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.txtPassowrd);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.lblOrgId);
            this.Controls.Add(this.lblTimeout);
            this.Controls.Add(this.lblPassowrd);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassowrd;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Label lblOrgId;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassowrd;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.TextBox txtOrgId;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cansel;
    }
}