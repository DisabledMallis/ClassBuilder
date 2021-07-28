namespace ClassBuilder.CLI
{
	public abstract class AbstractCommand {
		string Name;
		public AbstractCommand(string name) {
			this.Name = name;
		}

		public string GetName() {
			return Name;
		}

		public virtual bool Execute(string label, string[] args) {
			return false;
		}
	}
}