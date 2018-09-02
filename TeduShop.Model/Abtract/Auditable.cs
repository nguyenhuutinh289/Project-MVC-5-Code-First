using System;
using System.ComponentModel.DataAnnotations;

namespace TeduShop.Model.Abtract
{
    public abstract class Auditable : IAuditable, ISeoable, ISwitchable
    {
        //IAuditable
        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [MaxLength(256)]
        public string UpdateBy { get; set; }

        // ISeoable
        [MaxLength(256)]
        public string MetaKeyWord { get; set; }

        [MaxLength(256)]
        public string MetaDescription { get; set; }

        //ISwitchable
        public bool Status { get; set; }
    }
}