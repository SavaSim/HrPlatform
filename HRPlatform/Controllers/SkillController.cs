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
    public class SkillController : Controller
    {
        private readonly IDataBaseServices _dataBaseServices;
        public SkillController(IDataBaseServices dataBaseServices)
        {
            _dataBaseServices = dataBaseServices;
        }

        [HttpPost]
        public IActionResult PostSkill([FromBody] Skill skill)
        {
            if (_dataBaseServices.AddSkill(skill))
            {
                return Created("Skill successfully created!", skill);
            }
            else
            {
                return BadRequest("Skill already exist!");
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetCandidateSkill(string name)
        {
            if (name != string.Empty && _dataBaseServices.SearchBySkill(name) != null)
            {
                return Ok(_dataBaseServices.SearchBySkill(name));
            }
            else
            {
                return NotFound("Skill not found!");
            }
        }

        [HttpDelete("{candidateId}")]
        public IActionResult RemoveCandidateSkill(int skillId, int candidateId)
        {
            if (_dataBaseServices.RemoveSkillFromCandidate(skillId, candidateId))
            {
                return Ok("Skill successfully deleted from candidate!");
            }
            else
            {
                return NotFound("Candidate or skill not found!");
            }
        }

    }
}
