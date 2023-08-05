namespace CRUDCatalogoPersonas.Web.Endpoints.PeopleEndpoints;

public class DeletePeopleRequest
{
    public const string Route = "/People/{PeopleId:int}";
    public static string BuildRoute(int peopleId) => Route.Replace("{PeopleId:int}", peopleId.ToString());

    public int PeopleId { get; set; }
}
