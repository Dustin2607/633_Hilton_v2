namespace App.Components.RecipeEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CRcpData
    {
        private string description;
        private string value;
        private string unit;
        private double maxValue;
        private double minValue;
        private int useMinMax;
        private string plcVarName;
        private int plcVarType;

        public CRcpData()
        {
            this.description = "";
            this.value = "0.0";
            this.unit = "";
            this.useMinMax = 0;
            this.minValue = 0.0;
            this.maxValue = 0.0;
            this.plcVarName = "";
            this.plcVarType = 0;
        }

        public CRcpData(string description)
            : this()
        {
            this.description = description;
        }

        public CRcpData(string description, string value, string unit, int useMinMax, double minVal, double maxVal, string plcVarName, int plcVarType)
        {
            this.description = description;
            this.value = value;
            this.unit = unit;
            this.useMinMax = useMinMax;
            this.minValue = minVal;
            this.maxValue = maxVal;
            this.plcVarName = plcVarName;
            this.plcVarType = plcVarType;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public double MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;
            }
        }

        public double MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;
            }
        }

        public int UseMinMax
        {
            get
            {
                return this.useMinMax;
            }
            set
            {
                this.useMinMax = value;
            }
        }

        public string PlcVarName
        {
            get
            {
                return this.plcVarName;
            }
            set
            {
                this.plcVarName = value;
            }
        }

        public int PlcVarType
        {
            get
            {
                return this.plcVarType;
            }
            set
            {
                this.plcVarType = value;
            }
        }
    }
}
