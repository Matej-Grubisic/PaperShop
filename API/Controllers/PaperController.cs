using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service;
using Service.TransferModels.Requests;
using Service.TransferModels.Responses;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PaperController(IPaperService service,
    IOptionsMonitor<AppOptions> options
) : ControllerBase
{
    [HttpPost]
    [Route("")]
    public ActionResult<PaperDto> CreatePaper(CreatePaperDto createPaperDto)
    {
        var paper = service.CreatePaper(createPaperDto);
        return Ok(paper);
    }

    [HttpGet]
    [Route("")]
    public ActionResult<List<Paper>> GetAllPapers(int limit = 10, int startAt = 0)
    {
        var papers = service.GetAllPapers(limit, startAt);
        return Ok(papers);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeletePaper(int id)
    {
        var result = service.DeletePaper(id);

        if (result == null)
        {
            return NotFound(new { message = "Paper not found or already deleted" });
        }

        return Ok(result);
    }
    
    // Add this new endpoint for discontinuing a paper
    [HttpPatch]
    [Route("{id}/discontinue")]
    public ActionResult<Paper> DiscontinuePaper(int id)
    {
        var paper = service.DiscontinuePaper(id);

        if (paper == null)
        {
            return NotFound(new { message = "Paper not found" });
        }

        return Ok(paper);
    }
}