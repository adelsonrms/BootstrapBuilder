using System;
using System.Text;

namespace BootstrapBuilder.Components
{

    public   class BSGenericElement : IBSElement
    {
        string _content;
        private string _id, _tag, _ClassName;
        StringBuilder html;

        public string Content { get { return this._content; } set { _content = value; } }

        public string Id
        {
            get
            {
                if (this._id == null)
                {
                    this._id = Tag + "_" + Guid.NewGuid().ToString().Substring(1, 8);
                }
                return this._id;
            }
            set { this._id = value; }
        }

        public string Tag { get; set; }

        public string ClassName { get; set; }
        public BSGenericElement(string tag, string className , string id)
        {
            _tag = tag;
            _id = id;
            ClassName = className;

            getDefElement();
        }
        public BSGenericElement(string tag, string className)
        {
            _tag = tag;
            ClassName = className;
            getDefElement();
        }
        public BSGenericElement(string content)
        {
            _content = content;
            html = new StringBuilder(_content).AppendLine();
        }
        public BSGenericElement()
        {

        }

        private string getDefElement()
        {
            if (html == null) {
                html = new StringBuilder(string.Format("<{0} id = '{1}' class = '{2}'>", Tag, Id, ClassName)).AppendLine();
                if (_content!=null)
                {
                    html.AppendFormat(_content).AppendLine();
                    html.AppendFormat("</{0}>", Tag).AppendLine();
                }
            };  
            return html.ToString();
        }
        public void AddElement(IBSElement element) => throw new NotImplementedException();

        public string GetHTML() {
            return getDefElement();
        }
    }
}
