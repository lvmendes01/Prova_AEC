using Lvmendes.AEC.Base.Entidade;
using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Base.Servico.Interfaces;
using Lvmendes.AEC.Base.WebApi.Model;
using Lvmendes.AEC.Comum.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lvmendes.AEC.Base.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService servico;

        public UsuarioController(IUsuarioService _servico)
        {
            servico = _servico;

        }

      

        [HttpPost("Salvar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Salvar(UsuarioModel payload)
        {

            var retornoChamado = servico.Adicionar(new UsuarioEntidade
            {
                nome = payload.nome,
                Senha = payload.Senha,
                usuario = payload.usuario
            }); ;
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
            var usuarioretorno = new List<RetornoUsuario>();
            var retornoChamado = servico.ObterTodos(todos);



            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado != null? usuarioretorno: null,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "UsuarioEntidades não Encontrado" : string.Empty

            };
            return retorno;
        }

        [HttpPut("Atualizar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public ActionResult<RetornoApi> Atualizar(UsuarioEntidade item)
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
    }
}
