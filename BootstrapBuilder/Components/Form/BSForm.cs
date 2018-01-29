using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components
{
   public class BSForm:BSElementBase
    {
        public enum eFormOrientation { Horizontal, Vertical, Inline}
        public string FormAction { get; set; }
        public string Name { get; set; }
        public eFormOrientation Orientation { get; set; }
        public int ColWidthLabel { get; set; }
        public int ColWidthInput { get; set; }
        public bool IgnoreColumns { get; set; }
        public int InputsByColumn { get; set; }

        private List<BSFormControl> InputControls { get;  set; }
        private List<BSFormControl> ButtonControls { get; set; }
        private List<List<BSFormControl>> InputContainerControls { get; set; }
        private List<List<BSFormControl>> ButtonContainerControls { get; set; }

        public BSForm(string id)
        {
            initializeDefault(id);
        }
        void initializeDefault(string id)
        {
            InputControls = new List<BSFormControl>();
            ButtonControls = new List<BSFormControl>();

            InputContainerControls = new List<List<BSFormControl>>();
            ButtonContainerControls = new List<List<BSFormControl>>();

            ClassName = "form-horizontal";
            if (id != null) { Id = TrataID(id); }
        }

        public void AddInput(BSInput control)
        {
            AddInputToContainer(control);
        }

        public void AddButton(BSButton control)
        {
            AddButtonToContainer(control);
        }

        private void AddButtonToContainer(BSFormControl control)
        {
            ButtonControls.Add(control);
            //Reinicia a lista
            if (ButtonControls.Count == this.InputsByColumn)
            {
                ButtonContainerControls.Add(ButtonControls);
                ButtonControls = new List<BSFormControl>();
            }
            
        }

        private void AddInputToContainer(BSFormControl control)
        {
            //Reinicia a lista
            InputControls.Add(control);

            if (InputControls.Count==this.InputsByColumn) {
                InputContainerControls.Add(InputControls);
                InputControls = new List<BSFormControl>();
            }
            
        }

        public bool RemoveControlById(string id)
        {
          return (InputControls.RemoveAll(c => c.Id == id) > 0);
        }

        public string GetHTML()
        {
            var html = new StringBuilder();

            html.AppendFormat("<form id = '{0}' {1} action='{2}'>", this.Id, configClass(), FormAction).AppendLine();

            InputContainerControls.Add(InputControls);
            ButtonContainerControls.Add(ButtonControls); 

            //Cria uma Row para os Inputs
            html.AppendFormat("<div id='{0}' class='row'>", "Row_Inputs_Form_" + this.Id).AppendLine();
            html.Append(GetHtmlContainer(InputContainerControls)).AppendLine();
            html.AppendFormat("</div> <!-- End Row Tag ({0}) -->", "Row_Inputs_Form_" + this.Id).AppendLine();

            //Cria uma Row para os Buttons, caso tenha
            html.AppendFormat("<div id='{0}' class='row'>", "Row_Button_Form_" + this.Id).AppendLine();
            html.Append(GetHtmlContainer(ButtonContainerControls)).AppendLine();
            html.AppendFormat("</div> <!-- {0} -->", "Row_Button_Form_" + this.Id).AppendLine();

            html.AppendFormat("</form>").AppendLine();
            return html.ToString();
        }

        private string GetHtmlContainer(dynamic container)
        {
            BSFormControl ctr;
            StringBuilder htmlContainer = new StringBuilder();
            for (int i = 0; i < container.Count; i++)
            {
                if (container[i].Count>0)
                {
                    htmlContainer.AppendFormat("<div id = '{0}' class='col-sm-6'>", "Cols_For_" + container.GetType().Name + "_In_Form_ID_" + this.Id).AppendLine();
                    for (int y = 0; y < container[i].Count; y++)
                    {
                        ctr = container[i][y];
                        ctr.Parent = this;
                        htmlContainer.Append(ctr.GetHTML()).AppendLine();
                    }
                    htmlContainer.AppendFormat("</div> <!-- {0} -->", "Cols_For_" + container.GetType().Name + "_In_Form_ID_" + this.Id).AppendLine();
                }
            }

            return htmlContainer.ToString();
        }

        private string configClass()
        {

            switch (Orientation)
            {
                case eFormOrientation.Horizontal:
                    ClassName = "form-horizontal";
                    break;
                case eFormOrientation.Vertical:
                    ClassName = "";
                    break;
                case eFormOrientation.Inline:
                    ClassName = "form-inline";
                    break;
                default:
                    break;
            }
            return string.Format("class = '{0}'", ClassName);
        }
        private string extendedAttributes()
        {
            var att = new StringBuilder();
            return att.ToString();
        }
    }
}
