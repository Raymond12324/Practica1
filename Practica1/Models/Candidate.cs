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
        [StringLength(50, ErrorMessage = "value cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "value cannot exceed 50 characters. ")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "value cannot exceed 50 characters. ")]
        public string Area { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "value cannot exceed 50 characters. ")]
        public string Identification { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "value cannot exceed 20 characters. ")]
       
        public string PhoneNumber { get; set; }

        public DateTime dateCandidate { get; set; }

        //public Evaluation evaluation { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }

    }
}
