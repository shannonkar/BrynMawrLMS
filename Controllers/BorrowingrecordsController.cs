using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BrynMawrLMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingrecordsController : ControllerBase
    {
        private readonly LMSRepository lmsRepository;

        public BorrowingrecordsController(LMSRepository lmsRepository)
        {
            this.lmsRepository = lmsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Borrowingrecord>> GetBorrowingrecords()
        {
            var borrowingrecords = this.lmsRepository.GetAllBorrowingRecords();

            return Ok(borrowingrecords);
        }}
    }

