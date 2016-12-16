namespace CGrabber.Addin
{
    #region Namespace

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using CGrabber.Addin.Domain;
    using Office = Microsoft.Office.Core;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    #endregion

    /// <summary>
    /// Represents the starting point for CGrabber - Contact grabber Outlook add-in.
    /// </summary>
    public partial class ThisAddIn
    {
        #region Variable declaration

        /// <summary>
        /// Instance of outlook application.
        /// </summary>
        private Outlook.Application cgrabberApplication;

        #endregion

        #region Properties

        /// <summary>
        /// List of search keywords to find and grab an email address and add to contacts.
        /// </summary>
        private static List<string> SearchKeywords
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets instance of IRibbonUI interface for this outlook application add-in.
        /// </summary>
        internal static Office.IRibbonUI CGrabberRibbon
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update ruleset list used for searching keywords in incoming mails.
        /// </summary>
        internal static void UpdateRulesetList()
        {
            var dataContext = new CGrabberDBEntities();
            SearchKeywords = dataContext.GrabberRulesets.Select(items => items.RulesetKeyword).ToList();
        }

        /// <summary>
        /// Create ribbon extensibility object.
        /// </summary>
        /// <returns>Instance of IRibbonExtensibility interface.</returns>
        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new CGrabberRibbonMenu(this.cgrabberApplication);
        }
        
        #endregion

        #region Event handlers

        /// <summary>
        /// Event handler for CGrabber application new mail arrived event.
        /// </summary>
        /// <param name="entryIdCollection">Entry Id collection.</param>
        private void CGrabberApplicationNewMailEx(string entryIdCollection)
        {
            var namespaceitem = this.cgrabberApplication.GetNamespace("MAPI");
            var stores = this.cgrabberApplication.Session.Stores;
            foreach (var folder in from Outlook.Store store in stores select store.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox))
            {
                try
                {
                    var mailItem = (Outlook.MailItem)namespaceitem.GetItemFromID(entryIdCollection, folder.StoreID);
                    if(null == mailItem)
                    {
                        return;
                    }

                    var searchResult = false;
                    if(mailItem.Body != null)
                    {
                        searchResult = SearchKeywords.Any(keyword => mailItem.Body.IndexOf(keyword) != -1);   
                    }

                    var searchResultHtmlBody = false;
                    if (mailItem.HTMLBody != null)
                    {
                        searchResultHtmlBody = SearchKeywords.Any(keyword => mailItem.HTMLBody.IndexOf(keyword) != -1);
                    }

                    var subjectSearchResult = false;
                    if(mailItem.Subject != null)
                    {
                        subjectSearchResult = SearchKeywords.Any(keyword => mailItem.Subject.IndexOf(keyword) != -1);
                    }

                    if (!searchResult && !searchResultHtmlBody && !subjectSearchResult)
                    {
                        return;
                    }

                    Outlook.MAPIFolder contactsFolder = null;
                    Outlook.Items items = null;
                    Outlook.ContactItem contact = null;
                    try
                    {
                        contactsFolder = this.cgrabberApplication.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
                        items = contactsFolder.Items;
                        var filter = "[Email1Address] = '" + mailItem.SenderEmailAddress + "'";
                        Outlook.ContactItem existingContact = null;
                        existingContact = items.Find(filter) as Outlook.ContactItem;
                        if (existingContact != null)
                        {
                            return;
                        }
                        else
                        {
                            filter = "[Email2Address] = '" + mailItem.SenderEmailAddress + "'";
                            existingContact = items.Find(filter) as Outlook.ContactItem;
                            if (existingContact != null)
                            {
                                return;
                            }
                            else
                            {
                                filter = "[Email3Address] = '" + mailItem.SenderEmailAddress + "'";
                                existingContact = items.Find(filter) as Outlook.ContactItem;
                                if (existingContact != null)
                                {
                                    return;
                                }
                                else
                                {
                                    contact = items.Add(Outlook.OlItemType.olContactItem) as Outlook.ContactItem;
                                    if (null == contact)
                                    {
                                        return;
                                    }

                                    contact.Email1Address = mailItem.SenderEmailAddress;
                                    contact.Email1DisplayName = mailItem.SenderName;
                                    contact.Save();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        if (contact != null) Marshal.ReleaseComObject(contact);
                        if (items != null) Marshal.ReleaseComObject(items);
                        if (contactsFolder != null) Marshal.ReleaseComObject(contactsFolder);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Event handler for CGrabber add-in startup event.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void ThisAddInStartup(object sender, EventArgs eventArgs)
        {
            this.cgrabberApplication = this.Application;
            UpdateRulesetList();
            this.cgrabberApplication.NewMailEx += this.CGrabberApplicationNewMailEx;
        }

        /// <summary>
        /// Event handler for CGrabber add-in startup event.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void ThisAddInShutdown(object sender, EventArgs eventArgs)
        {
            SearchKeywords.Clear();
            this.cgrabberApplication = null;
        }
        
        #endregion

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddInStartup);
            this.Shutdown += new System.EventHandler(ThisAddInShutdown);
        }

        #endregion
    }
}
