using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Havan.Ecommerce.Padronizacao.Back.Dominio
{
    public class FiltroDeBuscaPizzasModelo
    {
        [Required(ErrorMessage = "É preciso passar uma lista de ids para executar a busca")]
        public List<long> Ids { get; set; }
    }
}
