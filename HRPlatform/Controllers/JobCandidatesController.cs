using HRPlatform.Models;
using HRPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobCandidatesController : Controller
    {
        private readonly IDataBaseServices _dataBaseServices;
        public JobCandidatesController (IDataBaseServices dataBaseServices)
        {
            _dataBaseServices = dataBaseServices;
        }

        [HttpPost]
        public IActionResult PostCandidate([FromBody] Candidate candidate)
        {
            if (_dataBaseServices.AddCandidate(candidate))
            {
                return Created("", candidate);
            }
            else
            {
                return BadRequest("Phone number or Email are not valid or already exist!!!");
            }
        }

    }
}
