namespace Test.Models.ManyToMany
{
    public class CaesDono
    {
        public Caes Caes { get; set; }        
        public int CaesId { get; set; }
        public Donos Donos { get; set; }        
        public int DonosId { get; set; }

        public CaesDono() { }
        
        public CaesDono(Caes caes, Donos donos)
        {
            Caes = caes;
            Donos = donos;
        }
    }
}