using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly BrickDbContext _context;
        string pathForPictures;

        public BlogController(BrickDbContext context, IConfiguration configuration) {
            _context = context;
            this.pathForPictures = configuration["ApplicationSettings:PathForPictures"];

        }

        // GET: api/Blog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlog()
        {
            return await _context.Blogs.Include(x => x.Usuario).ToListAsync();
        }

        //GET: api/Blog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {

            var blog = await _context.Blogs.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.BlogID == id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.BlogID)
            {
                return BadRequest();
            }
            string URL = "";
            var url = blog.ImgURL.Split("\\");
            if (url != null)
            {
                URL = url[url.Length - 1];
            }
            else
            {
                URL = blog.ImgURL;
            }
            blog.ImgURL = URL;
            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
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

        // POST: api/Blog
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            var url = blog.ImgURL.Split("\\");
            string URL = url[url.Length - 1];
            blog.ImgURL = URL;
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlog", new { id = blog.BlogID }, blog);
        }

        [Route("SaveFile")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SaveFile(string fileName)
        {
            try
            {

                foreach (var file2 in Request.Form.Files.ToList())
                {

                    if (!string.IsNullOrEmpty(file2?.FileName))
                    {
                        var dir = Path.Combine(this.pathForPictures, "Blog/");

                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var path = Path.Combine(dir, file2.FileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await file2.CopyToAsync(fileStream);
                        }

                    }

                }
            }
            catch (Exception e)
            {

            }

            return Ok();

        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            var Blog = await _context.Blogs.FindAsync(id);
            if (Blog == null)
            {
                return NotFound();
            }
            var file = Path.Combine(this.pathForPictures, "Blog/" + Blog.ImgURL);
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
            _context.Blogs.Remove(Blog);
            await _context.SaveChangesAsync();

            return Blog;
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogID == id);
        }


    }
}
