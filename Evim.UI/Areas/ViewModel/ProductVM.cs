
using Evim.DAL.Entities;

namespace Evim.UI.Areas.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
