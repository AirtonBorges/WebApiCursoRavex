#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using api_aula.webapi.ProdutoController.Responses;

namespace api_aula.webapi.ProdutoController.Requests
{
    public class ProdutoAdicionarRequest
    {
        [Required]
        [MaxLength(2000)]
        public string Nome { get; set; }

        [MaxLength(2000)]
        public string? Descricao { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Valor { get; set; }
    }
}