using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASP.NET_Webapi.Models
{
    public class DCandidate
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string fullName { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string mobile { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public int age { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string bloogGroup { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string address { get; set; }
    }
}
