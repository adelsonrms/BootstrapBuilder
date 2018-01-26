using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components
{
    public class BSButton : BSElementBase , IBSElement
    {

       public enum eButtonType
        {
            Button,
            Link
        }

        public enum eButtonStyle
        {
            Default,
            Danger,
            Warning
        }

        public enum eButtonAction
        {
            Default,
            Dropdown
        }


        public BSButton() {
            base.ClassBase = "btn";
            ButtonType = eButtonType.Button;
        }


        private StringBuilder html;
        private string _class;
        private string _buttonGroup;


        public eButtonType ButtonType { get; set; }
        public string ButtonStyle { get; set; }
        public eButtonAction Action { get; set; }
        
        public void AddElement(IBSElement element) => throw new NotImplementedException();
        public string GetHTML() {
            if (html==null)
            {
                html = new StringBuilder(configureButton());
            }
            return html.ToString();
        }

        private string configureButton()
        {
            return new StringBuilder().AppendFormat("<{0} type='{1}' class='{2}' {3}>{4}{5}</{0}>", ButtonType == eButtonType.Button ? "button" : "a", ButtonType, configureClass(), extendedStyle(), Title, Action == eButtonAction.Dropdown ? "<span class='caret'></span>" : "").ToString();
        }

        private string configureClass()
        {
            return string.Format("{0} {0}-{1} {2}", ClassBase, ButtonStyle, Action== eButtonAction.Dropdown? "dropdown-toggle" : "");
        }

        private string extendedStyle()
        {
                switch (Action)
                {
                case eButtonAction.Dropdown:
                    return "data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'";
                default:
                return "";
                }
        }

        private string configureButtonGroup()
        {
            var html = new StringBuilder();
                html.Append("<div class='btn-group'>").AppendLine();
                html.Append(configureButton()).AppendLine();
                html.Append("@Menu").AppendLine();
                html.Append("</div>").AppendLine();

            return html.ToString();
        }

        public void AddDropdownMenu(BSDropDown Dropdown)
        {
            html = new StringBuilder(configureButtonGroup()).Replace("@Menu", Dropdown.GetHTML());
        }
    }
}
