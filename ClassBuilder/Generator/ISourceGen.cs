using ClassBuilder.Project.ClassData;

namespace ClassBuilder.Generator {
	public interface ISourceGen {
		string GenerateClass(ProjectClass projClass);
		string GenerateField(ClassField classField);
	}
}