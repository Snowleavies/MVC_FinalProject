//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjFinal.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Tabletmovie1091750
    {
        [DisplayName("電影編號")]
        [Required(ErrorMessage = "電影編號不可空白")]
        public string fmovieId { get; set; }
        [DisplayName("電影名字")]
        [Required(ErrorMessage = "電影名字不可空白")]
        public string fmovieName { get; set; }
        [DisplayName("上映日期")]
        [DataType(DataType.Date, ErrorMessage = "上映日期日期必須為日期格式(XXXXX/XX/XX)")]
        public string fdate { get; set; }
        [DisplayName("電影層級")]
        [Required(ErrorMessage = "電影名字不可空白")]
        [StringLength(3, ErrorMessage = "電影層級應填XX級", MinimumLength = 3)]
        public string flevel { get; set; }
        [DisplayName("電影評價")]
        [Required(ErrorMessage = "電影評價不可空白")]
        public Nullable<int> fevaluation { get; set; }
        [DisplayName("電影種類")]
        public Nullable<int> fcategoryId { get; set; }
    
        public virtual Tabletcategory1091750 Tabletcategory1091750 { get; set; }
    }
}
