using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evim.DAL.Entities
{
    public class Slide
    {
        public int ID { get;set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Slogan Buyuk")]
        public string SloganBuyuk { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Slogan Buyuk2")]
        public string SloganBuyuk2 { get; set; }

        [Column(TypeName = "Varchar(MAX)"), StringLength(1000), Display(Name = "Slogan Kucuk")]
        public string SloganKucuk { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Slogan Renkli Kelime")]
        public string SloganRenkliKelime { get; set; }

        [Column(TypeName = "Varchar(150)"), StringLength(50), Display(Name = "Resim 1 ")]
        public string? Picture { get; set; }



        [Display(Name ="Görüntülenme Sırası")]
        public int?  DisplayIndex { get; set; }

        public ICollection<SlidePicture> SlidePictures { get; set; }


    }
}
