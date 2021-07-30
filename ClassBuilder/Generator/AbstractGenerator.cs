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
			foreach(Function func in cls.Functions) {
				ret += GenFunc(func)+"\n";
			}
			foreach(Virtual virt in cls.Virtuals) {
				ret += GenVirtual(virt)+"\n";
			}
			return ret;
		}
		public virtual string GenField(Field field) {
			return "\tFIELD: " + field.Name + " AT: " + field.Offset + " TYPE: " + field.Type.TypeName + " SIZE: " + field.Type.TypeSize;
		}
		public virtual string GenFunc(Function function) {
			return "\tFUNC: " + function.Name + " TYPE: " + function.Type + " CONVENTION: " + function.Convention + " SIGNATURE: " + function.Signature;
		}
		public virtual string GenVirtual(Virtual virt) {
			return "\tVIRT: " + virt.Name;
		}
	}
}