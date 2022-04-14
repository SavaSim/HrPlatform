using HRPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Services
{
    public interface IDataBaseServices
    {
        bool AddCandidate(Candidate candidate);
        bool AddSkill(Skill skill);
        bool UpdateCandidate(Candidate candidate, Skill skill);

    }
}
