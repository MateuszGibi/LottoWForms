using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoWForms
{
    public partial class BuyTicketForm : Form
    {
        GameForm gameForm;

        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<int> ticketNumbers = new List<int>();
        private bool IsTicketFull { get => this.ticketNumbers.Count < 6; }

        public BuyTicketForm(GameForm gameFormContext)
        {
            InitializeComponent();
            this.InitCheckboxList();
            this.gameForm = gameFormContext;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked) ticketNumbers.Add(Int32.Parse(checkBox.Text));
            else ticketNumbers.Remove(Int32.Parse(checkBox.Text));

            if(this.IsTicketFull && !checkBox.Checked)
            {
                this.EnableAllCheckBox();
                return;
            }

            if (!this.IsTicketFull)
            {
                this.DisableAllCheckBox();
            }
        }

        private void InitCheckboxList()
        {
            this.checkBoxes.Add(this.checkBox1);
            this.checkBoxes.Add(this.checkBox2);
            this.checkBoxes.Add(this.checkBox2);
            this.checkBoxes.Add(this.checkBox3);
            this.checkBoxes.Add(this.checkBox4);
            this.checkBoxes.Add(this.checkBox5);
            this.checkBoxes.Add(this.checkBox6);
            this.checkBoxes.Add(this.checkBox7);
            this.checkBoxes.Add(this.checkBox8);
            this.checkBoxes.Add(this.checkBox9);
            this.checkBoxes.Add(this.checkBox10);
            this.checkBoxes.Add(this.checkBox11);
            this.checkBoxes.Add(this.checkBox12);
            this.checkBoxes.Add(this.checkBox13);
            this.checkBoxes.Add(this.checkBox14);
            this.checkBoxes.Add(this.checkBox15);
            this.checkBoxes.Add(this.checkBox16);
            this.checkBoxes.Add(this.checkBox17);
            this.checkBoxes.Add(this.checkBox18);
            this.checkBoxes.Add(this.checkBox19);
            this.checkBoxes.Add(this.checkBox20);
            this.checkBoxes.Add(this.checkBox21);
            this.checkBoxes.Add(this.checkBox21);
            this.checkBoxes.Add(this.checkBox22);
            this.checkBoxes.Add(this.checkBox23);
            this.checkBoxes.Add(this.checkBox24);
            this.checkBoxes.Add(this.checkBox25);
            this.checkBoxes.Add(this.checkBox26);
            this.checkBoxes.Add(this.checkBox27);
            this.checkBoxes.Add(this.checkBox28);
            this.checkBoxes.Add(this.checkBox29);
            this.checkBoxes.Add(this.checkBox30);
            this.checkBoxes.Add(this.checkBox31);
            this.checkBoxes.Add(this.checkBox32);
            this.checkBoxes.Add(this.checkBox33);
            this.checkBoxes.Add(this.checkBox34);
            this.checkBoxes.Add(this.checkBox35);
            this.checkBoxes.Add(this.checkBox36);
            this.checkBoxes.Add(this.checkBox37);
            this.checkBoxes.Add(this.checkBox38);
            this.checkBoxes.Add(this.checkBox39);
            this.checkBoxes.Add(this.checkBox40);
            this.checkBoxes.Add(this.checkBox41);
            this.checkBoxes.Add(this.checkBox42);
            this.checkBoxes.Add(this.checkBox43);
            this.checkBoxes.Add(this.checkBox44);
            this.checkBoxes.Add(this.checkBox45);
            this.checkBoxes.Add(this.checkBox46);
            this.checkBoxes.Add(this.checkBox47);
            this.checkBoxes.Add(this.checkBox48);
            this.checkBoxes.Add(this.checkBox49);

        }

        private void EnableAllCheckBox()
        {
            for (int i = 0; i < this.checkBoxes.Count; i++)
            {
                if (this.checkBoxes[i].Checked) continue;

                this.checkBoxes[i].Enabled = true;
            }
        }
        private void DisableAllCheckBox()
        {
            for(int i = 0; i < this.checkBoxes.Count; i++)
            {
                if (this.checkBoxes[i].Checked) continue;

                this.checkBoxes[i].Enabled = false;
            }
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            if(this.ticketNumbers.Count < 6)
            {
                MessageBox.Show("Please select 6 numbers");
                return;
            }

            this.gameForm.ticketManager.BuyTicket(this.gameForm.auth.AuthUserId, this.ticketNumbers);
            this.gameForm.UpdateView();
            this.Close();
        }
    }
}
