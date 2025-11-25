using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Learning_DotNet.Models
{
    public class Category
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name{ get; set; }
        //order in which multiple categories will be displayed
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }

    }
}
