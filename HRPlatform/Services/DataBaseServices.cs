using HRPlatform.Helper;
using HRPlatform.Models;
using HRPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Services
{
    public class DataBaseServices : IDataBaseServices
    {
        private readonly IHrPlatformRepository _hrPlatformRepository;
        private readonly IEmailValidator _emailValidator;
        private readonly IPhoneValidator _phoneValidator;

        public DataBaseServices(IHrPlatformRepository hrPlatformRepository, IEmailValidator emailValidator, IPhoneValidator phoneValidator)
        {
            _hrPlatformRepository = hrPlatformRepository;
            _emailValidator = emailValidator;
            _phoneValidator = phoneValidator;
        }
        public bool AddCandidate(Candidate candidate)
        {
            if (_emailValidator.IsValid(candidate.Email) && _phoneValidator.IsValid(candidate.ContactNumber) && !_hrPlatformRepository.ExistingEmail(candidate.Email) && !_hrPlatformRepository.ExistingPhoneNumber(candidate.ContactNumber))
            {
                _hrPlatformRepository.AddCandidate(candidate);
                return true;
            }
            return false;
        }

        public bool AddSkill(Skill skill)
        {
            if (!_hrPlatformRepository.ExistingSkill(skill.Id))
            {
                _hrPlatformRepository.AddSkill(skill);
                return true;
            }
            return false;
        }

        public bool UpdateCandidate(int candidateId, int skillId)
        {
            if (_hrPlatformRepository.ExistingCandidate(candidateId))
            {
                _hrPlatformRepository.UpdateSkill(candidateId, skillId);
                return true;
            }
            return false;
        }

        public bool RemoveSkillFromCandidate(int candidateId, int skillId)
        {
            if (_hrPlatformRepository.RemoveSkill(candidateId, skillId))
            {
                return true;
            }
            return false;
        }

        public bool RemoveCandidate(int id)
        {
            if (_hrPlatformRepository.ExistingCandidate(id))
            {
                _hrPlatformRepository.RemoveCandidate(id);
                return true;
            }
            return false;
        }

        public List<Candidate> SearchByName(string name)
        {
            return _hrPlatformRepository.GetByCandidate(name);
        }

        public List<Candidate> SearchBySkill(string name)
        {
            return _hrPlatformRepository.GetBySkill(name);
        }
    }
}
