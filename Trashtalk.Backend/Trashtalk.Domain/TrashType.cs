using System;
using System.Collections.Generic;

namespace Trashtalk.Domain
{
    public class TrashType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public TrashBin TrashBin { get; set; }
        public Guid TrashBinId { get; set; }
        public IList<Trash> Trash { get; set; }

    }
}
