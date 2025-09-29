using Microsoft.AspNetCore.Mvc;
using virtualletters.api.Models;
using virtualletters.api.Services;

namespace virtualletters.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LetterControllers : ControllerBase
{
    private readonly LetterServices _letterServices;

    public LetterControllers(LetterServices letterServices)
    {
        _letterServices = letterServices;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Letter>> GetAllLetters()
    {
        return Ok(_letterServices.GetAllLetters());
    }

    [HttpGet("{id}")]
    public ActionResult<Letter> GetLetterById(string id)
    {
        var letter = _letterServices.GetLetterById(id);
        if (letter == null)
        {
            return NotFound();
        }
        return Ok(letter);
    }

    [HttpPost]
    public ActionResult<Letter> CreateLetter([FromBody] Letter letter)
    {
        _letterServices.AddLetter(letter);
        return CreatedAtAction(nameof(GetLetterById), new { id = letter.Id }, letter);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateLetter(string id, [FromBody] Letter updatedLetter)
    {
        var existingLetter = _letterServices.GetLetterById(id);
        if (existingLetter == null)
        {
            return NotFound();
        }
        _letterServices.UpdateLetter(id, updatedLetter);
        return NoContent();
    }

    [HttpPost("{id}/send")]
    public IActionResult SendLetter(string id)
    {
        var existingLetter = _letterServices.GetLetterById(id);
        if (existingLetter == null)
        {
            return NotFound();
        }
        _letterServices.SendLetter(id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLetter(string id)
    {
        var existingLetter = _letterServices.GetLetterById(id);
        if (existingLetter == null)
        {
            return NotFound();
        }
        _letterServices.DeleteLetter(id);
        return NoContent();
    }
}