using System.Collections.Generic;

namespace CRUDCatalogoPersonas.Web.Endpoints.PeopleEndpoints;

public class PeopleListResponse
{
    public List<PeopleRecord> People { get; set; } = new();
}
