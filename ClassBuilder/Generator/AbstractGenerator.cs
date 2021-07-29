using System.Collections.Generic;
using ClassBuilder.ClassData;

namespace ClassBuilder.Generator {
	public abstract class AbstractGenerator {
		public virtual string GenClass(NativeClass cls, List<NativeClass> classSet) {
			string ret = "";
			ret += "CLASS: " + cls.ClassName + (cls.Extends == null ? "" : " EXTENDS: " + cls.Extends) + "\n";
			foreach(Field f in cls.Fields) {
				ret += GenField(f)+"\n";
			}
			return ret;
		}
		public virtual string GenField(Field field) {
			return "\tFIELD: " + field.Name + " AT: " + field.Offset + " TYPE: " + field.Type.TypeName + " SIZE: " + field.Type.TypeSize;
		}
	}
}