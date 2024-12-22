﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnQLBS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            this.CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            this.THAMGIAs = new HashSet<THAMGIA>();
        }
        [Display(Name = "Mã sách")]
        public int MASACH { get; set; }
        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Vui lòng nhập tên sách")]
        public string TENSACH { get; set; }
        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Vui lòng nhập giá bán")]
        public Nullable<decimal> GIABAN { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]

        public string MOTA { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string ANHBIA { get; set; }
        [Display(Name = "Ngày cập nhật")]
        [Required(ErrorMessage = "Vui lòng chọn ngày cập nhật")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public Nullable<System.DateTime> NGAYCAPNHAT { get; set; }
        [Display(Name = "Số lượng tồn")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng tồn")]

        public Nullable<int> SOLUONGTON { get; set; }
        public Nullable<int> MANXB { get; set; }
        public Nullable<int> MACHUDE { get; set; }
        [Display(Name = "Mới")]
        public Nullable<int> Moi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual CHUDE CHUDE { get; set; }
        public virtual NXB NXB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA> THAMGIAs { get; set; }
    }
}
