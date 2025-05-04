using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BrynMawrLMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly LMSRepository lmsRepository;

        public PublishersController(LMSRepository lmsRepository)
        {
            this.lmsRepository = lmsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> GetPublishers()
        {
            var publishers = this.lmsRepository.GetAllPublishers();

            return Ok(publishers);
        }}
    }

