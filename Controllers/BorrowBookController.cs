using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BorrowBookController : ControllerBase
{
    private readonly LMSRepository lmsRepository;

    public BorrowBookController(LMSRepository lmsRepository)
    {
        this.lmsRepository = lmsRepository;
    }

    [HttpPost()]
    public IActionResult BorrowBook([FromBody] BorrowRequest request)
    {
        try
        {
            var result = lmsRepository.BorrowBook(request.CatalogueID, request.MemberID, request.DueDays, request.Librarian);
            return Ok(new { message = result });
        }
        catch (Exception ex)
        {
            return BadRequest($"Error {ex.Message}");
        }
    }
}

