using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Entities
{
    public partial class TblSubSub00
    {
        public int SubSub00Id { get; set; }
        public int Sub00Id { get; set; }
        public string SubSub00Data { get; set; }

        public virtual TblSub00 Sub00 { get; set; }
    }
}
