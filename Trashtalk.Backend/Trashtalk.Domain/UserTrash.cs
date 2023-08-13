using NetTopologySuite.Geometries;
using System;

namespace Trashtalk.Domain
{
    public class UserTrash
    {
        public Guid Id { get; set; }
        public Trash Trash { get; set; }
        public Guid TrashId { get; set; }
        public Guid UserId { get; set; }
        public Point Coordinates { get; set; }
        public DateTime Time { get; set; }
    }
}
