using System;
using LibraryClass.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Net;
using System.Text.Json;

namespace MainProject.API.MiddleWare
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Call _next when ready to continue to next pipeline step
            // Code before _next call will be processed when the pipeline is handling the initial request
            // Code after _next call will be processed when the pipeline is handling the response
            try
            {
                await _next(context);
            }
            catch (Exception err)
            {
                // Get the response object so we can edit it
                var response = context.Response;
                response.ContentType = "application/json";
                string errorMessage;

                switch (err)
                {

                    case NotFoundException e: // Handles all NotFoundExceptions thrown by the system
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorMessage = e.Message;
                        break;
                    case DbUpdateException: // Handles all DbUpdateExceptions and DbUpdateConcurrencyExceptions thrown by the system
                    case PostgresException: // Handles general Postgres database connection exceptions
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "We're sorry, we were unable to complete your request, please try again later";
                        break;
                    default: // Some unknown error. We want to prevent generic 500 errors from being returned.
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "We're sorry, your request could not be completed";
                        break;
                }

                // Return the response
                var result = JsonSerializer.Serialize(new { message = errorMessage });
                await response.WriteAsync(result);
            }
        }
    }
}
