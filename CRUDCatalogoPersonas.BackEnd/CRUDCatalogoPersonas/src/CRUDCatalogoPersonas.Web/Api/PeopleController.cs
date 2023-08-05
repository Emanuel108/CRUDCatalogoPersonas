using CRUDCatalogoPersonas.Core.PeopleAggregate;
using CRUDCatalogoPersonas.SharedKernel.Interfaces;
using CRUDCatalogoPersonas.Web.ApiModels;
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

        /*
        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectDTO request)
        {
            var newProject = new Project(request.Name);

            var createdProject = await _repository.AddAsync(newProject);

            var result = new ProjectDTO
            {
                Id = createdProject.Id,
                Name = createdProject.Name
            };
            return Ok(result);
        }*/
    }


}
