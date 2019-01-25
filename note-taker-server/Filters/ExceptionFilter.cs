using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using note_taker_server.CustomExceptions;

namespace note_taker_server.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute
		{

		public override void OnException(ExceptionContext context)
		{
			if(context.Exception is EntityNotExistException)
			{
				EntityNotExistException ex = (EntityNotExistException)context.Exception;
				context.Result = new NotFoundObjectResult(ex.message);
			}
		}
}
}
