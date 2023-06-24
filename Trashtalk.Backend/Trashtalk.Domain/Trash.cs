using System;
using System.Collections.Generic;

namespace Trashtalk.Domain
{
    public class Trash
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public float Weight { get; set; }
        public TrashType Type { get; set; }
        public Guid TypeId { get; set; }
        public IList<UserTrash> UserTrash { get; set; }
    }
}
