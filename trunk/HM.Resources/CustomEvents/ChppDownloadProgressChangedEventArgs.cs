using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Resources.CustomEvents
{
    public class ChppDownloadProgressChangedEventArgs : EventArgs
    {
        #region Properties

        public string FileName { get; set; }
        public bool Successful { get; set; }
        public int FilesDownloaded { get; set; }
        public int TotalFilesToDownload { get; set; }
        public bool DownloadFinished { get; set; }

        #endregion

        #region Methods

        public ChppDownloadProgressChangedEventArgs(string FileName, bool Successful, int FilesDownloaded, int TotalFilesToDownload, bool DownloadFinished)
        {
            this.FileName = FileName;
            this.Successful = Successful;
            this.FilesDownloaded = FilesDownloaded;
            this.TotalFilesToDownload = TotalFilesToDownload;
            this.DownloadFinished = DownloadFinished;
        }

        #endregion
    }

    public delegate void ChppDownloadProgressChangedEventHandler(ChppDownloadProgressChangedEventArgs eventArgs);
}
