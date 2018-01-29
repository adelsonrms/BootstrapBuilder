using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace BootstrapBuilder.Components
{
    public class BSTooltip
    {
       public enum ToolTip_Toggle { popover, tooltip }
       public enum ToolTip_Action { hover, click, focus, manual }
       public  enum ToolTip_Position { top, bottom, left, right }

        public ToolTip_Toggle Data_Toggle { get; set; }
        public ToolTip_Action Action { get; set; }
        public string Title { get; set; }
        public ToolTip_Position Position { get; set; }
        public string Content { get; set; }

        public BSTooltip(string content, string title)
        {
            inicializeDefault(content, title);
        }

        public BSTooltip(string content)
        {
            inicializeDefault(content, "Info");
        }

        public BSTooltip()
        {

        }

        private void inicializeDefault(string content, string title)
        {
            Content = content;
            Title = title;
            Data_Toggle = ToolTip_Toggle.popover;
            Action = ToolTip_Action.hover;
            Position = ToolTip_Position.top;
        }

        public string Html()
        {
            if (Content == null) { inicializeDefault("Info", "Nenhuma informação especificada"); }

            var html = new StringBuilder();
            html.AppendFormat(" data-original-title='{0}'", Title);
            html.AppendFormat("data-toggle='{0}'", Data_Toggle.ToString());
            html.AppendFormat("data-content='{0}'", Content);
            html.AppendFormat("data-placement='{0}'", Position.ToString());
            html.AppendFormat("data-container='{0}'", "body");
            html.AppendFormat("data-trigger='{0}' ", Action.ToString());
            return html.ToString();
        }
    }
}