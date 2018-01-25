using System.Text;

namespace BootstrapBuilder.Util
{
    static public class HtmlBuilder
    {

        static int camposGerados = 0;

        public static string criarToogle(string Titulo, string corpo = "")
        {
            camposGerados++;

            StringBuilder html = new StringBuilder();

            //Inicio do Default
            html.AppendFormat("<Div ID='{0}' class='{1}'>", "DivDefault_" + camposGerados, "panel panel-default");

            //Heading
            html.AppendFormat("<Div ID='{0}'", "DivHeading_" + camposGerados);
            html.AppendFormat(" class='{0}'", "panel-heading");
            html.AppendFormat(" data-toggle='{0}'", "collapse");
            html.AppendFormat(" data-target='{0}'", "#pnlDemandante_" + camposGerados);
            html.AppendFormat(" >");
            //Title
            html.AppendFormat("<Div ");
            html.AppendFormat(" ID='{0}'", "DivTitle_" + camposGerados);
            html.AppendFormat(" class='{0}'", "panel-title legend font14");
            html.AppendFormat(" >");
            html.AppendFormat(Titulo);
            //Fecha Title
            html.AppendFormat("</Div>");
            //Fecha Heading
            html.AppendFormat("</Div>");

            //Collapse
            html.AppendFormat("<Div ");
            html.AppendFormat(" ID='{0}'", "pnlDemandante_" + camposGerados);
            html.AppendFormat(" class='{0}'", "panel-collapse collapse in");
            html.AppendFormat(" >");

            //Body
            html.AppendFormat("<Div ");
            html.AppendFormat(" ID='{0}'", "DivBody_" + camposGerados);
            html.AppendFormat(" class='{0}'", "panel-body");
            html.AppendFormat(" >");

            if (!string.IsNullOrEmpty(corpo))
            {
                html.AppendFormat(corpo);
            }
            else
            {
                html.AppendFormat("@Corpo");
            }

            //Fecha Body
            html.AppendFormat("</Div>");


            //Fecha Collapse
            html.AppendFormat("</Div>");

            //Fecha Default
            html.AppendFormat("</Div>");

            return html.ToString();
        }

        static public string criarContainer(string tipo)
        {
            StringBuilder html = new StringBuilder();
            //Title
            html.AppendFormat("<Div ");
            html.AppendFormat(" ID='{0}'", "divFluid_" + camposGerados);
            html.AppendFormat(" class='{0}'", "container-" + tipo);
            html.AppendFormat(" >");
            html.AppendFormat("@InnerHtml");
            //Fecha Title
            html.AppendFormat("</Div>");

            return html.ToString();
        }


        internal static string criarInput(string id, string rotulo, string valor)
        {

            StringBuilder html = new StringBuilder();
            //Title

            html.AppendFormat("<Div ID='{0}' class='{1} >", "divSpVertical_Row_" + camposGerados, "row sp-vertical-10");

            html.AppendFormat("<Div ID='{0}' class='{1} >", "Col_3_LBL_" + camposGerados, "col-sm-3");
            html.AppendFormat("<Label ID='{0}'for='{0}' class='{1} >{2}</label>", "DivLabel_9_" + camposGerados, "control-label", rotulo);
            html.AppendFormat("</Div>");

            html.AppendFormat("<Div ID='{0}' class='{1} >", "Col_9_LBL_" + camposGerados, "col-sm-3");
            html.AppendFormat("<input ID='{0}' Name='{0}' class='{1} >{2}</label>", id, "control-label", valor);
            html.AppendFormat("</Div>");

            html.AppendFormat("</Div>");

            return html.ToString();


        }
    }
}