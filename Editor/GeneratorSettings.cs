using UnityEditor;

namespace DoxygenGenerator
{
    public static class GeneratorSettings
    {
        public static string doxygenPath
        {
            get => EditorPrefs.GetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(doxygenPath)}", string.Empty);
            set => EditorPrefs.SetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(doxygenPath)}", value);
        }

        public static string inputDirectory
        {
            get => EditorPrefs.GetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(inputDirectory)}", string.Empty);
            set => EditorPrefs.SetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(inputDirectory)}", value);
        }

        public static string outputDirectory
        {
            get => EditorPrefs.GetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(outputDirectory)}", string.Empty);
            set => EditorPrefs.SetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(outputDirectory)}", value);
        }

        public static string project
        {
            get => EditorPrefs.GetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(project)}", string.Empty);
            set => EditorPrefs.SetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(project)}", value);
        }

        public static string synopsis
        {
            get => EditorPrefs.GetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(synopsis)}", string.Empty);
            set => EditorPrefs.SetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(synopsis)}", value);
        }

        public static string version
        {
            get => EditorPrefs.GetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(version)}", string.Empty);
            set => EditorPrefs.SetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(version)}", value);
        }

        public static string readme
        {
            get => EditorPrefs.GetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(readme)}", string.Empty);
            set => EditorPrefs.SetString($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(readme)}", value);
        }

        public static bool graph
        {
            get => EditorPrefs.GetBool($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(graph)}", false);
            set => EditorPrefs.SetBool($"{nameof(DoxygenGenerator)}.{nameof(GeneratorSettings)}.{nameof(graph)}", value);
        }
    }
}
