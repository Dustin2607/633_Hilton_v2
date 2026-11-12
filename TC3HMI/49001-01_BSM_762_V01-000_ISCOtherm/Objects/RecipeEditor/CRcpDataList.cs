namespace App.Components.RecipeEditor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class CRcpDataList
    {
        private string sDataDirectoryName;
        private string sDataFileName;
        private string sDataFile;

        public ArrayList Col;
        public List<CRcpData> Data;
        public string Description;
        public string Name;

        public CRcpDataList()
        {
            this.Name = "Not Set";
            this.Description = "";
            this.sDataDirectoryName = "";
            this.sDataFileName = "";
            this.sDataFile = "";
            this.Col = new ArrayList();
            this.Data = new List<CRcpData>();
        }

        public CRcpDataList(string name)
            : this()
        {
            this.Name = name;
        }

        public string DataDirectoryName
        {
            get { return this.sDataDirectoryName; }
            set
            {
                this.sDataDirectoryName = value;
                this.sDataFile = this.sDataDirectoryName + this.sDataFileName;
            }
        }

        public string DataFileName
        {
            get { return this.sDataFileName; }
            set
            {
                this.sDataFileName = value;
                this.sDataFile = this.sDataDirectoryName + this.sDataFileName;
            }
        }

        public string DataFile
        {
            get { return this.sDataFile; }
        }

        public void AddCol(CRcpCol col)
        {
            this.Col.Add(col);
        }

        public CRcpCol GetCol(int idx)
        {
            if (this.Col.Count > idx)
            {
                return (CRcpCol)this.Col[idx];
            }
            return null;
        }

        public void RemoveCol()
        {
            if (this.Col.Count > 0)
            {
                this.Col.RemoveAt(this.Col.Count - 1);
            }
        }

        public void RemoveCol(int idx)
        {
            if ((idx > 0) && (idx < this.Col.Count))
            {
                this.Col.RemoveAt(idx);
            }
        }
    }
}
