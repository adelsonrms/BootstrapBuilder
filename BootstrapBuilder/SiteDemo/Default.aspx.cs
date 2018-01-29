using BootstrapBuilder.Components;
using BootstrapBuilder.Components.Tab;
using BootstrapBuilder.Components.Nav;
using BootstrapBuilder.Components.Panel;
using System;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      this.principal.InnerHtml = PegarHtmlPagina();
    }


    public static string PegarHtmlPagina()
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
        BSButton botao = new BSButton() { Title = "Financeiro", ButtonStyle = "danger", Action = BSButton.eButtonAction.Dropdown };
        //Incorpora o menu no botão convertendo-o em um botão com drop
        botao.AddDropdownMenu(BotaoDropdown);

        //Cria duas Tabs
        BSTab tabDados = new BSTab()
        {
            TabRef = "Info",
            Active = true,
            Title = "Dados"
        };

        tabDados.TabPane.AddElement(new BSGenericElement("<p>Conteudo da Tab de Dados. Pode ser o complemento de um HTML</p><br /><br />" + botao.GetHTML() + "<br />" + BotaoDropdown.GetHTML() + "<br />" + PegarHTMLForm()));



        BSTab tabDoc = new BSTab()
        {
            TabRef = "Doc",
            Title = "Documentos"
        };

        BSPanel pnlInfo = new BSPanel("Resumo");

        pnlInfo.Content = PegarHTMLForm();

        BSPanelGroup pnlGroup = new BSPanelGroup();
        pnlGroup.AddPanel(pnlInfo);
        tabDoc.TabPane.AddElement(pnlGroup);

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

        return conteudo;

    }
    public static string PegarHTMLForm()
    {

        var html = new StringBuilder();


        BSContainer container = new BSContainer();

        var row = container.AddRow();


        BSForm form = new BSForm("Cadastro") { FormAction = "/Index.html" };
        form.Orientation = BSForm.eFormOrientation.Horizontal;
        form.ColWidthLabel = 3;
        form.InputsByColumn = 6;

        //Inputs
        form.AddInput(new BSInput("Nome") { Disabled = true, Value = "Adelson", Tooltip = "Informe o nome" });
        form.AddInput(new BSInput("Sobre Nome") { ReadOnly = true, Value = "Silva", Tooltip = "Informe o nome", Columns = new int[2] {form.ColWidthLabel, 5} });
        form.AddInput(new BSInput("Nickname") { Tooltip = "Nome da rua" });
        form.AddInput(new BSInput("email", "email") { Requeried=true,  Label="Email", Tooltip = "Informe o email do usuário" });
        
        //Segunda coluna
        form.AddInput(new BSInput("Endereço") { Tooltip = "Nome da rua" });
        form.AddInput(new BSInput("Cidade") { Tooltip = "Nome da Cidade" });
        form.AddInput(new BSInput("Estado/UF") { Tooltip = "UF do Estado" });
        form.AddInput(new BSInput("CEP") { Tooltip = "CEP" });


        BSButton botaoPadrao = new BSButton() {
            ButtonType = BSButton.eButtonType.SubmitButton,
            Title = "Salvar",
            ButtonStyle = "btn-danger",
            Columns = new int[2] { 2, 2 }
        };

        //form.AddButton(botaoPadrao);


        html.AppendFormat("{0}", form.GetHTML());
        
        
        return html.ToString();
    }
}