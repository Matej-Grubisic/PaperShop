using DataAccess.Models;

namespace DataAccess.Interfaces;

public interface IPaperRepository
{
    public Paper CreatePaper(Paper paper);

    public List<Paper> GetAllPaper();

    public Paper DeletePaper(int id);
    Paper? GetById(int id);
    void Update(Paper paper); // Make sure this method exists
}