using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService) =>
        _booksService = booksService;

    [HttpGet]
    public async Task<List<Book>> Get() =>
        await _booksService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    // public async Task<IActionResult> Post(Book newBook)
    // {
    //     await _booksService.CreateAsync(newBook);

    //     return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    // }

    [HttpPost]
    public async Task<IActionResult> Post(Book newBook)
    {
        if (ModelState.IsValid)
        {
            await _booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }
        else
        {
            var errors = ModelState
    .Where(e => e.Value?.Errors.Count > 0)
    .ToDictionary(
        kvp => kvp.Key,
        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
    );


            return BadRequest(new
            {
                Message = "The request is invalid.",
                ModelState = errors
            });
        }
    }




    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
}