using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Candidate> Candidates { get; set; }
    }
}
