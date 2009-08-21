// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Horn Development Team">
//   (C) 2009 Horn Development Team
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Horn.PackageDoc
{
    #region Using Directives

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Domain;

    using log4net;
    using log4net.Config;

    using OutputFormatters;

    #endregion

    /// <summary>
    /// Tool for parsing the Package Tree and generating
    /// various output formats.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Instance of the logging framework.
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// Main entry point into the app.
        /// </summary>
        /// <param name="args">
        /// The command line args. 
        /// </param>
        /// <example>
        /// -packagetree:"c:\code\Horn\package_tree"
        /// </example>
        public static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            log.Info("PackageDoc starting.........");

            var output = new StringWriter();

            var parser = new SwitchParser(output, args);

            if (!parser.IsAValidRequest())
            {
                log.Error(output.ToString());
                return;
            }

            var packageParser = new PackageParser();

            log.Info(string.Format("Package_Tree Path: {0}", parser.ParsedArgs.First().Value.First()));

            DirectoryInfo info = new DirectoryInfo(parser.ParsedArgs.First().Value.First());

            List<FileInfo> files = new List<FileInfo>(info.GetFiles("*.boo", SearchOption.AllDirectories));
            List<PackageDescriptor> packages = new List<PackageDescriptor>();

            foreach (var file in files)
            {
                packages.Add(packageParser.ExtractPackageDescriptor(File.ReadAllText(file.FullName)));
            }

            var outputContent = new GoogleWikiOutputFormatter().Render(packages);

            File.WriteAllText(Path.Combine(info.FullName, "package_tree-wiki.txt"), outputContent);

            log.Info(string.Format("Wiki Page written to path: {0}", Path.Combine(info.FullName, "package_tree-wiki.txt")));
        }
    }
}