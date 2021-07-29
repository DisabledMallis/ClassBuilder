using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;

using ClassBuilder.ClassData;
using ClassBuilder.Generator;

namespace ClassBuilder {
	public class ClassBuilder {
		public static void Main(string[] args) {
			string json = File.ReadAllText("test.json");
			List<NativeClass> nc = NativeClass.FromJson(json);
			CppGen gen = new CppGen();
			foreach(NativeClass cls in nc) {
				Console.WriteLine(gen.GenClass(cls, nc));
			}
		}
	}
}