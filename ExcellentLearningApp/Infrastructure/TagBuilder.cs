using System.Collections.Generic;
using System.Text;

namespace ExcellentLearningApp.Infrastructure
{
    public class TagBuilder
    {
        private HtmlElement _rootTag;
        private readonly string _rootTagName;
        public TagBuilder(string name, string text = null, IEnumerable<(string, string)> attributes = null)
        {
            _rootTag = CreateElement(name, text, attributes);
            _rootTagName = name;
        }

        public TagBuilder AddChild(string name, string text = null, IEnumerable<(string, string)> attributes = null)
        {
            _rootTag.AddElement(CreateElement(name, text, attributes));
            return this;
        }

        private HtmlElement CreateElement(
            string name,
            string text = null,
            IEnumerable<(string, string)> attributes = null)
        {
            var result = new HtmlElement(name);
            if (text != null) { result.AddText(text); }
            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    result.AddAttribute(new HtmlAttibuteElement(attribute.Item1, attribute.Item2));
                }
            }
            return result;
        }

        public override string ToString() => _rootTag.ToString();

        public void Clear()
        {
            _rootTag = new HtmlElement(_rootTagName);
        }

        public TagBuilder SetIntendSize(int intendSize)
        {
            _rootTag.IntendSize = intendSize;
            return this;
        }
    }

    public class HtmlElement
    {
        public int IntendSize { get; set; } = 2;

        private readonly string _name;
        private string _text;
        private List<HtmlAttibuteElement> _attributes = new List<HtmlAttibuteElement>();
        private List<HtmlElement> _elements = new List<HtmlElement>();

        public HtmlElement(string name)
        {
            _name = name;
        }


        public void AddElement(HtmlElement element)
        {
            element.IntendSize = IntendSize;
            _elements.Add(element);
        }

        public void AddAttribute(HtmlAttibuteElement attibute)
        {
            _attributes.Add(attibute);
        }

        public void AddText(string text)
        {
            _text = text;
        }

        private string ToStringImp(int intend)
        {
            var sb = new StringBuilder();

            sb.AppendLine(StartTag(intend));
            sb.Append(TagText(intend));
            AppendTagChildren(sb, _elements, intend + 1);
            sb.Append(EndTag(intend));

            return sb.ToString();
        }

        private string StartTag(int intend) =>
            HasContent() ?
                $"{PutIntend(intend)}<{_name}{PutAttributes()}>" :
                $"{PutIntend(intend)}<{_name}{PutAttributes()} />";


        private string TagText(int intend) =>
            HasText() ?
                $"{PutIntend(intend + 1)}{_text}\r\n" :
                string.Empty;


        private void AppendTagChildren(StringBuilder sb, List<HtmlElement> tags, int intend)
        {
            foreach (var tag in tags)
            {
                sb.Append(tag.ToStringImp(intend));
            }
        }

        private string EndTag(int intend) =>
            HasContent() ?
                $"{PutIntend(intend)}</{_name}>\r\n" :
                string.Empty;

        private bool HasContent() =>
            HasText() || HasChild();

        private bool HasText() =>
            !string.IsNullOrWhiteSpace(_text);

        private bool HasChild() =>
            _elements.Count >= 1;
        private string PutAttributes()
        {
            var result = new StringBuilder();
            foreach (var attribute in _attributes)
            {
                var value = string.IsNullOrWhiteSpace(attribute.Value) ?
                    $" {attribute.Name}" :
                    $" {attribute.Name}=\"{attribute.Value}\"";

                result.Append(value);
            }
            return result.ToString();
        }

        public override string ToString() =>
            ToStringImp(0);

        private string PutIntend(int intend) =>
            new string(' ', intend * IntendSize);
    }

    public class HtmlAttibuteElement
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public HtmlAttibuteElement(string name)
        {
            Name = name;
        }

        public HtmlAttibuteElement(string name, string value) : this(name)
        {
            Value = value;
        }
    }
}
