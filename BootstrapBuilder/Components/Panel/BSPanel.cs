using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components.Panel
{


    /*
     * 
    <div class="panel panel-default" id="panel1">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-target="#collapseOne" href="#collapseOne">Informações</a>
            </h4>
        </div>
        <div id='collapseOne' class='panel-collapse collapse in'>
            <div class='panel-body'>
                Conteudo do primeiro Painel
            </div>
        </div>
    </div>
     *
     */

    public class BSPanel
    {
        public string Id { get; private set; }
        public string IdRef { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public BSPanel(string title)
        {
            Id = "Panel_id_for_" + TrataCaracteres(title);
            IdRef = "Panel_idRef_for_" + TrataCaracteres(title);
            Title = title;
        }
        private string TrataCaracteres(string text)
        {
            return text.Replace(" ", "_").Replace("/", "_").Replace("\\", "_").Replace("%", "_").Replace("&", "_");
        }

        public string GetHTML()

        {
            var html = new StringBuilder();
            html.Append("<div class='panel panel-default' id='" + Id + "'>").AppendLine();
            html.Append(configureHead()).AppendLine();
            html.Append(configureBody()).AppendLine();
            html.Append("</div>").AppendLine();
            return html.ToString();
        }

        private string configureHead() {
            var html = new StringBuilder();
            html.Append("   <div class='panel-heading'>").AppendLine();
            html.Append("       <h4 class='panel-title'>").AppendLine();
            html.AppendFormat("       <a data-toggle='collapse' data-target='#{0}' href='#{0}'>{1}</a>", IdRef, Title).AppendLine();
            html.Append("       </h4>").AppendLine();
            html.Append("   </div>").AppendLine();
            return html.ToString();
        }

        private string configureBody()
        {
            var html = new StringBuilder();
            html.AppendFormat("   <div id='{0}' class='panel-collapse collapse in'>", IdRef).AppendLine();
            html.AppendFormat("       <div class='panel-body'>").AppendLine();
            html.AppendFormat("           {0}", Content).AppendLine();
            html.AppendFormat("       </div>").AppendLine();
            html.AppendFormat("   </div>").AppendLine();
            return html.ToString();
        }

    }
}
