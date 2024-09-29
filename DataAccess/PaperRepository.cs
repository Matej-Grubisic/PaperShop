using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess;

public class PaperRepository(PaperContext context) : IPaperRepository
{
    public Paper CreatePaper(Paper paper)
    {
        context.Papers.Add(paper);
        context.SaveChanges();
        return paper;
    }

    public List<Paper> GetAllPaper()
    {
        return context.Papers.ToList();
    }

    public Paper DeletePaper(int id)
    {
        // Fetch the paper from the context (or database)
        var paper = context.Papers.FirstOrDefault(p => p.Id == id);

        // If the paper is not found, return null
        if (paper == null)
        {
            return null;
        }

        context.SaveChanges();
        return paper;
    }

    public Paper? GetById(int id)
    {
        return context.Papers.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Paper paper)
    {
        context.Papers.Update(paper);
        context.SaveChanges(); // Commit the changes to the database
    }
}