using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evim.DAL.Entities
{
    public class Product
    {
        public int ID { get;set; }

        [Column(TypeName="Varchar(100)"),StringLength(200),Display(Name ="Mülk Adı"),Required(ErrorMessage ="Mülk Adı boş bırakılamaz")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)"),  Display(Name = "Fiyat"), Required(ErrorMessage = "Fiyat boş bırakılamaz")]
        public decimal Fiyat { get; set; }


        
        public string FiyatFormatted
        {
            get
            {
                
                string formattedFiyat = Fiyat.ToString("N0");

                formattedFiyat += " ₺";

                return formattedFiyat;
            }
        }

        [Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Adres"), Required(ErrorMessage = "Adres boş bırakılamaz")]
        public string Adres { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Metrekare"),Required(ErrorMessage = "Metrekare boş bırakılamaz")]
        public string Metrekare { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Yatak Odası"), Required(ErrorMessage = "Yatak Odası Sayısı boş bırakılamaz")]
        public string YatakOdasi { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Banyo"), Required(ErrorMessage = "Banyo Sayısı boş bırakılamaz")]
        public string Banyo { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Durum(SATILIK-KİRALIK)"), Required(ErrorMessage = "Durum boş  bırakılamaz")]
        public string Durum { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Mülk Türü(Apartman,Villa vb."), Required(ErrorMessage = "Tür boş bırakılamaz")]
        public string Tur { get; set; }

        [Display(Name ="Görüntülenme Sırası")]
        public int  DisplayIndex { get; set; }

        public ICollection<ProductPicture> ProductPictures { get; set; }

        [Display(Name ="Kategorisi")]
        public int? CategoryID { get; set; }    
        public Category Category { get; set; }

        
    }
}
