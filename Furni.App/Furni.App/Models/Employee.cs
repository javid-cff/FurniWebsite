using Furni.App.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Furni.App.Models
{
    public class Employee:BaseEntity
    {
        [MinLength(3)]
        [MaxLength(25)]
        public string FirstName { get; set; } = null!;
        [MinLength(3)]
        [MaxLength(25)]
        public string LastName { get; set; } = null!;
        [MaxLength(25)]
        public string Position { get; set; } = null!;
        public string? Description { get; set; }
        public string ImageName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
