﻿using Lvmendes.AEC.Base.Entidade;
using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Base.Servico.Interfaces;
using Lvmendes.AEC.Base.WebApi.Model;
using Lvmendes.AEC.Comum.Entidades;
using Lvmendes.AEC.Comum.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lvmendes.AEC.Base.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService servico;
      

        public EnderecoController(IEnderecoService _servico)
        {
            servico = _servico;
        }
        [HttpPost("Salvar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public ActionResult<RetornoApi> Salvar(EnderecoModel item)
        {
            var endereco = ModelEntidade._RecuperarEndereco(item);

            var retornoChamado = servico.Adicionar(endereco);
            return new RetornoApi
            {
                Resultado = true,
                Status = retornoChamado == "Ok",
                Mensagem = retornoChamado == "Ok" ? "Cadastrado com Sucesso!" : retornoChamado

            };
        }


        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("Lista")]
        [Authorize]
        public ActionResult<RetornoApi> Lista(bool todos)
        {
            var retornoChamado = servico.ObterTodos(todos);
            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "EnderecoEntidades não Encontrado" : string.Empty

            };
            return retorno;
        }

        [HttpPut("Atualizar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public ActionResult<RetornoApi> Atualizar(EnderecoEntidade item)
        {
            var retornoChamado = servico.Atualizar(item);
            return new RetornoApi
            {
                Resultado = true,
                Status = retornoChamado == "Atualizar com sucesso!!",
                Mensagem = retornoChamado

            };
        }

        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("Carregar")]
        [Authorize]
        public ActionResult<RetornoApi> Carregar(Int64 Id)
        {
            var retornoChamado = servico.Primeiro(s=>s.Id ==Id);
            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "Item não Encontrado" : string.Empty

            };
            return retorno;
        }


        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("ObterDadosAtravesCep")]
        [Authorize]
        public ActionResult<RetornoApi> ObterDadosAtravesCep(string cep)
        {
            var endereco  = servico.ObterDadosAtravesCep(cep);


            var retornoChamado = ModelEntidade._RecuperarEndereco(endereco);


            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "Item não Encontrado" : string.Empty

            };
            return retorno;
        }

        
    }
}