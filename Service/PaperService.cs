using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using Service.TransferModels.Requests;
using Service.TransferModels.Responses;

namespace Service;

public interface IPaperService
{
    public PaperDto CreatePaper(CreatePaperDto createPaperDto);

    public List<Paper> GetAllPapers(int limit, int startAt);

    public Paper DeletePaper(int id);
    
    Paper? DiscontinuePaper(int id);
}

public class PaperService(IPaperRepository paperRepository, PaperContext context): IPaperService
{
    public PaperDto CreatePaper(CreatePaperDto createPaperDto)
    {
        //createPaperValidator.ValidateAndThrow(createPaperDto);
        var paper = createPaperDto.ToPaper();
        Paper newPaper = paperRepository.CreatePaper(paper);
        return new PaperDto().FromEntity(newPaper);
    }

    public List<Paper> GetAllPapers(int limit, int startAt)
    {
        return context.Papers.OrderBy(p => p.Id).Skip(startAt).Take(limit).ToList();
    }

    public Paper DeletePaper(int id)
    {
        var paper = paperRepository.DeletePaper(id);
        
        if (paper == null)
        {
            return null;
        }
        context.SaveChanges();
        return paper;
    }
    public Paper? DiscontinuePaper(int id)
    {
        var paper = paperRepository.GetById(id);
        if (paper == null) return null;

        paper.Discontinued = true;
        paperRepository.Update(paper);
        return paper;
    }
    
}