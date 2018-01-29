using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components
{
    public  class BSContainer: IBSElement
    {
        StringBuilder html;

        private string _ClassName;
        private string _id;

        private string tagEnd { get { return "</div><!--#Fim_" + ClassName + "_" + Id +  "#-->"; }  }

        public string Id
        {
            get
            {
                if (this._id ==null)
                {
                    this._id = "Container_" + Guid.NewGuid().ToString().Substring(1, 8);
                }
                return this._id;
            }
            set { this._id = value; }
        }

        public string ClassName
        {
            get
            {
                if (this._ClassName == null)
                {
                    this._ClassName = "container";
                }
                return this._ClassName;
            }
            set { this._ClassName = value; }

        }


        public string Content { get; set; }
        public string ExtendedClass { get; set; }

        public BSContainer()
        {
           // getDefContainer();
        }

        public BSContainer(string classBase)
        {
            _ClassName = classBase;
            getDefContainer();
        }

        public BSContainer(string classBase, string id)
        {
            _ClassName = classBase;
            _id = id;
            getDefContainer();
        }

        public BSContainer(string classBase, string id, string Content)
        {
            getDefContainer();
        }

        private string getDefContainer()
        {
            if (html == null) { html = new StringBuilder().AppendFormat("<div id = '{0}' class='{1}'>{2}{3}", Id, ClassName, tagEnd, Content).AppendLine(); }
            return html.ToString();
        }

        public string ContainerType { get; set; }
        public void AddElement(IBSElement element) {
            getDefContainer();
            html.Replace(tagEnd, element.GetHTML() + tagEnd);
        }
        public string GetHTML()
        {
            {
                getDefContainer();
                return html.ToString();
            }
        }

        public BSGenericElement AddRow(string content, string id)
        {
            BSGenericElement row = new BSGenericElement() { Tag = "div", ClassName = "row", Content = content, Id= id};

            getDefContainer();
            html.Replace(tagEnd, row.GetHTML() + tagEnd);
            return new BSGenericElement(html.ToString());
        }

        public BSGenericElement AddRow(string content)
        {
            return AddRow(content);
        }

        public void AddDropdownMenu(BSDropDown Dropdown)
        {
            AddElement(Dropdown);
        }
    }
}
