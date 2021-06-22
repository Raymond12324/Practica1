using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Area { get; set; }
        [Required]
        [StringLength(50)]
        public string Identification { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime dateCandidate { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }

    }
}
