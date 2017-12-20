using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordOfTheDay.Models;

namespace WordOfTheDay
{
    public partial class FromMain : Form
    {
        private Random rand = new Random(System.DateTime.Now.GetHashCode());
        private SpeechSynthesizer speechSynthesizerObj;

        public FromMain()
        {
            InitializeComponent();
            RegRun(Application.ExecutablePath, true);
            ShowWord();
        }

        private void CreateDatabase()
        {
            SQLiteConnection.CreateFile("WordsDB.sqlite");
            SQLiteConnection m_connection = new SQLiteConnection("Data Source=WordsDB.sqlite;Version=3;");
            m_connection.Open();

            string createTable = "CREATE TABLE `Word` (" +
                                       "`Id`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                                       "`Text`	TEXT," +
                                       "`Type`	TEXT," +
                                       "`Definition`	TEXT," +
                                       "`Example`	TEXT," +
                                       "`Comment`	TEXT" +
                                       ");";

            SQLiteCommand command = new SQLiteCommand(createTable, m_connection);
            command.ExecuteNonQuery();

        }

        public void UpdateConnectionString()
        {
            //when called on startup, the connectionStrings should be a full path
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["MyDBContext"].ConnectionString = "Data Source="+Application.StartupPath+"\\WordsDB.sqlite";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void RegRun(string App_path, bool r)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            if (r)
                key.SetValue("WordOfTheDay", App_path);
            else
                key.DeleteValue("WordOfTheDay");
            key.Close();
        }
        private void DeleteWord(int id)
        {
            using (var db = new MyContext())
            {
                var word = db.Words.Find(id);
                db.Words.Remove(word);
                db.SaveChanges();
            }
        }



        private Word GetWord()
        {
            UpdateConnectionString();
            using (var db = new MyContext())
            {
                var words = db.Words.ToList();
                int num = rand.Next(words.Count);
                if (words.Count == 0) return new Word();
                return words[num];
            }
        }

        private void ShowWord()
        {
            var q = GetWord();
            this.lblId.Text = q.Id.ToString();
            txtWord.Clear();

            AppendText(q.Text,16,FontStyle.Bold,Color.BlueViolet);
            AppendText(" (" + q.Type + ")" + Environment.NewLine,5,FontStyle.Regular,Color.Black);
            AppendText(q.Definition + Environment.NewLine,12,FontStyle.Italic,Color.Black);
            AppendText(q.Example + Environment.NewLine,12,FontStyle.Italic,Color.Blue);

        }

        private void AppendText(string txt, int size, FontStyle fs,Color fc)
        {
            var ss = txtWord.TextLength;
            var sl = txt.Length;
            txtWord.AppendText(txt);
            txtWord.Select(ss,sl);
            txtWord.SelectionFont = new Font("Times New Roman", size,fs);
            txtWord.SelectionColor = fc;
            txtWord.Select(0,0);
        }
        private void itmAdd_Click(object sender, EventArgs e)
        {
            var frmAdd = new AddForm();
            frmAdd.Show();

        }

        private void itmEdit_Click(object sender, EventArgs e)
        {
            var frmAdd = new AddForm();
            frmAdd.Id = Convert.ToInt32(lblId.Text);
            frmAdd.Show();
        }

        private void itmDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                DeleteWord(Convert.ToInt32(lblId.Text));
                ShowWord();
            }

        }

        private void itmNext_Click(object sender, EventArgs e)
        {
            ShowWord();
        }

        private void itmAutorun_Click(object sender, EventArgs e)
        {
            if (itmAutorun.Checked)
            {
                RegRun("", false);
                itmAutorun.Checked = false;

            }
            else
            {
                RegRun(Application.ExecutablePath, true);
                itmAutorun.Checked = true;
            }

        }
        private void itmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtWord_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            txtWord.Dock = DockStyle.None;

            const int margin = 5;
            RichTextBox rch = sender as RichTextBox;
            rch.ClientSize = new Size(
            e.NewRectangle.Width + margin,
            e.NewRectangle.Height + margin);

            this.Width = rch.Width + 20;
            this.Height = rch.Height + 40;

            txtWord.Dock = DockStyle.Fill;
        }

        private void FromMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                ShowWord();

                tmrMain.Enabled = true;

                if (speechSynthesizerObj != null)
                {
                    speechSynthesizerObj.Dispose();
                    speechSynthesizerObj = null;
                }
            }

        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            tmrMain.Enabled = false;
            this.Show();

        }

        private void ntfyIcon_DoubleClick(object sender, EventArgs e)
        {
            tmrMain.Enabled = false;
            this.Show();
        }


        private void FromMain_Activated(object sender, EventArgs e)
        {
            if (speechSynthesizerObj == null)
            {
                speechSynthesizerObj = new SpeechSynthesizer();
                speechSynthesizerObj.SpeakAsync(txtWord.Text);
            }
            else if (speechSynthesizerObj.State == SynthesizerState.Paused)
            {
                speechSynthesizerObj.Resume();
            }
            else
            {
                speechSynthesizerObj.Dispose();
                speechSynthesizerObj = null;
            }

        }

        private void FromMain_Deactivate(object sender, EventArgs e)
        {
            if (speechSynthesizerObj != null && speechSynthesizerObj.State == SynthesizerState.Speaking)
            {
                speechSynthesizerObj.Pause();
            }else if (speechSynthesizerObj.State == SynthesizerState.Ready)
            {
                speechSynthesizerObj.Dispose();
                speechSynthesizerObj = null;
            }
        }
    }
}
