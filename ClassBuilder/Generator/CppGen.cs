using System;
using System.Collections.Generic;
using System.Globalization;
using ClassBuilder.ClassData;

namespace ClassBuilder.Generator {
	public class CppGen : AbstractGenerator {
		Dictionary<string, long> classSizes = new Dictionary<string, long>();
		string currentClass = "";
		bool extends = false;
		string currentExtension = "";
		public override string GenClass(NativeClass cls, List<NativeClass> classSet) {
			string ret = "";
			currentClass = cls.ClassName;
			classSizes[cls.ClassName] = 0; // New class padding
			if(cls.Extends != null) { //If it extends, we have to add that size
				classSizes[cls.ClassName] += classSizes[cls.Extends];
			}
			ret += "struct " + cls.ClassName + (cls.Extends == null ? "" : " : public " + cls.Extends) + " {\n";
			foreach(Field f in cls.Fields) {
				ret += GenField(f)+"\n";
			}
			ret += "};";
			return ret;
		}
		public override string GenField(Field field) {
			string ret = "";
			int parsedOffset = Convert.ToInt32(field.Offset, 16);
			ret += "\tchar padding_"+parsedOffset+"["+(parsedOffset-classSizes[currentClass])+"];\n";
			classSizes[currentClass] = (extends ? classSizes[currentExtension] : 0) + parsedOffset+field.Type.TypeSize;
			ret += "\t"+field.Type.TypeName+" "+field.Name+";";
			return ret;
		}
	}
}