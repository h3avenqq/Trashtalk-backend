using System;

namespace Trashtalk.Domain
{
    public class UserTrash
    {
        public Guid Id { get; set; }
        public Trash Trash { get; set; }
        public Guid TrashId { get; set; }
        public Guid UserId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime Time { get; set; }
    }
}
