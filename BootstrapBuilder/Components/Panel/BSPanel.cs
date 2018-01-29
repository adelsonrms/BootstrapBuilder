#region Pacotes Utilizadas
    using System.Text;
#endregion

namespace BootstrapBuilder.Components.Panel
{
    /// <summary>
    /// -------------------------------------------------------------------------------------
    /// Autor   : Adelson RM Silva
    /// Data    : 26/01/2018
    /// Versão  : 1.0
    /// -------------------------------------------------------------------------------------
    /// Representa a implementação de um Panel serializado para o Boostrap.
    /// Um BSPanel deve ser incorporado a um grupo de BSPanels atraves da classe BSPanelGroup.
    /// </summary>
    /// <remarks>
    /// Autor   : Adelson RM Silva
    /// Data    : 26/01/2018
    /// Versão  : 1.0
    /// O objetivo dessa classe é gerar o bloco de codigo HTML necessário para criação de um Painel (Accordion) estilidado pelo Bootstrap.
    /// </remarks>
    public class BSPanel
    {
        #region Propriedades
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// ID do Panel
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// O ID que é atribuido ao bloco da Div que será exibida/ocultada conforme o clique no cabeçalho
        /// </summary>
        public string IdRef { get; set; }
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Titulo ja do panel (Cabeçalho)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Corpo do painel que é exibido.
        /// </summary>
        /// <remarks>Aqui pode ser qualquer implementação, ate mesmo codigo HTML  que será interpretado pelo Browser</remarks>
        public string Content { get; set; }
        #endregion

        #region Construtores
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Inicializa um novo Panel ja informando o titulo
        /// </summary>
        /// <remarks>O titulo informado será usando para gerar automaticamente o ID do painel e tambem o ID da Div que será o corpo do conteudo</remarks>
        /// <param name="title"></param>
        public BSPanel(string title)
        {
            Id = "Panel_id_for_" + TrataCaracteres(title);
            IdRef = "Panel_idRef_for_" + TrataCaracteres(title);
            Title = title;
        }

        #endregion

        #region Métodos Privados
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Faz o tratamento de alguns caracteres especiais que não podem aparecer em IDs
        /// </summary>
        private string TrataCaracteres(string text)
        {
            return text.Replace(" ", "_").Replace("/", "_").Replace("\\", "_").Replace("%", "_").Replace("&", "_");
        }
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Recupera o HTML que representa o cabeçalho
        /// </summary>
        private string configureHead() {
            var html = new StringBuilder();
            html.Append("   <div class='panel-heading'>").AppendLine();
            html.Append("       <h4 class='panel-title'>").AppendLine();
            html.AppendFormat("       <a data-toggle='collapse' data-target='#{0}' href='#{0}'>{1}</a>", IdRef, Title).AppendLine();
            html.Append("       </h4>").AppendLine();
            html.Append("   </div>").AppendLine();
            return html.ToString();
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Retorna o HTML que representa o Corpo do Painel. Onde outros conteudos aparecerão.
        /// </summary>
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

        #endregion

        #region Métodos Publicos
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Retorna o HTML que representa o Painel completo com todos os elementos
        /// </summary>
        public string GetHTML()
        {
            var html = new StringBuilder();
            html.Append("<div class='panel panel-default' id='" + Id + "'>").AppendLine();
            html.Append(configureHead()).AppendLine();
            html.Append(configureBody()).AppendLine();
            html.Append("</div>").AppendLine();
            return html.ToString();
        }
        #endregion
    }
}
