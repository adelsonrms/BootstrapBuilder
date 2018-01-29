using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components.Nav
{
    public class BSNavBar : BSContainer
    {

        public enum eNavBarStyleColor
        {
            Default,
            Black
        }


        StringBuilder html;
        public string Title { get; set; }
        public BSDropDown Menu { get; set; }
        public string IconBrandLocation { get; set; }
        public string LinkDestination { get; set; }
        
        public eNavBarStyleColor NavStyleColor { get; set; }

        public BSNavBar()
        {

        }

        public BSNavBar(string title)
        {
            Title = title;
        }

        private string configureElement()
        {
            html = new StringBuilder();
            html.AppendFormat("<nav class='navbar navbar-{0}'>", NavStyleColor==eNavBarStyleColor.Black?"inverse":"default").AppendLine();

            BSContainer cntBrand = new BSContainer();

            cntBrand = new BSContainer("collapse navbar-collapse", "Menu");
            cntBrand.AddDropdownMenu(Menu);


            html.Append(configHead()).AppendLine();
            html.Append(cntBrand.GetHTML()).AppendLine();

            html.Append("</nav>").AppendLine();

            return html.ToString();
        }

        private string configHead()
        {
            var btn = new StringBuilder();
            btn.Append("<div class='navbar-header'>").AppendLine();
            btn.Append(ToggleButtonResponsive()).AppendLine();
            btn.AppendFormat("    <a class='navbar-brand' href='{1}'><img class='Brand' src='{1}' /></a>", LinkDestination, IconBrandLocation).AppendLine();
            btn.Append("</div>").ToString();
            return btn.ToString();
        }

        private string ToggleButtonResponsive()
        {
            var btn = new StringBuilder();
            btn.Append("    <button type = 'button' class='navbar-toggle' data-toggle='collapse' data-target='#Menu'>").AppendLine();
            btn.Append("        <span class='sr-only'>Toggle</span>").AppendLine();
            btn.Append("        <span class='icon-bar'></span>").AppendLine();
            btn.Append("        <span class='icon-bar'></span>").AppendLine();
            btn.Append("        <span class='icon-bar'></span>").AppendLine();
            btn.Append("    </button>").ToString();
            return btn.ToString();
        }
        public new string GetHTML()
        {
            {
                configureElement();
                return html.ToString();
            }
        }


    }
}
