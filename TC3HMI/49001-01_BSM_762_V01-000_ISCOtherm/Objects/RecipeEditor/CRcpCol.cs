namespace App.Components.RecipeEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class CRcpCol
    {
        private string name = "Col";
        private string plcVar = "";
        private int readWrite = 1;
        private int visible = 1;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string PLCVar
        {
            get
            {
                return this.plcVar;
            }
            set
            {
                this.plcVar = value;
            }
        }

        public int ReadWrite
        {
            get
            {
                return this.readWrite;
            }
            set
            {
                this.readWrite = value;
            }
        }

        public int Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
            }
        }
    }
}
