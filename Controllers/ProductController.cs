using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.Entities;
using Microsoft.Identity.Client;

namespace WebApi_DBOPERATION.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }
        public ProductController()
        {
                
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()


        {
            try
            {
                return _db.Products.ToList();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }
        //POST:API/PRODUCT
        [HttpPost]
        public IActionResult Add(Product model)
        {
            try
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                return CreatedAtAction("Add", model);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Product model)
        {
            try
            {
                if (id != model.ProductId)
                    return BadRequest();
                _db.Products.Update(model);
                _db.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }




        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                Product model = _db.Products.Find(id);
                if (model != null)
                {
                    _db.Products.Remove(model);
                    _db.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }


    }
}