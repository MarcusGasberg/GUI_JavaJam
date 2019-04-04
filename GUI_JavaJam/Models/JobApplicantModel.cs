using System.ComponentModel.DataAnnotations;

namespace GUI_JavaJam.Models
{
    public class JobApplicantModel
    {
        public int Id { get; set; }
        
        [Display(Name = "*Your name")]
        [StringLength(255)]
        [Required]
        public string ApplicantName { get; set; }
        [EmailAddress]
        [Display(Name = "*E-mail")]
        [StringLength(255)]
        [Required]
        public string Email { get; set; }
        [Display(Name = "*Your experience")]
        [StringLength(1024)]
        [Required]
        public string Experience { get; set; }
    }
}