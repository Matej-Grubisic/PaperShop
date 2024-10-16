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
    public ActionResult<Paper> CreatePaper(CreatePaperDto createPaperDto)
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
    
    [HttpPost]
    [Route("restock/{id}")]
    public ActionResult<PaperDto> RestockPaper(int id, [FromBody] int updatedStock)
    {
        if (updatedStock <= 0)
        {
            return BadRequest("Invalid stock quantity.");
        }

        var paper = service.GetPaperById(id);
        if (paper == null)
        {
            return NotFound("Paper not found");
        }

        paper.Stock += updatedStock;
        service.UpdatePaper(paper);

        // Manually map to DTO
        var paperDto = new PaperDto
        {
            Id = paper.Id,
            Name = paper.Name,
            Stock = paper.Stock,
            Price = paper.Price,
            Discontinued = paper.Discontinued
        };

        return Ok(paperDto);
    }
    
    [HttpGet]
    [Route("SortByPrice")]
    public ActionResult<IEnumerable<PaperDto>> GetPapersSortedByPrice()
    {
        var papers = service.GetAllPapersSortedByPrice();
        return Ok(papers);
    }

    [HttpGet]
    [Route("SortByStock")]
    public ActionResult<IEnumerable<PaperDto>> GetPapersSortedByStock()
    {
        var papers =  service.GetAllPapersSortedByStockAmount();
        return Ok(papers);
    }

    [HttpGet]
    [Route("SortByDiscount")]
    public ActionResult<IEnumerable<PaperDto>> GetPapersSortedByDiscount()
    {
        var papers =  service.GetAllPapersSortedByDiscount();
        return Ok(papers);
    } 

    [HttpGet]
    [Route("Search")]
    public ActionResult<IEnumerable<Paper>> SearchPapers(string name)
    {
        var papers = service.SearchPapers(name);
        return Ok(papers);
    }
}