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
}