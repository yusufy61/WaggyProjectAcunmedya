using System.ComponentModel.DataAnnotations.Schema;

namespace WaggyProjectAcunmedya.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Review { get; set; }


        /// <summary>
        /// Burada kullandığımız NotMapped attribute'u, bu property'sinin veritabanında bir sütun olarak oluşturulmamasını sağlar.
        /// </summary>
        /// 
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        /// <summary>
        /// Veri tabanında CategoryId sütunu oluşturulacak ve bu sütun Product ile Category arasındaki ilişkiyi temsil edeck alan.
        /// </summary>
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
