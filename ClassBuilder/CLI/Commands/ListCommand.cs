using System;
using System.Collections;
using System.Collections.Generic;

using ClassBuilder.CLI;
using ClassBuilder.Data;
using ClassBuilder.Data.ClassData;

namespace ClassBuilder.CLI.Commands
{
	public class ListCommand : AbstractCommand {
		public ListCommand() : base("list") {
			
		}

		public override bool Execute(string label, string[] args) {
			Project proj = ProjectLoader.CurrentProject;
			if(proj == null) {
				Console.WriteLine("No project is open!");
				return false;
			}

			foreach(ProjectClass cls in proj.Classes) {
				PrintClasses(cls, 0);
			}
			return true;
		}

		private void PrintClasses(ProjectClass current, int level) {
			for(int i = 0; i < level; i++) {
				Console.Write("\t");
			}
			Console.WriteLine(current.Name);

			if(current.AbstractedClasses != null) {
				List<ProjectClass> abstracted = current.AbstractedClasses;
				foreach(ProjectClass cls in abstracted) {
					PrintClasses(cls, level+1);
				}
			}
		}
	}
}