using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HM.Resources.CustomClasses {
    public static class TextPrompt {
        public static string ShowDialog(string text, string currentValue, string promptName) {
            System.Windows.Forms.Form prompt = new System.Windows.Forms.Form();
            prompt.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            prompt.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            prompt.ClientSize = new System.Drawing.Size(284, 67);
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;
            prompt.Text = promptName;
            prompt.FormBorderStyle = FormBorderStyle.FixedSingle;
            prompt.Name = "dlgPrompt";
            prompt.Font = new Font("Calibri", 9, FontStyle.Regular);
            prompt.StartPosition = FormStartPosition.CenterParent;

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label() { Location = new System.Drawing.Point(12, 5), Size = new System.Drawing.Size(185, 23), Text = text, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(12, 34), Size = new System.Drawing.Size(185, 23), Text = currentValue };
            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Location = new System.Drawing.Point(217, 5), Size = new System.Drawing.Size(55, 23), Text = "OK" };
            System.Windows.Forms.Button cancel = new System.Windows.Forms.Button() { Location = new System.Drawing.Point(217, 34), Size = new System.Drawing.Size(55, 23), Text = "Cancel" };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { textBox.Text = string.Empty;  prompt.Close(); };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();

            return textBox.Text;
        }

        public static string ShowDialog(string text, string caption) {
            return (ShowDialog(text, caption, "Prompt"));
        }
    }
}
