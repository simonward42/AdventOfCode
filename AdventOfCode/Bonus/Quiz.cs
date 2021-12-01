
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode {
	public class Quiz : IDisposable {

		private StreamReader _CurrentScript;
		private IEnumerable<string> _ScriptsList;
		private const string _ScriptDirPath = @"C:\Users\SWARD\Downloads\scripts_tng";

		private int _Count = 0;

		public Quiz() {
			_ScriptsList = Directory.EnumerateFiles(_ScriptDirPath, "*.*");

		}

		public void Dispose() {
		}

		/// <summary>
		/// Search for phrase in all TNG scripts! Cos why not.
		/// </summary>
		/// <returns>Number of instances of the phrase found.</returns>
		public int FindInTng(string searchString) {

			foreach (var script in _ScriptsList) {
				_CurrentScript = new StreamReader(script);

				_Count += FindOccurrencesOfPhraseInCurrentScript(searchString);

				_CurrentScript.Close();
			}


			return _Count;
		}

		private int FindOccurrencesOfPhraseInCurrentScript(string searchString) {

			var scriptText = _CurrentScript.ReadToEnd();
			scriptText = Regex.Replace(scriptText, ",", " ");
			scriptText = Regex.Replace(scriptText, @"\n", " ");

			scriptText = Regex.Replace(scriptText, @"\s\s+", " ");
			var searchStringOccurrences = Regex.Matches(scriptText, searchString, RegexOptions.IgnoreCase).Count;

			return searchStringOccurrences;
		}


	}
}
