namespace TimelessEmulatorGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.jewelTypeSelection = new System.Windows.Forms.ComboBox();
            this.jewelTypeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.keystoneTypeSelection = new System.Windows.Forms.ComboBox();
            this.selectedSkills = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.skillFilter = new System.Windows.Forms.TextBox();
            this.desiredStatCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.desiredStatList = new System.Windows.Forms.ListBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.validJewels = new System.Windows.Forms.ListBox();
            this.bruteforceProgress = new System.Windows.Forms.ProgressBar();
            this.warningText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // jewelTypeSelection
            // 
            this.jewelTypeSelection.FormattingEnabled = true;
            this.jewelTypeSelection.Location = new System.Drawing.Point(12, 37);
            this.jewelTypeSelection.Name = "jewelTypeSelection";
            this.jewelTypeSelection.Size = new System.Drawing.Size(186, 23);
            this.jewelTypeSelection.TabIndex = 0;
            this.jewelTypeSelection.SelectionChangeCommitted += new System.EventHandler(this.jewelTypeSelection_SelectionChangeCommitted);
            // 
            // jewelTypeLabel
            // 
            this.jewelTypeLabel.AutoSize = true;
            this.jewelTypeLabel.Location = new System.Drawing.Point(12, 19);
            this.jewelTypeLabel.Name = "jewelTypeLabel";
            this.jewelTypeLabel.Size = new System.Drawing.Size(35, 15);
            this.jewelTypeLabel.TabIndex = 1;
            this.jewelTypeLabel.Text = "Jewel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Keystone";
            // 
            // keystoneTypeSelection
            // 
            this.keystoneTypeSelection.FormattingEnabled = true;
            this.keystoneTypeSelection.Location = new System.Drawing.Point(12, 81);
            this.keystoneTypeSelection.Name = "keystoneTypeSelection";
            this.keystoneTypeSelection.Size = new System.Drawing.Size(186, 23);
            this.keystoneTypeSelection.TabIndex = 3;
            this.keystoneTypeSelection.SelectedIndexChanged += new System.EventHandler(this.keystoneTypeSelection_SelectedIndexChanged);
            // 
            // selectedSkills
            // 
            this.selectedSkills.FormattingEnabled = true;
            this.selectedSkills.Location = new System.Drawing.Point(13, 154);
            this.selectedSkills.Name = "selectedSkills";
            this.selectedSkills.Size = new System.Drawing.Size(185, 274);
            this.selectedSkills.TabIndex = 4;
            this.selectedSkills.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selectedSkills_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Affected Skills";
            // 
            // skillFilter
            // 
            this.skillFilter.Location = new System.Drawing.Point(13, 125);
            this.skillFilter.Name = "skillFilter";
            this.skillFilter.PlaceholderText = "Filter";
            this.skillFilter.Size = new System.Drawing.Size(185, 23);
            this.skillFilter.TabIndex = 6;
            this.skillFilter.TextChanged += new System.EventHandler(this.skillFilter_TextChanged);
            // 
            // desiredStatCombo
            // 
            this.desiredStatCombo.FormattingEnabled = true;
            this.desiredStatCombo.Location = new System.Drawing.Point(204, 37);
            this.desiredStatCombo.Name = "desiredStatCombo";
            this.desiredStatCombo.Size = new System.Drawing.Size(223, 23);
            this.desiredStatCombo.Sorted = true;
            this.desiredStatCombo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Desired Stats";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // desiredStatList
            // 
            this.desiredStatList.FormattingEnabled = true;
            this.desiredStatList.ItemHeight = 15;
            this.desiredStatList.Location = new System.Drawing.Point(204, 64);
            this.desiredStatList.Name = "desiredStatList";
            this.desiredStatList.Size = new System.Drawing.Size(251, 364);
            this.desiredStatList.TabIndex = 12;
            this.desiredStatList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.desiredStatList_MouseDoubleClick);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(459, 37);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(147, 24);
            this.generateButton.TabIndex = 13;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // validJewels
            // 
            this.validJewels.FormattingEnabled = true;
            this.validJewels.ItemHeight = 15;
            this.validJewels.Location = new System.Drawing.Point(459, 79);
            this.validJewels.Name = "validJewels";
            this.validJewels.Size = new System.Drawing.Size(144, 349);
            this.validJewels.TabIndex = 14;
            // 
            // bruteforceProgress
            // 
            this.bruteforceProgress.Location = new System.Drawing.Point(459, 63);
            this.bruteforceProgress.Name = "bruteforceProgress";
            this.bruteforceProgress.Size = new System.Drawing.Size(144, 15);
            this.bruteforceProgress.TabIndex = 15;
            // 
            // warningText
            // 
            this.warningText.AutoSize = true;
            this.warningText.ForeColor = System.Drawing.Color.Red;
            this.warningText.Location = new System.Drawing.Point(150, 63);
            this.warningText.Name = "warningText";
            this.warningText.Size = new System.Drawing.Size(0, 15);
            this.warningText.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 450);
            this.Controls.Add(this.warningText);
            this.Controls.Add(this.bruteforceProgress);
            this.Controls.Add(this.validJewels);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.desiredStatList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.desiredStatCombo);
            this.Controls.Add(this.skillFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedSkills);
            this.Controls.Add(this.keystoneTypeSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jewelTypeLabel);
            this.Controls.Add(this.jewelTypeSelection);
            this.Name = "Form1";
            this.Text = "TimelessJewelSearch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox jewelTypeSelection;
        private Label jewelTypeLabel;
        private Label label1;
        private ComboBox keystoneTypeSelection;
        private CheckedListBox selectedSkills;
        private Label label2;
        private TextBox skillFilter;
        private ComboBox desiredStatCombo;
        private Label label4;
        private Button button1;
        private ListBox desiredStatList;
        private Button generateButton;
        private ListBox validJewels;
        private ProgressBar bruteforceProgress;
        private Label warningText;
    }
}