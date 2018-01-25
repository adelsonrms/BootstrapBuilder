using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components
{
    class BSTab
    {
        StringBuilder htmlBuilder;
        private string _active;

        public BSTab()
        {
            htmlBuilder = new StringBuilder();
        }
        public string TabRef { get; set; }
        public string TabID { get { return TabRef; } }
        public string ToggleType { get; set; }
        public string PillType { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public string getHtml (){
                htmlBuilder.AppendFormat("< ul class='nav nav - tabs cor_azul'>");
                if (Active) {_active = "class='active'";}
                htmlBuilder.AppendFormat("<li><a href='#{0}' id='{1}' data-toggle='{2}' pilltype='{3}' {4}>Informações</a></li>", TabRef, TabID, ToggleType, PillType, _active);
                htmlBuilder.AppendFormat("</ul>");
                return htmlBuilder.ToString();
            ;
        }
    }
