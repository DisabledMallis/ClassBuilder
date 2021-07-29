using System;
using System.Collections.Generic;
using System.Globalization;
using ClassBuilder.ClassData;

namespace ClassBuilder.Generator {
	public class CppGen : AbstractGenerator {
		long currentPad = 0;
		public override string GenClass(NativeClass cls, List<NativeClass> classSet) {
			string ret = "";
			if(cls.Extends == null) {
				currentPad = 0; // Its a new class, so we want to reset the padding
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
			ret += "\tchar padding_"+parsedOffset+"["+(parsedOffset-currentPad)+"]\n";
			currentPad = parsedOffset+field.Type.TypeSize;
			ret += "\t"+field.Type.TypeName+" "+field.Name+";";
			return ret;
		}
	}
}