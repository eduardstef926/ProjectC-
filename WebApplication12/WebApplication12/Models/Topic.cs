using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication12.Models
{
    public class Topic
    {   
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string username;

        [Column(TypeName = "nvarchar(100)")]
        public string text;

        [Column(TypeName = "int")]
        public int time;
    }
}
