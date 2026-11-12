namespace App.Components.ProgramEditor
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

    public partial class UCProgramEditor : UserControlBase
    {
        string filepath = "";

        string tbxfilepathtext = "USB Stick "/*"Datenträger "*/;
        string tbxplcfilepathtext = "PLC "/*"SPS "*/;

        public UCProgramEditor()
        {
            InitializeComponent();

            this.tbxplcfilepath.Text = tbxplcfilepathtext;
            this.tbxfilepath.Text = tbxfilepathtext;

            this.tbxfilepath.BackColor = SystemColors.Window;
            this.tbxFileResults.BackColor = SystemColors.Window;
        }

        public void OpenFile()
        {
            OpenFileDialog();
        }

        private void OpenFileDialog()
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            //openFileDialog.InitialDirectory = @"\Hard disk";

            openFileDialog.Filter = "Program files (*.prg)|*.prg|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            // Process input if the user clicked OK.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open the selected file to read.
                //System.IO.Stream fileStream = openFileDialog. .File.OpenRead();
                //System.IO.Stream fileStream = openFileDialog.File.OpenRead();

                //using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                //{
                //    // Read the first line from the file and write it the textbox.
                //    tbxFileResults.Text = reader.ReadLine();
                //}
                //fileStream.Close();

                this.filepath = openFileDialog.FileName;
                this.tbxfilepath.Text = tbxfilepathtext + this.filepath;

                ReadFromFile(openFileDialog.FileName, ref tbxFileResults);

            }

            this.BringToFront();

        }

        public void SaveFile()
        {
            SaveFileDialog();
        }

        private void SaveFileDialog()
        {
            // Displays a SaveFileDialog so the user can save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set filter options and filter index.
            saveFileDialog.Filter = "Program files (*.prg)|*.prg|All files (*.*)|*.*";
            saveFileDialog.ShowDialog();

            // Process input if the user clicked OK.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Open the selected file to write.
                //System.IO.FileStream fileStream = (System.IO.FileStream)saveFileDialog.OpenFile();


                //using (System.IO.StreamWriter write = new System.IO.StreamWriter(fileStream))
                //{
                //    // Read the first line from the file and write it the textbox.
                //    write.Write(tbxFileResults.Text);
                //}
                //fileStream.Close();

                this.filepath = saveFileDialog.FileName;

                WriteToFile(saveFileDialog.FileName + ".prg", tbxFileResults);

            }

            this.BringToFront(); 
        }

        public void LoadFromFile(string filepath)
        {
            tbxfilepath.Text = filepath;
            ReadFromFile(filepath, ref tbxFileResults);
        }

        private void ReadFromFile(string filepath, ref TextBox tbx)
        {

            string line = String.Empty;

            if (string.IsNullOrEmpty(filepath))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            if (!System.IO.File.Exists(filepath))
            {
                string directory = Path.GetDirectoryName(filepath);

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
                tbx.Text = string.Empty;
                using (Stream stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
                {
                    //using (StreamReader reader = new StreamReader(filepath, System.Text.Encoding.Default))
                    using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            tbx.Text += line + Environment.NewLine;
                        }
                        // Close reader
                        reader.Close();
                    }
                }
            }
            catch
            {
                string caption = "Message";//lm["FMain.LeaveApplication.Caption"];
                string message = String.Format("The file \"{0}\" could not be read." /*tclm["frmNCEditor.FailedOpen"]*/ , filepath);

                MessageBox.Show(message, caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button1);

                //    //Log that is failed with open file
                //    //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                //    return;
            }

        }

        private void WriteToFile(string filepath, TextBox tbx)
        {
            // If the file name is not an empty string open it for saving.
            if (string.IsNullOrEmpty(filepath))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            //if (!System.IO.File.Exists(this.filepath))
            //{
            string directory = Path.GetDirectoryName(filepath);

            //Check to see if the directory exists
            if (!Directory.Exists(directory))
            {
                //Log that developer location does not exist
                //ucHeader.LogMessage(tclm["frmNCEditor.DirNotExist"], Color.Red, directory);
                return;
            }

            //}      

            try
            {
                using (Stream stream = File.Create(filepath))
                {
                    //using (StreamReader reader = new StreamReader(filepath, System.Text.Encoding.Default))
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Default))
                    {
                        writer.WriteLine(tbx.Text);

                        // Close writer
                        writer.Close();
                    }
                }
            }
            catch
            {
                string caption = "Message";//lm["FMain.LeaveApplication.Caption"];
                string message = String.Format("The file \"{0}\" could not be written." /*tclm["frmNCEditor.FailedOpen"]*/ , filepath);

                MessageBox.Show(message, caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button1);

                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

        }

        public void LoadFromPLC(byte[] filepathplc)
        {
            ReadFromPLC(filepathplc);
        }

        private void ReadFromPLC(byte[] filepathplc)
        {
            TextBox tbx = new TextBox();
            string content = "";

            byte[] buffer = new byte[128];
            buffer = filepathplc;

            //Use ASCII encoding to work with string and byte
            ASCIIEncoding Encoding = new ASCIIEncoding();

            //Loop through read until done
            int bytesCounter = 0;

            do
            {
                if (Encoding.GetString(buffer, bytesCounter, 1) != "\0")
                {
                    content += Encoding.GetString(buffer, bytesCounter, 1);
                    bytesCounter++; ;
                }
                else
                    break;

            } while (buffer.Length > bytesCounter);

            if (string.IsNullOrEmpty(content))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            if (!System.IO.File.Exists(content))
            {
                string directory = Path.GetDirectoryName(content);

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

            }

            // Read data from file
            ReadFromFile(content, ref tbx);

            // Show plc data
            tbxPLCFileResult.Text = tbx.Text;

        }

        public string SaveInToPLC(byte[] filepathplc)
        {
            WriteToPLC(filepathplc);

            if (string.IsNullOrEmpty(filepath))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return "";
            }

            if (!System.IO.File.Exists(filepath))
            {
                string directory = Path.GetDirectoryName(filepath);

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

                return "";

            }

            return Path.GetFileNameWithoutExtension(filepath);
        }

        private void WriteToPLC(byte[] filepathplc)
        {
            string content = "";

            byte[] buffer = new byte[128];
            buffer = filepathplc;

            //Use ASCII encoding to work with string and byte
            ASCIIEncoding Encoding = new ASCIIEncoding();

            //Loop through read until done
            int bytesCounter = 0;

            do
            {
                if (Encoding.GetString(buffer, bytesCounter, 1) != "\0")
                {
                    content += Encoding.GetString(buffer, bytesCounter, 1);
                    bytesCounter++; ;
                }
                else
                    break;

            } while (buffer.Length > bytesCounter);


            if (string.IsNullOrEmpty(filepath))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            if (!System.IO.File.Exists(filepath))
            {
                string directory = Path.GetDirectoryName(filepath);

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

            if (string.IsNullOrEmpty(content))
            {
                //Log that is failed with open file
                //ucHeader.LogMessage(tclm["frmNCEditor.FailedOpen"], Color.Red);
                return;
            }

            if (!System.IO.File.Exists(content))
            {
                string directory = Path.GetDirectoryName(filepath);

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

            //// Read data from file
            //ReadFromFile(filepath, ref tbx);

            //// Write data to plc file
            //WriteToFile(content, tbx);

            // File copy
            File.Copy(filepath, content, true);

            // Show plc data
            ReadFromPLC(filepathplc);

        }

        private void UCProgramEditor_Load(object sender, EventArgs e)
        {
            this.tbxFileResults.Refresh();
            this.tbxPLCFileResult.Refresh();
        }

    }
}
