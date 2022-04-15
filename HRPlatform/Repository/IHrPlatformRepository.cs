using HRPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Repository
{
    public interface IHrPlatformRepository
    {
        void AddCandidate(Candidate candidate);
        void AddSkill(Skill skill);
        void RemoveCandidate(int id);
        bool RemoveSkill(int candidateId, int skillId);
        List<Candidate> GetByCandidate(string name);
        List<Candidate> GetBySkill(string skillName);
        void UpdateSkill(int candidateId, int skillId);
        bool ExistingSkill(int id);
        bool ExistingPhoneNumber(string number);
        bool ExistingEmail(string email);
        bool ExistingCandidate(int id);
        bool ExistingCandidateSkill(int id);
    }
}
