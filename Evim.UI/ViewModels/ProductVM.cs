
using Evim.DAL.Entities;

namespace Evim.UI.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }

        public IEnumerable<Product> RelatedProducts{ get; set; }
    }
}
