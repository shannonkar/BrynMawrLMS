using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BrynMawrLMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CataloguesController : ControllerBase
    {
        private readonly LMSRepository lmsRepository;

        public CataloguesController(LMSRepository lmsRepository)
        {
            this.lmsRepository = lmsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Catalogue>> GetCatalogues()
        {
            var catalogues = this.lmsRepository.GetAllCatalogues();

            return Ok(catalogues);
        }}
    }

