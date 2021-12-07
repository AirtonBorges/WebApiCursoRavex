#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using api_aula.webapi.Entities;

namespace api_aula.webapi.ProdutoController.Responses
{
    public class ProdutoResponse
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(2000)]
        public string Nome { get; set; }

        [MaxLength(2000)]
        public string? Descricao { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Valor { get; set; }

        public static Produto Mapper(ProdutoResponse pProdutoResponse)
        {
            var xId = ProdutoController._produtos.Count + 1;
            var xProduto = new Produto {
                Id =  xId,
                Nome = pProdutoResponse.Nome,
                Descricao = pProdutoResponse.Descricao,
                Valor = pProdutoResponse.Valor
            };

            return xProduto;
        }
    }
}