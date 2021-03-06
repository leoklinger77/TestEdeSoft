using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Test.Models.ManyToMany;

namespace Test.Models
{
    public class Donos : Entity
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres e minimo de 2", MinimumLength = 2)]
        public string Nome { get; set; }

        public IEnumerable<CaesDono> CaesDono { get; set; } = new List<CaesDono>();

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