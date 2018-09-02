// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-29-2018
//
// Last Modified By : admin
// Last Modified On : 08-29-2018
// ***********************************************************************
// <copyright file="ItemSummary.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace PublishedSummary.Models
{
    /// <summary>
    /// Class ItemSummary.
    /// </summary>
    public class ItemSummary
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string title { get; set; }
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        public int? page { get; set; }
        /// <summary>
        /// Gets or sets the component template.
        /// </summary>
        /// <value>The component template.</value>
        public int? componentTemplate { get; set; }

        /// <summary>
        /// Gets or sets the component.
        /// </summary>
        /// <value>The component.</value>
        public int? component { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public int? category { get; set; }
    }
}
