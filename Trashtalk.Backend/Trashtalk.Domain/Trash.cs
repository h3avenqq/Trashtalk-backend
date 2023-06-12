using System;

namespace Trashtalk.Domain
{
    public class Trash
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public TrashType Type { get; set; }

    }
}
