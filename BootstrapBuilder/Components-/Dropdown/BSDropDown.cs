using System.Collections.Generic;
using System.Text;

namespace BootstrapBuilder.Components
{
    public class BSDropDown:IBSElement
    {

        string _classBase;

        public BSDropDown()
        {
            _classBase = "dropdown-menu";
        }

        public BSDropDown(string classBase)
        {
            _classBase = classBase;
        }
        public enum eItemType
        {
            Button,
            ListItem
        }
        private List<BSMenuItem> _items = new List<BSMenuItem>();
        public string StyleList { get; private set; }

        public void AddMenuItem(IBSElement element) {
            _items.Add(element as BSMenuItem);
        }
        public string GetHTML() {
            var cItem = new StringBuilder();
            _items.ForEach(item => cItem.Append(item.GetHTML()));
            var html = new StringBuilder(getUL());
            html.Replace("@BSMenuItems", cItem.ToString());
            return html.ToString();
        }
        private string getUL()
        {
            var html = new StringBuilder();
            html.AppendFormat ("<ul class='{0}'>", StyleList == null ? _classBase : "").AppendLine();
            html.Append("@BSMenuItems").AppendLine();
            html.Append("</ul>").AppendLine();
            return html.ToString();
        }

        public void AddElement(IBSElement element) => throw new System.NotImplementedException();
    }
}
