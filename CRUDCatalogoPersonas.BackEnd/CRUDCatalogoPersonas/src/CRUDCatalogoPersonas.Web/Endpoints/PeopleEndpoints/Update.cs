using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CRUDCatalogoPersonas.Core.PeopleAggregate;
using CRUDCatalogoPersonas.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUDCatalogoPersonas.Web.Endpoints.PeopleEndpoints;

public class Update : BaseAsyncEndpoint
    .WithRequest<UpdatePeopleRequest>
    .WithResponse<UpdatePeopleResponse>
{
    private readonly IRepository<People> _repository;

    public Update(IRepository<People> repository)
    {
        _repository = repository;
    }

    [EnableCors("CORS")]
    [HttpPut(UpdatePeopleRequest.Route)]
    [SwaggerOperation(
        Summary = "Actualiza los datos de una persona",
        Description = "Actualiza los datos de una persona",
        OperationId = "People.Update",
        Tags = new[] { "PeopleEndpoints" })
    ]
    public override async Task<ActionResult<UpdatePeopleResponse>> HandleAsync(UpdatePeopleRequest request,
        CancellationToken cancellationToken)
    {
        var data = await _repository.GetByIdAsync(request.Id);

        if (data == null) return NotFound();

        data.UpdatePeople(request.Name, request.LastName, request.Address, request.Email, request.Phone, request.Gender);

        await _repository.UpdateAsync(data);

        var response = new UpdatePeopleResponse()
        {
            People = new PeopleRecord(data.Id, data.Name, data.LastName, data.Address, data.Email, data.Phone, data.Gender)
        };

        return Ok(response);
    }
}
