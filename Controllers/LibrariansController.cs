using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BrynMawrLMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrariansController : ControllerBase
    {
        private readonly LMSRepository lmsRepository;

        public LibrariansController(LMSRepository lmsRepository)
        {
            this.lmsRepository = lmsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Librarian>> GetLibrarians()
        {
            var librarians = this.lmsRepository.GetAllLibrarians();

            return Ok(librarians);
        }}
    }

