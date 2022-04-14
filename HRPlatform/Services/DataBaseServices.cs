using HRPlatform.Helper;
using HRPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Services
{
    public class DataBaseServices : IDataBaseServices
    {
        private readonly IHrPlatformRepository _hrPlatformRepository;
        private IEmailValidator _emailValidator;
        private IPhoneValidator _phoneValidator;

        public DataBaseServices(IHrPlatformRepository hrPlatformRepository, IEmailValidator emailValidator, IPhoneValidator phoneValidator)
        {
            _hrPlatformRepository = hrPlatformRepository;
            _emailValidator = emailValidator;
            _phoneValidator = phoneValidator;
        }
        public bool AddCandidate(Candidate candidate)//provera mail i broj tf
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
            if (!_hrPlatformRepository.ExistingSkill(skill.Name))//preko id-a
            {
                _hrPlatformRepository.AddSkill(skill);
                return true;
            }
            return false;
        }

        public bool UpdateCandidate(Candidate candidate, Skill skill)
        {
            if (_hrPlatformRepository.ExistingCandidate(candidate))
            {
                _hrPlatformRepository.UpdateSkill(candidate, skill);
                return true;
            }
            return false;
        }

        public bool RemoveSkill(Candidate candidate, Skill skill)
        {
            if (candidate.Skills.Contains(skill))
            {
                _hrPlatformRepository.RemoveSkill(candidate, skill);
                return true;
            }
            return false;
        }

        public bool RemoveCandidate(Candidate candidate)
        {
            if (_hrPlatformRepository.ExistingCandidate(candidate))
            {
                _hrPlatformRepository.RemoveCandidate(candidate);
                return true;
            }
            return false;
        }

        /*public bool SearchByCandidate(string name)
        public bool SearchBySkill()*/
    }
}
