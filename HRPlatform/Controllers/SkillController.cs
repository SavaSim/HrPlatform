using HRPlatform.Models;
using HRPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Controllers
{
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
                return Created("", skill);
            }
            else
            {
                return BadRequest("Phone number or Email are not valid or already exist!!!");
            }
        }

    }
}
