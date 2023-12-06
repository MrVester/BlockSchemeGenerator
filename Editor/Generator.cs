using System.IO;
using System.Text;
using System.Threading;

using Debug = UnityEngine.Debug;

namespace DoxygenGenerator
{
    public static class Generator
    {
        private const string filesPath = "Packages/com.CaseyDeCoder.doxygengenerator/Editor/Files~";

        public static Thread GenerateAsync()
        {
            // Get settings (I find it easier to read this way)
            var doxygenPath = GeneratorSettings.doxygenPath;
            var inputDirectory = GeneratorSettings.inputDirectory;
            var outputDirectory = GeneratorSettings.outputDirectory;
            var readme = GeneratorSettings.readme;
            var project = GeneratorSettings.project;
            var synopsis = GeneratorSettings.synopsis;
            var version = GeneratorSettings.version;
            var graph = GeneratorSettings.graph;


            // Add the readme to the input directory
            var readmeSource = (!string.IsNullOrEmpty(readme)) ? $"{readme}" : null;
            var readmeDestination = $"{outputDirectory}/README.md";
            if (!string.IsNullOrEmpty(readme))
            {
                // Copy the readme to the output directory
                File.Copy(readmeSource, readmeDestination, true);
            }

            // Add the Doxyfile
            var doxyFileSource = $"{filesPath}/Doxyfile";
            var doxyFileDestination = $"{outputDirectory}/Doxyfile";
            File.Copy(doxyFileSource, doxyFileDestination, true);
            
            // Add doxygen-awesome
            Directory.CreateDirectory($"{outputDirectory}/html");
            Directory.CreateDirectory($"{outputDirectory}/html/doxygen-custom");

            var doxygenAwesomeSource = $"{filesPath}/doxygen-awesome.css";
            var doxygenAwesomeDestination = $"{outputDirectory}/html/doxygen-awesome.css";
            File.Copy(doxygenAwesomeSource, doxygenAwesomeDestination, true);

            var doxygenAwesomeSidebarOnlySource = $"{filesPath}/doxygen-awesome-sidebar-only.css";
            var doxygenAwesomeSidebarOnlyDestination = $"{outputDirectory}/html/doxygen-awesome-sidebar-only.css";
            File.Copy(doxygenAwesomeSidebarOnlySource, doxygenAwesomeSidebarOnlyDestination, true);
			
			var doxygenAwesomeSidebarOnlyDarkTogglerSource = $"{filesPath}/doxygen-awesome-sidebar-only-darkmode-toggle.css";
            var doxygenAwesomeSidebarOnlyDarkTogglerDestination = $"{outputDirectory}/html/doxygen-awesome-sidebar-only-darkmode-toggle.css";
            File.Copy(doxygenAwesomeSidebarOnlyDarkTogglerSource, doxygenAwesomeSidebarOnlyDarkTogglerDestination, true);
			
			var customSource = $"{filesPath}/doxygen-custom/custom.css";
            var customDestination = $"{outputDirectory}/html/doxygen-custom/custom.css";
            File.Copy(customSource, customDestination, true);
			
			var customAltSource = $"{filesPath}/doxygen-custom/custom-alternative.css";
            var customAltDestination = $"{outputDirectory}/html/doxygen-custom/custom-alternative.css";
            File.Copy(customAltSource, customAltDestination, true);
			
			// Extra Files
			var darkModeTogglerJS = $"{filesPath}/doxygen-awesome-darkmode-toggle.js";
            var darkModeTogglerJSDestination = $"{outputDirectory}/html/doxygen-awesome-darkmode-toggle.js";
            File.Copy(darkModeTogglerJS, darkModeTogglerJSDestination, true);
			
			var fragmentCopyButtonJS = $"{filesPath}/doxygen-awesome-fragment-copy-button.js";
            var fragmentCopyButtonJSDestination = $"{outputDirectory}/html/doxygen-awesome-fragment-copy-button.js";
            File.Copy(fragmentCopyButtonJS, fragmentCopyButtonJSDestination, true);
			
			var paragraphLinkJS = $"{filesPath}/doxygen-awesome-paragraph-link.js";
            var paragraphLinkJSDestination = $"{outputDirectory}/html/doxygen-awesome-paragraph-link.js";
            File.Copy(paragraphLinkJS, paragraphLinkJSDestination, true);
			
			var toggleAltThemeJS = $"{filesPath}/doxygen-custom/toggle-alternative-theme.js";
            var toggleAltThemeJSDestination = $"{outputDirectory}/html/doxygen-custom/toggle-alternative-theme.js";
            File.Copy(toggleAltThemeJS, toggleAltThemeJSDestination, true);
			
			var tocJS = $"{filesPath}/doxygen-awesome-interactive-toc.js";
            var tocJSDestination = $"{outputDirectory}/html/doxygen-awesome-interactive-toc.js";
            File.Copy(tocJS, tocJSDestination, true);
			
			var tabsJS = $"{filesPath}/doxygen-awesome-tabs.js";
            var tabsJSDestination = $"{outputDirectory}/html/doxygen-awesome-tabs.js";
            File.Copy(tabsJS, tabsJSDestination, true);
			
			// Custom Header
			var customHeaderSource = $"{filesPath}/doxygen-custom/header.html";
            var customHeaderDestination = $"{outputDirectory}/html/doxygen-custom/header.html";
            File.Copy(customHeaderSource, customHeaderDestination, true);

            // Update Doxyfile parameters
            var doxyFileText = File.ReadAllText(doxyFileDestination);
            var doxyFileStringBuilder = new StringBuilder(doxyFileText);

            doxyFileStringBuilder = doxyFileStringBuilder.Replace("PROJECT_NAME           =", $"PROJECT_NAME           = \"{project}\"");
            doxyFileStringBuilder = doxyFileStringBuilder.Replace("PROJECT_BRIEF          =", $"PROJECT_BRIEF          = \"{synopsis}\"");
            doxyFileStringBuilder = doxyFileStringBuilder.Replace("HTML_HEADER            =", $"HTML_HEADER            = \"{customHeaderDestination}\"");
            doxyFileStringBuilder = doxyFileStringBuilder.Replace("PROJECT_NUMBER         =", $"PROJECT_NUMBER         = {version}");
            if (!string.IsNullOrEmpty(readme))
            {
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("USE_MDFILE_AS_MAINPAGE =", $"USE_MDFILE_AS_MAINPAGE = \"{readmeDestination}\"");
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("INPUT                  =", $"INPUT                  = \"{inputDirectory}\" \"{readmeDestination}\"");
            }
            else
            {
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("USE_MDFILE_AS_MAINPAGE =", $"USE_MDFILE_AS_MAINPAGE = ");
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("INPUT                  =", $"INPUT                  = \"{inputDirectory}\"");
            }
            doxyFileStringBuilder = doxyFileStringBuilder.Replace("OUTPUT_DIRECTORY       =", $"OUTPUT_DIRECTORY       = \"{outputDirectory}\"");
            doxyFileStringBuilder = doxyFileStringBuilder.Replace("HTML_EXTRA_STYLESHEET  =", $"HTML_EXTRA_STYLESHEET  = \"{doxygenAwesomeDestination}\" \"{customDestination}\" \"{doxygenAwesomeSidebarOnlyDestination}\" \"{doxygenAwesomeSidebarOnlyDarkTogglerDestination}\" \"{customAltDestination}\"");
            doxyFileStringBuilder = doxyFileStringBuilder.Replace("HTML_EXTRA_FILES       =", $"HTML_EXTRA_FILES  	   = \"{darkModeTogglerJSDestination}\" \"{fragmentCopyButtonJSDestination}\" \"{paragraphLinkJSDestination}\" \"{toggleAltThemeJSDestination}\" \"{tocJSDestination}\" \"{tabsJSDestination}\"");

            if (graph)
            {
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("HAVE_DOT               = NO", "HAVE_DOT               = YES");
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("UML_LOOK               = NO", "UML_LOOK               = YES");
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("TEMPLATE_RELATIONS     = NO", "TEMPLATE_RELATIONS     = YES");
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("CALL_GRAPH             = NO", "CALL_GRAPH             = YES");
                doxyFileStringBuilder = doxyFileStringBuilder.Replace("CALLER_GRAPH           = NO", "CALLER_GRAPH           = YES");
            }

            doxyFileText = doxyFileStringBuilder.ToString();
            File.WriteAllText(doxyFileDestination, doxyFileText);

            // Run doxygen on a new thread
            var doxygenOutput = new DoxygenThreadSafeOutput();
            doxygenOutput.SetStarted();
            var doxygen = new DoxygenRunner(doxygenPath, new[] { doxyFileDestination }, doxygenOutput, OnDoxygenFinished);
            var doxygenThread = new Thread(new ThreadStart(doxygen.RunThreadedDoxy));
            doxygenThread.Start();

            return doxygenThread;

            void OnDoxygenFinished(int code)
            {
                if (code != 0)
                {
                    Debug.LogError($"Doxygen finsished with Error: return code {code}. Check the Doxgen Log for Errors and try regenerating your Doxyfile.");
                }

                // Read doxygen-awesome since the files are destroyed in the doxygen process
                File.Copy(doxygenAwesomeSource, doxygenAwesomeDestination, true);
                File.Copy(doxygenAwesomeSidebarOnlySource, doxygenAwesomeSidebarOnlyDestination, true);

                // Create a doxygen log file
                var doxygenLog = doxygenOutput.ReadFullLog();
                var doxygenLogDestination = $"{outputDirectory}/Log.txt";
                if (File.Exists(doxygenLogDestination))
                {
                    File.Delete(doxygenLogDestination);
                }

                File.WriteAllLines(doxygenLogDestination, doxygenLog);
            }
        }
    }
}
