using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataModels.Reevaluation
{
    public class InsertReeval
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string tweet { get; set; }
    }
}
