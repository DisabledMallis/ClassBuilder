using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

using ClassBuilder.Data;
using ClassBuilder.Data.ClassData;

namespace ClassBuilder.UI
{
	public partial class HostWindow {
		public void OpenClassEditor(string className) {
			TabControl tabControl = new TabControl();
			TabPage editPage = new TabPage();
			editPage.Text = "Edit";
			TabPage sourcePage = new TabPage();
			sourcePage.Text = "Source";
			tabControl.TabPages.Add(editPage);
			tabControl.TabPages.Add(sourcePage);

			tabControl.Location = new Point(nextX, 0);
			tabControl.Size = contentPanel.ClientSize;
			tabControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

			contentPanel.Controls.Add(tabControl);
		}
	}
}