namespace App.Components.RecipeEditor
{
    partial class UCRecipeEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvList = new System.Windows.Forms.TreeView();
            this.lvData = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUseMinMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlcVarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlcVarType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.tvList.Indent = 30;
            this.tvList.Location = new System.Drawing.Point(0, 0);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(222, 548);
            this.tvList.TabIndex = 5;
            this.tvList.TabStop = false;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colDescription,
            this.colValue,
            this.colUnit,
            this.colUseMinMax,
            this.colMin,
            this.colMax,
            this.colPlcVarName,
            this.colPlcVarType});
            this.lvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lvData.FullRowSelect = true;
            this.lvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvData.Location = new System.Drawing.Point(0, 0);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(794, 548);
            this.lvData.TabIndex = 6;
            this.lvData.TabStop = false;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            this.lvData.SelectedIndexChanged += new System.EventHandler(this.lvData_SelectedIndexChanged);
            // 
            // colNo
            // 
            this.colNo.Text = "No";
            this.colNo.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 413;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 80;
            // 
            // colUnit
            // 
            this.colUnit.Text = "Unit";
            // 
            // colUseMinMax
            // 
            this.colUseMinMax.Text = "UseMinMax";
            this.colUseMinMax.Width = 0;
            // 
            // colMin
            // 
            this.colMin.Text = "Min";
            this.colMin.Width = 80;
            // 
            // colMax
            // 
            this.colMax.Text = "Max";
            this.colMax.Width = 80;
            // 
            // colPlcVarName
            // 
            this.colPlcVarName.Text = "Plc Var Name";
            this.colPlcVarName.Width = 0;
            // 
            // colPlcVarType
            // 
            this.colPlcVarType.Text = "Plc Var Type";
            this.colPlcVarType.Width = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvData);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 548);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 7;
            // 
            // UCRecipeEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UCRecipeEditor";
            this.Size = new System.Drawing.Size(1020, 548);
            this.Load += new System.EventHandler(this.UCRecipeEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ColumnHeader colUnit;
        private System.Windows.Forms.ColumnHeader colMin;
        private System.Windows.Forms.ColumnHeader colMax;
        private System.Windows.Forms.ColumnHeader colPlcVarName;
        private System.Windows.Forms.ColumnHeader colPlcVarType;
        private System.Windows.Forms.ColumnHeader colUseMinMax;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
