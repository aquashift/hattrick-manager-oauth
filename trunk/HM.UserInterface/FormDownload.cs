﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HMEntities = HM.Entities.HattrickManager;
using HM.Core;
using HM.Resources.CustomEvents;
using System.Threading;
using HM.Resources.Constants;

namespace HM.UserInterface {
    public partial class FormDownload : FormBase {
        #region Delegates

        public delegate void UpdateDownloadStatusCallback(ChppDownloadProgressChangedEventArgs eventArgs);

        #endregion

        #region Properties

        HMEntities.UserProfiles.User currentUser;
        private DownloadManager downloadManager;

        #endregion

        #region Events

        public FormDownload(HMEntities.UserProfiles.User currentUser) {
            InitializeComponent();
            this.currentUser = currentUser;
            this.downloadManager = new DownloadManager(currentUser);
            downloadManager.ChppDownloadProgressChanged += new ChppDownloadProgressChangedEventHandler(OnChppDownloadProgressChanged);
        }

        protected virtual void OnChppDownloadProgressChanged(ChppDownloadProgressChangedEventArgs eventArgs) {
            UpdateDownloadStatus(eventArgs);
        }

        private void buttonDownload_Click(object sender, EventArgs e) {
            this.UseWaitCursor = true;
            this.buttonClose.Enabled = false;
            this.buttonDownload.Enabled = false;
            this.checkBoxDownloadExistingFiles.Enabled = false;
            this.FormClosing += FormDownload_FormClosing;

            Thread downloadThread = new Thread(StartDownload);

            downloadThread.Start();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FormDownload_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
        }

        #endregion

        #region Methods

        private void StartDownload() {
            downloadManager.Download(checkBoxDownloadExistingFiles.Checked);
        }

        private void AddDownloadItem(string downloadName, bool complete) {
            dataGridViewDownload.RowCount++;

            dataGridViewDownload.Rows[dataGridViewDownload.RowCount - 1].Cells[0].Value = downloadName;

            if (complete) {
                dataGridViewDownload.Rows[dataGridViewDownload.RowCount - 1].Cells[1].Value = 100;
            } else {
                dataGridViewDownload.Rows[dataGridViewDownload.RowCount - 1].Cells[1].Value = 0;
            }

            if (dataGridViewDownload.RowCount > 1) {
                dataGridViewDownload.Rows[dataGridViewDownload.RowCount - 2].Cells[1].Value = 100;
            }

            dataGridViewDownload.FirstDisplayedScrollingRowIndex = dataGridViewDownload.RowCount - 1;

            dataGridViewDownload.ClearSelection();
        }

        private void UpdateDownloadStatus(ChppDownloadProgressChangedEventArgs eventArgs) {
            try {
                if (this.InvokeRequired) {
                    this.Invoke(new UpdateDownloadStatusCallback(UpdateDownloadStatus), eventArgs);
                } else {
                    progressBarDownload.Maximum = eventArgs.TotalFilesToDownload;
                    progressBarDownload.Value = eventArgs.FilesDownloaded;
                    AddDownloadItem(resourceManager.GetString(eventArgs.FileName), eventArgs.DownloadFinished);
                }

                if (eventArgs.DownloadFinished) {
                    this.UseWaitCursor = false;
                    this.buttonClose.Enabled = true;
                    this.buttonDownload.Enabled = true;
                    this.checkBoxDownloadExistingFiles.Enabled = true;
                    this.FormClosing -= FormDownload_FormClosing;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Fills the form's controls with the selected language
        /// </summary>
        protected override void PopulateLanguage() {
            this.Text = resourceManager.GetString(Localization.ui_download_FormText);
            this.buttonDownload.Text = resourceManager.GetString(Localization.ui_download_buttonDownload);
            this.buttonClose.Text = resourceManager.GetString(Localization.ui_download_buttonClose);
            this.checkBoxDownloadExistingFiles.Text = resourceManager.GetString(Localization.ui_download_checkBoxDownloadExistingFiles);
            this.groupBoxDownload.Text = resourceManager.GetString(Localization.ui_download_groupBoxDownload);
        }

        #endregion
    }
}