namespace CGrabber.Addin
{
    partial class ManageCGrabberRulesetView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCGrabberRulesetView));
            this.btnCGrabberRulesetDone = new System.Windows.Forms.Button();
            this.lblCGrabberRulesetHelpText = new System.Windows.Forms.Label();
            this.grabberRulesetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstBoxCGrabberRuleset = new System.Windows.Forms.ListBox();
            this.lblRulesetName = new System.Windows.Forms.Label();
            this.lblRulesetKeyword = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxKeyword = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grabberRulesetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCGrabberRulesetDone
            // 
            this.btnCGrabberRulesetDone.Location = new System.Drawing.Point(703, 362);
            this.btnCGrabberRulesetDone.Name = "btnCGrabberRulesetDone";
            this.btnCGrabberRulesetDone.Size = new System.Drawing.Size(99, 26);
            this.btnCGrabberRulesetDone.TabIndex = 0;
            this.btnCGrabberRulesetDone.Text = "Close";
            this.btnCGrabberRulesetDone.UseVisualStyleBackColor = true;
            this.btnCGrabberRulesetDone.Click += new System.EventHandler(this.CGrabberRulesetButtonDoneClick);
            // 
            // lblCGrabberRulesetHelpText
            // 
            this.lblCGrabberRulesetHelpText.AutoSize = true;
            this.lblCGrabberRulesetHelpText.Location = new System.Drawing.Point(15, 14);
            this.lblCGrabberRulesetHelpText.Name = "lblCGrabberRulesetHelpText";
            this.lblCGrabberRulesetHelpText.Size = new System.Drawing.Size(733, 18);
            this.lblCGrabberRulesetHelpText.TabIndex = 1;
            this.lblCGrabberRulesetHelpText.Text = "Add / Edit / Delete - Enable / disable ruleset to grab email address for adding t" +
    "o outlook contacts.";
            // 
            // grabberRulesetBindingSource
            // 
            this.grabberRulesetBindingSource.DataSource = typeof(CGrabber.Addin.Domain.GrabberRuleset);
            // 
            // lstBoxCGrabberRuleset
            // 
            this.lstBoxCGrabberRuleset.DisplayMember = "RulesetId";
            this.lstBoxCGrabberRuleset.FormattingEnabled = true;
            this.lstBoxCGrabberRuleset.ItemHeight = 18;
            this.lstBoxCGrabberRuleset.Location = new System.Drawing.Point(18, 46);
            this.lstBoxCGrabberRuleset.Name = "lstBoxCGrabberRuleset";
            this.lstBoxCGrabberRuleset.Size = new System.Drawing.Size(330, 310);
            this.lstBoxCGrabberRuleset.TabIndex = 2;
            this.lstBoxCGrabberRuleset.ValueMember = "RulesetId";
            this.lstBoxCGrabberRuleset.SelectedIndexChanged += new System.EventHandler(this.CGrabberRulesetListBoxSelectedIndexChanged);
            // 
            // lblRulesetName
            // 
            this.lblRulesetName.AutoSize = true;
            this.lblRulesetName.Location = new System.Drawing.Point(383, 53);
            this.lblRulesetName.Name = "lblRulesetName";
            this.lblRulesetName.Size = new System.Drawing.Size(52, 18);
            this.lblRulesetName.TabIndex = 3;
            this.lblRulesetName.Text = "Name";
            // 
            // lblRulesetKeyword
            // 
            this.lblRulesetKeyword.AutoSize = true;
            this.lblRulesetKeyword.Location = new System.Drawing.Point(364, 94);
            this.lblRulesetKeyword.Name = "lblRulesetKeyword";
            this.lblRulesetKeyword.Size = new System.Drawing.Size(74, 18);
            this.lblRulesetKeyword.TabIndex = 4;
            this.lblRulesetKeyword.Text = "Keyword";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Enabled = false;
            this.txtBoxName.Location = new System.Drawing.Point(439, 50);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(354, 26);
            this.txtBoxName.TabIndex = 5;
            // 
            // txtBoxKeyword
            // 
            this.txtBoxKeyword.Enabled = false;
            this.txtBoxKeyword.Location = new System.Drawing.Point(439, 91);
            this.txtBoxKeyword.Multiline = true;
            this.txtBoxKeyword.Name = "txtBoxKeyword";
            this.txtBoxKeyword.Size = new System.Drawing.Size(354, 167);
            this.txtBoxKeyword.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(130, 362);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 26);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.EditClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(242, 362);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 26);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.DeleteClick);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Location = new System.Drawing.Point(18, 362);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(106, 26);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.NewClick);
            // 
            // btnDone
            // 
            this.btnDone.Enabled = false;
            this.btnDone.Location = new System.Drawing.Point(709, 264);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(84, 26);
            this.btnDone.TabIndex = 11;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.DoneClick);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Location = new System.Drawing.Point(441, 264);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(90, 22);
            this.checkBoxEnabled.TabIndex = 12;
            this.checkBoxEnabled.Text = "On / Off";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // ManageCGrabberRulesetView
            // 
            this.AcceptButton = this.btnCGrabberRulesetDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 404);
            this.Controls.Add(this.checkBoxEnabled);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtBoxKeyword);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblRulesetKeyword);
            this.Controls.Add(this.lblRulesetName);
            this.Controls.Add(this.lstBoxCGrabberRuleset);
            this.Controls.Add(this.lblCGrabberRulesetHelpText);
            this.Controls.Add(this.btnCGrabberRulesetDone);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageCGrabberRulesetView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage CGrabber Ruleset";
            this.Load += new System.EventHandler(this.ManageCGrabberRulesetViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grabberRulesetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCGrabberRulesetDone;
        private System.Windows.Forms.Label lblCGrabberRulesetHelpText;
        private System.Windows.Forms.BindingSource grabberRulesetBindingSource;
        private System.Windows.Forms.ListBox lstBoxCGrabberRuleset;
        private System.Windows.Forms.Label lblRulesetName;
        private System.Windows.Forms.Label lblRulesetKeyword;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxKeyword;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
    }
}