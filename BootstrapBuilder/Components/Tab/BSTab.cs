using BootstrapBuilder.Components.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components.Tab
{
    public class BSTab:IBSElement
    {
        private string _toggleType, _pillType;
        StringBuilder html;

        public enum eItemType
        {
            Button,
            Dropdown
        }

        BSTabPane _tabPane;
        string _id;
        bool _active;

        public string TabRef {
            get { return _id; }
            set {
                _id = value;
                TabID = _id;
                if (_tabPane == null)
                {
                    _tabPane = new BSTabPane(_id);
                };
                _tabPane.Active = this.Active;
            }
        }

        public string TabID { get; private set; }
        public string ToggleType { get; set; }
        public string PillType { get; set; }
        public bool Active { get { return _active; } set { _active = value;  TabPane.Active = _active; } }
        public string Title { get; set; }
        public BSTabPane TabPane
        {
            get
            {
                if (_tabPane==null) {_tabPane = new BSTabPane(_id);}
                return _tabPane;
            }
            set { _tabPane = value; }
        }

        public eItemType ItemType { get; set; }


        public string GetHTML()
        {
            if (html==null) {configureItem();}

            return html.ToString();
        }

        private void setDefault()
        {
            if (ToggleType==null) { _toggleType = "tab"; } else { _toggleType = ToggleType; };
            if (PillType == null) { _pillType = "pill"; } else { _pillType = PillType; };
        }

        private void configureItem()
        {
            setDefault();
            html = new StringBuilder().AppendFormat("<li {4}><a href='#{0}_Ref' id='{1}' data-toggle='{2}' pilltype='{3}'>{5}</a></li>", TabRef, TabID, _toggleType, _pillType, Active == true ? "class='active'" : "", Title).AppendLine();
        }

        public void ConfigureDropDown(IBSElement menuDrop)
        {
            html = new StringBuilder(menuDrop.GetHTML());
        }
        public void AddElement(IBSElement element) => throw new NotImplementedException();

        public string HtmlTabPane
        {
            get {
                if (this.ItemType == eItemType.Button)
                {
                    TabPane.Id = TabRef;
                    return TabPane.GetHTML();
                }
                else
                {
                    return "";
                }
            }
                
        }
    }
}
