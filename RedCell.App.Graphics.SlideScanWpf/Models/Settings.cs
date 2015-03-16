using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;

namespace RedCell.App.Graphics.SlideScan
{
    /// <summary>
    /// Class Settings.
    /// </summary>
    public class Settings
    {
        #region Properties
        /// <summary>
        /// Gets or sets the image editor.
        /// </summary>
        /// <value>The image editor.</value>
        [Category("External"), DisplayName("Image Editor")]
        public FileInfo ImageEditor { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns>XDocument.</returns>
        public XDocument Serialize()
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XElement("settings",
                    new XElement("ImageEditor", ImageEditor == null ? "" : ImageEditor.ToString())));
        }

        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public void Deserialize(XDocument xml)
        {
            string path = xml.Root.Element("ImageEditor").Value;
            if (string.IsNullOrEmpty(path))
                return;

            ImageEditor = new FileInfo(path);
        }
        #endregion
    }
}
