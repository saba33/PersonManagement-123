﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonManagement.Services.Exceptions;
using System;
using System.Net;

namespace PersonManagement.Web
{
    public class ApiError : ProblemDetails
    {
        public const string UnhandledError = "UnhandledException";
        private HttpContext _context;
        private Exception _exception;

        public LogLevel LogLevel { get; set; }
        public string Code { get; set; }
        public string TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                {
                    return (string)traceId;
                }

                return null;
            }
            set => Extensions["TraceId"] = value;
        }

        public ApiError(HttpContext context, Exception exception)
        {
            _context = context;
            _exception = exception;

            TraceId = context.TraceIdentifier;
            Code = "UnhandledErrorCode";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Instance = context.Request.Path;
            Status = Status = (int)HttpStatusCode.InternalServerError;

            HandleException((dynamic)exception);
        }

        private void HandleException(ObjectNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Trace;
        }

        private void HandleException(ObjectAlreadyExistsException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(Exception exception)
        {

        }
    }
}
