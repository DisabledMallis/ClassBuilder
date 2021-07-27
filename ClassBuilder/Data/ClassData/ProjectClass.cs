using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassBuilder.Data.ClassData {
	public class ProjectClass {
		public ProjectClass BaseClass;
		public string Name;
		public List<ClassField> Fields;
		public ProjectClass(string name) {
			this.Name = name;
			this.Fields = new List<ClassField>();
		}

		public void AddField(ClassField toAdd) {
			this.Fields.Add(toAdd);
		}
	}
}