using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RedCell.App.Graphics.SlideScan
{
    /// <summary>
    /// Class Set.
    /// </summary>
    public class Set
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Set"/> class.
        /// </summary>
        public Set()
        {
            Filenames = new BindingList<string>();
            Date = DateTime.Now;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the scan date.
        /// </summary>
        /// <value>The scan date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>The operator.</value>
        public string Operator { get; set; }

        /// <summary>
        /// Gets the filenames.
        /// </summary>
        /// <value>The filenames.</value>
        public BindingList<string> Filenames { get; private set; }
        #endregion

        #region Methods

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns>XDocument.</returns>
        public XDocument Serialize()
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("set",
                    new XAttribute("name", Name),
                    new XAttribute("date", Date.ToString("s")),
                    new XAttribute("operator", Operator),
                    from fn in Filenames select new XElement("file", fn)));
        }

        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public void Deserialize(XDocument xml)
        {
            Name = xml.Root.Attribute("name").Value;
            Date = DateTime.Parse(xml.Root.Attribute("date").Value);
            Operator = xml.Root.Attribute("operator").Value;
            Filenames = new BindingList<string>((from XElement fn in xml.Root.Elements("file") select fn.Value).ToArray());
        }
        #endregion
    }
}
