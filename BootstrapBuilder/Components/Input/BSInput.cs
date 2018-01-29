using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace BootstrapBuilder.Components
{
    

    public class BSInput:BSFormControl
    {
        int[] _collunms;
        int _col_label = 2;
        int _col_input =  -1;


        #region Propriedades
        public string Mask { get; set; }
        public string Tooltip { get; set; }
        public string PlaceHolder { get; set; }
        public bool ReadOnly { get; set; }
        public bool Requeried { get; set; }
        public bool Disabled { get; set; }
        public string Value { get; set; }
        public string MaxLenght { get; set; }
        public int[] Columns {
            get
            {
                if (_collunms==null)
                {
                     _collunms = new int[2] { _col_label,
                                              _col_input ==-1?12- _col_label: _col_input};
                }
                return _collunms;
            }
            set {
                _col_label = value[0];
                _col_input = value[1];
            }
        }
        #endregion

        #region Construtores
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Inicializa um novo Panel ja informando o titulo
        /// </summary>
        /// <remarks>O titulo informado será usando para gerar automaticamente o ID do painel e tambem o ID da Div que será o corpo do conteudo</remarks>
        /// <param name="label"></param>
        public BSInput(string label)
        {
            Label = label;
            initializeDefault("text", null);
        }

        public BSInput(string type, string id)
        {
            initializeDefault(type, id);
        }

        public BSInput()
        {
            initializeDefault("text", null);
        }

        void initializeDefault(string type, string id)
        {
            ClassName = "form-control";
            Type = type;
            if (id!=null) {Id = TrataCaracteres(id);}
            
        }

        void defaultParentForm()
        {
            _col_label = Parent.ColWidthLabel == 0?_col_label: Parent.ColWidthLabel;
            _col_input = Parent.ColWidthInput == 0 ? _col_input : Parent.ColWidthInput;
        }

        #endregion
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
        #region Métodos publicos
        /// <summary>
        /// -------------------------------------------------------------------------------------
        /// Autor   : Adelson RM Silva, 26/01/2018
        /// -------------------------------------------------------------------------------------
        /// Recupera o HTML que representa o cabeçalho
        /// </summary>
        public override string GetHTML()
        {
            defaultParentForm();

            var html = new StringBuilder();
            html.AppendFormat("<div id = '{0}' class='form-group'>", "FormGroup_For_" + TrataCaracteres(Label)).AppendLine();

            if (Type=="submit")
            {
                html.AppendFormat("  <div class='col-sm-offset-{0} col-sm-{1}'>", Parent.IgnoreColumns==true?"":Columns[0].ToString(), Parent.IgnoreColumns == true ? "" : Columns[1].ToString()).AppendLine();
                html.AppendFormat("     {0}", HtmlInput).AppendLine();
                html.AppendFormat("  </div>").AppendLine();
            }
            else
            {
                //Caso seja um form de orientaçao vertical, ou seja, os rotulos  ficam direita dos input, 
                //O Input fica dentro de uma Row
                if (Parent.Orientation == BSForm.eFormOrientation.Horizontal)
                {
                    html.AppendFormat("     {0}", HtmlLabel).AppendLine();
                    html.AppendFormat("  <div class='{0}'>", CollunmInput).AppendLine();
                    html.AppendFormat("     {0}", HtmlInput).AppendLine();
                    html.AppendFormat("  </div>").AppendLine();
                }
                else
                {
                    //Caso contrário, com orientação, os rotulos ficam acima dos inputs. Nesse caso não há row dividindo o Input do Lable
                    html.AppendFormat("     {0}", HtmlLabel).AppendLine();
                    html.AppendFormat("     {0}", HtmlInput).AppendLine();
                }
            }

            
            html.AppendFormat("</div>").AppendLine();
            return html.ToString();
        }

        private string CollunmLabel { get { return string.Format("col-sm-{0}", Parent.IgnoreColumns == true ? "" : Columns[0].ToString()) ; } }
        private string CollunmInput { get { return string.Format("col-sm-{0}", Parent.IgnoreColumns == true ? "" : Columns[1].ToString()); } }

        public string HtmlLabel { get {return string.Format("<label class='control-label {2}' for='{0}'>{1}</label>", TrataCaracteres(Id), Label, CollunmLabel); } }
        public string HtmlInput { get { return string.Format("<input name='{0}' class='{1} {6}' id='{0}' type='{2}' placeholder='{3}' {4} {5} />", TrataCaracteres(Id), ClassName, Type, PlaceHolder == null ? Tooltip == null ? Label : Tooltip : PlaceHolder, new BSTooltip(Tooltip, Label).Html(), ExtendedAtributes(), ExtendedClass); } }

        protected override string ExtendedAtributes()
        {
            var att = new StringBuilder();
            if (MaxLenght != null) { att.AppendFormat("maxlenght = '{0}'", MaxLenght).AppendLine(); }
            if (Value != null) { att.AppendFormat("Value = '{0}'", Value).AppendLine(); }
            att.AppendFormat(ReadOnly == true ? " readonly" : "").AppendLine();
            att.AppendFormat(Disabled == true ? " disabled" : "").AppendLine();
            att.AppendFormat(Requeried == true ? " required" : "").AppendLine();

            return att.ToString();
        }


        #endregion
    }

}
    
