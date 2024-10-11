using API_LKS_2018.Data;
using API_LKS_2018.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LKS_2018.Controllers
{
    [Route("SMK_RESTAURANT/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PackageController(AppDBContext context)
        {
            _context = context;
        }

        //GET PACKAGE
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> getPackage()
        {
            return await _context.Packages.ToListAsync();
        }
    }
}
