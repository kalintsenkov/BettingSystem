namespace BettingSystem.Web.Common;

using System;
using System.IO;
using System.Threading.Tasks;
using Application.Common;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
    protected const string Id = "{id}";
    protected const string PathSeparator = "/";

    private IMediator? mediator;

    protected IMediator Mediator
        => this.mediator ??= this.HttpContext
            .RequestServices
            .GetService<IMediator>()!;

    protected Task<ActionResult<TResult>> Send<TResult>(
        IRequest<TResult> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult<TResult>> Send<TResult>(
        IRequest<Result<TResult>> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult> Send(
        IRequest<Result> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult> Send(
        IRequest<Stream> request)
    {
        var headers = this.Response.GetTypedHeaders();

        headers.CacheControl = new CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromDays(30)
        };

        headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));

        return this.Mediator.Send(request).ToActionResult();
    }
}