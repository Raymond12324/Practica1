using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Models
{
    public class Evaluation
    {   [Key]
        public int EvaluationID { get; set; }

        [Required]
        [StringLength(50)]
        public string RRHH_evaluator { get; set; }

        [Required]
        public int evaluation { get; set; }
        [StringLength(100)]
        public string Commentary { get; set; }
        
        [ForeignKey("CandidateID")]
        public Candidate Candidate { get; set; }


        public DateTime DateEvaluation { get; set; } 

    }
}
