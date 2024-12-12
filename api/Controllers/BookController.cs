using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        public BookController(IBookRepository bookRepo)
        {
           _bookRepo=bookRepo;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAll()
        {
             var books = await _bookRepo.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        // [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        // [Authorize]
        public async  Task<IActionResult> Create([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookModel = bookDto.ToBookCreateDto();
            await _bookRepo.CreateAsync(bookModel);
            return CreatedAtAction(nameof(GetById),new {id=bookModel.Id},bookModel.ToBookDto());
        }

        [HttpPut]
        [Route("{id}")]
        // [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] Book updateDto)
        {
            var bookModel =await _bookRepo.UpdateAsync(id,updateDto);
            if(bookModel == null)
            {
                return NotFound();
            }
            return Ok(bookModel.ToBookDto());
        }

        [HttpDelete]
        [Route("{id}")]
        // [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bookModel =await  _bookRepo.DeleteAsync(id);
            if(bookModel == null )
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}