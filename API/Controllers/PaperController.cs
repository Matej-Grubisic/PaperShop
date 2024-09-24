using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service;
using Service.TransferModels.Requests;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PaperController(IPaperService service,
    IOptionsMonitor<AppOptions> options
) : ControllerBase
{
    [HttpPost]
    [Route("")]
    public ActionResult<Paper> CreatePatient(CreatePaperDto createPaperDto)
    {
        var patient = service.CreatePaper(createPaperDto);
        return Ok(patient);
    }

    [HttpGet]
    [Route("")]

    public ActionResult<List<Paper>> GetAllPapers(int limit = 10, int startAt = 0)
    {
        var papers = service.GetAllPapers(limit, startAt);
        return Ok(papers);
    }
}