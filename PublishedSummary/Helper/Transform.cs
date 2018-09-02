// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-20-2018
//
// Last Modified By : admin
// Last Modified On : 08-22-2018
// ***********************************************************************
// <copyright file="Transform.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PublishedSummary.Helper
{
    /// <summary>
    /// Class TransformObjectAndXml.
    /// </summary>
    public class TransformObjectAndXml
    {
        
        /// <summary>
        /// Deserializes the specified XML document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlDocument">The XML document.</param>
        /// <returns>T.</returns>
        public static T Deserialize<T>(XmlDocument xmlDocument)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            StringReader reader = new StringReader(xmlDocument.InnerXml);
            XmlReader xmlReader = new XmlTextReader(reader);
            //Deserialize the object.
            return (T)ser.Deserialize(xmlReader);
        }

        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="serializeXml">The serialize XML.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Serialize<T>(T value, ref string serializeXml)
        {
            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                StringWriter stringWriter = new StringWriter();
                XmlWriter writer = XmlWriter.Create(stringWriter);

                xmlserializer.Serialize(writer, value);

                serializeXml = stringWriter.ToString();

                writer.Close();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        


    }


}

