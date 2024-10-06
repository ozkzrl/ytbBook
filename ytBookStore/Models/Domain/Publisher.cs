using System.ComponentModel.DataAnnotations;

namespace ytBookStore.Models.Domain
{
    public class Publisher
    {

        public int Id { get; set; }
        [Required]
        public string PublisherNAme { get; set; }

    }
}
