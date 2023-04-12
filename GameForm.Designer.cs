namespace LottoWForms
{
    partial class GameForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.ticketsGroupBox = new System.Windows.Forms.GroupBox();
            this.ticketList = new System.Windows.Forms.ListView();
            this.Numbers = new System.Windows.Forms.ColumnHeader();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.helloLabel = new System.Windows.Forms.Label();
            this.numbersLabel = new System.Windows.Forms.Label();
            this.checkBtn = new System.Windows.Forms.Button();
            this.buyTicketBtn = new System.Windows.Forms.Button();
            this.prizeLabel = new System.Windows.Forms.Label();
            this.ticketsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ticketsGroupBox
            // 
            this.ticketsGroupBox.Controls.Add(this.ticketList);
            this.ticketsGroupBox.Location = new System.Drawing.Point(6, 62);
            this.ticketsGroupBox.Name = "ticketsGroupBox";
            this.ticketsGroupBox.Size = new System.Drawing.Size(227, 279);
            this.ticketsGroupBox.TabIndex = 10;
            this.ticketsGroupBox.TabStop = false;
            this.ticketsGroupBox.Text = "Your tickets:";
            // 
            // ticketList
            // 
            this.ticketList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Numbers});
            this.ticketList.HideSelection = false;
            this.ticketList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ticketList.Location = new System.Drawing.Point(6, 22);
            this.ticketList.Name = "ticketList";
            this.ticketList.Size = new System.Drawing.Size(215, 251);
            this.ticketList.TabIndex = 2;
            this.ticketList.UseCompatibleStateImageBehavior = false;
            this.ticketList.View = System.Windows.Forms.View.Details;
            // 
            // Numbers
            // 
            this.Numbers.Text = "Numbers";
            this.Numbers.Width = 150;
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(239, 99);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(99, 15);
            this.balanceLabel.TabIndex = 9;
            this.balanceLabel.Text = "Your balance: 000";
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Location = new System.Drawing.Point(239, 84);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(93, 15);
            this.helloLabel.TabIndex = 8;
            this.helloLabel.Text = "Hello UserName";
            // 
            // numbersLabel
            // 
            this.numbersLabel.AutoSize = true;
            this.numbersLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numbersLabel.Location = new System.Drawing.Point(6, 39);
            this.numbersLabel.Name = "numbersLabel";
            this.numbersLabel.Size = new System.Drawing.Size(189, 20);
            this.numbersLabel.TabIndex = 14;
            this.numbersLabel.Text = "Today\'s numbers: 1,2,3,4,5,6";
            this.numbersLabel.Visible = false;
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(239, 314);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(117, 23);
            this.checkBtn.TabIndex = 13;
            this.checkBtn.Text = "Check your tickets";
            this.checkBtn.UseVisualStyleBackColor = true;
            // 
            // buyTicketBtn
            // 
            this.buyTicketBtn.Location = new System.Drawing.Point(239, 285);
            this.buyTicketBtn.Name = "buyTicketBtn";
            this.buyTicketBtn.Size = new System.Drawing.Size(117, 23);
            this.buyTicketBtn.TabIndex = 12;
            this.buyTicketBtn.Text = "Buy ticket";
            this.buyTicketBtn.UseVisualStyleBackColor = true;
            // 
            // prizeLabel
            // 
            this.prizeLabel.AutoSize = true;
            this.prizeLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizeLabel.Location = new System.Drawing.Point(6, 9);
            this.prizeLabel.Name = "prizeLabel";
            this.prizeLabel.Size = new System.Drawing.Size(226, 30);
            this.prizeLabel.TabIndex = 11;
            this.prizeLabel.Text = "Today\'s prize: 10000zł";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 349);
            this.Controls.Add(this.ticketsGroupBox);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.helloLabel);
            this.Controls.Add(this.numbersLabel);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.buyTicketBtn);
            this.Controls.Add(this.prizeLabel);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.ticketsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ticketsGroupBox;
        private System.Windows.Forms.ListView ticketList;
        private System.Windows.Forms.ColumnHeader Numbers;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label helloLabel;
        private System.Windows.Forms.Label numbersLabel;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Button buyTicketBtn;
        private System.Windows.Forms.Label prizeLabel;
    }
}