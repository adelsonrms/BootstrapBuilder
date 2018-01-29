#region Pacotes Utilizadas
    using System.Collections.Generic;
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
    /// Representa a implementação de um grupo de Paineis onde varios paineis são incorporados no Bootstrap
    /// </summary>
    /// <remarks>
    /// A propriedade Html retorna o codigo html serializado das classes com toda a implementação necessária para renderizar os paineis Bootstrap.
    /// </remarks>
    public class BSPanelGroup:IBSElement
    {
        List<BSPanel> _panels;

        #region Propriedades
        public List<BSPanel> Panels { get { return this._panels; } }
        #endregion

        #region Construtores
        public BSPanelGroup()
        {
            _panels = new List<BSPanel>();
        }
        #endregion

        #region Métodos Publicos
        public void AddPanel(BSPanel panel)
        {
            _panels.Add(panel);
        }
        public string GetHTML()
        {
            StringBuilder htmlBuilder = new StringBuilder();
            //Constroi o grupo de tabs no menu
            htmlBuilder.Append("<div class='panel-group' id='accordion'>").AppendLine();
            _panels.ForEach(tb => htmlBuilder.Append(tb.GetHTML()).AppendLine());
            htmlBuilder.Append("</div>").AppendLine();
            return htmlBuilder.ToString();
            ;
        }
        /// <summary>
        /// Necessário devido a herança da Interface. Não esta sendo utilizado nessa classe
        /// </summary>
        /// <param name="element">Um elemento qualquer que herde a propria interface IBSElement</param>
        public void AddElement(IBSElement element) { }
        #endregion
    }
}
