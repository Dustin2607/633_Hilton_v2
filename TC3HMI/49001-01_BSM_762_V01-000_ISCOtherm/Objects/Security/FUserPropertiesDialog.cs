namespace App.Security
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    using App.Components;

    public class FUserPropertiesDialog : Form
    {
        private Button buttonApply;
        private Button buttonClose;
        private Button buttonOk;
        private CheckBox checkBoxAutoLogOn;
        private CheckBox checkBoxDisabled;
        private ComboBox comboBoxLanguage;
        private ComboBox comboBoxUserType;
        private ComboBox comboBoxAutoLogout;
        private Container components;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private CUser localUser;
        private CLanguageManager lm;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBoxDescription;
        private TextBox textBoxFullName;
        private TextBox textBoxPassword;
        private TextBox textBoxShiftEnd;
        private TextBox textBoxShiftStart;
        private Label label10;
        private Label label9;
        private TextBox textBoxUserName;

        public FUserPropertiesDialog(CUser user)
        {
            this.InitializeComponent();
            this.localUser = user;
            this.FillComboUserType();
            this.FillComboAutoLogout();
            this.FillComboUserLanguage();
            this.WriteInfoToField();
            this.buttonApply.Enabled = false;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            this.WriteInfoToStruct();
            this.WriteInfoToField();
            this.buttonApply.Enabled = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (!this.buttonApply.Enabled)
            {
                base.DialogResult = DialogResult.OK;
            }
            base.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.WriteInfoToStruct();
            this.WriteInfoToField();
            base.Close();
        }

        private void checkBoxDisabled_CheckedChanged(object sender, EventArgs e)
        {
            this.buttonApply.Enabled = true;
        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonApply.Enabled = true;
        }

        private void comboBoxAutoLogout_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillComboUserLanguage()
        {
            this.comboBoxLanguage.Items.Add("German");
            this.comboBoxLanguage.Items.Add("English");
            this.comboBoxLanguage.Items.Add("Frensh");
            this.comboBoxLanguage.Items.Add("Italian");
            this.comboBoxLanguage.Items.Add("Spain");
            if (this.comboBoxLanguage.Items.Count >= 1)
            {
                this.comboBoxLanguage.SelectedIndex = 1;
            }
        }

        private void FillComboUserType()
        {
            foreach (CUserLevel level in Enum.GetValues(typeof(CUserLevel)))
            {
                this.comboBoxUserType.Items.Add(level.ToString());
            }
            if (this.comboBoxUserType.Items.Count >= 1)
            {
                this.comboBoxUserType.SelectedIndex = 0;
            }
        }

        private void FillComboAutoLogout()
        {
            this.comboBoxAutoLogout.Items.Add("None");
            this.comboBoxAutoLogout.Items.Add("1 min");
            this.comboBoxAutoLogout.Items.Add("2 min");
            this.comboBoxAutoLogout.Items.Add("5 min");
            this.comboBoxAutoLogout.Items.Add("10 min");
            this.comboBoxAutoLogout.Items.Add("15 min");
            if (this.comboBoxAutoLogout.Items.Count >= 1)
            {
                this.comboBoxAutoLogout.SelectedIndex = 0;
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxShiftStart = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxShiftEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxAutoLogOn = new System.Windows.Forms.CheckBox();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.comboBoxAutoLogout = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxDisabled = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Full name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(104, 25);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(232, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(104, 49);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(232, 20);
            this.textBoxFullName.TabIndex = 1;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(104, 73);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(232, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(104, 113);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(232, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxShiftStart);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxShiftEnd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(8, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shift";
            this.groupBox1.Visible = false;
            // 
            // textBoxShiftStart
            // 
            this.textBoxShiftStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.textBoxShiftStart.Location = new System.Drawing.Point(96, 19);
            this.textBoxShiftStart.Name = "textBoxShiftStart";
            this.textBoxShiftStart.Size = new System.Drawing.Size(224, 20);
            this.textBoxShiftStart.TabIndex = 0;
            this.textBoxShiftStart.Text = "00:00:00";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Start:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxShiftEnd
            // 
            this.textBoxShiftEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.textBoxShiftEnd.Location = new System.Drawing.Point(96, 48);
            this.textBoxShiftEnd.Name = "textBoxShiftEnd";
            this.textBoxShiftEnd.Size = new System.Drawing.Size(224, 20);
            this.textBoxShiftEnd.TabIndex = 1;
            this.textBoxShiftEnd.Text = "00:00:00";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(24, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "End:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOk
            // 
            this.buttonOk.AccessibleDescription = "";
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOk.Location = new System.Drawing.Point(104, 361);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(72, 24);
            this.buttonOk.TabIndex = 9;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonClose.Location = new System.Drawing.Point(184, 361);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(72, 24);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // checkBoxAutoLogOn
            // 
            this.checkBoxAutoLogOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxAutoLogOn.Location = new System.Drawing.Point(16, 314);
            this.checkBoxAutoLogOn.Name = "checkBoxAutoLogOn";
            this.checkBoxAutoLogOn.Size = new System.Drawing.Size(320, 16);
            this.checkBoxAutoLogOn.TabIndex = 8;
            this.checkBoxAutoLogOn.Text = "User can logged on automatically";
            this.checkBoxAutoLogOn.Visible = false;
            this.checkBoxAutoLogOn.CheckedChanged += new System.EventHandler(this.checkBoxDisabled_CheckedChanged);
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.Location = new System.Drawing.Point(104, 136);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(232, 21);
            this.comboBoxUserType.TabIndex = 4;
            this.comboBoxUserType.SelectedIndexChanged += new System.EventHandler(this.comboBoxUserType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "User type:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Location = new System.Drawing.Point(104, 160);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(232, 21);
            this.comboBoxLanguage.TabIndex = 5;
            this.comboBoxLanguage.Visible = false;
            // 
            // comboBoxAutoLogout
            // 
            this.comboBoxAutoLogout.Location = new System.Drawing.Point(104, 184);
            this.comboBoxAutoLogout.Name = "comboBoxAutoLogout";
            this.comboBoxAutoLogout.Size = new System.Drawing.Size(232, 21);
            this.comboBoxAutoLogout.TabIndex = 39;
            this.comboBoxAutoLogout.SelectedIndexChanged += new System.EventHandler(this.comboBoxAutoLogout_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Language:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 1);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 193);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(328, 1);
            this.textBox2.TabIndex = 6;
            this.textBox2.TabStop = false;
            // 
            // buttonApply
            // 
            this.buttonApply.AccessibleDescription = "";
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonApply.Location = new System.Drawing.Point(264, 361);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(72, 24);
            this.buttonApply.TabIndex = 11;
            this.buttonApply.Text = "Apply";
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // checkBoxDisabled
            // 
            this.checkBoxDisabled.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxDisabled.Location = new System.Drawing.Point(16, 338);
            this.checkBoxDisabled.Name = "checkBoxDisabled";
            this.checkBoxDisabled.Size = new System.Drawing.Size(320, 16);
            this.checkBoxDisabled.TabIndex = 9;
            this.checkBoxDisabled.Text = "Account is disabled";
            this.checkBoxDisabled.CheckedChanged += new System.EventHandler(this.checkBoxDisabled_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 38;
            this.label10.Text = "Auto logout time:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(328, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Edit user properties";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FUserPropertiesDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(346, 393);
            this.Controls.Add(this.comboBoxAutoLogout);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBoxDisabled);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBoxUserType);
            this.Controls.Add(this.checkBoxAutoLogOn);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FUserPropertiesDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New User";
            this.Load += new System.EventHandler(this.UserProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.label1.Text = this.lm.GetString("UserProperties.label1", "User name:", true);
                this.label2.Text = this.lm.GetString("UserProperties.label2", "Full name:", true);
                this.label3.Text = this.lm.GetString("UserProperties.label3", "Description:", true);
                this.label4.Text = this.lm.GetString("UserProperties.label4", "Password:", true);
                this.label5.Text = this.lm.GetString("UserProperties.label5", "Member Of:", true);
                this.label6.Text = this.lm.GetString("UserProperties.label6", "Language:", true);
                this.label7.Text = this.lm.GetString("UserProperties.label7", "Start:", true);
                this.label8.Text = this.lm.GetString("UserProperties.label8", "End:", true);
                this.label9.Text = this.lm.GetString("UserProperties.label9", "Edit user properties", true);
                this.groupBox1.Text = this.lm.GetString("UserProperties.groupBox1", "Shift:", true);
                this.checkBoxAutoLogOn.Text = this.lm.GetString("UserProperties.checkBoxAutoLogOn", "User can logged on automatically", true);
                this.checkBoxDisabled.Text = this.lm.GetString("UserProperties.checkBoxDisabled", "Account is disabled", true);
                this.buttonOk.Text = this.lm.GetString("UserProperties.buttonOk", "OK", true);
                this.buttonClose.Text = this.lm.GetString("UserProperties.buttonClose", "Close", true);
                this.buttonApply.Text = this.lm.GetString("UserProperties.buttonApply", "Apply", true);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001b')
            {
                base.Close();
            }
            if (((('A' <= char.ToUpper(e.KeyChar)) && (char.ToUpper(e.KeyChar) <= 'Z')) || (('0' <= e.KeyChar) && (e.KeyChar <= '9'))) || ((e.KeyChar == '.') || (e.KeyChar == '\b')))
            {
                this.buttonApply.Enabled = true;
            }
            base.OnKeyPress(e);
        }

        private void UserProperties_Load(object sender, EventArgs e)
        {
            this.LoadLanguageStrings();
            this.TopMost = true;
        }

        private void WriteInfoToField()
        {
            try
            {
                this.textBoxUserName.Text = this.localUser.Name;
                this.textBoxFullName.Text = this.localUser.FullName;
                this.textBoxDescription.Text = this.localUser.Description;
                this.textBoxPassword.Text = this.localUser.Password;
                int userLevel = (int) this.localUser.UserLevel;
                if (this.comboBoxUserType.Items.Count >= userLevel)
                {
                    this.comboBoxUserType.SelectedIndex = userLevel;
                }
                int autoLogoutTime = (int)this.localUser.UserAutoLogout.Symbol;
                if (this.comboBoxAutoLogout.Items.Count >= autoLogoutTime)
                {
                    this.comboBoxAutoLogout.SelectedIndex = autoLogoutTime;
                }
                userLevel = this.localUser.Language;
                if (this.comboBoxLanguage.Items.Count >= userLevel)
                {
                    this.comboBoxLanguage.SelectedIndex = userLevel;
                }
                this.checkBoxAutoLogOn.Checked = this.localUser.AutoLogOn;
                this.checkBoxDisabled.Checked = this.localUser.Disabled;
                this.textBoxShiftStart.Text = this.localUser.ShiftStart.ToShortTimeString();
                this.textBoxShiftEnd.Text = this.localUser.ShiftEnd.ToShortTimeString();
            }
            catch
            {
            }
        }

        private void WriteInfoToStruct()
        {
            try
            {
                this.localUser.Name = this.textBoxUserName.Text;
                this.localUser.FullName = this.textBoxFullName.Text;
                this.localUser.Description = this.textBoxDescription.Text;
                this.localUser.Password = this.textBoxPassword.Text;
                this.localUser.UserLevel = (CUserLevel)this.comboBoxUserType.SelectedIndex;
                this.localUser.UserAutoLogout.Symbol = this.localUser.UserAutoLogout.GetSymbol(this.comboBoxAutoLogout.SelectedIndex);
                this.localUser.UserAutoLogout.Text = this.localUser.UserAutoLogout.GetText(this.comboBoxAutoLogout.SelectedIndex);
                this.localUser.UserAutoLogout.Time = this.localUser.UserAutoLogout.GetTime(this.comboBoxAutoLogout.SelectedIndex);
                this.localUser.AutoLogOn = this.checkBoxAutoLogOn.Checked;
                this.localUser.Disabled = this.checkBoxDisabled.Checked;
                this.localUser.Language = this.comboBoxLanguage.SelectedIndex;
                this.localUser.ShiftStart = Convert.ToDateTime(this.textBoxShiftStart.Text);
                this.localUser.ShiftEnd = Convert.ToDateTime(this.textBoxShiftEnd.Text);
            }
            catch
            {
            }
        }

        [Category("App"), Description("Connects to the Language Manager.")]
        public CLanguageManager LanguageManager
        {
            get
            {
                return this.lm;
            }
            set
            {
                this.lm = value;
            }
        }
    }
}

