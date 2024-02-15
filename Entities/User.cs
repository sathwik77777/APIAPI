using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CodingCha.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        [Column("UserName",TypeName="varchar")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email {  get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public string RoleName {  get; set; }
    }
}
