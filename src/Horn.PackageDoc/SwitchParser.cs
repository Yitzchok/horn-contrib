// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitchParser.cs" company="Horn Development Team">
//   (C) 2009 Horn Development Team
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Horn.PackageDoc
{
    #region Using Directives

    using System.Collections.Generic;
    using System.IO;

    using Core.Utils.CmdLine;

    #endregion

    /// <summary>
    /// Custom SwitchParser for dealing with input for the PackageDoc app.
    /// </summary>
    public class SwitchParser : Core.Utils.CmdLine.SwitchParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchParser"/> class.
        /// </summary>
        /// <param name="output">
        /// The output (to write to the console)
        /// </param>
        /// <param name="args">
        /// The args to parse
        /// </param>
        public SwitchParser(TextWriter output, string[] args)
        {
            this.HelpText = 
@"THE HORN PACKAGE DOCUMENTER

Usage : packagedoc -packagetree:<path>";

            this.output = output;

            var parameters = new List<Parameter>
                                 {
                                     new Parameter("packagetree", true, true, false),
                                 };

            paramTable = parameters.ToArray();

            parsedArgs = Parse(args);
        }
    }
}