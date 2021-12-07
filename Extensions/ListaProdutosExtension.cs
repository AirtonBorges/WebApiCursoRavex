using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using api_aula.webapi.Entities;
using api_aula.webapi.ProdutoController.Requests;
using api_aula.webapi.ProdutoController.Responses;

namespace api_aula.webapi.Extensions
{
    public static class ListaProdutosExtension
    {
        public static List<Produto> AdicionarProdutoDeRequest(this List<Produto> pListaProdutos, ProdutoAdicionarRequest pProdutoAdicionarRequest)
        {
            pListaProdutos.Add(new Produto
            {
                Id = pListaProdutos.Count + 1,
                Nome = pProdutoAdicionarRequest.Nome,
                Descricao = pProdutoAdicionarRequest.Descricao,
                Valor = pProdutoAdicionarRequest.Valor
            });

            return pListaProdutos;
        }

        public static bool TentaAtualizarProdutoDeRequest(this List<Produto> pListaProdutos, int pId,
            ProdutoAdicionarRequest pProdutoAdicionarRequest)
        {
            var xPersistido = pListaProdutos.FirstOrDefault(p => p.Id == pId);
            if (xPersistido is null)
                return false;

            xPersistido.Nome = pProdutoAdicionarRequest.Nome;
            xPersistido.Descricao = pProdutoAdicionarRequest.Descricao;
            xPersistido.Valor = pProdutoAdicionarRequest.Valor;

            return true;
        }

        public static Produto GetUltimoProduto(this List<Produto> pListaProdutos)
        {
            return pListaProdutos.Last();
        }

        public static List<ProdutoResponse> ToListaProdutoResponse(this List<Produto> pListaProdutos)
        {
            var pListaProdutoResponse = pListaProdutos.Select(p => p.ToResponse()).ToList();

            return pListaProdutoResponse;
        }

        public static bool TentaDeletar(this List<Produto> pListaProdutos, int pId)
        {
            var xRetorno = false;
            
            var xPedido = pListaProdutos.FirstOrDefault(p => p.Id == pId);

            if (!(xPedido is null))
                xRetorno = true;

            var xDeletou = pListaProdutos.Remove(xPedido);

            if (!xDeletou)
                xRetorno = true;

            return xRetorno;
        }
    }
}