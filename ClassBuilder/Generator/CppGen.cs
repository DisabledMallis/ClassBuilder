using ClassBuilder.Data.ClassData;

namespace ClassBuilder.Generator {
	/// <summary>
	/// Generates C++ code from classes
	/// </summary>
	public class CppGen : ISourceGen
	{
		string HeaderguardPrefix;
		public CppGen()
		{
		}

		public string GenerateClass(ProjectClass projClass) {
			string className = projClass.Name;
			string credits = "/* Class was generated using ClassBuilder's built in C++ code generator\n"
			+ "Github: https://github.com/DisabledMallis/ClassBuilder */";
			string macroName = HeaderguardPrefix+"_"+className;
			string header = "#ifndef "+macroName+
			"#define "+macroName+"\n"+
			"struct "+className+" {";
			string fields = "\n";
			foreach(ClassField field in projClass.Fields) {
				fields += GenerateField(field)+"\n";
			}
			string footer = "};"
			+ "#endif";

			return credits+
					header+
					fields+
					footer;
		}

		//TODO: Implement
		public string GenerateField(ClassField classField) {
			return "";
		}
	}
}