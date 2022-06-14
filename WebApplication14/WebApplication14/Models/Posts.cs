using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication14.Models
{
    public class Posts
    {   
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string userName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int getId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string text { get; set; }

        [Column(TypeName = "int")]
        public int date { get; set; }   

    }
}
