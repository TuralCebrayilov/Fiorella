using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorella.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        //[NotMapped]
        //public IFormFile Photo { get; set; }
        //public bool IsDeactive { get; set; }
    }
}
