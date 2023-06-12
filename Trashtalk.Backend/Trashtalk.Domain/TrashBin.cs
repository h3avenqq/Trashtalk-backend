using System;
using System.Collections.Generic;

namespace Trashtalk.Domain
{
    public class TrashBin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public IList<TrashType> TrashTypes { get; set; }
    }
}
