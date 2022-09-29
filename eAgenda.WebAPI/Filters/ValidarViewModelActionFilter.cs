using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace eAgenda.WebAPI.Filters
{
    public class ValidarViewModelActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) // Executando
        {
            if (!context.ModelState.IsValid)
            {
                var listaErros = context.ModelState
                .Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);
                context.Result = new BadRequestObjectResult(new
                {
                    sucesso = false,
                    erros = listaErros.ToList()
                });

                return; // Cancela a execução do Inserir, Editar...
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) // Depois de executada
        {
        }
    }
}
