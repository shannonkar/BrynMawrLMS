using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BrynMawrLMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly LMSRepository lmsRepository;

        public MembersController(LMSRepository lmsRepository)
        {
            this.lmsRepository = lmsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers()
        {
            var members = this.lmsRepository.GetAllMembers();

            return Ok(members);
        }}
    }

