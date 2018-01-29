using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components
{
    /// <summary>
    /// Representa a implementação de um LI
    /// </summary>
   public class BSMenuItem:BSElementBase,  IBSElement 
    {
        StringBuilder html;

        public enum eButtonAction
        {
            Default,
            Dropdown
        }


        public BSMenuItem()
        {
            base.ClassBase = "btn";
        }
        public string LinkRef { get; set; }
        public bool Active { get; set; }
        public eButtonAction Action { get; set; }
        public void AddElement(IBSElement element) => throw new NotImplementedException();
        public string GetHTML() {
            if (html == null)
            {
                html = new StringBuilder(configureItem());
            }
            return html.ToString();
        }

        private string configureItem()
        {
            return new StringBuilder().AppendFormat("<li {0}><a href='{1}#' {2} {3}>{4} {5}</a></li>", Active == true ? "class='active'" : "", LinkRef, configureClass(), configureDataAction(), Title, Action == eButtonAction.Dropdown ? "<span class='caret'></span>" : "").AppendLine().ToString();
        }

        //class="dropdown-toggle" data-toggle="dropdown"

        private string configureClass()
        {
            return string.Format("class = '{0}'", Action == eButtonAction.Dropdown ? "dropdown-toggle" : "");
        }

        private  string configureDataAction()
        {
            return string.Format("{0}", Action == eButtonAction.Dropdown ? "data-toggle='dropdown'" : "");
        }

        private string configureItemGroup()
        {
            var html = new StringBuilder();
            html.Append("<li class='dropdown'> ").AppendLine();

            var defItem = configureItem().Replace("<li>", "").Replace("</li>", "");

            html.Append(defItem);
            html.Append("@Menu").AppendLine();
            html.Append("</li>").AppendLine();

            return html.ToString();
        }

        public void AddDropdownMenu(BSDropDown Dropdown)
        {
            html = new StringBuilder(configureItemGroup()).Replace("@Menu", Dropdown.GetHTML());
        }

    }
}

