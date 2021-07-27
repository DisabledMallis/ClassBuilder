using System;
using System.Windows;
using System.Windows.Forms;

namespace ClassBuilder.UI {
	public class HostWindow : Form {

		public static HostWindow instance = new HostWindow();

		private HostWindow() {
			this.Text = "ClassBuilder";

			this.IsMdiContainer = true;
					ToolStripMenuItem newProject = new ToolStripMenuItem();
					newProject.Name = "newProject";
					newProject.Text = "New";
					ToolStripMenuItem openProject = new ToolStripMenuItem();
					openProject.Name = "openProject";
					openProject.Text = "Open";
				ToolStripMenuItem fileDropdown = new ToolStripMenuItem();
				fileDropdown.DropDownItems.AddRange(new ToolStripItem[] {
					newProject,
					openProject
				});
				fileDropdown.Name = "fileDropdown";
				fileDropdown.Text = "File";
			MenuStrip menu = new MenuStrip();
			menu.Items.AddRange(new ToolStripItem[] {
				fileDropdown
			});
			menu.Name = "menu";
			menu.Text = "Menu";
			this.Controls.Add(menu);
			this.MainMenuStrip = menu;
			
			ClassManager cm = new ClassManager();
			cm.MdiParent = this;
			cm.Show();
		}
	}
}