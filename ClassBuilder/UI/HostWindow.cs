using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace ClassBuilder.UI
{
	public class HostWindow : Form {

		public static HostWindow instance = new HostWindow();

		private HostWindow() : base() {
			this.Text = "ClassBuilder";
			this.MainMenuStrip = CreateMenuBar();
			this.MainMenuStrip.Dock = DockStyle.Top;
			this.Controls.Add(this.MainMenuStrip);

			Panel contentPanel = new Panel();
			contentPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			int menuHeight = this.MainMenuStrip.Height;
			contentPanel.Location = new Point(0, menuHeight);
			contentPanel.Size = new Size(contentPanel.Width, this.Height-menuHeight);
			contentPanel.Controls.Add(CreateClassList());

			this.Controls.Add(contentPanel);
		}

		private MenuStrip CreateMenuBar() {
			MenuStrip menu = new MenuStrip();
			ToolStripMenuItem file = CreateFileTab();
			menu.Items.AddRange(new ToolStripMenuItem[] {
				file
			});
			return menu;
		}

		private ToolStripMenuItem CreateFileTab() {

			ToolStripMenuItem newProj = new ToolStripMenuItem();
			newProj.Text = "New";

			ToolStripMenuItem openProj = new ToolStripMenuItem();
			openProj.Text = "Open";

			ToolStripMenuItem file = new ToolStripMenuItem();
			file.DropDownItems.AddRange(new ToolStripMenuItem[] {
				newProj,
				openProj
			});

			file.Text = "File";

			return file;
		}

		private TreeView CreateClassList() {
			TreeView classTree = new TreeView();

			classTree.Dock = DockStyle.Left;
			classTree.Nodes.Add(new TreeNode("Test"));

			return classTree;
		}
	}
}