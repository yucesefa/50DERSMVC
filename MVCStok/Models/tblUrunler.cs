//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStok.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUrunler()
        {
            this.tblSatislar = new HashSet<tblSatislar>();
        }
    
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public string Marka { get; set; }
        public Nullable<short> UrunKategori { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<byte> Stok { get; set; }
    
        public virtual tblKategoriler tblKategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSatislar> tblSatislar { get; set; }
    }
}
