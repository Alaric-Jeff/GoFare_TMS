namespace IPT_TMS_GoFare.Views
{
    partial class AdminPanelForm
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
            menuStrip1 = new MenuStrip();
            panel1 = new Panel();
            AnalyticsButton = new Button();
            TransactionButton = new Button();
            UserButton = new Button();
            GoFareLogo = new TextBox();
            dataGridView1 = new DataGridView();
            addClientBtn = new Button();
            UpdateClientBtn = new Button();
            DeleteBtn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1013, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(AnalyticsButton);
            panel1.Controls.Add(TransactionButton);
            panel1.Controls.Add(UserButton);
            panel1.Controls.Add(GoFareLogo);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1095, 59);
            panel1.TabIndex = 1;
            // 
            // AnalyticsButton
            // 
            AnalyticsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AnalyticsButton.Location = new Point(886, 12);
            AnalyticsButton.Name = "AnalyticsButton";
            AnalyticsButton.Size = new Size(112, 34);
            AnalyticsButton.TabIndex = 2;
            AnalyticsButton.Text = "Analytics";
            AnalyticsButton.UseVisualStyleBackColor = true;
            AnalyticsButton.Click += AnalyticsButton_Click;
            // 
            // TransactionButton
            // 
            TransactionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TransactionButton.Location = new Point(676, 12);
            TransactionButton.Name = "TransactionButton";
            TransactionButton.Size = new Size(194, 34);
            TransactionButton.TabIndex = 2;
            TransactionButton.Text = "Transaction History";
            TransactionButton.UseVisualStyleBackColor = true;
            TransactionButton.Click += button1_Click;
            // 
            // UserButton
            // 
            UserButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UserButton.Location = new Point(546, 12);
            UserButton.Name = "UserButton";
            UserButton.Size = new Size(112, 34);
            UserButton.TabIndex = 3;
            UserButton.Text = "Clients";
            UserButton.UseVisualStyleBackColor = true;
            // 
            // GoFareLogo
            // 
            GoFareLogo.BorderStyle = BorderStyle.None;
            GoFareLogo.Location = new Point(12, 12);
            GoFareLogo.Name = "GoFareLogo";
            GoFareLogo.ReadOnly = true;
            GoFareLogo.Size = new Size(150, 24);
            GoFareLogo.TabIndex = 0;
            GoFareLogo.Text = "Go-Fare";
            GoFareLogo.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 134);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(989, 304);
            dataGridView1.TabIndex = 2;
            // 
            // addClientBtn
            // 
            addClientBtn.Location = new Point(12, 83);
            addClientBtn.Name = "addClientBtn";
            addClientBtn.Size = new Size(112, 34);
            addClientBtn.TabIndex = 3;
            addClientBtn.Text = "Add Client";
            addClientBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateClientBtn
            // 
            UpdateClientBtn.Location = new Point(733, 83);
            UpdateClientBtn.Name = "UpdateClientBtn";
            UpdateClientBtn.Size = new Size(137, 34);
            UpdateClientBtn.TabIndex = 4;
            UpdateClientBtn.Text = "Update Client";
            UpdateClientBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(886, 83);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(112, 34);
            DeleteBtn.TabIndex = 5;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // AdminPanelForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1013, 450);
            Controls.Add(DeleteBtn);
            Controls.Add(UpdateClientBtn);
            Controls.Add(addClientBtn);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminPanelForm";
            Text = "Admin Panel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Panel panel1;
        private TextBox GoFareLogo;
        private Button TransactionButton;
        private Button UserButton;
        private Button AnalyticsButton;
        private DataGridView dataGridView1;
        private Button addClientBtn;
        private Button UpdateClientBtn;
        private Button DeleteBtn;
    }
}