using System;
using ClassBuilder.CLI;
using ClassBuilder.Data;
using ClassBuilder.Data.ClassData;

namespace ClassBuilder.CLI.Commands
{
	public class NewCommand : AbstractCommand {
		public NewCommand() : base("new") {

		}

		public override bool Execute(string label, string[] args) {
			if(args.Length == 0) {
				Console.WriteLine("Missing type to create:");
				Console.WriteLine("- project");
				Console.WriteLine("- class");
				Console.WriteLine("- field");
				return false;
			}
			if(args[0] == "project") {
				ProjectLoader.CurrentProject = new Project();
				Console.WriteLine("Created new project");
				return true;
			}
			if(args[0] == "class") {
				if(ProjectLoader.CurrentProject == null) {
					Console.WriteLine("No project to add a class to!");
					return false;
				}
				ProjectClass newClass = new ProjectClass("Unnamed");
				Console.Write("Created new class");
				if(args.Length == 2) {
					string className = args[1];
					newClass.Name = className;
					Console.Write(" with name "+className);
				}
				Console.WriteLine();
				ProjectLoader.CurrentProject.AddClass(newClass);
				return true;
			}
			return false;
		}
	}
}