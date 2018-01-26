using System.Collections.Generic;
using System.Text;

namespace BootstrapBuilder.Components.Panel
{
    public class BSPanelGroup:IBSElement
    {
        List<BSPanel> _panels;

        public List<BSPanel> Panels { get { return this._panels; } }

        public BSPanelGroup()
        {
            _panels = new List<BSPanel>();
        }

        public void AddPanel(BSPanel panel)
        {
            _panels.Add(panel);
        }
        public string GetHTML()
        {
            StringBuilder htmlPanels = new StringBuilder();
            StringBuilder htmlBuilder = new StringBuilder();
            _panels.ForEach(tb => htmlPanels.Append(tb.GetHTML()));
            //Constroi o grupo de tabs no menu
            htmlBuilder.Append("<div class='panel-group' id='accordion'>").AppendLine();
            htmlBuilder.Append(htmlPanels.ToString()).AppendLine();
            htmlBuilder.Append("</div>").AppendLine();
            return htmlBuilder.ToString();
            ;
        }
        public void AddElement(IBSElement element) => throw new System.NotImplementedException();
    }
}
