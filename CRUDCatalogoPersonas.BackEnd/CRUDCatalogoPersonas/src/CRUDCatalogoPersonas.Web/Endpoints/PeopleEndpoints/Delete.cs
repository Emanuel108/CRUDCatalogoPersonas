using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CRUDCatalogoPersonas.Core.PeopleAggregate;
using CRUDCatalogoPersonas.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUDCatalogoPersonas.Web.Endpoints.PeopleEndpoints;

public class Delete : BaseAsyncEndpoint
    .WithRequest<DeletePeopleRequest>
    .WithoutResponse
{
    private readonly IRepository<People> _repository;

    public Delete(IRepository<People> repository)
    {
        _repository = repository;
    }

    [HttpDelete(DeletePeopleRequest.Route)]
    [SwaggerOperation(
        Summary = "Elimina una persona",
        Description = "Elimina una persona",
        OperationId = "People.Delete",
        Tags = new[] { "PeopleEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] DeletePeopleRequest request,
        CancellationToken cancellationToken)
    {
        var data = await _repository.GetByIdAsync(request.PeopleId); // TODO: pass cancellation token

        if (data == null) return NotFound();

        await _repository.DeleteAsync(data);

        var message = $"Se ha eliminado exitosamente el registro {data.Name}";

        return Ok(message);
    }
}
