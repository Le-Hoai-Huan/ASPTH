using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        [DisplayName("Tên danh mục")]
        public string Name { get; set; }
    }
}
