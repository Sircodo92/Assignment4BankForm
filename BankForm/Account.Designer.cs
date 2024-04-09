namespace BankForm
{
    partial class Account
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Accounttype = new DataGridViewTextBoxColumn();
            AmountBalance = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Accounttype, AmountBalance, Date });
            dataGridView1.Location = new Point(136, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(547, 202);
            dataGridView1.TabIndex = 0;
            // 
            // Accounttype
            // 
            Accounttype.HeaderText = "Accounttype";
            Accounttype.MinimumWidth = 6;
            Accounttype.Name = "Accounttype";
            Accounttype.Width = 125;
            // 
            // AmountBalance
            // 
            AmountBalance.HeaderText = "AmountBalance";
            AmountBalance.MinimumWidth = 6;
            AmountBalance.Name = "AmountBalance";
            AmountBalance.Width = 125;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(300, 280);
            button1.Name = "button1";
            button1.Size = new Size(223, 29);
            button1.TabIndex = 1;
            button1.Text = "Transaction History";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Account
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 343);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Account";
            Text = "Account";
            Load += Account_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Accounttype;
        private DataGridViewTextBoxColumn AmountBalance;
        private Button button1;
        private DataGridViewTextBoxColumn Date;
    }
}