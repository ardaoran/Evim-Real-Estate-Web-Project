using Evim.DAL.Entities;


namespace Evim.UI.Areas.admin.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; } // Ekle - Sil - Güncelle

        public IEnumerable<Category> Categories { get; set; } // Combo box için
    }
}
