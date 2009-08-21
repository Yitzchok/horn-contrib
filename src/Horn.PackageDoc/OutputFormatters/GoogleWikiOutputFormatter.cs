// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleWikiOutputFormatter.cs" company="Horn Development Team">
//   (C) 2009 Horn Development Team
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Horn.PackageDoc.OutputFormatters
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Horn.PackageDoc.Contracts;
    using Horn.PackageDoc.Domain;

    #endregion

    /// <summary>
    /// Renders the Package List into Google Wiki Format.
    /// </summary>
    public class GoogleWikiOutputFormatter : IOutputFormatter
    {
        /// <summary>
        /// Render the list of packages into Google Wiki format.
        /// </summary>
        /// <param name="packages">
        /// The packages.
        /// </param>
        /// <returns>
        /// A wiki table of the packages, sorted by category and name.
        /// </returns>
        public string Render(IList<PackageDescriptor> packages)
        {
            packages = packages.OrderBy(x => x.Category).ThenBy(y => y.Name).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("|| *Category* || *Project* || *Package Name* || *Description* || *Links* || *Notes* ||");
            sb.Append(Environment.NewLine);

            foreach (var package in packages)
            {
                sb.Append("||");
                sb.Append(package.Category); // Category
                sb.Append("||"); 
                sb.Append(package.Name); // Project Name
                sb.Append("||");
                sb.Append(package.Id); // Package Name
                sb.Append("||");
                sb.Append(package.Description); // Description
                sb.Append("||");
                sb.Append("["); // Links
                sb.Append(package.HomePageUrl);
                sb.Append(" Home]"); // Links
                sb.Append(" | ["); // Links
                sb.Append(package.ForumUrl);
                sb.Append(" Forum]"); // Links
                sb.Append("||");
                sb.Append(package.Notes); // Notes
                sb.Append("||");
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}