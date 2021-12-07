#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using api_aula.webapi.Entities;
using api_aula.webapi.Extensions;
using api_aula.webapi.ProdutoController.Requests;
using api_aula.webapi.ProdutoController.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace api_aula.webapi.ProdutoController
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : ControllerBase 
    {
        public static List<Produto> _produtos = new List<Produto>();

        [HttpGet("{pId:int}")]
        [ProducesResponseType((StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProdutoResponse> Get(int pId)
        {
            var xResponse = _produtos.FirstOrDefault(p => p.Id == pId);
            if (xResponse == null)
            {
                return NotFound();
            }

            return Ok(xResponse);
        }

        [HttpGet]
        [ProducesResponseType((StatusCodes.Status200OK))]
        public ActionResult<List<ProdutoResponse>> Get()
        {
            var xProdutos = _produtos.ToListaProdutoResponse();

            return Ok(xProdutos);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProdutoResponse> Post([FromBody] ProdutoAdicionarRequest pProdutoAdicionarRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var xProduto = _produtos
                .AdicionarProdutoDeRequest(pProdutoAdicionarRequest)
                .GetUltimoProduto();

            return Created($"produtos/{xProduto.Id}", xProduto.ToResponse());
        }

        [HttpPut("{pId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int pId, [FromBody] ProdutoAtualizarRequest pProdutoAtualizarRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var xAtualizado = _produtos.TentaAtualizarProdutoDeRequest(pId, pProdutoAtualizarRequest);
            
            if (!xAtualizado)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpDelete("{pId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int pId)
        {
            var xDeletado = _produtos.TentaDeletar(pId);
            
            if (!xDeletado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}