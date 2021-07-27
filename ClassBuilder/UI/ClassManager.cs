using System;
using System.Windows.Forms;

namespace ClassBuilder.UI
{
	public class ClassManager : Form
	{
		public ClassManager()
		{
			this.MdiParent = HostWindow.instance;
		}
	}
}