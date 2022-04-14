using HRPlatform.Models;
using HRPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Helper
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

        public void RemoveCandidate(Candidate candidate)
        {
            _dbcontext.Candidates.Remove(candidate);
            _dbcontext.SaveChanges();
            //skill.Candidates.Remove(candidate);
        }

        public void RemoveSkill(Candidate candidate,Skill skill)
        {
            var data = _dbcontext.Candidates.FirstOrDefault(x => x.Id == candidate.Id);
            data.Skills.Remove(skill);
            _dbcontext.SaveChanges();
        }

        public Candidate GetByCandidate(string name)
        {
            var data = _dbcontext.Candidates
               .Where(x => x.Name == name)
               .FirstOrDefault();

            return data;
        }

        public List<Candidate> GetBySkill(string skillName)
        {
            /*var data = _dbcontext.Skills
                .Where(x => x.Name == skillName)
                .FirstOrDefault();*/

            List<Candidate> candidates = new List<Candidate>();

            /*foreach (Candidate can in data.Candidates)
            {
                candidates.Add(can);
            }*/

            return candidates;
        }

        public void UpdateSkill(Candidate candidate, Skill skill)
        {
            var data = _dbcontext.Candidates.FirstOrDefault(x => x.Id == candidate.Id);
            data.Skills.Add(skill);
            _dbcontext.SaveChanges();
        }

        public bool ExistingCandidate(Candidate candidate)
        {
            bool result = _dbcontext.Candidates.Any(x => x.Id == candidate.Id);
            return result;
        }

        public bool ExistingSkill(string name)
        {
            bool result = _dbcontext.Skills.Any(x => x.Name == name);
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
