using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapBuilder.Components.Tab
{

    public enum eTabBarType
    {
        Tab,
        Pill
    }
    public class BSTabBar:IBSElement
    {
        List<BSTab> _tabs ;
        StringBuilder htmlBuilder = new StringBuilder();

        public eTabBarType TabBarType { get; set; }

        public List<BSTab> BSTabs { get { return _tabs; } }

        public BSTabBar()
        {
            _tabs = new List<BSTab>();
        }

        public void AddTab(BSTab tab)
        {
            _tabs.Add(tab);
        }

        public string GetHTML()
        {

            StringBuilder htmlTabBar = new StringBuilder();
            StringBuilder htmlTabPane = new StringBuilder();

            _tabs.ForEach(tb =>
                         {
                             htmlTabBar.Append(tb.GetHTML());
                             htmlTabPane.Append(tb.HtmlTabPane);
                         }
             );

            //Constroi o grupo de tabs no menu
            htmlBuilder.Append("<div class='row'>").AppendLine();
            htmlBuilder.Append("  <div class='col-xs-12'>").AppendLine();
            htmlBuilder.Append("      <ul class='nav nav-tabs'>").AppendLine();
            htmlBuilder.Append("            " + htmlTabBar.ToString()).AppendLine();
            htmlBuilder.Append("      </ul>").AppendLine();
            htmlBuilder.Append("  </div>").AppendLine();
            htmlBuilder.Append("</div>").AppendLine();

            //Constroi as tab-panes que serão visualizadas de acordo com a tab selecionada
            htmlBuilder.Append("<div class='row'>").AppendLine();
            htmlBuilder.Append("  <div class='col-xs-12'>").AppendLine();
            htmlBuilder.Append("      <div class='tab-content'>").AppendLine();
            htmlBuilder.Append("            " + htmlTabPane.ToString()).AppendLine();
            htmlBuilder.Append("      </div>").AppendLine();
            htmlBuilder.Append("  </div>").AppendLine();
            htmlBuilder.Append("</div>").AppendLine();


            return htmlBuilder.ToString();
            ;
        }
        public void AddElement(IBSElement element) => throw new NotImplementedException();
    }
}
