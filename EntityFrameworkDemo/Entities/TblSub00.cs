using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Entities
{
    public partial class TblSub00
    {
        public TblSub00()
        {
            TblSubSub00 = new HashSet<TblSubSub00>();
        }

        public int Sub00Id { get; set; }
        public int MainId { get; set; }
        public string Sub00Data { get; set; }

        public virtual ICollection<TblSubSub00> TblSubSub00 { get; set; }
        public virtual TblMain Main { get; set; }
    }
}
