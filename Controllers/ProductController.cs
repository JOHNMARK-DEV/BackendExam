using BackendExam.Contracts;
using BackendExam.Models;
using BackendExam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.IdentityModel.Tokens;

namespace BackendExam.Controllers
{
    [Authorize]
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly UnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork?)unitOfWork; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _unitOfWork.ProductRepository.GetAll().Result;
                return Ok(data);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {
            try
            {
                var data = _unitOfWork.ProductRepository.GetOne(id).Result;
                return Ok(data);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductModel data)
        {
            try
            {
                 _unitOfWork.ProductRepository.Add(data);
                var result =  _unitOfWork.SaveChanges();
                if (result)
                { 
                    return Ok();
                }
                return StatusCode(409);
          
            }
            catch (Exception)
            { 
                return BadRequest(); 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _unitOfWork.ProductRepository.Delete(id);
                var result = _unitOfWork.SaveChanges();
                if (result)
                {
                    return Ok();
                }
                return StatusCode(409);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductDtoModel payload)
        {
            try
            {
                ProductModel data = new ProductModel
                {
                    Id = id,
                   Name = payload.Name, 
                   Code = payload.Code,
                };
              
                _unitOfWork.ProductRepository.Update(data);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



    }
}
