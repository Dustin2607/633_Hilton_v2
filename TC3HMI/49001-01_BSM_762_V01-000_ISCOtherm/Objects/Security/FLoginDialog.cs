namespace App.Security
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    using App.Components;

    public class FLoginDialog : Form
    {
        private Button buttonCancel;
        private Button buttonLockComputer;
        private Button btnLogout;
        private Button btnLogin;
        private Button buttonUserAdmin;
        private UserLoginDelegate CheckUserLogin;
        private Container components;
        private CUser currentUser;
        private GroupBox groupBoxLogOn;
        private Label labelLockMsg1;
        private Label labelLockMsg2;
        private Label labelLogOnTime;
        private Label labelLogOnUser;
        private Label labelPassword;
        private Label labelUserName;
        private bool lockedStatus;
        private Bitmap logOnBitmap;
        private string msg_labelLogOnTime;
        private string msg_labelLogOnUser;
        private string msg_ShutDown;
        private Panel panel1;
        private Panel panel2;
        private Point pointUserLogOn;
        private string[] sMsgLockUser;
        private CLanguageManager lm;
        private TextBox textPassword;
        private TextBox textUserName;
        private Button btnShutDown;
        private CUserManager userAdmin;

        public FLoginDialog(CUserManager usrAdmin)
        {
            this.InitializeComponent();
            this.userAdmin = usrAdmin;
            this.pointUserLogOn = new Point();
            this.sMsgLockUser = new string[5];
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (!this.lockedStatus)
            {
                base.DialogResult = DialogResult.OK;
            }
            base.Close();
        }

        private void buttonLockComputer_Click(object sender, EventArgs e)
        {
            this.LockControls(true);
            if (this.CheckUserLogin != null)
            {
                this.CheckUserLogin("", "", false, false);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (this.CheckUserLogin != null)
            {  
                if (!this.lockedStatus)
                {
                    this.btnLogout.Enabled = false;
                    this.CheckUserLogin("", "", false, false);
                    base.DialogResult = DialogResult.OK;
                }
            }
            base.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int num = this.CheckUser(this.textUserName.Text, this.textPassword.Text, true);
            this.textPassword.Text = "";
            switch (num)
            {
                case 0:
                    this.textUserName.Focus();
                    return;

                case 1:
                    this.textPassword.Focus();
                    return;

                case 2:
                    this.btnLogout.Enabled = true;
                    this.btnLogin.DialogResult = DialogResult.OK;
                    base.DialogResult = DialogResult.OK;
                    base.Close();
                    return;
            }
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this.msg_ShutDown, "Shut Down", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                WinControl.ShutDown();
            }
        }

        private void buttonUserAdmin_Click(object sender, EventArgs e)
        {
            this.userAdmin.UserManagerDialog();
        }

        private int CheckUser(string userName, string password, bool showMessage)
        {
            if (this.CheckUserLogin != null)
            {
                return this.CheckUserLogin(userName, password, showMessage, true);
            }
            return 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EnableAdminStatus()
        {
            bool flag = false;
            if ((this.currentUser != null) && (this.currentUser.UserLevel == CUserLevel.Administrator))
            {
                flag = true;
            }
            this.buttonUserAdmin.Enabled = flag;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShutDown = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.buttonUserAdmin = new System.Windows.Forms.Button();
            this.buttonLockComputer = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxLogOn = new System.Windows.Forms.GroupBox();
            this.labelLogOnTime = new System.Windows.Forms.Label();
            this.labelLogOnUser = new System.Windows.Forms.Label();
            this.labelLockMsg1 = new System.Windows.Forms.Label();
            this.labelLockMsg2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxLogOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShutDown);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.buttonUserAdmin);
            this.panel1.Controls.Add(this.buttonLockComputer);
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.textUserName);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.labelUserName);
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 158);
            this.panel1.TabIndex = 0;
            // 
            // btnShutDown
            // 
            this.btnShutDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShutDown.Location = new System.Drawing.Point(252, 82);
            this.btnShutDown.Name = "btnShutDown";
            this.btnShutDown.Size = new System.Drawing.Size(115, 25);
            this.btnShutDown.TabIndex = 9;
            this.btnShutDown.Text = "Shut Down";
            this.btnShutDown.Visible = false;
            this.btnShutDown.Click += new System.EventHandler(this.btnShutDown_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogout.Location = new System.Drawing.Point(130, 112);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(115, 25);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // buttonUserAdmin
            // 
            this.buttonUserAdmin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonUserAdmin.Location = new System.Drawing.Point(130, 82);
            this.buttonUserAdmin.Name = "buttonUserAdmin";
            this.buttonUserAdmin.Size = new System.Drawing.Size(115, 25);
            this.buttonUserAdmin.TabIndex = 6;
            this.buttonUserAdmin.Text = "User Admin";
            this.buttonUserAdmin.Click += new System.EventHandler(this.buttonUserAdmin_Click);
            // 
            // buttonLockComputer
            // 
            this.buttonLockComputer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLockComputer.Location = new System.Drawing.Point(8, 82);
            this.buttonLockComputer.Name = "buttonLockComputer";
            this.buttonLockComputer.Size = new System.Drawing.Size(115, 25);
            this.buttonLockComputer.TabIndex = 7;
            this.buttonLockComputer.Text = "Lock Computer";
            this.buttonLockComputer.Visible = false;
            this.buttonLockComputer.Click += new System.EventHandler(this.buttonLockComputer_Click);
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(120, 41);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(248, 20);
            this.textPassword.TabIndex = 1;
            this.textPassword.Text = "Password";
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(120, 9);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(248, 20);
            this.textUserName.TabIndex = 0;
            this.textUserName.Text = "UserName";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(253, 112);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(115, 25);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Location = new System.Drawing.Point(8, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(115, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelPassword.Location = new System.Drawing.Point(16, 41);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(104, 24);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUserName
            // 
            this.labelUserName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelUserName.Location = new System.Drawing.Point(16, 9);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(104, 24);
            this.labelUserName.TabIndex = 2;
            this.labelUserName.Text = "User name:";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBoxLogOn);
            this.panel2.Controls.Add(this.labelLockMsg1);
            this.panel2.Controls.Add(this.labelLockMsg2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 81);
            this.panel2.TabIndex = 1;
            // 
            // groupBoxLogOn
            // 
            this.groupBoxLogOn.Controls.Add(this.labelLogOnTime);
            this.groupBoxLogOn.Controls.Add(this.labelLogOnUser);
            this.groupBoxLogOn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxLogOn.Location = new System.Drawing.Point(8, 11);
            this.groupBoxLogOn.Name = "groupBoxLogOn";
            this.groupBoxLogOn.Size = new System.Drawing.Size(360, 64);
            this.groupBoxLogOn.TabIndex = 0;
            this.groupBoxLogOn.TabStop = false;
            this.groupBoxLogOn.Text = "Logon Information";
            // 
            // labelLogOnTime
            // 
            this.labelLogOnTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLogOnTime.Location = new System.Drawing.Point(10, 40);
            this.labelLogOnTime.Name = "labelLogOnTime";
            this.labelLogOnTime.Size = new System.Drawing.Size(345, 16);
            this.labelLogOnTime.TabIndex = 1;
            this.labelLogOnTime.Text = "Logon Date:";
            // 
            // labelLogOnUser
            // 
            this.labelLogOnUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLogOnUser.Location = new System.Drawing.Point(10, 16);
            this.labelLogOnUser.Name = "labelLogOnUser";
            this.labelLogOnUser.Size = new System.Drawing.Size(345, 16);
            this.labelLogOnUser.TabIndex = 0;
            this.labelLogOnUser.Text = "... is logged on as";
            // 
            // labelLockMsg1
            // 
            this.labelLockMsg1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelLockMsg1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLockMsg1.Location = new System.Drawing.Point(16, 24);
            this.labelLockMsg1.Name = "labelLockMsg1";
            this.labelLockMsg1.Size = new System.Drawing.Size(336, 16);
            this.labelLockMsg1.TabIndex = 2;
            this.labelLockMsg1.Text = "This computer has been locked.";
            this.labelLockMsg1.Visible = false;
            // 
            // labelLockMsg2
            // 
            this.labelLockMsg2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelLockMsg2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLockMsg2.Location = new System.Drawing.Point(16, 48);
            this.labelLockMsg2.Name = "labelLockMsg2";
            this.labelLockMsg2.Size = new System.Drawing.Size(320, 32);
            this.labelLockMsg2.TabIndex = 3;
            this.labelLockMsg2.Text = "Only permitted users or an administrator can unlock this computer.";
            this.labelLockMsg2.Visible = false;
            // 
            // FLoginDialog
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(378, 238);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLoginDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Security";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.UserLogOn_Closing);
            this.Load += new System.EventHandler(this.UserLogOn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBoxLogOn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void LoadLanguageStrings()
        {
            this.msg_labelLogOnUser = " is logged on as ";
            this.msg_labelLogOnTime = "Logon Date: ";
            this.msg_ShutDown = "Do you really want to shut down?";
            this.sMsgLockUser[0] = "This computer has been locked.";
            this.sMsgLockUser[1] = "Only permitted users or an administrator can unlock this computer.";
            if (this.lm != null)
            {
                this.sMsgLockUser[0] = this.lm.GetString("UserLogOn.LockUser1", "This computer has been locked.", true);
                this.sMsgLockUser[1] = this.lm.GetString("UserLogOn.LockUser2", "Only permitted users or an administrator can unlock this computer.", true);
                this.msg_labelLogOnUser = this.lm.GetString("UserLogOn.labelLogOnUser", " is logged on as", true) + " ";
                this.msg_labelLogOnTime = this.lm.GetString("UserLogOn.labelLogOnTime", "Logon Date:", true) + " ";
                this.msg_ShutDown = this.lm.GetString("UserLogOn.ShutDown", "Do you really want to shut down?", true);
                this.groupBoxLogOn.Text = this.lm.GetString("UserLogOn.groupBoxLogOn", "Logon Information", true);
                this.labelUserName.Text = this.lm.GetString("UserLogOn.labelUserName", "User name:", true);
                this.labelPassword.Text = this.lm.GetString("UserLogOn.labelPassword", "Password:", true);
                this.buttonLockComputer.Text = this.lm.GetString("UserLogOn.buttonLockComputer", "Lock Computer", true);
                this.btnLogout.Text = this.lm.GetString("UserLogOn.buttonLockOff", "Lock Off…", true);
                this.buttonUserAdmin.Text = this.lm.GetString("UserLogOn.buttonUserAdmin", "User Admin", true);
                this.btnLogin.Text = this.lm.GetString("UserLogOn.buttonOk", "OK", true);
                this.buttonCancel.Text = this.lm.GetString("UserLogOn.buttonCancel", "Cancel", true);
            }
        }

        private void LockControls(bool lockControls)
        {
            this.lockedStatus = lockControls;
            this.groupBoxLogOn.Visible = !lockControls;
            this.buttonLockComputer.Visible = false;//!lockControlsv;
            this.btnLogout.Visible = !lockControls;
            this.buttonUserAdmin.Visible = !lockControls;
            this.labelLockMsg1.Text = this.sMsgLockUser[0];
            this.labelLockMsg2.Text = this.sMsgLockUser[1];
            this.labelLockMsg1.Visible = lockControls;
            this.labelLockMsg2.Visible = lockControls;
        }

        public void ShowImage(string fileToDisplay, int xSize, int ySize)
        {
            if (this.logOnBitmap != null)
            {
                this.logOnBitmap.Dispose();
            }
            try
            {
                this.logOnBitmap = new Bitmap(fileToDisplay);
            }
            catch
            {
                MessageBox.Show("LogOn Bitmap " + fileToDisplay + " could not be loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void UserLogOn_Closing(object sender, CancelEventArgs e)
        {
            if (base.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void UserLogOn_Load(object sender, EventArgs e)
        {
            this.LoadLanguageStrings();
            if (this.currentUser != null)
            {
                if (this.currentUser.Name != "")
                {
                    this.btnLogout.Enabled = true;
                    this.pointUserLogOn.Y = this.panel2.Height;// + this.pictureBox1.Height;
                    this.panel1.Location = this.pointUserLogOn;
                    this.labelLogOnUser.Text = this.currentUser.FullName + this.msg_labelLogOnUser + Environment.MachineName.ToString() + @"\" + this.currentUser.Name;
                    this.labelLogOnTime.Text = this.msg_labelLogOnTime + this.currentUser.LogOnTime.ToString();             
                }
                else
                {
                    this.btnLogout.Enabled = false;
                    //this.pointUserLogOn.Y = this.pictureBox1.Height;
                    this.groupBoxLogOn.Visible = false;
                    this.panel1.Location = this.pointUserLogOn;
                }
                base.Height = (this.panel1.Location.Y + this.panel1.Height) + 0x20;
                this.textUserName.Text = this.currentUser.Name;
                this.textPassword.Text = "";
            }

            this.TopMost = true;
        }

        public void UserLoginFunction(UserLoginDelegate loginFunc)
        {
            this.CheckUserLogin = loginFunc;
        }

        [Category("App"), Description("Gets or sets the current user.")]
        public CUser CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
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
                this.LoadLanguageStrings();
            }
        }

        [Category("App"), Description("Gets or sets the current user.")] 
        public bool LockOptionControls
        {
            get
            {
                return this.lockedStatus;
            }
            set
            {
                this.lockedStatus = value;
                this.LockControls(this.lockedStatus);
                if (!this.lockedStatus)
                {
                    this.EnableAdminStatus();
                }
            }
        }
    }
}

