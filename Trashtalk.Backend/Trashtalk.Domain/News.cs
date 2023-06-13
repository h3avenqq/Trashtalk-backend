using System;

namespace Trashtalk.Domain
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? EditDate { get; set; }
        public ReceptionPoint Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
