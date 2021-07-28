using System;
using ClassBuilder.CLI;
using ClassBuilder.Data;

namespace ClassBuilder.CLI.Commands
{
	public class SaveCommand : AbstractCommand {
		public SaveCommand() : base("save") {

		}

		public override bool Execute(string label, string[] args) {
			if(args.Length == 0) {
				Console.WriteLine("No path provided!");
				return false;
			}
			if(ProjectLoader.CurrentProject == null) {
				Console.WriteLine("No open project to save.");
				return false;
			}
			string path = args[0];
			ProjectLoader.SaveFile(ProjectLoader.CurrentProject, path);
			Console.WriteLine("Saved project at "+path);
			return true;
		}
	}
}