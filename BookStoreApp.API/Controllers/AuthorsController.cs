using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using AutoMapper;
using Microsoft.OpenApi.Validations;
using BookStoreApp.API.Static;

namespace BookStoreApp.API.Controllers
{
    // Route to api/"name of controllers" : api/authors
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper mapper;
        private readonly ILogger<AuthorsController> logger;

        // Injecting the context into the controller
        public AuthorsController(BookStoreDbContext context, IMapper mapper, ILogger<AuthorsController> logger)
        {
            _context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAuthors()
        {
          /*
          if (_context.Authors == null)
          {
              return NotFound();
          }

          var authors = await _context.Authors.ToListAsync();
          var authorDtos = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors);
          return Ok(authorDtos);

          // SELECT * FROM Authors;
          // Ok: specify the 200 Successful Code
          // return Ok(await _context.Authors.ToListAsync());
          */
          try
            {
                var authors = await _context.Authors.ToListAsync();
                var authorDtos = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors);
                return Ok(authorDtos);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorReadOnlyDto>> GetAuthor(int id)
        {
            try
            {
                if (_context.Authors == null)
                {
                    return NotFound();
                }
                // SELECT * FROM Authors WHERE Authors.Id = id;
                var author = await _context.Authors.FindAsync(id);

                if (author == null)
                {
                    logger.LogWarning($"Record Not Found: {nameof(GetAuthor)} - ID: {id}");
                    return NotFound(); //Return 404 not found status code
                }

                var authorDto = mapper.Map<AuthorReadOnlyDto>(author);

                return Ok(authorDto);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }

        }

        // Put means Update
        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDto authorDto) // Send the id of the record we want to update, and the record content that we want to update 
        {
            // Check if the ID in the request match the id in the "author" record content
            if (id != authorDto.Id)
            {
                logger.LogWarning($"Update ID invalid in: {nameof(PutAuthor)} - ID: {id}");
                return BadRequest();
            }

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                logger.LogWarning($"{nameof(Author)} record not found in {nameof(PutAuthor)} - ID: {id}");
                return NotFound(); //Return 404 not found status code
            }

            mapper.Map(authorDto, author);
            // Tell the database that we want to modify the entry Author author
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                // Commit to database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    logger.LogError(ex, $"Error Performing GET in {nameof(PutAuthor)}");
                    return StatusCode(500, Messages.Error500Message);
                }
            }

            // Return 204 Status Code: The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.
            return NoContent();
        }

        // Post means Create
        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorCreateDto>> PostAuthor(AuthorCreateDto authorDto)
        {
          if (_context.Authors == null)
          {
              return Problem("Entity set 'BookStoreDbContext.Authors'  is null.");
          }

          try
            {
                var author = mapper.Map<Author>(authorDto);
                // Add a new entry to the table Authors with the content of Author author object
                await _context.Authors.AddAsync(author);
                // Commit database
                await _context.SaveChangesAsync();

                // Return a 201 status code, with that author's information and the new entry's id in the database
                // 201 status code: The request has been fulfilled and has resulted in one or more new resources being created.
                return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(PostAuthor)}", authorDto);
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                // If Author table not exists
                if (_context.Authors == null)
                {
                    logger.LogWarning($"{nameof(_context.Authors)} table not found in {nameof(DeleteAuthor)}");
                    // Return 404 status code
                    return NotFound();
                }
                // Get the record with that id
                var author = await _context.Authors.FindAsync(id);
                // If the author with that id not exist
                if (author == null)
                {
                    logger.LogWarning($"{nameof(Author)} record not found in {nameof(DeleteAuthor)} - ID: {id}");
                    // Return 404 status code
                    return NotFound();
                }

                // Remove that entry from the Author table
                _context.Authors.Remove(author);

                // Commit changes to database
                await _context.SaveChangesAsync();

                return NoContent();
            } 
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing DELETE in {nameof(DeleteAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }




        }

        private async Task<bool> AuthorExists(int id)
        {
            return await (_context.Authors?.AnyAsync(e => e.Id == id)); //.GetValueOrDefault();
        }
    }
}
