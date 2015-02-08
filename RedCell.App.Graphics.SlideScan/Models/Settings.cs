using System.ComponentModel;
using System.IO;
using System.Xml.Linq;

namespace RedCell.App.Graphics.SlideScan
{
    public class Settings
    {
        #region Properties
        [Category("External"), DisplayName("Image Editor")]
        public FileInfo ImageEditor { get; set; }
        #endregion

        #region Methods

        public XDocument Serialize()
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XElement("settings",
                    new XElement("ImageEditor", ImageEditor == null ? "" : ImageEditor.ToString()))
                
                );
        }

        public void Deserialize(XDocument xml)
        {
            ImageEditor = new FileInfo(xml.Root.Element("ImageEditor").Value);
        }
        #endregion
    }
}
