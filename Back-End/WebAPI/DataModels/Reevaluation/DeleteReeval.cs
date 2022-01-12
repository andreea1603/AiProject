using System.ComponentModel.DataAnnotations;


namespace WebAPI.DataModels.Users
{
    public class DeleteReeval
    {
        [Required]
        public int id { get; set; }

    }
}
