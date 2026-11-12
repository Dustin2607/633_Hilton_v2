namespace App.Security
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    public class CUserListData
    {
        private CUser administrator;
        private CUser currentUser;
        public string FileName = "AppUser.usr";
        public const int MaxUsers = 30;
        private char[] SecurityCArr;
        private CUser[] userList = new CUser[30];

        public CUserListData()
        {
            for (int i = 0; i < 30; i++)
            {
                this.userList[i] = new CUser();
            }
            int[] intArr = new int[10];
            intArr[0] = 0x53;
            intArr[1] = 0x65;
            intArr[2] = 0x63;
            intArr[3] = 0x75;
            intArr[4] = 0x72;
            intArr[5] = 0x69;
            intArr[6] = 0x74;
            intArr[7] = 0x79;
            this.SecurityCArr = this.IntArrToString(intArr).ToCharArray();
            int[] numArray2 = new int[20];
            numArray2[0] = 270;
            numArray2[1] = 0x143;
            numArray2[2] = 330;
            numArray2[3] = 0x158;
            numArray2[4] = 0x15a;
            numArray2[5] = 0x14c;
            numArray2[6] = 0x161;
            numArray2[7] = 0x167;
            numArray2[8] = 0x13f;
            numArray2[9] = 320;
            numArray2[10] = 0x151;
            numArray2[11] = 350;
            numArray2[12] = 350;
            int[] numArray3 = new int[20];
            numArray3[0] = 0x132;
            numArray3[1] = 0x10D;
            numArray3[2] = 0x14F;
            numArray3[3] = 0x158;
            numArray3[4] = 0x151;
            numArray3[5] = 0x15B;
            this.administrator = new CUser();
            this.administrator.Name = this.DeCrypt(this.IntArrToString(numArray2));
            this.administrator.FullName = this.DeCrypt(this.IntArrToString(numArray2));
            this.administrator.Description = "";
            this.administrator.Password = this.DeCrypt(this.IntArrToString(numArray3));
            this.administrator.UserLevel = CUserLevel.Administrator;
            this.administrator.UserAutoLogout.Symbol = CUserAutoLogout.TimeSymbol.None;
            this.administrator.UserAutoLogout.Text = "None";
            this.administrator.UserAutoLogout.Time = 0;
            this.administrator.LogOnTime = DateTime.Now;
            this.currentUser = new CUser();
        }

        public int CheckUser(string userName, string password, bool showMessage)
        {
            int num = 0;
            CUser administrator = null;
            if ((userName.ToUpper() == this.administrator.Name.ToUpper()) && (password == this.administrator.Password))
            {
                administrator = this.administrator;
                num = 2;
            }
            else
            {
                foreach (CUser user2 in this.userList)
                {
                    if (((userName != "") && (userName.ToUpper() == user2.Name.ToUpper())) && !user2.Disabled)
                    {
                        num = 1;
                        if (password == user2.Password)
                        {
                            administrator = user2;
                            num = 2;
                            break;
                        }
                    }
                }
            }
            if (((num == 2) && (administrator != null)) && (administrator.Name != this.currentUser.Name))
            {
                this.currentUser = administrator;
                this.currentUser.LogOnTime = DateTime.Now;
                this.Serialize();
            }
            return num;
        }

        public bool LogoutCurrentUser()
        {
            if (this.currentUser != null)
            {
                this.currentUser = new CUser();

                return true;
            }
            else
                return false;
        }

        private string Crypt(string password)
        {
            string str = "";
            char[] chArray = password.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                chArray[i] = (char) (chArray[i] + 'z');
                chArray[i] = (char) (chArray[i] + this.SecurityCArr[i % 8]);
                str = str + chArray[i];
                char ch1 = chArray[i];
            }
            return str;
        }

        public CUser CurrentUser()
        {
            return this.currentUser;
        }

        private string DeCrypt(string password)
        {
            string str = "";
            char[] chArray = password.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                chArray[i] = (char) (chArray[i] - 'z');
                chArray[i] = (char) (chArray[i] - this.SecurityCArr[i % 8]);
                str = str + chArray[i];
            }
            return str;
        }

        public bool DeleteUser(int index)
        {
            if ((0 > index) || (index >= 30))
            {
                return false;
            }
            for (int i = index; i < 0x1d; i++)
            {
                this.userList[i] = this.userList[i + 1];
            }
            return true;
        }

        public bool DeleteUser(string userName)
        {
            for (int i = 0; i < 30; i++)
            {
                if (userName == this.userList[i].Name)
                {
                    this.DeleteUser(i);
                    return true;
                }
            }
            return false;
        }

        private void Deserialize()
        {
            if (File.Exists(this.FileName))
            {
                try
                {
                    FileStream serializationStream = new FileStream(this.FileName, FileMode.Open);
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        this.currentUser = (CUser) formatter.Deserialize(serializationStream);
                        this.userList = (CUser[]) formatter.Deserialize(serializationStream);
                    }
                    catch (SerializationException exception)
                    {
                        MessageBox.Show("User Manager: Failed to deserialize. Reason: " + exception.Message);
                    }
                    finally
                    {
                        serializationStream.Close();
                        for (int i = 0; i < 29; i++)
                        {
                            this.userList[i].Password = this.DeCrypt(this.userList[i].Password);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public CUser GetUser(int index)
        {
            if ((0 <= index) && (index < 30))
            {
                return this.userList[index];
            }
            return null;
        }

        public CUser GetUser(string userName)
        {
            for (int i = 0; i < 30; i++)
            {
                if (userName == this.userList[i].Name)
                {
                    return this.userList[i];
                }
            }
            return null;
        }

        private string IntArrToString(int[] intArr)
        {
            string str = "";
            for (int i = 0; intArr[i] != 0; i++)
            {
                str = str + ((char) intArr[i]);
            }
            return str;
        }

        public void Load()
        {
            DateTime logOnTime = this.currentUser.LogOnTime;
            this.Deserialize();
            this.currentUser.LogOnTime = logOnTime;
        }

        public void Save()
        {
            DateTime logOnTime = this.currentUser.LogOnTime;
            CUser user = this.GetUser(this.currentUser.Name);
            if (user != null)
            {
                user.LogOnTime = logOnTime;
                this.currentUser = user;
            }
            this.Serialize();
        }

        private void Serialize()
        {
            for (int i = 0; i < 0x1d; i++)
            {
                this.userList[i].Password = this.Crypt(this.userList[i].Password);
            }
            try
            {
                FileStream serializationStream = new FileStream(this.FileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(serializationStream, this.currentUser);
                    formatter.Serialize(serializationStream, this.userList);
                }
                catch (SerializationException exception)
                {
                    MessageBox.Show("User Manager: Failed to serialize. Reason: " + exception.Message);
                    throw;
                }
                finally
                {
                    serializationStream.Close();
                    for (int j = 0; j < 0x1d; j++)
                    {
                        this.userList[j].Password = this.DeCrypt(this.userList[j].Password);
                    }
                }
            }
            catch
            {
            }
        }
    }
}

