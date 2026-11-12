namespace App.Security
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;

    using App.Components;

    public class FUserManagementDialog : Form
    {
        private Button buttonAdd;
        private Button buttonClose;
        private Button buttonDelete;
        private Button buttonProperties;
        private Button buttonSave;
        private IContainer components;
        private ImageList imageList1;
        private ListView listViewUser;
        private string msg1;
        private string msg1Caption;
        private string[] sListDescription;
        private CLanguageManager lm;
        private CUserListData userListData;

        public FUserManagementDialog(CUserListData usrListData)
        {
            this.InitializeComponent();
            this.userListData = usrListData;
            this.sListDescription = new string[10];
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int count = this.listViewUser.Items.Count;
            if (count < 30)
            {
                CUser user = this.userListData.GetUser(count);
                FUserPropertiesDialog dialog = new FUserPropertiesDialog(user);
                dialog.LanguageManager = this.lm;
                dialog.Text = "New User";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int imageIndex = !user.Disabled ? 0 : 1;
                    ListViewItem item = new ListViewItem(user.Name, imageIndex);
                    this.listViewUser.Items.Add(item);
                    item.Checked = user.AutoLogOn;
                    item.SubItems.Add(user.FullName);
                    item.SubItems.Add(user.Description);
                    item.SubItems.Add(user.UserLevel.ToString());
                    item.SubItems.Add(user.UserAutoLogout.Text);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.listViewUser.FocusedItem != null)
            {
                int index = this.listViewUser.FocusedItem.Index;
                if (MessageBox.Show(this.msg1 + this.listViewUser.FocusedItem.Text, this.msg1Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.userListData.DeleteUser(index);
                    this.listViewUser.Items.Remove(this.listViewUser.FocusedItem);
                }
            }
        }

        private void buttonProperties_Click(object sender, EventArgs e)
        {
            if (this.listViewUser.FocusedItem != null)
            {
                int index = this.listViewUser.FocusedItem.Index;
                CUser user = this.userListData.GetUser(index);
                FUserPropertiesDialog dialog = new FUserPropertiesDialog(user);
                dialog.LanguageManager = this.lm;
                dialog.Text = "User: " + user.FullName;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int num = !user.Disabled ? 0 : 1;
                    this.listViewUser.FocusedItem.ImageIndex = num;
                    this.listViewUser.Items[index].Text = user.Name;
                    this.listViewUser.Items[index].Checked = user.AutoLogOn;
                    this.listViewUser.Items[index].SubItems[1].Text = user.FullName;
                    this.listViewUser.Items[index].SubItems[2].Text = user.Description;
                    this.listViewUser.Items[index].SubItems[3].Text = user.UserLevel.ToString();
                    this.listViewUser.Items[index].SubItems[4].Text = user.UserAutoLogout.Text;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.userListData.Save();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillUserList()
        {
            for (int i = 0; i < 30; i++)
            {
                CUser user = this.userListData.GetUser(i);
                if ((user != null) && (user.Name != ""))
                {
                    int imageIndex = !user.Disabled ? 0 : 1;
                    ListViewItem item = new ListViewItem(user.Name, imageIndex);
                    this.listViewUser.Items.Add(item);
                    item.Checked = user.AutoLogOn;
                    item.SubItems.Add(user.FullName);
                    item.SubItems.Add(user.Description);
                    item.SubItems.Add(user.UserLevel.ToString());
                    item.SubItems.Add(user.UserAutoLogout.Text);
                }
            }
        }

        private void InitGrid()
        {
            this.components = new Container();
            new ResourceManager(typeof(FUserManagementDialog));
            this.listViewUser = new ListView();
            this.listViewUser.Bounds = new Rectangle(0x10, 50, base.Size.Width - 0x24, base.Size.Height - 0x5f);
            this.listViewUser.View = View.Details;
            this.listViewUser.LabelEdit = false;
            this.listViewUser.AllowColumnReorder = true;
            this.listViewUser.CheckBoxes = true;
            this.listViewUser.FullRowSelect = true;
            this.listViewUser.GridLines = true;
            this.listViewUser.HideSelection = false;
            this.listViewUser.DoubleClick += new EventHandler(this.listViewUser_DoubleClick);
            this.listViewUser.ItemCheck += new ItemCheckEventHandler(this.listViewUser_ItemCheck);
            this.listViewUser.Columns.Add(this.sListDescription[0], 100, HorizontalAlignment.Left);
            this.listViewUser.Columns.Add(this.sListDescription[1], 100, HorizontalAlignment.Left);
            this.listViewUser.Columns.Add(this.sListDescription[2], 100, HorizontalAlignment.Left);
            this.listViewUser.Columns.Add(this.sListDescription[3], 100, HorizontalAlignment.Left);
            this.listViewUser.Columns.Add(this.sListDescription[4], -2, HorizontalAlignment.Left);
            this.listViewUser.SmallImageList = this.imageList1;
            base.Controls.Add(this.listViewUser);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FUserManagementDialog));
            this.buttonAdd = new Button();
            this.buttonDelete = new Button();
            this.buttonProperties = new Button();
            this.buttonSave = new Button();
            //this.imageList1 = new ImageList(this.components);
            this.buttonClose = new Button();
            base.SuspendLayout();
            this.buttonAdd.FlatStyle = FlatStyle.System;
            this.buttonAdd.Location = new Point(0x10, 0x10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new Size(0x48, 0x18);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new EventHandler(this.buttonAdd_Click);
            this.buttonDelete.FlatStyle = FlatStyle.System;
            this.buttonDelete.Location = new Point(0x68, 0x10);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new Size(0x48, 0x18);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new EventHandler(this.buttonDelete_Click);
            this.buttonProperties.FlatStyle = FlatStyle.System;
            this.buttonProperties.Location = new Point(0xc0, 0x10);
            this.buttonProperties.Name = "buttonProperties";
            this.buttonProperties.Size = new Size(80, 0x18);
            this.buttonProperties.TabIndex = 0;
            this.buttonProperties.Text = "Properties";
            this.buttonProperties.Click += new EventHandler(this.buttonProperties_Click);
            this.buttonSave.FlatStyle = FlatStyle.System;
            this.buttonSave.Location = new Point(0x120, 0x10);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new Size(0x48, 0x18);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new EventHandler(this.buttonSave_Click);
            //this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            //this.imageList1.TransparentColor = Color.Transparent;
            //this.imageList1.Images.SetKeyName(0, "");
            //this.imageList1.Images.SetKeyName(1, "");
            this.buttonClose.DialogResult = DialogResult.OK;
            this.buttonClose.FlatStyle = FlatStyle.System;
            this.buttonClose.Location = new Point(0x1af, 0x10);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(0x48, 0x18);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
            base.AcceptButton = this.buttonProperties;
            this.AutoScaleBaseSize = new Size(5, 13);
            base.CancelButton = this.buttonClose;
            base.ClientSize = new Size(0x207, 0x16b);
            base.Controls.Add(this.buttonAdd);
            base.Controls.Add(this.buttonDelete);
            base.Controls.Add(this.buttonProperties);
            base.Controls.Add(this.buttonSave);
            base.Controls.Add(this.buttonClose);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            //base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "UserManagement";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "User managementn";
            base.Load += new EventHandler(this.UserManagement_Load);
            base.ResumeLayout(false);
        }

        private void listViewUser_DoubleClick(object sender, EventArgs e)
        {
            this.buttonProperties_Click(sender, e);
        }

        private void listViewUser_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                this.userListData.GetUser(e.Index).AutoLogOn = true;
            }
            else
            {
                this.userListData.GetUser(e.Index).AutoLogOn = false;
            }
        }

        private void LoadLanguageStrings()
        {
            this.msg1 = "Do you really want to delete the item:";
            this.msg1Caption = "Delete entry";
            this.sListDescription[0] = "Name";
            this.sListDescription[1] = "Full Name";
            this.sListDescription[2] = "Description";
            this.sListDescription[3] = "Type";
            this.sListDescription[4] = "Auto logout time";
            if (this.lm != null)
            {
                this.msg1 = this.lm.GetString("UserManagement.Msg_ReallyDelete", "Do you really want to delete the item:", true);
                this.msg1Caption = this.lm.GetString("UserManagement.Msg_ReallyDeleteCaption", "Delete Entry", true);
                this.buttonAdd.Text = this.lm.GetString("UserManagement.buttonAdd", "Add", true);
                this.buttonDelete.Text = this.lm.GetString("UserManagement.buttonDelete", "Delete", true);
                this.buttonProperties.Text = this.lm.GetString("UserManagement.buttonProperties", "Properties", true);
                this.buttonSave.Text = this.lm.GetString("UserManagement.buttonSave", "Save", true);
                this.buttonClose.Text = this.lm.GetString("UserManagement.buttonClose", "Close", true);
                this.sListDescription[0] = this.lm.GetString("UserProperties.ListDescr0", "Name", true);
                this.sListDescription[1] = this.lm.GetString("UserProperties.ListDescr1", "Full Name", true);
                this.sListDescription[2] = this.lm.GetString("UserProperties.ListDescr2", "Description", true);
                this.sListDescription[3] = this.lm.GetString("UserProperties.ListDescr3", "Type", true);
                this.sListDescription[4] = this.lm.GetString("UserProperties.ListDescr4", "Auto logout time", true);
            }
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            this.LoadLanguageStrings();
            this.InitGrid();
            this.FillUserList();
            this.TopMost = true;
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

