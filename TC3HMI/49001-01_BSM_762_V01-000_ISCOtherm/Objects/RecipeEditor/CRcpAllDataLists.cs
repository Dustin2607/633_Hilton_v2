namespace App.Components.RecipeEditor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class CRcpAllDataLists
    {
        public ArrayList Lists = new ArrayList();

        public CRcpAllDataLists()
        {

        }

        public void AddList(CRcpDataList list)
        {
            this.Lists.Add(list);
        }

        public CRcpDataList GetList(int idx)
        {
            if (this.Lists.Count > idx)
            {
                return (CRcpDataList)this.Lists[idx];
            }
            return null;
        }
    }
}
