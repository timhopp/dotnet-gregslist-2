using System.ComponentModel.DataAnnotations;

namespace gregslist_api.Models
{
    public class House
    {
        public int Id { get; set; }
        [Required]
        public string Levels { get; set; }
        [Required]
        public string Bathrooms { get; set; }
        [Required]
        public string Sqft { get; set; }
        [Required]
        public string Bedrooms { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}