using eLedger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eLedgerGUI
{
    public partial class eLedger : Form
    {
        Manager man;
        public eLedger()
        {
            InitializeComponent();
            man = new Manager();
        }

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            double bal;
            if(txtNewAccount.Text != "" && !isEmpty(txtNewAccount.Text))
            {
                bal = man.parseAmt(txtNewBal.Text);
                if (bal == -1)
                    ;//Throw Warning
                else 
                    man.AddAccount(txtNewAccount.Text, bal);
            }
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {

        }

        private void btnValidateSingle_Click(object sender, EventArgs e)
        {

        }

        private void btnValDate_Click(object sender, EventArgs e)
        {

        }
        
        private bool isEmpty(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                    return false;
            }
            return true;
        }

        private void cmbAccountList_SelectedIndexChanged(object sender, EventArgs e)
        {
            man.SetAccount(cmbAccountList.Text);
        }
    }
}
