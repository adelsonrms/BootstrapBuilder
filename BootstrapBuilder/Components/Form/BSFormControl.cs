namespace BootstrapBuilder.Components
{
    abstract public class BSFormControl : BSElementBase, IBSElement
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string _Label { get; set; }
        public string Label
        {
            get
            {
                if (_Label == null) { _Label = ""; }
                return _Label;
            }
            set
            { _Label = value; }
        }
        public dynamic Parent { get; set; }
        public string ExtendedClass { get; set; }
        public BSFormControl(string type)
        {
            Type = type;
        }
        public BSFormControl(string type, string id)
        {
            Type = type;
            Id = id;
        }
        public BSFormControl()
        {

        }
        abstract protected string ExtendedAtributes();
        virtual public string GetHTML() => throw new System.NotImplementedException();
        public void AddElement(IBSElement element) => throw new System.NotImplementedException();
    }
}
