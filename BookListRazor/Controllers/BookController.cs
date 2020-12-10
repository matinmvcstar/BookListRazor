using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<BookController> _logger;

        public BookController(ApplicationDbContext db, ILogger<BookController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Books.ToList() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Books.FirstOrDefaultAsync(u => u.Id == id);
            if(bookFromDb == null)
            {
                return Json(new { success = false, message = "حذف فایل امکان پذیر نیست" });
            }
            else
            {
                _db.Books.Remove(bookFromDb);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "حذف انجام شد" });
            }
        }
    }
}
