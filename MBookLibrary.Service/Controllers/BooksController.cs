using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBookLibrary.Business;
using MBookLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MBookLibrary.Service.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpPost("find")]
        public ActionResult<List<BookModel>> Find([FromBody]BookSearchCriteriaModel criteriaModel)
        {
            return _service.Find(criteriaModel);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BookModel> Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/values
        [HttpPost("add")]
        public void Post([FromBody] BookModel bookModel)
        {
            _service.Add(bookModel);
        }

        // PUT api/values/5
        [HttpPut("update")]
        public void Put([FromBody] BookModel bookModel)
        {
            _service.Update(bookModel);
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
