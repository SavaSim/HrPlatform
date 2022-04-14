using HRPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Helper
{
    public interface IHrPlatformRepository
    {
        void AddCandidate(Candidate candidate);
        void AddSkill(Skill skill);
        void RemoveCandidate(Candidate candidate);
        void RemoveSkill(Candidate candidate, Skill skill);
        Candidate GetByCandidate(string name);
        List<Candidate> GetBySkill(string skillName);
        void UpdateSkill(Candidate candidate, Skill skill);
        bool ExistingSkill(string name);
        bool ExistingPhoneNumber(string number);
        bool ExistingEmail(string email);
        bool ExistingCandidate(Candidate candidate);
    }
}
