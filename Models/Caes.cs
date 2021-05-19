namespace Test.Models
{
    public class Caes : Entity
    {        
        public string Nome { get; set; }
        public string Raca { get; set; }
        public Caes() : base() { }
        
        public Caes(int id, string nome, string raca) : base(id)
        {            
            Nome = nome;
            Raca = raca;
        }

        public override bool Equals(object obj)
        {
            return obj is Caes caes &&
                   Id == caes.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}