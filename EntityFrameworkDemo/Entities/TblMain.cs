using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Entities
{
    public partial class TblMain
    {
        public TblMain()
        {
            TblSub00 = new HashSet<TblSub00>();
            TblSub01 = new HashSet<TblSub01>();
        }

        public int MainId { get; set; }
        public string MainData { get; set; }

        public virtual ICollection<TblSub00> TblSub00 { get; set; }
        public virtual ICollection<TblSub01> TblSub01 { get; set; }
    }
}
