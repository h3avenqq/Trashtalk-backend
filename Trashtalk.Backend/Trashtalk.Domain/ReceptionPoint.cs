using System;
using System.Collections.Generic;
using System.Drawing;

namespace Trashtalk.Domain
{
    public class ReceptionPoint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public Point Coordinates { get; set; }
        public IList<News> News { get; set; }
    }
}
