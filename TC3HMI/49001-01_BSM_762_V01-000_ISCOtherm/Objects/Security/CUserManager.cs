
namespace App.Security
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    using App.Components;

    [Description("User management for the application.")]
    public class CUserManager : Component
    {
        private Container components;
        private CUser prevUser;
        private string sLogOnMsgCaption;
        private string[] sLogOnMsgDescription;
        private CLanguageManager lm;
        private CUserListData userListData;
        private Timer tmrDateTime;

        public event OnCurrentUserChanged CurrentUserChanged;

        public CUserManager()
        {
            this.InitializeComponent();
            this.userListData = new CUserListData();
            this.prevUser = new CUser();
            this.sLogOnMsgDescription = new string[5];

            tmrDateTime = new Timer();
            tmrDateTime.Enabled = true;
            tmrDateTime.Interval = 1000;
            tmrDateTime.Start();
            tmrDateTime.Tick += TmrDateTime_Tick;
        }

        public CUserManager(IContainer container)
        {
            container.Add(this);
            this.InitializeComponent();
            this.userListData = new CUserListData();
            this.prevUser = new CUser();
            this.sLogOnMsgDescription = new string[5];

            tmrDateTime = new Timer();
            tmrDateTime.Enabled = true;
            tmrDateTime.Interval = 1000;
            tmrDateTime.Start();
            tmrDateTime.Tick += TmrDateTime_Tick;
        }


        private void InitializeComponent()
        {
            this.components = new Container();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }

        public static uint GetIdleTime()
        {
            LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(LastUserAction);
            GetLastInputInfo(ref LastUserAction);
            return ((uint)Environment.TickCount - LastUserAction.dwTime);
        }

        private void TmrDateTime_Tick(object sender, EventArgs e)
        {
            //timeLeft = timeInSecondsAfterSessionOut - secondTick

            //if ((this.userListData.CurrentUser().UserAutoLogout.Time > 0) && (GetIdleTime() > this.userListData.CurrentUser().UserAutoLogout.Time))
            //{
            //    if ((this.userListData.CurrentUser() != null) && (this.CurrentUserLevel < CUserLevel.None))
            //    {
            //        this.CheckUser1("", "", false, false);
            //    }
            //}

        }

        [Description("Checks if the user is valid and in the user list. (0-unknown user, 1-user ok invalid password, 2-user ok password ok)")]
        private int CheckUser1(string userName, string password, bool showMessage, bool logOn)
        {
            int num = 2;
            if (logOn)
            {
                num = this.userListData.CheckUser(userName, password, showMessage);
                switch (num)
                {
                    case 0:
                        if (showMessage)
                        {
                            MessageBox.Show(this.sLogOnMsgDescription[0] + " " + this.sLogOnMsgDescription[1], this.sLogOnMsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        break;

                    case 1:
                        if (showMessage)
                        {
                            MessageBox.Show(this.sLogOnMsgDescription[2] + " " + this.sLogOnMsgDescription[3], this.sLogOnMsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        break;

                    case 2:
                        if ((this.prevUser.UserLevel != CUserLevel.None) && (this.CurrentUserChanged != null))
                        {
                            this.CurrentUserChanged(this.prevUser, false);
                        }
                        this.prevUser = this.userListData.CurrentUser();
                        break;
                }
            }
            if ((num == 2) && (this.CurrentUserChanged != null))
            {
                if (!logOn)
                {
                    this.prevUser = this.userListData.CurrentUser();
                    this.userListData.LogoutCurrentUser();
                }
                    
                this.CurrentUserChanged(this.userListData.CurrentUser(), logOn);
            }
            return num;
        }

        [Description("Returns the Application user.")]
        public CUser GetUser(string userName)
        {
            return this.userListData.GetUser(userName);
        }

        private void LoadLanguageStrings()
        {
            this.sLogOnMsgDescription[0] = "This computer is locked. Only permitted users";
            this.sLogOnMsgDescription[1] = "or an administrator can unlock this computer.";
            this.sLogOnMsgDescription[2] = "The password is incorrect. Please retype your password.";
            this.sLogOnMsgDescription[3] = "Letters in passwords must be typed using the correct case.";
            if (this.lm != null)
            {
                this.sLogOnMsgCaption = this.lm.GetString("UserManagement.LogOn.Caption", "Computer Locked.", true);
                this.sLogOnMsgDescription[0] = this.lm.GetString("UserManagement.WrongUser1", "This computer is locked.", true);
                this.sLogOnMsgDescription[1] = this.lm.GetString("UserManagement.WrongUser2", "Make sure your User name is correct, then type your password again", true);
                this.sLogOnMsgDescription[2] = this.lm.GetString("UserManagement.WrongPassword1", "The password is incorrect. Please retype your password.", true);
                this.sLogOnMsgDescription[3] = this.lm.GetString("UserManagement.WrongPassword2", "Letters in passwords must be typed using the correct case.", true);
            }
        }

        [Description("Shoes the user logon dialog.")]
        public void LoginDialog(bool bAutoLogOn)
        {
            this.LoginDialog(bAutoLogOn, true);
        }

        [Description("Shoes the user logon dialog.")]
        public void LoginDialog(bool bAutoLogOn, string name, string password)
        {
            if ((name.Length != 0) && (password.Length != 0))
            {
                this.CheckUser1(name, password, false, true);
            }
        }

        [Description("Shoes the user logon dialog.")]
        public void LoginDialog(bool bAutoLogOn, bool bLockComputer)
        {
            if (bAutoLogOn)
            {
                string password = this.userListData.GetUser(this.CurrentUser.Name).Password;
                this.CheckUser1(this.CurrentUser.Name, password, false, true);
            }
            else
            {
                FLoginDialog dialog = new FLoginDialog(this);
                dialog.UserLoginFunction(new UserLoginDelegate(this.CheckUser1));
                dialog.LanguageManager = this.lm;
                dialog.CurrentUser = this.userListData.CurrentUser();
                dialog.LockOptionControls = bLockComputer;
                dialog.ShowDialog();
                dialog.Dispose();
            }
        }

        [Description("Shoes the user manager dialog.")]
        public void UserManagerDialog()
        {
            if ((this.userListData.CurrentUser() != null) && (this.userListData.CurrentUser().UserLevel == CUserLevel.Administrator))
            {
                FUserManagementDialog management = new FUserManagementDialog(this.userListData);
                management.LanguageManager = this.lm;
                management.ShowDialog();
                management.Dispose();
            }
        }

        [Category("App"), Description("Gets the current user.")]
        public CUser CurrentUser
        {
            get
            {
                return this.userListData.CurrentUser();
            }
        }

        [Category("App"), Description("Gets the current full-user name.")]
        public string CurrentUserFullName
        {
            get
            {
                return this.userListData.CurrentUser().FullName;
            }
        }

        [Category("App"), Description("Gets the current user level.")]
        public CUserLevel CurrentUserLevel
        {
            get
            {
                return this.userListData.CurrentUser().UserLevel;
            }
        }

        [Category("App"), Description("Gets the current user auto logout time.")]
        public CUserAutoLogout CurrentUserAutoLogout
        {
            get
            {
                return this.userListData.CurrentUser().UserAutoLogout;
            }
        }

        [Category("App"), Description("Gets the current user name.")]
        public string CurrentUserName
        {
            get
            {
                return this.userListData.CurrentUser().Name;
            }
        }

        [Category("App"), Description("Gets or sets the file name for the user list.")]
        public string FileName
        {
            get
            {
                return this.userListData.FileName;
            }
            set
            {
                this.userListData.FileName = value;
                this.userListData.Load();
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

    }
}
