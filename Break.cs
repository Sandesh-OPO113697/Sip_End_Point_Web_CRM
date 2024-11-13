using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneCRM
{
    public partial class Break : Form
    {        
        public delegate void CurrentStatusIdEventHandler(int currentstatusid,string brkstatus);
        System.Windows.Forms.Timer Timerbreak  = new System.Windows.Forms.Timer();  
        public event CurrentStatusIdEventHandler CurrentStatusId;
        public Int32 count = 0;
        public Break()
        {
            InitializeComponent();

            this.TopMost = true;
            this.Activate();
            try
            {
                if (!string.IsNullOrEmpty(CL_AgentDetails.BreakTypes))
                {
                    string TypesofBreak = Convert.ToString(CL_AgentDetails.BreakTypes);
                    if (TypesofBreak != "")
                    {
                        string[] mm = TypesofBreak.Split(',');
                        for (int i = 0; i < mm.Length; i++)
                        {
                            cmbbreakopt.DisplayMember = "Text";
                            cmbbreakopt.ValueMember = "Value";
                            string[] TypeBreak = mm[i].ToString().Split(':');
                            for (int j = 0; j < TypeBreak.Length; j++)
                            {
                                cmbbreakopt.Items.Add(new { Text = TypeBreak[j + 1].ToString(), Value = TypeBreak[j].ToString() });
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void cmdbreakcancel_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            Timerbreak.Stop();
            CTI.isnotready = false;
            this.Close();
        }
        private void Break_Load(object sender, EventArgs e)
        {
            InitializeCounterTimer();
            this.TopMost = true;
            this.Activate();

            try
            {
                if (!string.IsNullOrEmpty(CL_AgentDetails.BreakTypes))
                {
                    string TypesofBreak = Convert.ToString(CL_AgentDetails.BreakTypes);
                    if (TypesofBreak != "")
                    {
                        string[] mm = TypesofBreak.Split(',');
                        for (int i = 0; i < mm.Length; i++)
                        {
                            cmbbreakopt.DisplayMember = "Text";
                            cmbbreakopt.ValueMember = "Value";
                            string[] TypeBreak = mm[i].ToString().Split(':');
                            for (int j = 0; j < TypeBreak.Length; j++)
                            {
                                cmbbreakopt.Items.Add(new { Text = TypeBreak[j + 1].ToString(), Value = TypeBreak[j].ToString() });
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
           
        }
        public void InitializeCounterTimer()
        {
            Timerbreak.Tick += new EventHandler(Timerbreak_Tick);
            Timerbreak.Interval = 10000;
            Timerbreak.Enabled = true;
            Timerbreak.Start();

        }
        private void cmdbreakok_Click(object sender, EventArgs e)
        {
            if (cmbbreakopt.SelectedIndex >= 0)
            {
                //string brk = cmbbreakopt.Text;

                //if (cmbbreakopt.Text == "Tea")
                //{
                //    CurrentStatusId(5, "Tea");
                //}
                //else if (cmbbreakopt.Text == "Lunch")
                //{
                //    CurrentStatusId(6, "Lunch");
                //}
                //else if (cmbbreakopt.Text == "Training")
                //{
                //    CurrentStatusId(7, "Training");
                //}
                //else if (cmbbreakopt.Text == "Quality")
                //{
                   // CurrentStatusId(8, "Quality");
                //}
                //else if (cmbbreakopt.Text == "Bio Break")
                //{
                //    CurrentStatusId(9, "Emergency");
                //}
                //else if (cmbbreakopt.Text == "Vat BREAK")
                //{
                //    CurrentStatusId(27, "Vat BREAK");
                //}

                string Breaktypes = cmbbreakopt.SelectedItem.ToString();
                string[] mm = Breaktypes.Split(',');
                string TypeBreaks = mm[1].ToString().Replace(" Value = ", "").Replace(" }", "");
                string brk = cmbbreakopt.Text;
                Int32 bid = Convert.ToInt32(TypeBreaks.ToString());

                if (cmbbreakopt.Text == "Bio")
                {
                    CurrentStatusId(bid, "Emergency");
                }
                else
                {
                    CurrentStatusId(bid, brk);
                }

                this.TopMost = false;
                CTI.isnotready = true;
                this.Close();
            }
        }
        private void Timerbreak_Tick(object sender, EventArgs e)
        {
            count++;

            if (count >= 2)
            {
                Timerbreak.Stop();
                CTI.isnotready = false;
                this.Close();
                count = 0;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbbreakopt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void Break_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    count = 0;
        //    e.Cancel = true;
        //    this.Hide();
        //}
    }
}

