using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankForm.Models.Entities;

namespace BankForm
{
    public partial class Account : Form
    {
        public User user;
        public Account(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            using (BankFormDBContext db = new BankFormDBContext())
            {
                BankForm.Models.Entities.Account account = new BankForm.Models.Entities.Account();
                account = db.Accounts.Where(a => a.UserId == user.Id).FirstOrDefault();

                foreach (var item in db.Accounts)
                {
                    dataGridView1.Rows.Add(item.AccountType, item.CurrentBalance, item.DateCreated);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BankFormDBContext db = new BankFormDBContext())
            {
                BankForm.Models.Entities.Account account = new BankForm.Models.Entities.Account();
                account = db.Accounts.Where(a => a.UserId == user.Id).FirstOrDefault();
                Transaction form2 = new Transaction(account.AccountId);
                form2.ShowDialog();
            }

        }
    }
}
