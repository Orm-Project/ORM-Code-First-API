using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ORM_Code_First_API.Context;
using ORM_Code_First_API.DTO;
using ORM_Code_First_API.Models;
using ORM_Code_First_API.Returns;

namespace ORM_Code_First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ORMContext _context;

        public DepartmentsController(ORMContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<Department>> GetDepartments()
        {
            try
            {
                var returnlist = _context.Departments.ToList();
                //.FromSqlRaw($"EXEC GetDepartments")
                //.ToListAsync();
                //.ExecuteSqlInterpolatedAsync($"EXEC GetDepartments");

                if (returnlist == null || returnlist.Count == 0)
                {
                    string notFound = "Ingen data";
                    return BadRequest($"An error occurred: {notFound}");
                }

                return Ok(returnlist);
            }
            catch (SqlException sqlEx)
            {
                // Log the SQL exception details
                return StatusCode(500, $"SQL Exception: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Log the general exception details
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<OkMessage>> PostDepartment(DepartmentDTO req)
        {
            try
            {
                var affectedRows = await _context.Database
                    .ExecuteSqlInterpolatedAsync($"EXEC CreateDepartment {req.DepartmentName}");
                //.FromSqlRaw($"EXEC GetDepartments")
                //.ToListAsync();
                //.ExecuteSqlInterpolatedAsync($"EXEC GetDepartments");

                if (affectedRows > 0)
                {
                    await _context.SaveChangesAsync(); // Save changes to the database
                    OkMessage okMessage = new OkMessage() { Message = "Created" };
                    return Ok(okMessage);
                }
                else
                {
                    // Return not found, if there no item found
                    return NotFound("No changes applied.");
                }
            }
            catch (SqlException sqlEx)
            {
                // Log the SQL exception details
                return StatusCode(500, $"SQL Exception: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Log the general exception details
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
