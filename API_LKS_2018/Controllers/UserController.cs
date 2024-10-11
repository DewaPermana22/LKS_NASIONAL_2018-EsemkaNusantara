    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using API_LKS_2018.Data;
    using API_LKS_2018.Models;
    using System.Linq;

    namespace API_LKS_2018.Controllers
    {
        [Route("SMK_RESTAURANT/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly AppDBContext _context;

            public UserController(AppDBContext context)
            {
                _context = context;
            }

            // LOGIN
            [HttpPost("login")]
            public IActionResult Login([FromBody] Employe employe)
            {
                // Cek apakah email dan password ada
                if (employe == null || string.IsNullOrEmpty(employe.Email) || string.IsNullOrEmpty(employe.Password))
                {
                    return BadRequest("Email and Password Required!");
                }

                // Cari employee berdasarkan email dan password
                var employee = _context.MsEmploye
                    .FirstOrDefault(e => e.Email == employe.Email && e.Password == employe.Password);

                // Jika ditemukan
                if (employee != null)
                {
                var id = employee.EmployeId;// Otomatis mengambil EmployeId

                    return Ok(new { Message = "Login Successful!", EmployeId = id });
                }
                else
                {
                    // Jika tidak ditemukan
                    return Unauthorized(new { Message = "Invalid Email or Password" });
                }
            }

        }
    }
