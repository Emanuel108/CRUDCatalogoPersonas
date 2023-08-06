using CRUDCatalogoPersonas.Core.PeopleAggregate;
using CRUDCatalogoPersonas.SharedKernel.Interfaces;
using CRUDCatalogoPersonas.Web.ApiModels;
using CRUDCatalogoPersonas.Web.Endpoints.PeopleEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRUDCatalogoPersonas.Web.Api
{
    public class PeopleController : BaseApiController
    {
        private readonly IRepository<People> _repository;

        public PeopleController(IRepository<People> repository)
        {
            _repository = repository;
        }

        // GET: api/People
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = (await _repository.ListAsync())
                .Select(people => new PeopleDTO
                {
                    Id = people.Id,
                    Name = people.Name,
                    LastName = people.LastName, 
                    Address = people.Address,   
                    Email = people.Email,   
                    Phone = people.Phone,   
                    Gender = people.Gender

                })
                .ToList();

            return Ok(data);
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePeopleRequest request)
        {
            var data = new People(request.Name, request.LastName, request.Address, request.Email, request.Phone, request.Gender);

            var response = await _repository.AddAsync(data);

            var result = new PeopleDTO
            {
                Id = response.Id,
                Name = response.Name
            };

            return Ok(result);
        }

        // PUT: api/People
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePeopleRequest request)
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

        // DELETE: api/People
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePeopleRequest request)
        {
            var data = await _repository.GetByIdAsync(request.PeopleId); 

            if (data == null) return NotFound();

            await _repository.DeleteAsync(data);

            var message = $"Se ha eliminado exitosamente el registro {data.Name}";

            return Ok(message);
        }
    }


}
