using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

using ClassBuilder.Data;
using ClassBuilder.Data.ClassData;

namespace ClassBuilder.UI
{
	public partial class HostWindow : Form {
		string projectLocation = "";
		Project currentProject;
		Panel contentPanel = new Panel();
		public static HostWindow instance = new HostWindow();
		int nextX = 0;
		int nextY = 0;

		private HostWindow() : base() {
			this.Text = "ClassBuilder";
			this.MainMenuStrip = CreateMenuBar();
			this.MainMenuStrip.Dock = DockStyle.Top;
			this.Controls.Add(this.MainMenuStrip);
		}

		private void NewProject() {
			OpenProject(new Project());
		}
		private void OpenProject(Project proj) {
			this.currentProject = proj;

			contentPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			contentPanel.Location = new Point(0, nextY);
			contentPanel.Size = new Size(contentPanel.Width, this.Height-nextY);
			contentPanel.Controls.Add(CreateClassList());

			this.Controls.Add(contentPanel);
		}

		private MenuStrip CreateMenuBar() {
			MenuStrip menu = new MenuStrip();
			ToolStripMenuItem file = CreateFileTab();
			menu.Items.AddRange(new ToolStripMenuItem[] {
				file
			});
			nextY += menu.Height;
			return menu;
		}

		private ToolStripMenuItem CreateFileTab() {

			ToolStripMenuItem newProj = new ToolStripMenuItem();
			newProj.Text = "New";
			newProj.Click += (object sender, EventArgs e)=> {
				this.NewProject();
			};

			ToolStripMenuItem openProj = new ToolStripMenuItem();
			openProj.Text = "Open";

			ToolStripMenuItem saveProj = new ToolStripMenuItem();
			saveProj.Text = "Save";

			ToolStripMenuItem saveAsProj = new ToolStripMenuItem();
			saveAsProj.Text = "Save as";

			ToolStripMenuItem file = new ToolStripMenuItem();
			file.DropDownItems.AddRange(new ToolStripMenuItem[] {
				newProj,
				openProj,
				saveProj,
				saveAsProj
			});

			file.Text = "File";

			return file;
		}

		private TreeNode NewClassAndUI() {
			ProjectClass cls = new ProjectClass("Unnamed");
			currentProject.AddClass(cls);
			TreeNode node = new TreeNode(cls.Name);

			ContextMenu modClassCtx = new ContextMenu();
			modClassCtx.MenuItems.Add(new MenuItem("Rename", (object sender, EventArgs e)=>{
				node.BeginEdit();
			}));
			modClassCtx.MenuItems.Add(new MenuItem("Delete", (object sender, EventArgs e)=>{
				DialogResult res = MessageBox.Show("Deleting this class will also delete any derivative classes. This action CANNOT be undone!", "Are you sure?", MessageBoxButtons.YesNo);
				if(res == DialogResult.Yes) {
					string className = node.Text;
					node.TreeView.Nodes.Remove(node);
					if(!currentProject.DeleteClass(className)) {
						MessageBox.Show("Failed to delete class");
					}
				}
			}));
			node.ContextMenu = modClassCtx;

			return node;
		}

		private TreeView CreateClassList() {
			TreeView classTree = new TreeView();

			classTree.LabelEdit = true;

			ContextMenu classViewCtx = new ContextMenu();
			classViewCtx.MenuItems.Add(new MenuItem("New Class", (object sender, EventArgs e)=>{
				classTree.Nodes.Add(NewClassAndUI());
			}));
			classTree.AfterLabelEdit += (object sender, NodeLabelEditEventArgs e)=>{
				string oldName = e.Node.Text;
				currentProject.GetClass(oldName).Name = e.Label;
			};
			classTree.NodeMouseDoubleClick += (object sender, TreeNodeMouseClickEventArgs e)=>{
				string name = e.Node.Text;
				OpenClassEditor(name);
			};

			classTree.Dock = DockStyle.Left;
			classTree.ContextMenu = classViewCtx;

			this.nextX += classTree.Width;

			return classTree;
		}
	}
}