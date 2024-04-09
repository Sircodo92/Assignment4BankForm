using BankForm.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankForm
{
    public partial class Transaction : Form
    {
        int accountId;

        public Transaction(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }


        private void Transaction_Load(object sender, EventArgs e)
        {
            using (BankFormDBContext db = new BankFormDBContext())
            {
                foreach (var item in db.TransactionHistories.Where(t => t.AccountId == accountId))
                {
                    dataGridView1.Rows.Add(item.TransactionDate, item.Amount, item.Description);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }

        private void refreshData()
        {
            dataGridView1.Rows.Clear();
            using (BankFormDBContext db = new BankFormDBContext())
            {
                foreach (var item in db.TransactionHistories.Where(t => t.AccountId == accountId))
                {
                    dataGridView1.Rows.Add(item.TransactionDate, item.Amount, item.Description);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isDateParsed = DateTime.TryParse(textBox1.Text, out DateTime date);
            string amount = textBox2.Text;
            string description = textBox3.Text;

            if (!isDateParsed)
            {
                MessageBox.Show("Invalid Date");
                return;
            }
            else if (string.IsNullOrEmpty(amount))
            {
                MessageBox.Show("Invalid Amount");
                return;
            }
            else if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Invalid Description");
                return;
            }

            else
            {
                using (BankFormDBContext db = new BankFormDBContext())
                {
                    TransactionHistory transaction = new TransactionHistory()
                    {
                        TransactionDate = date,
                        Amount = Convert.ToDecimal(amount),
                        Description = description,
                        AccountId = accountId

                    };

                    db.TransactionHistories.Add(transaction);
                    db.SaveChanges();
                    refreshData();
                    MessageBox.Show("Transaction Added Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                using (BankFormDBContext db = new BankFormDBContext())
                {
                    TransactionHistory transaction = db.TransactionHistories.Where(t => t.AccountId == accountId).FirstOrDefault();
                    transaction.TransactionDate = Convert.ToDateTime(textBox1.Text);
                    transaction.Amount = Convert.ToDecimal(textBox2.Text);
                    transaction.Description = textBox3.Text;
                    db.SaveChanges();
                    refreshData();
                    MessageBox.Show("Transaction Updated Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //remove
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                using (BankFormDBContext db = new BankFormDBContext())
                {
                    TransactionHistory transaction = db.TransactionHistories.Where(t => t.AccountId == accountId).FirstOrDefault();
                    db.TransactionHistories.Remove(transaction);
                    db.SaveChanges();
                    refreshData();
                    MessageBox.Show("Transaction Removed Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please select a row to remove");
            }
        }
    }
}
