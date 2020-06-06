using System.Threading.Tasks;
using jovens_ambientalistas_net_core.Di;
using jovens_ambientalistas_net_core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace jovens_ambientalistas_net_core.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController: InjectedController
    {
        public ProductController(Database context) : base(context) { }

        // Get department with given id.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await db.Product.FindAsync(id);
            if (department == default(Product))
            {
                return NotFound();
            }
            return Ok(department);
        }

        // Add a department to db.
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Product department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await db.Product.AddAsync(department);
            await db.SaveChangesAsync();
            return Ok(department.ID);
        }
    }
    
    // Helper class to take care of db context injection.
    public class InjectedController: ControllerBase
    {
        protected readonly Database db;

        public InjectedController(Database context)
        {
            db = context;
        }
    }
}