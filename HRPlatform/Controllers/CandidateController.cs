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
    public class CandidateController : Controller
    {
        private readonly IDataBaseServices _dataBaseServices;
        public CandidateController (IDataBaseServices dataBaseServices)
        {
            _dataBaseServices = dataBaseServices;
        }

        [HttpPost]
        public IActionResult PostCandidate([FromBody] Candidate candidate)
        {
            if (_dataBaseServices.AddCandidate(candidate))
            {
                return Created("Candidate successfully created!", candidate);
            }
            else
            {
                return BadRequest("Phone number or Email are not valid or already exist!");
            }
        }

        [HttpPut("{candidateId}")]
        public IActionResult AddSkillToCandidate([FromBody] int skillId, int candidateId)
        {
            if (_dataBaseServices.UpdateCandidate(candidateId, skillId))
            {
                return Ok("Skill successfully added to candidate!");
            }
            else
            {
                return NotFound("Candidate or skill not found!");
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetCandidateName(string name)
        {
            if (name != string.Empty && _dataBaseServices.SearchByName(name)!=null)
            {              
                return Ok(_dataBaseServices.SearchByName(name));
            }
            else
            {
                return NotFound("Candidate not found!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCandidate(int id)
        {
            if (_dataBaseServices.RemoveCandidate(id))
            {
                return Ok("Candidate successfully deleted!");
            }
            else
            {
                return NotFound("Candidate does not exist!");
            }
        }

    }
}
