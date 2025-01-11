using CrudOperationCore.Data;
using CrudOperationCore.Models;
using CrudOperationCore.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CrudOperationCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CrudController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dbContext.CrudOperations.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetByID(Guid id)
        {
            var dataid = dbContext.CrudOperations.Find(id);


            //if(dataid is null) 
            //{ 
            //    return NotFound();
            //}
            return Ok(dataid);
        }

        [HttpPost]

        public IActionResult Add(AddCrudOperationDto addCrudOperationDto)
        {
            var adddata = new CrudOperation()
            {
                Name = addCrudOperationDto.Name,
                Email = addCrudOperationDto.Email,
                Phone = addCrudOperationDto.Phone,
                Salary = addCrudOperationDto.Salary
            };

            dbContext.CrudOperations.Add(adddata);
            dbContext.SaveChanges();

            return Ok(new { message = "Data has been added successfully.", data = adddata });
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateCrud(Guid id, UpdateCrudOperation updateCrudOperation)
        {
            var dataupdate = dbContext.CrudOperations.Find(id);

            if (dataupdate is null)
            {
                return NotFound(new { message = $"Record with ID {id} not found." });
            }

            // Update the fields
            dataupdate.Name = updateCrudOperation.Name;
            dataupdate.Email = updateCrudOperation.Email;
            dataupdate.Phone = updateCrudOperation.Phone;
            dataupdate.Salary = updateCrudOperation.Salary;

            dbContext.SaveChanges();

            return Ok(new { message = $"Record with ID {id} has been updated successfully.", data = dataupdate });
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var deleteCrudopration = dbContext.CrudOperations.Find(id);
            if (deleteCrudopration is null)
            {
                return NotFound(new { message = $"Record with ID {id} not found." });
            }

            dbContext.CrudOperations.Remove(deleteCrudopration);
            dbContext.SaveChanges();

            return Ok(new { message = $"Record with ID {id} has been deleted successfully." });
        }

    }
}
