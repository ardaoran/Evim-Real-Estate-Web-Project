using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evim.DAL.Entities
{
    public class Personel
    {
        public int ID { get;set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Ad Soyad")]
        public string NameSurname { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(50), Display(Name = "Şirket İçi Görev")]
        public string Gorev { get; set; }

        [Column(TypeName = "Varchar(150)"), StringLength(50), Display(Name = "Resim 1 ")]
        public string? Picture { get; set; }

        [Display(Name ="Görüntülenme Sırası")]
        public int?  DisplayIndex { get; set; }

        public ICollection<PersonelPicture> PersonelPictures { get; set; }


    }
}
