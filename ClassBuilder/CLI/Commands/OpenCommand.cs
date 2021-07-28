using System;
using ClassBuilder.CLI;
using ClassBuilder.Data;

namespace ClassBuilder.CLI.Commands
{
	public class OpenCommand : AbstractCommand {
		public OpenCommand() : base("open") {

		}

		public override bool Execute(string label, string[] args) {
			if(args.Length == 0) {
				Console.WriteLine("No path provided!");
				return false;
			}
			string path = args[0];
			ProjectLoader.ReadFile(path);
			Console.WriteLine("Opened project at "+path);
			return true;
		}
	}
}