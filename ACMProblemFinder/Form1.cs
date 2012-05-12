using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace ACMProblemFinder
{
    public partial class Form1 : Form
    {
        private string _ownUrl = "";
        private string _oppositeUrl = "";
        private string _oppositeName = "";
        private int _x = 26;
        private int _y = 79;
        private int _w = 685;
        private int _h = 327;
        private Dictionary<string, string> _users = new Dictionary<string, string>();

        private string GetHtmlFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string response = reader.ReadToEnd();
                    return response;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            if (File.Exists("Users.shakil") == false)
            {
                File.Create("Users.shakil");
            }

            string allUsers = File.ReadAllText("Users.shakil");
            string[] users = allUsers.Split('\n');

            for (int i = 0; i < users.Length; i++)
            {
                if (i == 0)
                    _ownUrl = users[i];
                else if (users[i] != "")
                {

                    int inde = users[i].IndexOf("<separetor>");
                    _users[users[i].Substring(0, inde)] = users[i].Substring(inde + 11);
                }
            }

            cbUsers.Items.Clear();

            foreach (string key in _users.Keys)
            {
                cbUsers.Items.Add(key);
            }

            if (cbUsers.Items.Count > 0)
                cbUsers.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtUrl.Text.Trim() == "")
                MessageBox.Show("You have to fill all the field!!!");
            else
            {
                string allUsers = File.ReadAllText("Users.shakil");
                allUsers += "\n" + txtName.Text.Trim() + "<separetor>" + txtUrl.Text.Trim();

                File.WriteAllText("Users.shakil", allUsers);

                txtName.Text = "";
                txtUrl.Text = "";

                MessageBox.Show("Add Complete");

                LoadUser();
            }
        }

        private void MakeResult()
        {
            try
            {
                string ownHtml = GetHtmlFromUrl(_ownUrl);
                string oppositeHtml = GetHtmlFromUrl(_oppositeUrl);

                Result result = new Result();
                result._ownHtml = ownHtml;
                result._oppositeHtml = oppositeHtml;
                result._oppositeName = _oppositeName;
                //result.Show();
                Application.Run(result);
            }
            catch
            {
                MessageBox.Show("Error Occur!!!");
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _oppositeUrl = _users[cbUsers.SelectedItem.ToString()];
            _oppositeName = cbUsers.SelectedItem.ToString();

            MessageBox.Show("wait untill next message found!!!");
            
            Thread t = new Thread(MakeResult); 
            t.Start(); 
        }
    }
}
