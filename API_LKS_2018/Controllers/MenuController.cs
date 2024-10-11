using API_LKS_2018.Data;
using API_LKS_2018.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LKS_2018.Controllers
{
    [Route("SMK_RESTAURANT/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly AppDBContext _Context;

        public MenuController(AppDBContext context)
        {
            _Context = context;
        }

        //GET ALL MENU
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GettAllMenu()
        {
            return await _Context.MsMenu.ToListAsync();
        }                              
    }
}
