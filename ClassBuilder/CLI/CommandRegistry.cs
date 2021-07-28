using System;
using System.Collections;
using System.Collections.Generic;

using ClassBuilder.CLI.Commands;

namespace ClassBuilder.CLI {
	public class CommandRegistry {
		public static CommandRegistry instance = new CommandRegistry();
		List<AbstractCommand> commands;
		public CommandRegistry() {
			commands = new List<AbstractCommand>();
			
			commands.Add(new ListCommand());
			commands.Add(new NewCommand());
			commands.Add(new OpenCommand());
			commands.Add(new SaveCommand());
		}

		public bool DispatchRespective(string label, string[] args) {
			foreach(AbstractCommand cmd in commands) {
				if(cmd.GetName() == label) {
					return cmd.Execute(label, args);
				}
			}
			Console.WriteLine("Unknown command!");
			return false;
		}
	}
}