namespace App.Components.RecipeEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;

    using TwinCAT.Ads;

    using App.Utility;
    using App.Components;


    public partial class UCRecipeEditor : UserControlBase
    {
        private CRcpDataList rcpSelectedDataList;
        private CRcpAllDataLists rcpAllDataLists;

        private string rcpSourceDirectory;
        private string rcpDestinationDirectory;
        private string rcpExtensions;

        public UCRecipeEditor()
        {
            InitializeComponent();

            this.rcpSelectedDataList = new CRcpDataList();
            this.rcpAllDataLists = new CRcpAllDataLists();

            this.rcpSourceDirectory = @"C:\Riex\Recipe\";
            this.rcpDestinationDirectory = @"C:\Temp\";
            this.rcpExtensions = @"rcp";

        }

        public CRcpDataList GetSelectedList()
        {
            TreeNode selectedNode = this.tvList.SelectedNode;

            if ((selectedNode == null) || (selectedNode.Parent == null))
            {
                return null;
            }
            else
            {
                return (CRcpDataList)selectedNode.Tag;
            }
        }

        public void EditSelectedDataRow()
        {
            this.EditDataRow(rcpSelectedDataList);
        }

        private void EditDataRow(CRcpDataList list)
        {
            if ((this.rcpAllDataLists.Lists.Count > 0) && (list != null))
            {
                if (this.lvData.FocusedItem == null)
                {
                    return;
                }

                int index = this.lvData.FocusedItem.Index;
                CRcpData rcpData = list.Data[index];

                //if (rcpData.
                // NIe otwierac pada gdy nie ma warosci w wierszu

                FNumPad frmNumPad = new FNumPad();

                frmNumPad.VarInfo = rcpData.Description;
                frmNumPad.VarType = rcpData.PlcVarType;
                frmNumPad.VarUnit = rcpData.Unit;

                if (rcpData.UseMinMax == 1)
                {
                    frmNumPad.VarMinLimit = rcpData.MinValue.ToString();
                    frmNumPad.VarMaxLimit = rcpData.MaxValue.ToString();
                }
                else
                {
                    frmNumPad.VarMinLimit = "";
                    frmNumPad.VarMaxLimit = "";
                }

                string value = rcpData.Value;
                if (frmNumPad.Show(ref value) == DialogResult.OK)
                {
                    rcpData.Value = value.Trim();

                    this.lvData.FocusedItem.SubItems[1].Text = rcpData.Description;
                    this.lvData.FocusedItem.SubItems[2].Text = rcpData.Value;
                    this.lvData.FocusedItem.SubItems[3].Text = rcpData.Unit;

                    if (rcpData.UseMinMax == 1)
                    {
                        this.lvData.FocusedItem.SubItems[5].Text = rcpData.MinValue.ToString();
                        this.lvData.FocusedItem.SubItems[6].Text = rcpData.MaxValue.ToString();
                    }
                    else
                    {
                        this.lvData.FocusedItem.SubItems[5].Text = "";
                        this.lvData.FocusedItem.SubItems[6].Text = "";
                    }
                    if ((rcpData.Description == " ") || (rcpData.Description == "-"))
                    {
                        this.lvData.FocusedItem.SubItems[2].Text = "";
                    }

                    this.WriteListData(list);

                }
                frmNumPad.Dispose();

            }
        }

        private void FillListView(CRcpDataList list)
        {
            if (list == null)
            {
                return;
            }

            this.tvList.BeginUpdate();
            this.lvData.BeginUpdate();
            this.lvData.Items.Clear();
            //if (this.languageHasChanged)
            //{
            //    this.languageHasChanged = false;
            //    this.lvData.Clear();
            //    this.CreateListViewColums();
            //}

            foreach (CRcpData data in list.Data)
            {
                int index = list.Data.IndexOf(data) + 1;
                ListViewItem item = new ListViewItem(index.ToString());
                this.lvData.Items.Add(item);

                if (item.Index % 2 == 0)
                {
                    item.BackColor = Color.LightGray;
                }
                else
                {
                    item.BackColor = Color.White;
                }

                item.SubItems.Add(data.Description);
                switch (data.Description)
                {
                    case " ":
                    case "-":
                        item.SubItems.Add("");
                        break;

                    default:
                        item.SubItems.Add(data.Value);
                        break;
                }
                item.SubItems.Add(data.Unit);
                item.SubItems.Add(data.UseMinMax.ToString());

                switch (data.Description)
                {
                    case " ":
                    case "-":
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        //item.SubItems.Add("");
                        //item.SubItems.Add("");
                        break;

                    default:
                        if (data.UseMinMax == 1)
                        {
                            item.SubItems.Add(data.MinValue.ToString());
                            item.SubItems.Add(data.MaxValue.ToString());
                        }
                        else
                        {
                            item.SubItems.Add("");
                            item.SubItems.Add("");
                        }
                        break;
                }
                item.SubItems.Add(data.PlcVarName);
                item.SubItems.Add(data.PlcVarType.ToString());
            }

            this.lvData.EndUpdate();
            this.tvList.EndUpdate();
        }

        private void MemFree()
        {
            this.rcpAllDataLists.Lists.Clear();
            this.lvData.Items.Clear();
            this.tvList.Nodes.Clear();
        }

        public void RefreshView()
        {
            this.Read(this.rcpSourceDirectory);
            this.lvData.Refresh();
            this.tvList.Refresh();
        }

        public void Read()
        {
            this.Read(this.rcpSourceDirectory);
        }

        public void Read(string di)
        {
            this.tvList.SelectedImageIndex = -1;
            if (string.IsNullOrEmpty(di))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            //Check to see if the directory exists
            if (!Directory.Exists(di))
            {
                //Log that developer location does not exist
                //ucHeader.LogMessage(tclm["frmNCEditor.DirNotExist"], Color.Red, directory);

                return;
            }

            this.MemFree();

            DirectoryInfo dir = new DirectoryInfo(rcpSourceDirectory);
            this.tvList.Nodes.Add(this.ReadDirectory(dir));

            this.ReadAllData();

            if (this.rcpAllDataLists.Lists.Count > 0)
            {
                this.tvList.SelectedImageIndex = 1;
                //this.tvList.ExpandAll();
                this.tvList.SelectedNode = this.tvList.Nodes[0];
                this.tvList.SelectedNode.Expand();
            }

        }

        private void ReadAllData()
        {
            foreach (CRcpDataList list in rcpAllDataLists.Lists)
            {
                this.ReadListData(list);
            }
        }

        private void ReadListData(CRcpDataList list)
        {
            string line = String.Empty;
            string[] strArray = null;

            list.Data.Clear();

            if (string.IsNullOrEmpty(list.DataFile))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            if (!System.IO.File.Exists(list.DataFile))
            {
                string directory = Path.GetDirectoryName(list.DataFile);

                //Check to see if the directory exists
                if (!Directory.Exists(directory))
                {
                    //Log that developer location does not exist
                    //ucHeader.LogMessage(tclm["frmNCEditor.DirNotExist"], Color.Red, directory);

                }
                else
                {
                    //Log that file does not exist in either developer location
                    //ucHeader.LogMessage(tclm["frmNCEditor.FileDirNotExist"], Color.Red, file, directory);
                }

                return;

            }

            try
            {
                StreamReader reader = new StreamReader(list.DataFile, System.Text.Encoding.Default);
                while ((line = reader.ReadLine()) != null)
                {
                    strArray = line.Split(new char[] { '|' });
                    if (strArray.Length > 6)
                    {
                        // Add new data
                        list.Data.Add(new CRcpData(strArray[1].Trim(), strArray[2].Trim(), strArray[3].Trim(), this.GetInt(strArray[4].Trim()), this.GetVal(strArray[5].Trim()), this.GetVal(strArray[6].Trim()), strArray[7].Trim(), this.GetInt(strArray[8].Trim())));
                    }
                    else if (strArray.Length > 3)
                    {
                        // Add new data
                        list.Data.Add(new CRcpData(strArray[1].Trim(), strArray[2].Trim(), strArray[3].Trim(), 0, 0.0, 0.0, strArray[7].Trim(), this.GetInt(strArray[8].Trim())));
                    }
                }
                // Close reader
                reader.Close();
            }
            catch
            {
                //    //Log that is failed with open file
                //    //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                //    return;
            }
        }

        private TreeNode ReadDirectory(DirectoryInfo di)
        {
            //Check to see if the directory exists
            if (!di.Exists)
            {
                //Log that developer location does not exist
                //ucHeader.LogMessage(tclm["frmNCEditor.DirNotExist"], Color.Red, directory);

                return null;
            }

            TreeNode output = new TreeNode(di.Name);

            foreach (var subDir in di.GetDirectories())
            {
                try
                {
                    foreach (var file in subDir.GetFiles("*." + this.rcpExtensions))
                    {
                        if (file.Exists)
                        {
                            output.Nodes.Add(ReadDirectory(subDir));
                            break;
                        }
                     
                    }

                    
                }
                catch (IOException ex)
                {
                    //Log that developer location does not exist
                    //ucHeader.LogMessage(tclm["frmNCEditor.DirNotExist"], Color.Red, directory);
                }
            }

            foreach (var file in di.GetFiles("*." + this.rcpExtensions))
            {
                if (file.Exists)
                {
                    CRcpDataList list = new CRcpDataList();
                    TreeNode node = new TreeNode();

                    list.Name = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                    list.Description = "description";
                    list.DataDirectoryName = file.DirectoryName + "\\";
                    list.DataFileName = file.Name;
                    //list.DataFile = file.FullName;

                    node.Tag = list;
                    node.Text = System.IO.Path.GetFileNameWithoutExtension(file.Name);

                    output.Tag = new CRcpDataList();
                    output.Nodes.Add(node);

                    this.rcpAllDataLists.AddList(list);
                }
             
            }

            return output;
        }

        public void Write()
        {
            this.WriteAllData();
        }

        public void Write(string di)
        {
            this.WriteAllData(di);
        }

        private void WriteAllData()
        {
            foreach (CRcpDataList list in rcpAllDataLists.Lists)
            {
                this.WriteListData(list);
            }
        }

        private void WriteAllData(string di)
        {
            foreach (CRcpDataList list in rcpAllDataLists.Lists)
            {
                list.DataDirectoryName = di;

                this.WriteListData(list);
            }
        }

        private void WriteListData(CRcpDataList list)
        {
            if (list.DataFile != "")
            {
                try
                {
                    StreamWriter writer = new StreamWriter(list.DataFile, false, System.Text.Encoding.Default);

                    foreach (CRcpData data in list.Data)
                    {
                        int index = list.Data.IndexOf(data) + 1;
                        object[] objArray = new object[] { index.ToString(), "|", data.Description, "|", data.Value, "|", data.Unit, "|", data.UseMinMax, "|", data.MinValue, "|", data.MaxValue, "|", data.PlcVarName, "|", data.PlcVarType, "|"};
                        string str = string.Concat(objArray);
                        writer.WriteLine(str);
                    }
                    // Close writer
                    writer.Close();
                }
                catch
                {
                    //    //Log that is failed with open file
                    //    //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                    //    return;
                }
            }
        }

        public bool Create()
        {
            return this.CreateData(this.rcpSourceDirectory, this.rcpExtensions);
        }

        public bool CreateData(string di, string ext)
        {
            bool flag = false;
            string value = "new_recipe";
            string caption = "Enter your recipe name";//lm["FMain.LeaveApplication.Caption"];
            string promptText = "Recipe name:" /*tclm["frmNCEditor.FailedOpen"]*/;
            string rcpPath;

            TreeNode selectedNode = this.tvList.SelectedNode;

            if ((selectedNode == null) || (selectedNode.Parent == null))
            {
                selectedNode = this.tvList.Nodes[0];
                rcpPath = di;
            }
            else
            {
                CRcpDataList tag = (CRcpDataList)selectedNode.Tag;
                rcpPath = tag.DataDirectoryName;
            }

            InputBoxValidation validation = delegate(string val)
            {
                if (val == "")
                    return "Recipe name cannot be empty.";
                if (!(new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_-]+$")).IsMatch(val))
                    return "Recipe name is not valid.";
                return "";
            };

            FKeyboard inputBox = new FKeyboard();
            if (inputBox.Show(caption, promptText, ref value, validation) == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }

                if (CreateListData(rcpPath + value + "." + ext))
                {
                    this.tvList.BeginUpdate();
                    CRcpDataList list = new CRcpDataList();
                    TreeNode node = new TreeNode();

                    list.Name = System.IO.Path.GetFileNameWithoutExtension(value);
                    list.Description = "description";
                    list.DataDirectoryName = rcpPath;
                    list.DataFileName = value + "." + ext;
                    //list.DataFile = file.FullName;

                    node.Tag = list;
                    node.Text = value;

                    if (selectedNode.Parent == null)
                    {
                        selectedNode.Tag = new CRcpDataList();
                        selectedNode.Nodes.Add(node);
                    }
                    else
                    {
                        selectedNode.Parent.Nodes.Add(node);
                    }

                    this.tvList.SelectedNode = node;
                    this.tvList.EndUpdate();
                    this.tvList.Focus();
                    //this.tvList.SelectedNode.Expand();

                    this.rcpAllDataLists.AddList(list);

                    flag = true;
                }

                inputBox.Dispose();
            }

            return flag;
        }

        public bool CreateListData(string rcpDirectory)
        {

            if (string.IsNullOrEmpty(rcpDirectory))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
            }

            // Check that the file doesn't already exist. If it doesn't exist, create the file.
            if (!System.IO.File.Exists(rcpDirectory))
            {
                File.Create(rcpDirectory).Dispose();

                //using (StreamWriter writer = new StreamWriter(rcpDirectory, false, System.Text.Encoding.Default))
                //{
                //    writer.WriteLine("text");
                //    writer.Close();
                //}

                //using (StreamWriter writer = File.CreateText(rcpDirectory))
                //{
                //    writer.WriteLine("text");
                //    writer.Close();
                //}

                return true;

            }
            else if (System.IO.File.Exists(rcpDirectory))
            {
                string caption = "Message";//lm["FMain.LeaveApplication.Caption"];
                string message = String.Format("File \"{0}\" already exists." /*tclm["frmNCEditor.FailedOpen"]*/ , rcpDirectory);

                MessageBox.Show(message, caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button1);

            }

            return false;

        }

        public void AddData(string description, string value, string unit, int useMinMax, double minVal, double maxVal, string plcVarName, int plcVarType)
        {
            if (
                plcVarName == String.Empty
                || description == String.Empty
                || value == String.Empty
                || (useMinMax == 1 && (minVal.ToString() == String.Empty || maxVal.ToString() == String.Empty))
                || plcVarType == 0
            )
            {

                return;
            }

            AddListData(description, value, unit, useMinMax, minVal, maxVal, plcVarName, plcVarType);
        }

        private void AddListData()
        {
            if (this.tvList.SelectedNode != null)
            {
                CRcpDataList tag = (CRcpDataList)this.tvList.SelectedNode.Tag;
                tag.Data.Add(new CRcpData("New Param"));
                this.FillListView(tag);
            }
        
        }

        private void AddListData(string description)
        {
            if (this.tvList.SelectedNode != null)
            {
                CRcpDataList tag = (CRcpDataList)this.tvList.SelectedNode.Tag;
                tag.Data.Add(new CRcpData(description));
                this.FillListView(tag);
            }

        }

        private void AddListData(string description, string value, string unit, int useMinMax, double minVal, double maxVal, string plcVarName, int plcVarType)
        {
            if (this.tvList.SelectedNode != null)
            {
                CRcpDataList tag = (CRcpDataList)this.tvList.SelectedNode.Tag;
                tag.Data.Add(new CRcpData(description, value, unit, useMinMax, minVal, maxVal, plcVarName, plcVarType));
                this.FillListView(tag);
            }

        }

        public void Delete()
        {
            this.DeleteData();
            this.RefreshView();
        }

        public void DeleteData()
        {
            TreeNode selectedNode = this.tvList.SelectedNode;

            if ((selectedNode == null) || (selectedNode.Parent == null))
            {
                ;
            }
            else
            {
                CRcpDataList tag = (CRcpDataList)selectedNode.Tag;
                this.DeleteListData(tag.DataFile);
            }

        }

        public void DeleteListData(string di)
        {
            if (string.IsNullOrEmpty(di))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            // Check that the file already exist.
            if (System.IO.File.Exists(di))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    string caption = "Confirmation";//lm["FMain.LeaveApplication.Caption"];
                    string message = "Are you sure to delete this recipe? \n" + di;//lm["FMain.LeaveApplication.Msg"];

                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        System.IO.File.Delete(di);
                    }
                    else if (result == DialogResult.No)
                    {

                    }
                    else
                    {

                    }

                }
                catch (System.IO.IOException e)
                {
                    //Log that is failed with open file
                    //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                    return;
                }

            }
            else if (System.IO.File.Exists(di))
            {
                string caption = "Message";//lm["FMain.LeaveApplication.Caption"];
                string message = String.Format("File \"{0}\" not exists." /*tclm["frmNCEditor.FailedOpen"]*/ , di);

                MessageBox.Show(message, caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button1);
            }
        }


        public void CopyAll()
        {                     
            // Displays a FolderBrowserDialog so the user can choose the folder
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Set filter options and filter index.
                folderBrowserDialog.Description = "Select a folder in which to save your all recipes...";
                folderBrowserDialog.SelectedPath = rcpDestinationDirectory;
                folderBrowserDialog.ShowNewFolderButton = true;

                // Process input if the user clicked OK.
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    CopyAll(this.rcpSourceDirectory, folderBrowserDialog.SelectedPath + "\\" + DateTime.Now.ToString("yyyyMMddHHMMss") + "\\", this.rcpExtensions);
                }
            }

         }

        private void CopyAll(string SourcePath, string DestinationPath, string FileExtensions)
        {

            if (string.IsNullOrEmpty(SourcePath)
                || string.IsNullOrEmpty(DestinationPath))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            //Check to see if the directory exists
            if (!Directory.Exists(SourcePath))
            {
                //Log that developer location does not exist
                //ucHeader.LogMessage(tclm["frmNCEditor.DirNotExist"], Color.Red, directory);

                return;
            }

            //string destpath = DestinationPath + DateTime.Now.ToString("yyyyMMddHHMMss") + "\\";
                        
            //// Check that the file already exist.
            //if (System.IO.File.Exists(di))
            //{
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    if (!Directory.Exists(DestinationPath))
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }

                    //Now Create all of the directories
                    foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(DestinationPath + dirPath.Remove(0, SourcePath.Length));

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, DestinationPath + newPath.Remove(0, SourcePath.Length), true);

                }
                catch (System.IO.IOException e)
                {
                    //Log that is failed with open file
                    //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);

                    string caption = "Message";//lm["FMain.LeaveApplication.Caption"];

                    MessageBox.Show(e.ToString(), caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk,
                                    MessageBoxDefaultButton.Button1);

                    return;
                }

            //}

        }

        private int GetInt(string val)
        {
            if (val != "")
            {
                try
                {
                    return int.Parse(val);
                }
                catch
                {
                }
            }
            return 0;
        }

        private double GetVal(string val)
        {
            if (val != "")
            {
                try
                {
                    return double.Parse(val);
                }
                catch
                {
                }
            }
            return 0.0;
        }

        //[Description("Gets or sets the name of the recipe directory."), Category("App")]
        public string RcpSourceDirectory
        {
            get
            {
                return this.rcpSourceDirectory;
            }
            set
            {
                this.rcpSourceDirectory = value;
            }
        }

        public string RcpDestinationDirectory
        {
            get
            {
                return this.rcpDestinationDirectory;
            }
            set
            {
                this.rcpDestinationDirectory = value;
            }
        }

        public TreeNode m_previousSelectedNode = null;
        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.FillListView((CRcpDataList)e.Node.Tag);

            if (m_previousSelectedNode != null)
            {
                m_previousSelectedNode.BackColor = tvList.BackColor;
                m_previousSelectedNode.ForeColor = tvList.ForeColor;
            }

            e.Node.BackColor = SystemColors.Highlight;
            e.Node.ForeColor = Color.White;

            m_previousSelectedNode = tvList.SelectedNode;

        }

        private void lvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvData.SelectedIndices.Count > 0)
            {
                rcpSelectedDataList = (CRcpDataList)this.tvList.SelectedNode.Tag;

                this.EditDataRow(rcpSelectedDataList);
            }
        }

        private void UCRecipeEditor_Load(object sender, EventArgs e)
        {
            this.RefreshView();
        }

    }
}
