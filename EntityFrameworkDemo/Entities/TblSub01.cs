using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Entities
{
    public partial class TblSub01
    {
        public int Sub01Id { get; set; }
        public int MainId { get; set; }
        public string Sub01Data { get; set; }

        public virtual TblMain Main { get; set; }
    }
}
