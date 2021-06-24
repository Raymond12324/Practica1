using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Evaluator")]
        public string RRHH_evaluator { get; set; }

        [Required]
        [DisplayName("Evaluation")]
        [Range(0, 10, ErrorMessage = "Can only be between 0 .. 10")]
        public int evaluation { get; set; }
        [StringLength(100)]
        public string Commentary { get; set; }
        
        [ForeignKey("CandidateID")]
        public Candidate Candidate { get; set; }

        public int CandidateID { get; set; }


        public DateTime DateEvaluation { get; set; } 



    }
}
