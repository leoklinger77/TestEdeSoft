namespace DogAndPeoples.Models
{
    public class Donos : Entity
    {        
        public string Nome { get; set; }

        public Donos() : base() { }

        public Donos(int id, string nome): base(id)
        {
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            return obj is Donos donos &&
                   Id == donos.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}