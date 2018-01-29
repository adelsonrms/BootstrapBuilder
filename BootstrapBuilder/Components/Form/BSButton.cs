using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components
{
    public class BSButton : BSFormControl, IBSElement
    {

       public enum eButtonType {Button, Link, SubmitButton}

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
            base.ClassName = "btn";
            ButtonType = eButtonType.Button;
        }


        private StringBuilder html;
        public int[] Columns { get; set; }
        public eButtonType ButtonType { get; set; }
        public string ButtonStyle { get; set; }
        public eButtonAction Action { get; set; }
        private BSInput Input { get; set; }
        public new void AddElement(IBSElement element) {}
        public override string GetHTML() {
            if (html==null)
            {
                html = new StringBuilder(configureButton());
            }
            return html.ToString();
        }

        private string configureButton()
        {
            //Implementa o BSInput quando o tipo for submit
            if (ButtonType == eButtonType.SubmitButton)
            {
                Input = new BSInput() { Type = "submit", Label = this.Title, Columns = this.Columns, Parent = this.Parent, ExtendedClass = ButtonStyle};
                return Input.GetHTML();
            }
            else
            {
                return new StringBuilder().AppendFormat("<{0} type='{1}' class='{2}' {3}>{4}{5}</{0}>", ButtonType == eButtonType.Button ? "button" : ButtonType == eButtonType.SubmitButton ? "input" : "a", ButtonType, configureClass(), ExtendedAtributes(), Title, Action == eButtonAction.Dropdown ? "<span class='caret'></span>" : "").ToString();
            }
        }

        private string configureClass()
        {
            return string.Format("{0} {0}-{1} {2} {3}", ClassName, ButtonStyle, Action== eButtonAction.Dropdown? "dropdown-toggle" : "", ExtendedClass);
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

        protected override string ExtendedAtributes() {
            switch (Action)
            {
                case eButtonAction.Dropdown:
                    return "data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'";
                default:
                    return "";
            }
        }
    }
}
