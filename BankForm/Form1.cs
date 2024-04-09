using BankForm.Models.Entities;

namespace BankForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (BankFormDBContext db = new BankFormDBContext())
            {
                var user = db.Users.Where(u => u.Email == username && u.Password == password).FirstOrDefault();
                if (user != null)
                {
                    MessageBox.Show("Login Successful");
                    this.Hide();
                    Account form2 = new Account(user);
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
        }
    }
}
