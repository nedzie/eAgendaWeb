using AutoMapper;
using eAgenda.Aplicacao.ModuloContato;
using eAgenda.Dominio.ModuloContato;
using eAgenda.WebAPI.ViewModels.ModuloContato;
using eAgenda.WebAPI.ViewModels.ModuloTarefa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eAgenda.WebAPI.Controllers.ModuloContato
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContatoController : eAgendaControllerBase
    {
        private readonly ServicoContato servicoContato;
        private readonly IMapper mapeadorContato;

        public ContatoController(ServicoContato servicoContato, IMapper mapeadorContato)
        {
            this.servicoContato = servicoContato;
            this.mapeadorContato = mapeadorContato;
        }

        [HttpPost]
        public ActionResult<FormsContatoViewModel> Inserir(InserirContatoViewModel contatoVM)
        {
            var contato = mapeadorContato.Map<Contato>(contatoVM);

            var contatoResult = servicoContato.Inserir(contato);

            if (contatoResult.IsFailed)
                return InternalError(contatoResult);

            return Ok(new
            {
                sucesso = true,
                dados = contatoVM
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<FormsContatoViewModel> Editar(Guid id, EditarContatoViewModel contatoVM)
        {
            var contatoResult = servicoContato.SelecionarPorId(id);

            if (contatoResult.IsFailed && RegistroNaoEncontrado(contatoResult))
                return NotFound(contatoResult);

            var contato = mapeadorContato.Map(contatoVM, contatoResult.Value);

            contatoResult = servicoContato.Editar(contato);

            if (contatoResult.IsFailed)
                return InternalError(contatoResult);

            return Ok(new
            {
                sucesso = true,
                dados = contatoVM
            });
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var contatoResult = servicoContato.Excluir(id);

            if (contatoResult.IsFailed && RegistroNaoEncontrado<Contato>(contatoResult))
                return NotFound(contatoResult);

            if (contatoResult.IsFailed)
                return InternalError<Contato>(contatoResult);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ListarTarefaViewModel>> SelecionarTodos()
        {
            var contatoResult = servicoContato.SelecionarTodos(UsuarioLogado.Id);

            if (contatoResult.IsFailed)
                return InternalError(contatoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorContato.Map<List<ListarContatoViewModel>>(contatoResult.Value)
            });
        }

        [HttpGet("visualizar-completo/{id:guid}")]
        public ActionResult<VisualizarTarefaViewModel> SelecionarTarefaCompletaPorId(Guid id)
        {
            var contatoResult = servicoContato.SelecionarPorId(id);

            if (contatoResult.IsFailed && RegistroNaoEncontrado(contatoResult))
                return NotFound(contatoResult);

            if (contatoResult.IsFailed)
                return InternalError(contatoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorContato.Map<VisualizarContatoViewModel>(contatoResult.Value)
            });
        }
    }
}
