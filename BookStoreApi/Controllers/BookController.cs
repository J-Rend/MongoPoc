using BookStoreApi.Domain.Abstractions.Application;
using BookStoreApi.Domain.Arguments.Request;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("v1/book")]
    public class BookController : ControllerBase
    {
        IBookApplication _bookApplication;

        public BookController(IBookApplication bookApplication)
        {
            ArgumentNullException.ThrowIfNull(nameof(bookApplication));

            _bookApplication = bookApplication;
        }

        [HttpGet("get-all/{totalItems}")]
        public async Task<IActionResult> GetAllAsync([FromRoute]int? totalItems, CancellationToken cancellationToken)
        {
            var response = await _bookApplication.GetAllAsync(totalItems, cancellationToken);

            if(!response.Any())
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("get/{bookId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]string bookId, CancellationToken cancellationToken)
        {
            var response = await _bookApplication.GetByIdAsync(bookId, cancellationToken);

            if (response == null)
                return NoContent();

            return Ok(response);

        }

        [HttpPost("add/")]
        public async Task<IActionResult> InsertAsync([FromBody]SetBookRequest request, CancellationToken cancellationToken)
        {
            var response = await _bookApplication.CreateBookAsync(request, cancellationToken);

            if (response == null)
                return BadRequest();

            return Created(new Uri($"https://localhost:7086/v1/book/{response}"),new { Id = response});

        }
        [HttpPut("update/{bookId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] string bookId, [FromBody] SetBookRequest request, CancellationToken cancellationToken)
        {
            await _bookApplication.UpdateBookAsync(bookId, request, cancellationToken);

            return Ok();

        }

        [HttpDelete("delete/")]
        public async Task<IActionResult> DeleteAsync([FromBody] string bookId, CancellationToken cancellationToken)
        {
            await _bookApplication.DeleteBookAsync(bookId, cancellationToken);

            return Ok();
        }

    }
}
