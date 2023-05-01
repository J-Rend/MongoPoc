using BookStoreApi.Domain.Abstractions.Application;
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(int? totalItems, CancellationToken cancellationToken)
        {
            var response = await _bookApplication.GetAllAsync(totalItems, cancellationToken);

            if(!response.Any())
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
