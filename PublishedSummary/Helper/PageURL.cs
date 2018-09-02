// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-20-2018
//
// Last Modified By : admin
// Last Modified On : 08-22-2018
// ***********************************************************************
// <copyright file="PageURL.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace PublishedSummary.Helper
{
    /// <summary>
    /// Class PageURL.
    /// </summary>
    public static class PageURL
    {
        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetDomain()
        {
            Uri myuri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string pathQuery = myuri.PathAndQuery;
            string hostName = myuri.ToString().Replace(pathQuery, "");
            return hostName;
        }
    }
}
