using System;
using System.Windows;
using System.Windows.Forms;

using ClassBuilder.UI;
using ClassBuilder.CLI;

namespace ClassBuilder {
	public class ClassBuilder {
		public static void Main(string[] args) {
			Console.WriteLine("Loading...");
			string cmd = "";
			while(cmd != "exit") {
				cmd = ReadCommand();
				string label;
				string[] cmd_args;
				ParseCommand(cmd, out label, out cmd_args);
				CommandRegistry.instance.DispatchRespective(label, cmd_args);
			}

		}

		public static string ReadCommand() {
			Console.Write("CB-CLI> ");
			return Console.ReadLine();
		}

		public static void ParseCommand(string cmd, out string label, out string[] args) {
			string[] tokens = cmd.Split(' ');
			label = tokens[0];
			string[] newArgs = new string[tokens.Length-1];
			for(int i = 0; i < newArgs.Length; i++) {
				newArgs[i] = tokens[i+1];
			}
			args = newArgs;
		}
	}
}