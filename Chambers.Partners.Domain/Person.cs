namespace Chambers.Partners.Domain
{
    public abstract class Person
    {
        public Person(int identity, string name)
        {
            Identity = identity;
            Name = name;
        }

        public int Identity { get; }
        public string Name { get; }
    }
}
