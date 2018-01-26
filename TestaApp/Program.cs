using BootstrapBuilder.Components;
using BootstrapBuilder.Components.Tab;
using BootstrapBuilder.Components.Nav;
using BootstrapBuilder.Components.Panel;
using System.Text;

namespace TestaApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Barra de Menu
            //Cria um Container
            BSContainer container = new BSContainer();
            container.Id = "Conteudo";

            container.AddRow("<br />", "Espaco");

            var menu = new BSDropDown("nav navbar-nav");
            menu.AddMenuItem(new BSMenuItem() { LinkRef = "#", Title = "Admnistrativos", Active = true });
            menu.AddMenuItem(new BSMenuItem() { LinkRef = "#", Title = "Financeiro" });
            menu.AddMenuItem(new BSMenuItem() { LinkRef = "#", Title = "Comercial" });
            menu.AddMenuItem(new BSMenuItem() { LinkRef = "#", Title = "Gestão de Projetos" });

            BSNavBar NavBar = new BSNavBar();
            NavBar.NavStyleColor = BSNavBar.eNavBarStyleColor.Default;
            NavBar.IconBrandLocation = "http://www.tecnun.com.br/wp-content/uploads/2017/01/favicon.png";
            NavBar.Menu = menu;

            container.AddRow(NavBar.GetHTML(), "BarraDeMenu");

            container.AddRow("<h2>Criação de Layout Bootstrap via Objetos C#</h2>", "Titulo");

            //Inicializa uma TabBar
            BSTabBar TabBar = new BSTabBar();

            BSDropDown BotaoDropdown = new BSDropDown();
            //Items do Dropdown
            BotaoDropdown.AddMenuItem(new BSMenuItem() { Active = true, LinkRef = "#", Title = "Contas a Pagar" });
            BotaoDropdown.AddMenuItem(new BSMenuItem() { LinkRef = "#", Title = "Contas a Receber" });

            //Define o botão ja com as declarações de um dropdown
            BSButton botao = new BSButton() { Title = "Financeiro", ButtonStyle="danger", Action=BSButton.eButtonAction.Dropdown};
            //Incorpora o menu no botão convertendo-o em um botão com drop
            botao.AddDropdownMenu(BotaoDropdown);

            //Cria duas Tabs
            BSTab tabDados = new BSTab() {
                TabRef = "Info",
                Active = true,
                Title = "Dados"
            };

            tabDados.TabPane.AddElement(new BSGenericElement("<p>Conteudo da Tab de Dados. Pode ser o complemento de um HTML</p><br /><br />" + botao.GetHTML() + "<br />" + BotaoDropdown.GetHTML()));

            BSTab tabDoc = new BSTab()
            {
                TabRef = "Doc",
                Title = "Documentos"
            };

            BSPanel pnlInfo = new BSPanel("Resumo");

            pnlInfo.Content = PegarHTML();

            BSPanelGroup pnlGroup = new BSPanelGroup();
            pnlGroup.AddPanel(pnlInfo);
            tabDoc.TabPane.AddElement(pnlGroup);


            tabDoc.TabPane.AddElement(new BSGenericElement("<p>Relação dos documentos.</p><br />"));

            BSButton botaoPadrao = new BSButton() { Title = "Pesquisar", ButtonStyle = "default", Action = BSButton.eButtonAction.Default };
            tabDoc.TabPane.AddElement(botaoPadrao);



            //Cria um menu no estilo Dropdown
            BSMenuItem MenuItem = new BSMenuItem()
            {
                Title = "Módulo",
                Action = BSMenuItem.eButtonAction.Dropdown
            };

            BSDropDown menuDrop = new BSDropDown();

            //Items do Dropdown
            menuDrop.AddMenuItem(new BSMenuItem() { LinkRef = "#", Title = "Financeiro" });
            menuDrop.AddMenuItem(new BSMenuItem() { LinkRef = "#", Title = "Administrativo" });

            MenuItem.AddDropdownMenu(menuDrop);

            BSTab tabMenu = new BSTab();
            tabMenu.ConfigureDropDown(MenuItem);
           
            //Adiciona as tabs na TabBar
            TabBar.AddTab(tabDados);
            TabBar.AddTab(tabDoc);
            TabBar.AddTab(tabMenu);

            container.AddRow(TabBar.GetHTML(), "BarraDeGuias");

            var conteudo = container.GetHTML();
            System.Console.WriteLine(conteudo);
        }

        static string PegarHTML()
        {
            var html = new StringBuilder();

            html.Append("< div class='container'>");
            html.Append("<div class='col-md-5'>");
            html.Append("<div class='form-area'>  ");
            html.Append("<form role = 'form' >");
            html.Append("< br style='clear:both'>");
            html.Append("<h3 style = 'margin-bottom: 25px; text-align: center;' > Contact Form</h3>");
            html.Append("<div class='form-group'>");
            html.Append("<input type = 'text' class='form-control' id='name' name='name' placeholder='Name' required>");
            html.Append("</div>");
            html.Append("<div class='form-group'>");
            html.Append("<input type = 'text' class='form-control' id='email' name='email' placeholder='Email' required>");
            html.Append("</div>");
            html.Append("<div class='form-group'>");
            html.Append("<input type = 'text' class='form-control' id='mobile' name='mobile' placeholder='Mobile Number' required>");
            html.Append("</div>");
            html.Append("<div class='form-group'>");
            html.Append("<input type = 'text' class='form-control' id='subject' name='subject' placeholder='Subject' required>");
            html.Append("</div>");
            html.Append("<div class='form-group'>");
            html.Append("<textarea class='form-control' type='textarea' id='message' placeholder='Message' maxlength='140' rows='7'></textarea>");
            html.Append("<span class='help-block'><p id = 'characterLeft' class='help-block '>You have reached the limit</p></span>");
            html.Append("</div>");
            html.Append("<button type = 'button' id='submit' name='submit' class='btn btn-primary pull-right'>Submit Form</button>");
            html.Append("</form>");
            html.Append("</div> ");
            html.Append("</div> ");
            html.Append("</div> ");
            return html.ToString();
        }
    }
}
