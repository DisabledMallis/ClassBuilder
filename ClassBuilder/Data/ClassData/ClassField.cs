namespace ClassBuilder.Data.ClassData {
	public class ClassField {
		string name;
		long offset;
		string type;
		public ClassField(string name, long offset, string type) {
			this.name = name;
			this.offset = offset;
			this.type = type;
		}
	}
}