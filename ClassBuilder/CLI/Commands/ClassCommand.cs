using System;

using ClassBuilder;
using ClassBuilder.Data;
using ClassBuilder.Data.ClassData;

namespace ClassBuilder.CLI.Commands
{
	public class ClassCommand : AbstractCommand {
		public ClassCommand() : base("class") {

		}

		public override bool Execute(string label, string[] args) {
			Project proj = ProjectLoader.CurrentProject;
			if(proj == null) {
				Console.WriteLine("No project is open!");
				return false;
			}
			if(args.Length == 0 || args.Length < 2) {
				Console.WriteLine("Invalid args!");
				Console.WriteLine("class <class name> (rename/delete/extends) ...");
				return false;
			}
			ProjectClass cls = proj.GetClass(args[0]);
			if(args[1] == "rename") {
				Console.WriteLine("Renaming \""+cls.Name+"\" to "+args[2]);
				cls.Name = args[2];
				Console.WriteLine("Done!");
				return true;
			}
			if(args[1] == "delete") {
				proj.DeleteClass(cls.Name);
				Console.WriteLine("Deleted!");
				return true;
			}
			if(args[1] == "extends") {
				ProjectClass baseCls = proj.GetClass(args[2]);
				cls.SetBase(baseCls);
				Console.WriteLine("Done!");
				return true;
			}
			Console.WriteLine("Invalid arguments!");
			return false;
		}
	}
}