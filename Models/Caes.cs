using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Test.Models.ManyToMany;

namespace Test.Models
{
    public class Caes : Entity
    {        
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres e minimo de 2", MinimumLength = 2) ]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres e minimo de 2", MinimumLength = 2)]
        public string Raca { get; set; }        
        public IEnumerable<CaesDono> CaesDono { get; set; } = new List<CaesDono>();

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