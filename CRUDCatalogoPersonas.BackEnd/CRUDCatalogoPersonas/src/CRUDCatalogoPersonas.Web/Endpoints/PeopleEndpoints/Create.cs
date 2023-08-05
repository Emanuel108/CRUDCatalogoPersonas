using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CRUDCatalogoPersonas.Core.PeopleAggregate;
using CRUDCatalogoPersonas.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUDCatalogoPersonas.Web.Endpoints.PeopleEndpoints;

public class Create : BaseAsyncEndpoint
    .WithRequest<CreatePeopleRequest>
    .WithResponse<CreatePeopleResponse>
{
    private readonly IRepository<People> _repository;

    public Create(IRepository<People> repository)
    {
        _repository = repository;
    }

    [HttpPost("/People")]
    [SwaggerOperation(
        Summary = "Crear una nueva persona",
        Description = "API para crear una nueva persona",
        OperationId = "People.Create",
        Tags = new[] { "PeopleEndpoints" })
    ]
    public override async Task<ActionResult<CreatePeopleResponse>> HandleAsync(CreatePeopleRequest request,
        CancellationToken cancellationToken)
    {
        var data = new People(request.Name, request.LastName, request.Address, request.Email, request.Phone, request.Gender);

        var createdItem = await _repository.AddAsync(data);

        var response = new CreatePeopleResponse
        {
            Id = createdItem.Id,
            Name = createdItem.Name,
            Message = "Se ha creado exitosamente el nuevo registro."
        };

        return Ok(response);
    }
}
