// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageParser.cs" company="Horn Development Team">
//   (C) 2009 Horn Development Team
// </copyright>
// <summary>
//   Defines the type responsible for parsing the Horn Descriptor file
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Horn.PackageDoc
{
    #region Directives

    using System.Text.RegularExpressions;

    using Domain;

    using Properties;

    #endregion

    /// <summary>
    /// Parses the Package Descriptor Files.
    /// </summary>
    public class PackageParser
    {
        /// <summary>
        /// Extracts the Package Descriptor values from the provided string (contents of the physical file).
        /// </summary>
        /// <param name="content">
        /// The content of the physical Package Descriptor file.
        /// </param>
        /// <returns>
        /// A populated PackageDescriptor object.
        /// </returns>
        public PackageDescriptor ExtractPackageDescriptor(string content)
        {
            MatchCollection packageCategoryMatches = this.ExecuteExpression(Expressions.PackageCategory, content);
            MatchCollection packageDescriptionMatches = this.ExecuteExpression(Expressions.PackageDescription, content);
            MatchCollection packageForumUrlMatches = this.ExecuteExpression(Expressions.PackageForumUrl, content);
            MatchCollection packageHomepageUrlMatches = this.ExecuteExpression(Expressions.PackageHomepageUrl, content);
            MatchCollection packageIdMatches = this.ExecuteExpression(Expressions.PackageId, content);
            MatchCollection packageNameMatches = this.ExecuteExpression(Expressions.PackageName, content);
            MatchCollection packageNotesMatches = this.ExecuteExpression(Expressions.PackageNotes, content);
            MatchCollection packageVersionMatches = this.ExecuteExpression(Expressions.PackageVersion, content);

            var packageDescriptor = new PackageDescriptor
            {
                Category = this.GetMatch(packageCategoryMatches, "category"),
                Description = this.GetMatch(packageDescriptionMatches, "description"),
                ForumUrl = this.GetMatch(packageForumUrlMatches, "forumurl"),
                HomePageUrl = this.GetMatch(packageHomepageUrlMatches, "homepageurl"),
                Id = this.GetMatch(packageIdMatches, "id"),
                Name = this.GetMatch(packageNameMatches, "name"),
                Notes = this.GetMatch(packageNotesMatches, "notes"),
                Version = this.GetMatch(packageVersionMatches, "version"),
            };

            return packageDescriptor;
        }

        /// <summary>
        /// Extracts the specified named group item from the regexp results
        /// </summary>
        /// <param name="matches">
        /// The regexp matches
        /// </param>
        /// <param name="groupName">
        /// The group name to extract
        /// </param>
        /// <returns>
        /// Named group item from regexp match collection
        /// </returns>
        private string GetMatch(MatchCollection matches, string groupName)
        {
            string output = string.Empty;

            if (matches.Count > 0)
            {
                if (matches[0].Groups[groupName].Value != null)
                {
                    output = matches[0].Groups[groupName].Value.Trim();
                }
            }

            return output;
        }

        /// <summary>
        /// Helper Method which executes the provided Regular Expression
        /// </summary>
        /// <param name="expression">
        /// The Regular Expression to execute
        /// </param>
        /// <param name="input">
        /// The input to parse
        /// </param>
        /// <returns>
        /// Collection of Matches.
        /// </returns>
        private MatchCollection ExecuteExpression(string expression, string input)
        {
            Regex regex = new Regex(expression, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            return regex.Matches(input);
        }
    }
}