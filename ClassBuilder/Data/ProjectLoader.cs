using Newtonsoft.Json;
using System.IO;

namespace ClassBuilder.Data
{
	public class ProjectLoader {

		public static Project CurrentProject;

		public static Project ReadFile(string filename) {
			string json = File.ReadAllText(filename);
			CurrentProject = JsonConvert.DeserializeObject<Project>(json);
			return CurrentProject;
		}

		public static void SaveFile(Project toSave, string filename) {
			string json = JsonConvert.SerializeObject(toSave, Formatting.Indented);
			File.WriteAllText(filename, json);
		}
	}
}