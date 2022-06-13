using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication14.Models
{
    public class Topics
    {
        [Key]
        public int Id { get; set; }   

        [Column(TypeName = "nvarchar(100)")]
        public string username { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string text { get; set; }

}
}
