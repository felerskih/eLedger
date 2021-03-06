namespace eLedgerGUI
{
    partial class eLedger
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
            this.cmbAccountList = new System.Windows.Forms.ComboBox();
            this.lstledger = new System.Windows.Forms.ListView();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.btnValidateSingle = new System.Windows.Forms.Button();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.txtNewAccount = new System.Windows.Forms.TextBox();
            this.txtNewBal = new System.Windows.Forms.TextBox();
            this.txtValDate = new System.Windows.Forms.TextBox();
            this.btnValDate = new System.Windows.Forms.Button();
            this.lblNewAccount = new System.Windows.Forms.Label();
            this.lblNewBal = new System.Windows.Forms.Label();
            this.lblValDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbAccountList
            // 
            this.cmbAccountList.FormattingEnabled = true;
            this.cmbAccountList.Location = new System.Drawing.Point(33, 26);
            this.cmbAccountList.Name = "cmbAccountList";
            this.cmbAccountList.Size = new System.Drawing.Size(121, 21);
            this.cmbAccountList.TabIndex = 0;
            this.cmbAccountList.Text = "Select Account...";
            this.cmbAccountList.SelectedIndexChanged += new System.EventHandler(this.cmbAccountList_SelectedIndexChanged);
            // 
            // lstledger
            // 
            this.lstledger.HideSelection = false;
            this.lstledger.Location = new System.Drawing.Point(70, 95);
            this.lstledger.Name = "lstledger";
            this.lstledger.Size = new System.Drawing.Size(614, 222);
            this.lstledger.TabIndex = 1;
            this.lstledger.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.Location = new System.Drawing.Point(173, 27);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(121, 23);
            this.btnRemoveAccount.TabIndex = 2;
            this.btnRemoveAccount.Text = "RemoveAccount";
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);
            // 
            // btnValidateSingle
            // 
            this.btnValidateSingle.Location = new System.Drawing.Point(173, 348);
            this.btnValidateSingle.Name = "btnValidateSingle";
            this.btnValidateSingle.Size = new System.Drawing.Size(120, 23);
            this.btnValidateSingle.TabIndex = 3;
            this.btnValidateSingle.Text = "Validate Single Entry";
            this.btnValidateSingle.UseVisualStyleBackColor = true;
            this.btnValidateSingle.Click += new System.EventHandler(this.btnValidateSingle_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(33, 347);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(120, 23);
            this.btnAddEntry.TabIndex = 4;
            this.btnAddEntry.Text = "Add Ledger Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(563, 25);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(121, 23);
            this.btnAddAccount.TabIndex = 5;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // txtNewAccount
            // 
            this.txtNewAccount.Location = new System.Drawing.Point(300, 27);
            this.txtNewAccount.Name = "txtNewAccount";
            this.txtNewAccount.Size = new System.Drawing.Size(120, 20);
            this.txtNewAccount.TabIndex = 6;
            // 
            // txtNewBal
            // 
            this.txtNewBal.Location = new System.Drawing.Point(426, 27);
            this.txtNewBal.Name = "txtNewBal";
            this.txtNewBal.Size = new System.Drawing.Size(120, 20);
            this.txtNewBal.TabIndex = 7;
            // 
            // txtValDate
            // 
            this.txtValDate.Location = new System.Drawing.Point(426, 346);
            this.txtValDate.Name = "txtValDate";
            this.txtValDate.Size = new System.Drawing.Size(120, 20);
            this.txtValDate.TabIndex = 8;
            // 
            // btnValDate
            // 
            this.btnValDate.Location = new System.Drawing.Point(563, 346);
            this.btnValDate.Name = "btnValDate";
            this.btnValDate.Size = new System.Drawing.Size(121, 23);
            this.btnValDate.TabIndex = 9;
            this.btnValDate.Text = "Validate by Date";
            this.btnValDate.UseVisualStyleBackColor = true;
            this.btnValDate.Click += new System.EventHandler(this.btnValDate_Click);
            // 
            // lblNewAccount
            // 
            this.lblNewAccount.AutoSize = true;
            this.lblNewAccount.Location = new System.Drawing.Point(300, 8);
            this.lblNewAccount.Name = "lblNewAccount";
            this.lblNewAccount.Size = new System.Drawing.Size(112, 13);
            this.lblNewAccount.TabIndex = 10;
            this.lblNewAccount.Text = "New Account Name...";
            // 
            // lblNewBal
            // 
            this.lblNewBal.AutoSize = true;
            this.lblNewBal.Location = new System.Drawing.Point(423, 8);
            this.lblNewBal.Name = "lblNewBal";
            this.lblNewBal.Size = new System.Drawing.Size(123, 13);
            this.lblNewBal.TabIndex = 11;
            this.lblNewBal.Text = "New Account Balance...";
            // 
            // lblValDate
            // 
            this.lblValDate.AutoSize = true;
            this.lblValDate.Location = new System.Drawing.Point(426, 324);
            this.lblValDate.Name = "lblValDate";
            this.lblValDate.Size = new System.Drawing.Size(80, 13);
            this.lblValDate.TabIndex = 12;
            this.lblValDate.Text = "Validate Date...";
            // 
            // eLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblValDate);
            this.Controls.Add(this.lblNewBal);
            this.Controls.Add(this.lblNewAccount);
            this.Controls.Add(this.btnValDate);
            this.Controls.Add(this.txtValDate);
            this.Controls.Add(this.txtNewBal);
            this.Controls.Add(this.txtNewAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.btnValidateSingle);
            this.Controls.Add(this.btnRemoveAccount);
            this.Controls.Add(this.lstledger);
            this.Controls.Add(this.cmbAccountList);
            this.Name = "eLedger";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAccountList;
        private System.Windows.Forms.ListView lstledger;
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.Button btnValidateSingle;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.TextBox txtNewAccount;
        private System.Windows.Forms.TextBox txtNewBal;
        private System.Windows.Forms.TextBox txtValDate;
        private System.Windows.Forms.Button btnValDate;
        private System.Windows.Forms.Label lblNewAccount;
        private System.Windows.Forms.Label lblNewBal;
        private System.Windows.Forms.Label lblValDate;
    }
}

