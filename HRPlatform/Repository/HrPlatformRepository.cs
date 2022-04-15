using HRPlatform.DataBaseRepository;
using HRPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Repository
{
    public class HrPlatformRepository : IHrPlatformRepository
    {
        private DataBase _dbcontext;

        public HrPlatformRepository(DataBase dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddCandidate(Candidate candidate)
        {
            _dbcontext.Candidates.Add(candidate);
            _dbcontext.SaveChanges();
        }

        public void AddSkill(Skill skill)
        {
            _dbcontext.Skills.Add(skill);
            _dbcontext.SaveChanges();
        }

        public void RemoveCandidate(int id)
        {
            Candidate candidate = _dbcontext.Candidates.Find(id);
            if (candidate != null) 
            {
                _dbcontext.Candidates.Remove(candidate);
                _dbcontext.SaveChanges();
            }
        }

        public bool RemoveSkill(int candidateId, int skillId)
        {    
            if (ExistingCandidateSkill(skillId) && ExistingCandidate(candidateId))
            {
                var result = _dbcontext.Candidates.FirstOrDefault(x => x.Id == candidateId);
                result.Skills.Remove(_dbcontext.Skills.FirstOrDefault(x => x.Id == skillId));
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
           
        }

        public List<Candidate> GetByCandidate(string name)
        {
            var result = _dbcontext.Candidates
               .Where(x => x.Name == name);
               

            List<Candidate> candidates = (List<Candidate>)result;

            return candidates;
        }

        public List<Candidate> GetBySkill(string skillName)
        {
            var reuslt = _dbcontext.Skills
                .Where(x => x.Name == skillName)
                .FirstOrDefault();         

            List<Candidate> candidates = (List<Candidate>)reuslt.Candidates;

            return candidates;
        }

        public void UpdateSkill(int candidateId, int skillId)
        {
            if (ExistingCandidate(candidateId) && ExistingSkill(skillId))
            {
                var result = _dbcontext.Candidates.SingleOrDefault(x => x.Id == candidateId);
                result.Skills.Add(_dbcontext.Skills.SingleOrDefault(x => x.Id == skillId));
                _dbcontext.SaveChanges();
            }
        }
        public bool ExistingCandidateSkill(int id)
        {
            bool result = _dbcontext.Skills.Any(x => x.Id == id);
            return result;
        }

        public bool ExistingCandidate(int id)
        {
            bool result = _dbcontext.Candidates.Any(x => x.Id == id);
            return result;
        }

        public bool ExistingSkill(int id)
        {
            bool result = _dbcontext.Skills.Any(x => x.Id == id);
            return result;
        }

        public bool ExistingPhoneNumber(string number)
        {
            bool result = _dbcontext.Candidates.Any(x => x.ContactNumber == number);
            return result;
        }

        public bool ExistingEmail(string email)
        {
            bool result = _dbcontext.Candidates.Any(x => x.Email == email);
            return result;
        }
    }
}
