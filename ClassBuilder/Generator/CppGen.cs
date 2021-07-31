using System;
using System.Collections.Generic;
using System.Globalization;
using ClassBuilder.ClassData;

namespace ClassBuilder.Generator {
	public class CppGen : AbstractGenerator {
		Dictionary<string, long> lastVirt = new Dictionary<string, long>();
		Dictionary<string, long> classSizes = new Dictionary<string, long>();
		string currentClass = "";
		bool extends = false;
		string currentExtension = "";
		public override string GenClass(NativeClass cls, List<NativeClass> classSet) {
			string ret = "";

			if(cls.ClassName == "#INCLUDES") {
				return null;
			}

			//Header guarding
			ret += "#ifndef GUARD_"+cls.ClassName+"\n";
			ret += "#define GUARD_"+cls.ClassName+"\n";

			foreach(NativeClass incCls in classSet) {
				if(incCls.ClassName == "#INCLUDES") {
					foreach(Field f in incCls.Fields) {
						ret += "#include \""+f.Name+"\"\n";
					}
				}
			}

			if(cls.Extends != null) {
				ret += "#include \"" + cls.Extends + ".h\"\n";
			}

			currentClass = cls.ClassName;
			classSizes[cls.ClassName] = 0; // New class padding
			lastVirt[cls.ClassName] = 0; // New class virt padding
			if(cls.Extends != null) { //If it extends, we have to add that size
				lastVirt[cls.ClassName] += lastVirt[cls.Extends];
				classSizes[cls.ClassName] += classSizes[cls.Extends];
			}
			ret += "struct " + cls.ClassName + (cls.Extends == null ? "" : " : public " + cls.Extends) + " {\n";
			ret += "\t/* Fields */\n";
			foreach(Field f in cls.Fields) {
				ret += GenField(f)+"\n";
			}
			ret += "\t/* Virtuals */\n";
			foreach(Virtual virt in cls.Virtuals) {
				ret += GenVirtual(virt)+"\n";
			}
			ret += "\t/* Functions */\n";
			foreach(Function func in cls.Functions) {
				ret += GenFunc(func)+"\n";
			}
			ret += "};\n";
			ret += "#endif";
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
		public override string GenFunc(Function function)
		{
			string funcName = function.Name;

			string signature = function.Signature;
			int pushed = 0;
			while(signature.StartsWith("?? ")) {
				pushed++;
				signature = signature.Substring(3);
			}

			string ret = "\tstatic inline uintptr_t holder_"+funcName+";\n";
			string parms = "";
			string callParms = "";
			Parameter thisParam = null;
			foreach(Parameter param in function.Parameters) {
				if(param.Name == "this") {
					thisParam = param;
					continue;
				}
				parms += (param.Type + " " + param.Name + ", ");
				callParms += param.Name + ", ";
			}
			parms = parms.Substring(0, parms.Length-2);
			callParms = callParms.Substring(0, callParms.Length-2);
			ret += "\tauto " + function.Convention + " " + function.Name + "(" + parms + ") -> " + function.Type + " {\n";
			ret += "\t\tif(holder_"+funcName+" == 0) {\n";
			ret += "\t\t\tholder_"+funcName+" = Mem::FindSig(\""+signature+"\");\n";
			ret += "\t\t}\n";
			ret += "\t\tif(holder_"+funcName+" == 0){\n";
			ret += "\t\t\tUtils::DebugF(\"FATAL: Sig failure for "+funcName+"\");\n";
			ret += "\t\t}\n";
			ret += "\t\tholder_"+funcName+" += -"+pushed+";\n";
			ret += "\t\t(("+function.Type+"("+function.Convention+"*)("+ (thisParam != null ? thisParam.Type+"*, " : "") + parms + "))holder_"+funcName+")(" + (thisParam != null ? "this, " : "")+callParms+");\n";
			ret += "\t};";
			return ret;
		}
		public override string GenVirtual(Virtual virt)
		{
			string ret = "";
			for(long i = lastVirt[currentClass]; i < virt.Offset; i++) {
				ret += "\tvoid virt_pad_"+i+"() {};\n";
			}
			lastVirt[currentClass] = (extends ? lastVirt[currentExtension] : 0) + virt.Offset + 1;
			string callParms = "";
			foreach(Parameter parm in virt.Parameters) {
				callParms += parm.Type+" "+parm.Name+", ";
			}
			if(callParms != "")
				callParms = callParms.Substring(0, callParms.Length-2);
			ret += "\tauto "+virt.Name+"("+callParms+") -> "+virt.Type+" {};";
			return ret;
		}
	}
}