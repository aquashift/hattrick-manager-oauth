namespace HM.UserInterface {
    partial class FormMain {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAchievements = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemArena = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClub = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEconomy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLeague = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMatches = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTopScorers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWorldDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.buttonDownload = new System.Windows.Forms.ToolStripButton();
            this.buttonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSpace1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonLineup = new System.Windows.Forms.ToolStripButton();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(992, 24);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDownload,
            this.menuItemSettings,
            this.toolStripSeparator1,
            this.menuItemQuit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(68, 20);
            this.menuFile.Text = "menuFile";
            // 
            // menuItemDownload
            // 
            this.menuItemDownload.Name = "menuItemDownload";
            this.menuItemDownload.Size = new System.Drawing.Size(183, 22);
            this.menuItemDownload.Text = "menuItemDownload";
            this.menuItemDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(183, 22);
            this.menuItemSettings.Text = "menuItemSettings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // menuItemQuit
            // 
            this.menuItemQuit.Name = "menuItemQuit";
            this.menuItemQuit.Size = new System.Drawing.Size(183, 22);
            this.menuItemQuit.Text = "menuItemQuit";
            this.menuItemQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAchievements,
            this.menuItemArena,
            this.menuItemClub,
            this.menuItemEconomy,
            this.menuItemLeague,
            this.menuItemMatches,
            this.menuItemTraining,
            this.menuItemTopScorers,
            this.menuItemWorldDetails});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(79, 20);
            this.menuTools.Text = "menuTools";
            // 
            // menuItemAchievements
            // 
            this.menuItemAchievements.Name = "menuItemAchievements";
            this.menuItemAchievements.Size = new System.Drawing.Size(204, 22);
            this.menuItemAchievements.Text = "menuItemAchievements";
            this.menuItemAchievements.Click += new System.EventHandler(this.buttonAchievements_Click);
            // 
            // menuItemArena
            // 
            this.menuItemArena.Name = "menuItemArena";
            this.menuItemArena.Size = new System.Drawing.Size(204, 22);
            this.menuItemArena.Text = "menuItemArena";
            this.menuItemArena.Click += new System.EventHandler(this.buttonArena_Click);
            // 
            // menuItemClub
            // 
            this.menuItemClub.Name = "menuItemClub";
            this.menuItemClub.Size = new System.Drawing.Size(204, 22);
            this.menuItemClub.Text = "menuItemClub";
            this.menuItemClub.Click += new System.EventHandler(this.buttonClub_Click);
            // 
            // menuItemEconomy
            // 
            this.menuItemEconomy.Name = "menuItemEconomy";
            this.menuItemEconomy.Size = new System.Drawing.Size(204, 22);
            this.menuItemEconomy.Text = "menuItemEconomy";
            this.menuItemEconomy.Click += new System.EventHandler(this.buttonEconomy_Click);
            // 
            // menuItemLeague
            // 
            this.menuItemLeague.Name = "menuItemLeague";
            this.menuItemLeague.Size = new System.Drawing.Size(204, 22);
            this.menuItemLeague.Text = "menuItemLeague";
            this.menuItemLeague.Click += new System.EventHandler(this.buttonLeague_Click);
            // 
            // menuItemMatches
            // 
            this.menuItemMatches.Name = "menuItemMatches";
            this.menuItemMatches.Size = new System.Drawing.Size(204, 22);
            this.menuItemMatches.Text = "menuItemMatches";
            this.menuItemMatches.Click += new System.EventHandler(this.buttonMatches_Click);
            // 
            // menuItemTraining
            // 
            this.menuItemTraining.Name = "menuItemTraining";
            this.menuItemTraining.Size = new System.Drawing.Size(204, 22);
            this.menuItemTraining.Text = "menuItemTraining";
            // 
            // menuItemTopScorers
            // 
            this.menuItemTopScorers.Name = "menuItemTopScorers";
            this.menuItemTopScorers.Size = new System.Drawing.Size(204, 22);
            this.menuItemTopScorers.Text = "menuItemTopScorers";
            // 
            // menuItemWorldDetails
            // 
            this.menuItemWorldDetails.Name = "menuItemWorldDetails";
            this.menuItemWorldDetails.Size = new System.Drawing.Size(204, 22);
            this.menuItemWorldDetails.Text = "menuItemWorldDetails";
            this.menuItemWorldDetails.Click += new System.EventHandler(this.buttonWorldDetails_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDownload,
            this.buttonSettings,
            this.toolStripSpace1,
            this.buttonLineup});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(992, 31);
            this.toolStripMain.TabIndex = 3;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // buttonDownload
            // 
            this.buttonDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDownload.Image = ((System.Drawing.Image)(resources.GetObject("buttonDownload.Image")));
            this.buttonDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(28, 28);
            this.buttonDownload.Text = "buttonDownload";
            this.buttonDownload.ToolTipText = "Download";
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(28, 28);
            this.buttonSettings.Text = "buttonSettings";
            this.buttonSettings.ToolTipText = "Settings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonMatches_Click);
            // 
            // toolStripSpace1
            // 
            this.toolStripSpace1.Name = "toolStripSpace1";
            this.toolStripSpace1.Size = new System.Drawing.Size(6, 31);
            // 
            // buttonLineup
            // 
            this.buttonLineup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLineup.Image = ((System.Drawing.Image)(resources.GetObject("buttonLineup.Image")));
            this.buttonLineup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLineup.Name = "buttonLineup";
            this.buttonLineup.Size = new System.Drawing.Size(28, 28);
            this.buttonLineup.Text = "buttonLineup";
            this.buttonLineup.ToolTipText = "Lineup";
            this.buttonLineup.Click += new System.EventHandler(this.buttonLineup_Click);
            // 
            // panelMainContent
            // 
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 55);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(992, 418);
            this.panelMainContent.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 473);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemDownload;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemAchievements;
        private System.Windows.Forms.ToolStripMenuItem menuItemMatches;
        private System.Windows.Forms.ToolStripMenuItem menuItemLeague;
        private System.Windows.Forms.ToolStripMenuItem menuItemEconomy;
        private System.Windows.Forms.ToolStripMenuItem menuItemTraining;
        private System.Windows.Forms.ToolStripMenuItem menuItemArena;
        private System.Windows.Forms.ToolStripMenuItem menuItemClub;
        private System.Windows.Forms.ToolStripMenuItem menuItemTopScorers;
        private System.Windows.Forms.ToolStripMenuItem menuItemWorldDetails;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton buttonSettings;
        private System.Windows.Forms.ToolStripButton buttonDownload;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.ToolStripSeparator toolStripSpace1;
        private System.Windows.Forms.ToolStripButton buttonLineup;
    }
}

