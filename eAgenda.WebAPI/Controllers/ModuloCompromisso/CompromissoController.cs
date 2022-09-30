using AutoMapper;
using eAgenda.Aplicacao.ModuloCompromisso;
using eAgenda.Aplicacao.ModuloContato;
using eAgenda.Dominio.ModuloCompromisso;
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
        private readonly IMapper mapeadorCompromisso;
        public CompromissoController(ServicoCompromisso servicoCompromisso, IMapper mapeadorCompromisso)
        {
            this.servicoCompromisso = servicoCompromisso;
            this.mapeadorCompromisso = mapeadorCompromisso;
        }

        [HttpPost]
        public ActionResult<FormsCompromissoViewModel> Inserir(InserirCompromissoViewModel compromissoVM)
        {
            var compromisso = mapeadorCompromisso.Map<Compromisso>(compromissoVM);

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
                return InternalError<Compromisso>(compromissoResult);

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

        [HttpGet("visualizacao-completa/{id:guid}")]
        public ActionResult<VisualizarCompromissoViewModel> SelecionarCompromissoCompletoPorId(Guid id)
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

        [HttpGet("{id:guid}")]
        public ActionResult<FormsCompromissoViewModel> SelecionarCompromissoPorId(Guid id)
        {
            var compromissoResult = servicoCompromisso.SelecionarPorId(id);

            if (compromissoResult.IsFailed && RegistroNaoEncontrado(compromissoResult))
                return NotFound(compromissoResult);

            if (compromissoResult.IsFailed)
                return InternalError(compromissoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCompromisso.Map<FormsCompromissoViewModel>(compromissoResult.Value)
            });
        }

        [HttpGet, Route("entre/{dataInicial:datetime}/{dataFinal:datetime}")] // Nomes iguais aos parâmetros para que seja feita a bind
        public ActionResult<List<ListarCompromissoViewModel>> SelecionarCompromissosFuturos(DateTime dataInicial, DateTime dataFinal)
        {
            var compromissoResult = servicoCompromisso.SelecionarCompromissosFuturos(dataInicial, dataFinal);

            if (compromissoResult.IsFailed)
                return InternalError(compromissoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCompromisso.Map<List<ListarCompromissoViewModel>>(compromissoResult.Value)
            });
        }

        [HttpGet, Route("passados/{dataAtual:datetime}")]
        public ActionResult<List<ListarCompromissoViewModel>> SelecionarCompromissosPassados(DateTime dataAtual)
        {
            var compromissoResult = servicoCompromisso.SelecionarCompromissosPassados(dataAtual);

            if (compromissoResult.IsFailed)
                return InternalError(compromissoResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCompromisso.Map<List<ListarCompromissoViewModel>>(compromissoResult.Value)
            });
        }
    }
}

