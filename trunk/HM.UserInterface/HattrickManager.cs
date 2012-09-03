using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.UserInterface {
    static class HattrickManager {
        [STAThread]
        static void Main(string[] args) {
            if ((args != null) && (args.Length > 0)) {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(args[0]);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(args[0]);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}