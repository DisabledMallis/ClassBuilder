using System;
using System.Collections;
using System.Collections.Generic;

using ClassBuilder.Data.ClassData;

namespace ClassBuilder.Data {
	public class Project {
		public List<ProjectClass> Classes;
		public Project() {
			Classes = new List<ProjectClass>();
		}

		public void AddClass(ProjectClass toAdd) {
			Classes.Add(toAdd);
		}

		public ProjectClass GetClass(string name) {
			foreach(ProjectClass cls in Classes) {
				if(cls.Name == name) {
					return cls;
				}
			}
			return null;
		}

		public bool DeleteClass(string name) {
			ProjectClass toDel = null;
			foreach(ProjectClass cls in Classes) {
				if(cls.Name == name) {
					toDel = cls;
					break;
				}
			}
			if(toDel == null) {
				return false;
			}
			Classes.Remove(toDel);
			return true;
		}
	}
}