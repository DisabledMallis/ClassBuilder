using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassBuilder.Data.ClassData {
	public class ProjectClass {
		public List<ProjectClass> Abstractions;
		public string Name;
		public List<ClassField> Fields;
		public ProjectClass(string name) {
			this.Name = name;
			this.Fields = new List<ClassField>();
			this.Abstractions = new List<ProjectClass>();
		}

		public void AddField(ClassField toAdd) {
			this.Fields.Add(toAdd);
		}

		public List<ProjectClass> GetAbstractions() {
			return Abstractions;
		}

		public void AddAbstraction(ProjectClass abstracted) {
			this.Abstractions.Add(abstracted);
		}

		public void RemoveAbstraction(ProjectClass abstracted) {
			this.Abstractions.Remove(abstracted);
		}

		public void SetBase(ProjectClass newBase) {
			newBase.AddAbstraction(this);
			ProjectLoader.CurrentProject.DeleteClass(this.Name);
		}
	}
}