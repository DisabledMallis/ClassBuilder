using System;
using System.Windows;
using System.Windows.Forms;

using ClassBuilder.UI;

namespace ClassBuilder {
	public class ClassBuilder {
		public static void Main(string[] args) {
			Console.WriteLine("Loading...");

			Application.Run(HostWindow.instance);
		}
	}
}