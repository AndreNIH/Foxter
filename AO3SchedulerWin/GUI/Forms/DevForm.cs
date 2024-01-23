using AO3SchedulerWin.AO3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AO3SchedulerWin.GUI.Forms
{




    public partial class DevForm : Form
    {
        private Ao3Client _client;
        public DevForm(Ao3Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await _client.GetChaptersForWork(50137141);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var x = comboBox1.SelectedValue;
            MessageBox.Show(x.ToString());
        }

        private void DevForm_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "DisplayName";


            ArrayList USStates = new ArrayList();
            /*USStates.Add(new USState("Alabama", "AL"));
            USStates.Add(new USState("Washington", "WA"));
            USStates.Add(new USState("West Virginia", "WV"));
            USStates.Add(new USState("Wisconsin", "WI"));
            USStates.Add(new USState("Wyoming", "WY"));*/

            var nobj = new USState("Alabama", "AL");
            nobj.LongName2 = "SDASDSAD";
            USStates.Add(nobj);

            comboBox1.DataSource = USStates;
            comboBox1.DisplayMember = "LongName2";
            comboBox1.ValueMember = "ShortName";

        }


    }


    public class USState
    {
        private string myShortName;
        private string myLongName;

        public USState(string strLongName, string strShortName)
        {

            this.myShortName = strShortName;
            this.myLongName = strLongName;
        }

        public string ShortName
        {
            get
            {
                return myShortName;
            }
        }

        public string LongName
        {

            get
            {
                return myLongName;
            }
        }

        public string LongName2 { get;set; }
    }
}
