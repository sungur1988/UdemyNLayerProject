using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.DTOs;
using UdemyNLayerProject.Core.Entities;
using UdemyNLayerProject.Core.Services;


namespace UdemyNLayerProject.API.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class ,IEntity,new()
    {
        private IService<TEntity> _service;
        public NotFoundFilter(IService<TEntity> service)
        {
            _service = service;

        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _service.GetByIdAsync(id);
            if (product !=null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.StatusCode = 404;
                errorDto.Errors.Add($"id'si {id} olan ürün  veritabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
