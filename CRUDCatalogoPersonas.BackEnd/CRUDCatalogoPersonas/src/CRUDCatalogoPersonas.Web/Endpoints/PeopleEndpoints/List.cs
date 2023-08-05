using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CRUDCatalogoPersonas.Core.PeopleAggregate;
using CRUDCatalogoPersonas.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUDCatalogoPersonas.Web.Endpoints.PeopleEndpoints;

public class List : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<PeopleListResponse>
{
    private readonly IReadRepository<People> _repository;

    public List(IReadRepository<People> repository)
    {
        _repository = repository;
    }

    [HttpGet("/People")]
    [SwaggerOperation(
        Summary = "Obtener lista de personas",
        Description = "Obtener lista de personas",
        OperationId = "People.List",
        Tags = new[] { "PeopleEndpoints" })
    ]
    public override async Task<ActionResult<PeopleListResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var data = new PeopleListResponse();
        data.People = (await _repository.ListAsync()) // TODO: pass cancellation token
            .Select(people => new PeopleRecord(people.Id, people.Name, people.LastName, people.Address, people.Email, people.Phone, people.Gender))
            .ToList();

        return Ok(data);
    }
}
