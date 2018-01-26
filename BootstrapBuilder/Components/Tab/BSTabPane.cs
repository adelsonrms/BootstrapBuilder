using System.Text;

namespace BootstrapBuilder.Components.Tab
{
   public sealed class BSTabPane : BSContainer
    {
        public BSTabPane()
        {
        }
        public BSTabPane(string id)
        {
            base.Id = string.Format("{0}_Ref", id);
            base.ClassName = string.Format("{0}", "tab-pane");
        }
        public bool Active {
            set { base.ClassName = string.Format("{0} {1}", "tab-pane", value == true ? "active" : ""); } }
    }
}
