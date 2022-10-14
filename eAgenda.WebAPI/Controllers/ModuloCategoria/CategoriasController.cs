using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using eAgenda.WebAPI.ViewModels.ModuloCategoria;
using eAgenda.Aplicacao.ModuloDespesa;
using eAgenda.Dominio.ModuloDespesa;

namespace eAgenda.WebAPI.Controllers.ModuloCategoria
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : eAgendaControllerBase
    {
        private readonly ServicoCategoria servicoCategoria;
        private readonly IMapper mapeadorCategoria;

        public CategoriasController(ServicoCategoria servicoCategoria, IMapper mapeadorCategoria)
        {
            this.servicoCategoria = servicoCategoria;
            this.mapeadorCategoria = mapeadorCategoria;
        }

        [HttpPost]
        public ActionResult<FormsCategoriaViewModel> Inserir(InserirCategoriaViewModel categoriaVM)
        {
            var categoria = mapeadorCategoria.Map<Categoria>(categoriaVM);

            var categoriaResult = servicoCategoria.Inserir(categoria);

            if (categoriaResult.IsFailed)
                return InternalError(categoriaResult);

            return Ok(new
            {
                sucesso = true,
                dados = categoriaVM
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<FormsCategoriaViewModel> Editar(Guid id, EditarCategoriaViewModel categoriaVM)
        {
            var categoriaResult = servicoCategoria.SelecionarPorId(id);

            if (categoriaResult.IsFailed && RegistroNaoEncontrado(categoriaResult))
                return NotFound(categoriaResult);

            var categoria = mapeadorCategoria.Map(categoriaVM, categoriaResult.Value);

            categoriaResult = servicoCategoria.Editar(categoria);

            if (categoriaResult.IsFailed)
                return InternalError(categoriaResult);

            return Ok(new
            {
                sucesso = true,
                dados = categoriaVM
            });
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var categoriaResult = servicoCategoria.Excluir(id);

            if (categoriaResult.IsFailed && RegistroNaoEncontrado<Categoria>(categoriaResult))
                return NotFound(categoriaResult);

            if (categoriaResult.IsFailed)
                return InternalError<Categoria>(categoriaResult);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ListarCategoriaViewModel>> SelecionarTodos()
        {
            var categoriaResult = servicoCategoria.SelecionarTodos(UsuarioLogado.Id);

            if (categoriaResult.IsFailed)
                return InternalError(categoriaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCategoria.Map<List<ListarCategoriaViewModel>>(categoriaResult.Value)
            });
        }

        [HttpGet("visualizacao-completa/{id:guid}")]
        public ActionResult<VisualizarCategoriaViewModel> SelecionarCategoriaCompletaPorId(Guid id)
        {
            var categoriaResult = servicoCategoria.SelecionarPorId(id);

            if (categoriaResult.IsFailed && RegistroNaoEncontrado(categoriaResult))
                return NotFound(categoriaResult);

            if (categoriaResult.IsFailed)
                return InternalError(categoriaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCategoria.Map<VisualizarCategoriaViewModel>(categoriaResult.Value)
            });
        }

        [HttpGet("{id:guid}")]
        public ActionResult<FormsCategoriaViewModel> SelecionarCompromissoPorId(Guid id)
        {
            var categoriaResult = servicoCategoria.SelecionarPorId(id);

            if (categoriaResult.IsFailed && RegistroNaoEncontrado(categoriaResult))
                return NotFound(categoriaResult);

            if (categoriaResult.IsFailed)
                return InternalError(categoriaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorCategoria.Map<FormsCategoriaViewModel>(categoriaResult.Value)
            });
        }
    }
}
