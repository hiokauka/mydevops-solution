using virtualletters.api.Models;

namespace virtualletters.api.Services;

public class LetterServices
{
    private readonly List<Letter> _letters = new();

    public IEnumerable<Letter> GetAllLetters()
    {
        return _letters;
    }

    public Letter GetLetterById(string id)
    {
        return _letters.FirstOrDefault(l => l.Id == id);
    }

    public void AddLetter(Letter letter)
    {
        letter.Id = Guid.NewGuid().ToString();
        letter.CreatedAt = DateTime.UtcNow;
        _letters.Add(letter);
    }

    public void UpdateLetter(string id, Letter updatedLetter)
    {
        var letter = GetLetterById(id);
        if (letter != null)
        {
            letter.RecipientName = updatedLetter.RecipientName;
            letter.SenderName = updatedLetter.SenderName;
            letter.Title = updatedLetter.Title;
            letter.Content = updatedLetter.Content;
            // Note: Not updating CreatedAt or Status here
        }
    }

    public void SendLetter(string id)
    {
        var letter = GetLetterById(id);
        if (letter != null)
        {
            
            letter.SentAt = DateTime.UtcNow;
        }
    }

    public void DeleteLetter(string id)
    {
        var letter = GetLetterById(id);
        if (letter != null)
        {
            _letters.Remove(letter);
        }
    }
}