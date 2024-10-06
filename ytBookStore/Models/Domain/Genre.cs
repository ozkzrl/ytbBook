using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ytBookStore.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
