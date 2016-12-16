namespace CGrabber.Addin
{
    #region Namespace

    using System;
    using System.Linq;
    using System.Windows.Forms;
    using CGrabber.Addin.Domain;

    #endregion

    /// <summary>
    /// Represents windows form to manage CGrabber keyword ruleset.
    /// </summary>
    public partial class ManageCGrabberRulesetView : Form
    {
        #region Variable declaration

        /// <summary>
        /// Data context for CGrabberDBEntities object.
        /// </summary>
        private CGrabberDBEntities dataContext;

        /// <summary>
        /// Indicates a value is edit mode or new mode.
        /// </summary>
        private bool isEditMode;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public ManageCGrabberRulesetView()
        {
            InitializeComponent();
            dataContext = new CGrabberDBEntities();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Event handler for done button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void CGrabberRulesetButtonDoneClick(object sender, EventArgs eventArgs)
        {
            this.Close();
        }

        /// <summary>
        /// Event handler for CGrabber ruleset view load event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void ManageCGrabberRulesetViewLoad(object sender, EventArgs eventArgs)
        {
            this.LoadRulesets();
            this.lstBoxCGrabberRuleset.Enabled = true;
            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnDone.Enabled = false;
            txtBoxName.Enabled = false;
            txtBoxKeyword.Enabled = false;
            checkBoxEnabled.Enabled = false;
            isEditMode = false;
        }

        /// <summary>
        /// Load rulesets.
        /// </summary>
        private void LoadRulesets()
        {
            this.lstBoxCGrabberRuleset.DataSource = null;
            if (null != this.dataContext)
            {
                this.dataContext.Dispose();
            }

            this.dataContext = new CGrabberDBEntities();
            this.lstBoxCGrabberRuleset.DataSource = this.dataContext.GrabberRulesets;
            this.lstBoxCGrabberRuleset.DisplayMember = "RulesetName";
            this.lstBoxCGrabberRuleset.ValueMember = "RulesetId";
            this.lstBoxCGrabberRuleset.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for CGrabber ruleset list box selected index changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void CGrabberRulesetListBoxSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (this.lstBoxCGrabberRuleset.SelectedIndex == -1)
            {
                btnNew.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDone.Enabled = false;
                txtBoxName.Enabled = false;
                txtBoxKeyword.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDone.Enabled = false;
                txtBoxName.Enabled = false;
                txtBoxKeyword.Enabled = false;
                checkBoxEnabled.Enabled = false;
                var selectedItem = (GrabberRuleset)this.lstBoxCGrabberRuleset.Items[this.lstBoxCGrabberRuleset.SelectedIndex];
                if (null == selectedItem)
                {
                    return;
                }

                this.txtBoxName.Text = selectedItem.RulesetName;
                this.txtBoxKeyword.Text = selectedItem.RulesetKeyword;
                this.checkBoxEnabled.Checked = selectedItem.IsActive;
            }
        }

        /// <summary>
        /// Event handler for new button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void NewClick(object sender, EventArgs eventArgs)
        {
            this.lstBoxCGrabberRuleset.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnDone.Enabled = true;
            txtBoxName.Enabled = true;
            txtBoxName.Text = string.Empty;
            txtBoxKeyword.Enabled = true;
            txtBoxKeyword.Text = string.Empty;
            checkBoxEnabled.Enabled = true;
            checkBoxEnabled.Checked = false;
            isEditMode = false;
        }

        /// <summary>
        /// Event handler for edit button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void EditClick(object sender, EventArgs eventArgs)
        {
            if (-1 == this.lstBoxCGrabberRuleset.SelectedIndex)
            {
                return;
            }

            var selectedItem = (GrabberRuleset)this.lstBoxCGrabberRuleset.Items[this.lstBoxCGrabberRuleset.SelectedIndex];
            var item = this.dataContext.GrabberRulesets.FirstOrDefault(items => items.RulesetId == selectedItem.RulesetId);
            if (null == item)
            {
                return;
            }

            this.txtBoxName.Text = item.RulesetName;
            this.txtBoxKeyword.Text = item.RulesetKeyword;
            this.lstBoxCGrabberRuleset.Enabled = false;
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnDone.Enabled = true;
            this.txtBoxName.Enabled = true;
            this.txtBoxKeyword.Enabled = true;
            this.checkBoxEnabled.Enabled = true;
            this.isEditMode = true;
        }

        /// <summary>
        /// Event handler for delete button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void DeleteClick(object sender, EventArgs eventArgs)
        {
            this.lstBoxCGrabberRuleset.Enabled = true;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnDone.Enabled = false;
            txtBoxName.Enabled = false;
            txtBoxKeyword.Enabled = false;
            checkBoxEnabled.Enabled = false;

            var selectedItem = (GrabberRuleset)this.lstBoxCGrabberRuleset.Items[this.lstBoxCGrabberRuleset.SelectedIndex];
            if (null == selectedItem)
            {
                return;
            }

            this.dataContext.GrabberRulesets.DeleteObject(selectedItem);
            this.dataContext.SaveChanges();
            this.LoadRulesets();
        }

        /// <summary>
        /// Event handler for button done click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void DoneClick(object sender, EventArgs eventArgs)
        {
            if (string.IsNullOrEmpty(txtBoxName.Text.Trim()))
            {
                MessageBox.Show("Invalid name.");
                return;
            }
            if (string.IsNullOrEmpty(txtBoxKeyword.Text.Trim()))
            {
                MessageBox.Show("Invalid keyword.");
                return;
            }
            var isSomethingDone = false;
            if (!isEditMode)
            {
                var newItem = new GrabberRuleset()
                    {
                        RulesetId = Guid.NewGuid(),
                        RulesetName = txtBoxName.Text,
                        RulesetKeyword = txtBoxKeyword.Text,
                        IsActive = checkBoxEnabled.Checked,
                        CreatedDate = DateTime.UtcNow
                    };
                this.dataContext.AddToGrabberRulesets(newItem);
                this.dataContext.SaveChanges();
                isSomethingDone = true;
            }
            else
            {
                var selectedItem = (GrabberRuleset)this.lstBoxCGrabberRuleset.Items[this.lstBoxCGrabberRuleset.SelectedIndex];
                if (null != selectedItem)
                {
                    var getItem = this.dataContext.GrabberRulesets.FirstOrDefault(items => items.RulesetId == selectedItem.RulesetId);
                    if (null != getItem)
                    {
                        getItem.RulesetName = txtBoxName.Text;
                        getItem.RulesetKeyword = txtBoxKeyword.Text;
                        getItem.IsActive = checkBoxEnabled.Checked;
                        this.dataContext.SaveChanges();
                        isSomethingDone = true;
                    }
                }
            }

            if (!isSomethingDone)
            {
                return;
            }

            this.LoadRulesets();
            this.lstBoxCGrabberRuleset.Enabled = true;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnDone.Enabled = false;
            this.txtBoxName.Text = string.Empty;
            this.txtBoxKeyword.Text = string.Empty;
            this.txtBoxName.Enabled = false;
            this.txtBoxKeyword.Enabled = false;
            this.checkBoxEnabled.Enabled = false;
            this.checkBoxEnabled.Checked = false;
        }
        
        #endregion
    }
}
