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
    
    public partial class tblSatislar
    {
        public int SatisID { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Musteri { get; set; }
        public Nullable<byte> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
    
        public virtual tblMusteriler tblMusteriler { get; set; }
        public virtual tblUrunler tblUrunler { get; set; }
    }
}
