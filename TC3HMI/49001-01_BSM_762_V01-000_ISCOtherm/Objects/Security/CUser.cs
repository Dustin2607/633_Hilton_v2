namespace App.Security
{
    using System;

    [Serializable]
    public class CUser
    {
        public bool AutoLogOn = false;
        public CUserAutoLogout UserAutoLogout = new CUserAutoLogout(0);
        public string Description = "";
        public bool Disabled = false;
        public string FullName = "";
        public int Language = 0;
        public DateTime LogOnTime = DateTime.Now;
        public string Name = "";
        public string Password = "";
        public string Reserve1;
        public string Reserve2;
        public string Reserve3;
        public DateTime ShiftEnd = DateTime.Parse("0:00");
        public DateTime ShiftStart = DateTime.Parse("0:00");
        public CUserLevel UserLevel = CUserLevel.None;
    }
}

