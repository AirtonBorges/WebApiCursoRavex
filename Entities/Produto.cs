#nullable enable
using System;

namespace api_aula.webapi.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string? Descricao { get; set; }
        
        public decimal Valor { get; set; }
    }
}