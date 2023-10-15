using Evim.DAL.Entities;

namespace Evim.UI.ViewModels
{
    public class IndexVM
    {
        public Product Product { get; set; }
        public IEnumerable<Slide> Slides { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Product> RelatedProducts { get; set; }
        public IEnumerable<Personel> Personels { get; set; }

    }
}
