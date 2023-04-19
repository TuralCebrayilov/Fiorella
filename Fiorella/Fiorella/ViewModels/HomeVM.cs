using Fiorella.Models;
using System.Collections.Generic;

namespace Fiorella.ViewModels
{
    public class HomeVM
    {
        public List<Product> products { get; set; }
        public List<Category> category { get; set; }
        public List<Bio> Bio { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
