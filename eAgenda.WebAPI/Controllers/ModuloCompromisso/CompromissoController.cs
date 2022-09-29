using AutoMapper;
using eAgenda.Aplicacao.ModuloCompromisso;
using eAgenda.Aplicacao.ModuloContato;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.WebAPI.ViewModels.ModuloCompromisso;
using eAgenda.WebAPI.ViewModels.ModuloContato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eAgenda.WebAPI.Controllers.ModuloCompromisso
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompromissoController : eAgendaControllerBase
    {
        private readonly ServicoCompromisso servicoCompromisso;
        private readonly ServicoContato servicoContato;
        private readonly IMapper mapeadorCompromisso;
        public CompromissoController(ServicoCompromisso servicoCompromisso, ServicoContato servicoContato, IMapper mapeadorCompromisso)
        {
            this.servicoCompromisso = servicoCompromisso;
            this.servicoContato = servicoContato;
            this.mapeadorCompromisso = mapeadorCompromisso;
        }

        [HttpPost]
        public ActionResult<FormsCompromissoViewModel> Inserir(InserirCompromissoViewModel compromissoVM)
        {
            var compromisso = mapeadorCompromisso.Map<Compromisso>(compromissoVM);

            compromisso.Contato = servicoContato.SelecionarPorId(compromissoVM.ContatoId).Value;

            compromisso.UsuarioId = UsuarioLogado.Id;

            var compromissoResult = servicoCompromisso.Inserir(compromisso);

            if (compromissoResult.IsFailed)
                return InternalError(compromissoResult);

            return Ok(new
            {
                sucesso = true,
                dados = compromissoVM
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<FormsCompromissoViewModel> Editar(Guid id, EditarCompromissoViewModel compromissoWM)
        {
            var compromissoResult = servicoCompromisso.SelecionarPorId(id);

            if (compromissoResult.IsFailed && RegistroNaoEncontrado(compromissoResult))
                return NotFound(compromissoResult);

            var contato = mapeadorCompromisso.Map(compromissoWM, compromissoResult.Value);

            compromissoResult = servicoCompromisso.Editar(contato);

            if (compromissoResult.IsFailed)
                return InternalError(compromissoResult);

            return Ok(new
            {
                sucesso = true,
                dados = compromissoWM
            });
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var compromissoResult = servicoCompromisso.Excluir(id);

            if (compromissoResult.IsFailed && RegistroNaoEncontrado<Compromisso>(compromissoResult))
                return NotFound(compromissoResult);

            if (compromissoResult.IsFailed)
                return InternalError<Tarefa>(compromissoResult);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ListarCompromissoViewModel>> SelecionarTodos()
        {
            var compromissoResult = servicoCompromisso.SelecionarTodos(UsuarioLogado.Id);

            if (compromissoResult.IsFailed)
                return InternalError(compromissoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCompromisso.Map<List<ListarCompromissoViewModel>>(compromissoResult.Value)
            });
        }

        [HttpGet("visualizar-completo/{id:guid}")]
        public ActionResult<VisualizarCompromissoViewModel> SelecionarTarefaCompletaPorId(Guid id)
        {
            var compromissoResult = servicoCompromisso.SelecionarPorId(id);

            if (compromissoResult.IsFailed && RegistroNaoEncontrado(compromissoResult))
                return NotFound(compromissoResult);

            if (compromissoResult.IsFailed)
                return InternalError(compromissoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCompromisso.Map<VisualizarCompromissoViewModel>(compromissoResult.Value)
            });
        }
    }
}

