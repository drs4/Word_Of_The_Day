using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WordOfTheDay.Models;

namespace WordOfTheDay
{
    public partial class AddForm : Form
    {
        public int Id = 0;
        private static readonly HttpClient client = new HttpClient();

        public AddForm()
        {
            InitializeComponent();
        }
        private Word GetQuote(int id)
        {

            using (var db = new MyContext())
            {

                return db.Words.Find(id);
            }
        }


        private void AddWord(Word word)
        {
            using (var db = new MyContext())
            {

                db.Words.Add(word);
                db.SaveChanges();
            }
        }

        private void UpdateWord(Word word)
        {
            using (var db = new MyContext())
            {
                db.Entry(word).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtWord.Text))
            {
                MessageBox.Show("Invalid Word!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Word q = new Word
            {
                Text = txtWord.Text,
                Type = cmbType.Text,
                Definition = txtDefinition.Text,
                Example = txtExample.Text,
                Comment = txtComment.Text,
            };
            if (Id != 0)
            {
                q.Id = Id;
                UpdateWord(q);
                Id = 0;
            }
            else
            {
                AddWord(q);
            }

            txtWord.Clear();
            txtDefinition.Clear();
            txtExample.Clear();
            cmbType.Text = "";
            txtComment.Clear();


        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                var q = GetQuote(Id);
                txtWord.Text = q.Text;
                cmbType.Text = q.Type;
                txtDefinition.Text = q.Definition;
                txtExample.Text = q.Example;
                txtComment.Text = q.Comment;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWord.Text))
            {
                MessageBox.Show("Invalid Word!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Word q = new Word
            {
                Text = txtWord.Text,
                Definition = txtDefinition.Text,
                Example = txtExample.Text,
                Type = cmbType.Text,
                Comment = txtComment.Text,
            };
            if (Id != 0)
            {
                q.Id = Id;
                UpdateWord(q);
            }
            else
            {
                AddWord(q);
            }

            this.Hide();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random(System.DateTime.Now.GetHashCode());
                if (!client.DefaultRequestHeaders.Contains("app_id"))
                {
                    client.DefaultRequestHeaders.Add("app_id", "e7979876");
                    client.DefaultRequestHeaders.Add("app_key", "8b61eef92ef0d5084845d881b412ac6e");
                }
                //215619 is the total in metadata of the wordslist request
                string url = "https://od-api.oxforddictionaries.com:443/api/v1/wordlist/en/regions%3Dus?limit=1&offset=" + random.Next(215619);

                var responseString = await client.GetStringAsync(url);

                var wordsList = JsonConvert.DeserializeObject<APIListResponse>(responseString);
                txtWord.Text = wordsList.results[0].word;
                var wordId = txtWord.Text.Replace(' ', '_');
                url = "https://od-api.oxforddictionaries.com:443/api/v1/entries/en/" + wordId + "/regions=us";
                responseString = await client.GetStringAsync(url);

                var r = JsonConvert.DeserializeObject<APIMeaningResponse>(responseString);
                var definition = r.results[0].lexicalEntries[0].entries[0].senses[0].definitions[0]??"";
                var example = r.results[0].lexicalEntries[0].entries[0].senses[0].examples[0].text??"";
                var type = r.results[0].lexicalEntries[0].entries[0].lexicalCategory??"";
                txtDefinition.Text = definition;
                txtExample.Text = example;
                cmbType.Text = type;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");

            }


        }
    }
}
