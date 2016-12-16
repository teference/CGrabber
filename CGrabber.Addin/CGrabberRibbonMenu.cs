namespace CGrabber.Addin
{
    #region Namespace

    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Office = Microsoft.Office.Core;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    #endregion

    /// <summary>
    /// Represents the implementation of business logic for CGrabber ribbon menu items.
    /// </summary>
    [ComVisible(true)]
    public class CGrabberRibbonMenu : Office.IRibbonExtensibility
    {
        #region Variable declaration

        /// <summary>
        /// Instance of IRibbonUI interface.
        /// </summary>
        private Office.IRibbonUI ribbon;

        /// <summary>
        /// Reference instance to Outlook application.
        /// </summary>
        private Outlook.Application outlookApplication;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of the CGrabberRibbonMenu class.
        /// </summary>
        /// <param name="outlookApplication">Instance of Outlook application class.</param>
        public CGrabberRibbonMenu(Outlook.Application outlookApplication)
        {
            this.outlookApplication = outlookApplication as Outlook.Application;
        }
        
        #endregion

        #region IRibbonExtensibility Members

        /// <summary>
        /// Get custom UI based on ribbon Id provided.
        /// </summary>
        /// <param name="ribbonId">Ribbon Id.</param>
        /// <returns>Returns the configuration file that contains the ribbon UI details.</returns>
        public string GetCustomUI(string ribbonId)
        {
            return GetResourceText("CGrabber.Addin.CGrabberRibbonMenu.xml");
        }

        #endregion

        #region Ribbon Callbacks

        /// <summary>
        /// Event handler for CGrabber ruleset view form closed event.
        /// </summary>
        /// <param name="sender">Sender object.s</param>
        /// <param name="eventArgs">Event arguments.</param>
        private static void ManageCGrabberRulesetViewClosed(object sender, EventArgs eventArgs)
        {
            ThisAddIn.UpdateRulesetList();
        }

        /// <summary>
        /// Event handler for CGrabber ribbon menu RibbonUI object load event.
        /// </summary>
        /// <param name="ribbonUI">Instance of IRibbonUI interface.</param>
        public void RibbonLoad(Office.IRibbonUI ribbonUI)
        {
            ThisAddIn.CGrabberRibbon = ribbonUI;
        }

        /// <summary>
        /// Event handler for CGrabber ribbon tab get visible event.
        /// </summary>
        /// <param name="control">Instance of IRibbonControl interface.</param>
        /// <returns>Is tab visible or not.</returns>
        public bool CGrabberTabGetVisible(Office.IRibbonControl control)
        {
            return true;
        }

        /// <summary>
        /// Event handler for CGrabber ruleset settings button click event.
        /// </summary>
        /// <param name="control">Instance of IRibbonControl interface.</param>
        public void CGrabberRuleSettingsButtonClick(Office.IRibbonControl control)
        {
            var manageCGrabberRulesetView = new ManageCGrabberRulesetView
                {
                    ShowInTaskbar = false
                };
            manageCGrabberRulesetView.Closed += ManageCGrabberRulesetViewClosed;
            manageCGrabberRulesetView.ShowDialog();
        }

        /// <summary>
        /// Event handler for CGrabber about me button click event.
        /// </summary>
        /// <param name="control">Instance of IRibbonControl interface.</param>
        public void CGrabberAboutButtonClick(Office.IRibbonControl control)
        {
            var aboutView = new AboutCGrabberView { ShowInTaskbar = false };
            aboutView.ShowDialog();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Get resource text for resource name.
        /// </summary>
        /// <param name="resourceName">Resource name.</param>
        /// <returns>Resource text value.</returns>
        private static string GetResourceText(string resourceName)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var resourceNames = executingAssembly.GetManifestResourceNames();
            foreach (var resourceNameItem in resourceNames.Where(resourceNameItem => string.Compare(resourceName, resourceNameItem, StringComparison.OrdinalIgnoreCase) == 0))
            {
                using (var resourceReader = new StreamReader(executingAssembly.GetManifestResourceStream(resourceNameItem)))
                {
                    return resourceReader.ReadToEnd();
                }
            }
            return null;
        }

        #endregion
    }
}
