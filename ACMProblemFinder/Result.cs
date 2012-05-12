using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACMProblemFinder
{
    public partial class Result : Form
    {
        public string _ownHtml = "";
        public string _oppositeHtml = "";
        public string _oppositeName = "";
        private Dictionary<int, ProblemStatus> _ownSolved = new Dictionary<int, ProblemStatus>();
        private Dictionary<int, ProblemStatus> _oppositeSolved = new Dictionary<int, ProblemStatus>();

        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            int startIndex = 0;

            string temp = _ownHtml.ToLower();

            int p1 = temp.IndexOf("solved problems", startIndex);
            startIndex = p1;
            p1 = temp.IndexOf("<table", startIndex);
            startIndex = p1;
            p1 = temp.IndexOf("</table>", startIndex);
            temp = temp.Substring(startIndex, p1 - startIndex+1);

            startIndex = 0;

            while (true)
            {
                p1 = temp.IndexOf("<td", startIndex);
                if (p1 < 0)
                    break;

                string result = "";
                int count = 0;

                for (int i = p1; i < temp.Length; i++)
                {
                    if (temp[i] == '<')
                    {
                        count++;
                        result = result.Trim();
                        if (result != "")
                            break;
                    }
                    else if (temp[i] == '>')
                        count--;
                    else if (count == 0)
                        result += temp[i].ToString();
                }
                startIndex = p1 + 1;
                int problemNumber = 0;

                if (int.TryParse(result, out problemNumber) == true)
                {
                    ProblemStatus ps = new ProblemStatus();
                    ps.Id = problemNumber;
                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    result = "";
                    count = 0;

                    for (int i = p1; i < temp.Length; i++)
                    {
                        if (temp[i] == '<')
                        {
                            count++;
                            result = result.Trim();
                            if (result != "")
                                break;
                        }
                        else if (temp[i] == '>')
                            count--;
                        else if(count == 0)
                            result += temp[i].ToString();
                    }
                    startIndex = p1 + 1;
                    ps.Rank = result;
                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    startIndex = p1 + 1;
                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    result = "";
                    count = 0;

                    for (int i = p1; i < temp.Length; i++)
                    {
                        if (temp[i] == '<')
                        {
                            count++;
                            result = result.Trim();
                            if (result != "")
                                break;
                        }
                        else if (temp[i] == '>')
                            count--;
                        else if (count == 0)
                            result += temp[i].ToString();
                    }
                    startIndex = p1 + 1;
                    ps.Date = result;

                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    result = "";
                    count = 0;

                    for (int i = p1; i < temp.Length; i++)
                    {
                        if (temp[i] == '<')
                        {
                            count++;
                            result = result.Trim();
                            if (result != "")
                                break;
                        }
                        else if (temp[i] == '>')
                            count--;
                        else if (count == 0)
                            result += temp[i].ToString();
                    }
                    startIndex = p1 + 1;
                    ps.RunTime = result;

                    _ownSolved.Add(ps.Id, ps);
                }
            }

            /////////////////////////////////////////////

            startIndex = 0;

            temp = _oppositeHtml.ToLower();

            p1 = temp.IndexOf("solved problems", startIndex);
            startIndex = p1;
            p1 = temp.IndexOf("<table", startIndex);
            startIndex = p1;
            p1 = temp.IndexOf("</table>", startIndex);
            temp = temp.Substring(startIndex, p1 - startIndex + 1);

            startIndex = 0;

            while (true)
            {
                p1 = temp.IndexOf("<td", startIndex);
                if (p1 < 0)
                    break;

                string result = "";
                int count = 0;

                for (int i = p1; i < temp.Length; i++)
                {
                    if (temp[i] == '<')
                    {
                        count++;
                        result = result.Trim();
                        if (result != "")
                            break;
                    }
                    else if (temp[i] == '>')
                        count--;
                    else if (count == 0)
                        result += temp[i].ToString();
                }
                startIndex = p1 + 1;
                int problemNumber = 0;

                if (int.TryParse(result, out problemNumber) == true)
                {
                    ProblemStatus ps = new ProblemStatus();
                    ps.Id = problemNumber;
                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    result = "";
                    count = 0;

                    for (int i = p1; i < temp.Length; i++)
                    {
                        if (temp[i] == '<')
                        {
                            count++;
                            result = result.Trim();
                            if (result != "")
                                break;
                        }
                        else if (temp[i] == '>')
                            count--;
                        else if (count == 0)
                            result += temp[i].ToString();
                    }
                    startIndex = p1 + 1;
                    ps.Rank = result;
                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    startIndex = p1 + 1;
                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    result = "";
                    count = 0;

                    for (int i = p1; i < temp.Length; i++)
                    {
                        if (temp[i] == '<')
                        {
                            count++;
                            result = result.Trim();
                            if (result != "")
                                break;
                        }
                        else if (temp[i] == '>')
                            count--;
                        else if (count == 0)
                            result += temp[i].ToString();
                    }
                    startIndex = p1 + 1;
                    ps.Date = result;

                    p1 = temp.IndexOf("<td", startIndex);
                    if (p1 < 0)
                        continue;
                    result = "";
                    count = 0;

                    for (int i = p1; i < temp.Length; i++)
                    {
                        if (temp[i] == '<')
                        {
                            count++;
                            result = result.Trim();
                            if (result != "")
                                break;
                        }
                        else if (temp[i] == '>')
                            count--;
                        else if (count == 0)
                            result += temp[i].ToString();
                    }
                    startIndex = p1 + 1;
                    ps.RunTime = result;

                    _oppositeSolved.Add(ps.Id, ps);
                }
            }

            lblOwnSolved.Text = _ownSolved.Count.ToString();
            lblOpponentSolved.Text = _oppositeSolved.Count.ToString();
            lbCommon.Items.Clear();
            lbOppnent.Items.Clear();
            lbYour.Items.Clear();

            foreach (int key in _ownSolved.Keys)
            {
                if (_oppositeSolved.ContainsKey(key))
                    lbCommon.Items.Add(key.ToString());
                else
                    lbOppnent.Items.Add(key.ToString());
            }

            foreach (int key in _oppositeSolved.Keys)
            {
                if (_ownSolved.ContainsKey(key))
                { }
                else
                    lbYour.Items.Add(key.ToString());
            }

            lblOwnUnsolbed.Text = lbYour.Items.Count.ToString();
            lblOppositeUnsolved.Text = lbOppnent.Items.Count.ToString();
            lblCommon.Text = lbCommon.Items.Count.ToString();
        }

        private void ShowOneProblemStatic(int problemId)
        {
            lblProblemNumber.Text = problemId.ToString();

            if (_ownSolved.ContainsKey(problemId))
            {
                lblYourRank.Text = _ownSolved[problemId].Rank;
                lblYourRankTime.Text = _ownSolved[problemId].RunTime;
                lblYourDate.Text = _ownSolved[problemId].Date;
            }
            else
            {
                lblYourRank.Text = "Not Solved";
                lblYourRankTime.Text = "Not Solved";
                lblYourDate.Text = "Not Solved";
            }

            if (_oppositeSolved.ContainsKey(problemId))
            {
                lblOpponentRank.Text = _oppositeSolved[problemId].Rank;
                lblOpponentRuntime.Text = _oppositeSolved[problemId].RunTime;
                lblOpponentDate.Text = _oppositeSolved[problemId].Date;
            }
            else
            {
                lblOpponentRank.Text = "Not Solved";
                lblOpponentRuntime.Text = "Not Solved";
                lblOpponentDate.Text = "Not Solved";
            }
        }

        private void lbYour_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(lbYour.SelectedItem.ToString(), out id) == true)
                ShowOneProblemStatic(id);
        }

        private void lbOppnent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(lbOppnent.SelectedItem.ToString(), out id) == true)
                ShowOneProblemStatic(id);
        }

        private void lbCommon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(lbCommon.SelectedItem.ToString(), out id) == true)
                ShowOneProblemStatic(id);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(txtProblem.Text, out id) == true)
                ShowOneProblemStatic(id);
            else
                MessageBox.Show("Please, give a problem number!!!");
        }
    }
}
