// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageDescriptor.cs" company="Horn Development Team">
//   (C) 2009 Horn Development Team
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Horn.PackageDoc.Domain
{
    /// <summary>
    /// Defines the Package Descriptor Domain Object, 
    /// used to hold information about the Horn Package
    /// </summary>
    public class PackageDescriptor
    {
        /// <summary>
        /// Gets or sets Category of the project described by the package
        /// </summary>
        /// <example>
        /// Framework
        /// </example>
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Description of the project described by the package
        /// </summary>
        /// <example>
        /// This is a solid architectural foundation for rapidly building maintainable 
        /// web applications leveraging the ASP.NET MVC framework with NHibernate.
        /// </example>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ForumUrl of the project described by the package
        /// </summary>
        /// <example>
        /// http://groups.google.com/group/sharp-architecture
        /// </example>
        public string ForumUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets HomePageUrl of the project described by the package
        /// </summary>
        /// <example>
        /// http://groups.google.com/group/sharp-architecture"
        /// </example>
        public string HomePageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Id of the project described by the package
        /// </summary>
        /// <example>
        /// sharp.architecture
        /// </example>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Name of the project described by the package
        /// </summary>
        /// <example>
        /// Sharp Architecture
        /// </example>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Notes for the project described by the package
        /// </summary>
        public string Notes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Version number of the project described by the package
        /// </summary>
        public string Version
        {
            get;
            set;
        }
    }
}