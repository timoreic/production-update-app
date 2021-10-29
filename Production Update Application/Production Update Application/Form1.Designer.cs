
namespace Production_Update_Application
{
    partial class productionUpdateApplication
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
            this.openButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.openPrompt = new System.Windows.Forms.Label();
            this.clearPrompt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportPrompt = new System.Windows.Forms.Label();
            this.exitPrompt = new System.Windows.Forms.Label();
            this.reportButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.masterListBox = new System.Windows.Forms.ListBox();
            this.masterFileLabel = new System.Windows.Forms.Label();
            this.instructionsTextBox = new System.Windows.Forms.TextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(169, 59);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(169, 122);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(169, 187);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Remove";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(169, 323);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // openPrompt
            // 
            this.openPrompt.Location = new System.Drawing.Point(12, 64);
            this.openPrompt.Name = "openPrompt";
            this.openPrompt.Size = new System.Drawing.Size(134, 23);
            this.openPrompt.TabIndex = 4;
            this.openPrompt.Text = "Open the master file:";
            // 
            // clearPrompt
            // 
            this.clearPrompt.Location = new System.Drawing.Point(12, 192);
            this.clearPrompt.Name = "clearPrompt";
            this.clearPrompt.Size = new System.Drawing.Size(134, 23);
            this.clearPrompt.TabIndex = 7;
            this.clearPrompt.Text = "Remove the master file:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Update the master file:";
            // 
            // reportPrompt
            // 
            this.reportPrompt.Location = new System.Drawing.Point(12, 260);
            this.reportPrompt.Name = "reportPrompt";
            this.reportPrompt.Size = new System.Drawing.Size(144, 23);
            this.reportPrompt.TabIndex = 9;
            this.reportPrompt.Text = "Show last transaction report:";
            // 
            // exitPrompt
            // 
            this.exitPrompt.Location = new System.Drawing.Point(12, 328);
            this.exitPrompt.Name = "exitPrompt";
            this.exitPrompt.Size = new System.Drawing.Size(134, 23);
            this.exitPrompt.TabIndex = 10;
            this.exitPrompt.Text = "Exit the application:";
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(169, 255);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(75, 23);
            this.reportButton.TabIndex = 3;
            this.reportButton.Text = "Show";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files|*.txt";
            this.openFileDialog.InitialDirectory = "//C:";
            this.openFileDialog.Tag = "";
            // 
            // masterListBox
            // 
            this.masterListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.masterListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterListBox.FormattingEnabled = true;
            this.masterListBox.ItemHeight = 24;
            this.masterListBox.Location = new System.Drawing.Point(326, 59);
            this.masterListBox.Margin = new System.Windows.Forms.Padding(0);
            this.masterListBox.Name = "masterListBox";
            this.masterListBox.Size = new System.Drawing.Size(376, 288);
            this.masterListBox.TabIndex = 13;
            this.masterListBox.TabStop = false;
            this.masterListBox.Visible = false;
//            this.masterListBox.SelectedIndexChanged += new System.EventHandler(this.idListbox_selectedIndexChanged);
            // 
            // masterFileLabel
            // 
            this.masterFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.masterFileLabel.Location = new System.Drawing.Point(321, 20);
            this.masterFileLabel.Name = "masterFileLabel";
            this.masterFileLabel.Size = new System.Drawing.Size(155, 28);
            this.masterFileLabel.TabIndex = 12;
            this.masterFileLabel.Text = "Master File";
            this.masterFileLabel.Visible = false;
            // 
            // instructionsTextBox
            // 
            this.instructionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructionsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsTextBox.Location = new System.Drawing.Point(326, 75);
            this.instructionsTextBox.Multiline = true;
            this.instructionsTextBox.Name = "instructionsTextBox";
            this.instructionsTextBox.Size = new System.Drawing.Size(338, 276);
            this.instructionsTextBox.TabIndex = 15;
            this.instructionsTextBox.TabStop = false;
            this.instructionsTextBox.Text = "1. Click \'Open\'.\r\n\r\n2. Choose master file.\r\n\r\n3. Click \'OK\'.\r\n\r\nTo update the mas" +
    "ter file:\r\n\r\n4. Click \'Update\'.\r\n\r\n5. Choose transaction file.\r\n\r\n6. Click \'OK\'." +
    "";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.instructionsLabel.Location = new System.Drawing.Point(321, 20);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(155, 28);
            this.instructionsLabel.TabIndex = 16;
            this.instructionsLabel.Text = "Instructions";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "newMasterFile";
            this.saveFileDialog.Filter = "Text files|*.txt";
            // 
            // productionUpdateApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 374);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.instructionsTextBox);
            this.Controls.Add(this.masterListBox);
            this.Controls.Add(this.masterFileLabel);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.exitPrompt);
            this.Controls.Add(this.reportPrompt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearPrompt);
            this.Controls.Add(this.openPrompt);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.openButton);
            this.Name = "productionUpdateApplication";
            this.Text = "Production Update Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label openPrompt;
        private System.Windows.Forms.Label clearPrompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label reportPrompt;
        private System.Windows.Forms.Label exitPrompt;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox masterListBox;
        private System.Windows.Forms.Label masterFileLabel;
        private System.Windows.Forms.TextBox instructionsTextBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

