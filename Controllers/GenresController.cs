using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BrynMawrLMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly LMSRepository lmsRepository;

        public GenresController(LMSRepository lmsRepository)
        {
            this.lmsRepository = lmsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            var genres = this.lmsRepository.GetAllGenres();

            return Ok(genres);
        }}
    }

