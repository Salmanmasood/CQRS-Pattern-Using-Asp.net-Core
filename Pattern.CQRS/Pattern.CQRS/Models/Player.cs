using System;
using System.Collections.Generic;

#nullable disable

namespace Pattern.CQRS.Models
{
    public partial class Player
    {
        public long Id { get; set; }
        public int? ShirtNo { get; set; }
        public string Name { get; set; }
        public int? Appearances { get; set; }
        public int? Goals { get; set; }
    }
}
