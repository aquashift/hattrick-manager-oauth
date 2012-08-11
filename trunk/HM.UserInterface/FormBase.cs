using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using HM.Resources.Constants;

namespace HM.UserInterface
{
    // TODO. This form should be made abstract for release. 
    // We can't make it now because then designer for the derived forms
    // cannot be started
    public partial class FormBase : Form
    {
        protected ResourceManager resourceManager;

        public FormBase()
        {
            InitializeComponent();
            // Set CurrentUICulture. ResourceManager will then use it automatically.
            // TODO. This should be eventually moved to some event handler
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
            this.resourceManager = new ResourceManager(Localization.LocalizationBaseName,
                typeof(HM.Resources.GenericFunctions).Assembly);
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            PopulateLanguage();
        }

        // TODO. Make this abstract in release.
        /// <summary>
        /// Loads form strings from resources. It will try to get the localized string,
        /// using current thread's CurrentUICulture, and if appropriate string is not found, the default one
        /// (English) will be used.
        /// </summary>
        protected virtual void PopulateLanguage() { }
    }
}
