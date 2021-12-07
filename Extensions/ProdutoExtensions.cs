using api_aula.webapi.Entities;
using api_aula.webapi.ProdutoController.Requests;
using api_aula.webapi.ProdutoController.Responses;

namespace api_aula.webapi.Extensions
{
    public static class ProdutoExtensions
    {
        public static ProdutoResponse ToResponse(this Produto pProduto)
        {
            return new ProdutoResponse()
            {
                Id = pProduto.Id,
                Nome = pProduto.Nome,
                Descricao = pProduto.Descricao,
                Valor = pProduto.Valor
            };
        }
        public static ProdutoAdicionarRequest ToAdicionarRequest(this Produto pProduto)
        {
            return new ProdutoAdicionarRequest()
            {
                Nome = pProduto.Nome,
                Descricao = pProduto.Descricao,
                Valor = pProduto.Valor
            };
        }
    }
}