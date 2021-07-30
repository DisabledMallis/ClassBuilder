using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

using ClassBuilder.ClassData;
using ClassBuilder.Generator;

namespace ClassBuilder {
	public class ClassBuilder {
		public static void Main(string[] args) {
			bool dGen = false;
			AbstractGenerator gen = null;
			bool dProj = false;
			string projPath = "";
			bool dOut = false;
			string outPath = "";
			foreach(string arg in args) {
				if(arg == "--proj") {
					dProj = true;
					continue;
				}
				if(dProj) {
					projPath = arg;
					dProj = false;
					continue;
				}

				if(arg == "--gen") {
					dGen = true;
					continue;
				}
				if(dGen) {
					string genType = arg;
					Type type = null;
					foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
					{
						foreach (Type t in a.GetTypes())
						{
							if(t.Name == genType) {
								type = t;
							}
						}
					}
					if(type == null) {
						Console.WriteLine("Couldn't find type \"{0}\"", genType);
					}
					if(!type.IsSubclassOf(typeof(AbstractGenerator))) {
						Console.WriteLine(genType+" doesn't associate with AbstractGenerator");
					}
					gen = (AbstractGenerator)Activator.CreateInstance(type);
					dGen = false;
					continue;
				}

				if(arg == "--output") {
					dOut = true;
					continue;
				}
				if(dOut) {
					outPath = arg;
					dOut = false;
					continue;
				}
			}
			string json = File.ReadAllText(projPath);
			List<NativeClass> nc = NativeClass.FromJson(json);
			if(!Directory.Exists(outPath)) {
				Directory.CreateDirectory(outPath);
			}
			foreach(NativeClass cls in nc) {
				string source = gen.GenClass(cls, nc);
				if(source == null) {
					continue;
				}
				if(outPath == "") {
					Console.WriteLine(source);
				} else {
					File.WriteAllText(outPath+"/"+cls.ClassName+".h",source);
				}
			}
		}
	}
}