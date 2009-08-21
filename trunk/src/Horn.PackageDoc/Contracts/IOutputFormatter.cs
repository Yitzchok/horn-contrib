// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOutputFormatter.cs" company="Horn Development Team">
//   (C) 2009 Horn Development Team
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Horn.PackageDoc.Contracts
{
    #region Using Directives

    using System.Collections.Generic;

    using Domain;

    #endregion

    /// <summary>
    /// Defines the interface for rendering the list of packages.
    /// </summary>
    public interface IOutputFormatter
    {
        /// <summary>
        /// Renders the list of packages
        /// </summary>
        /// <param name="packages">
        /// The packages to render
        /// </param>
        /// <returns>
        /// Rendered version of the package list
        /// </returns>
        string Render(IList<PackageDescriptor> packages);
    }
}