namespace OstreC.Services
{
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }

        public static implicit operator Option(List<Option> v)
        {
            throw new NotImplementedException();
        }
    }
}