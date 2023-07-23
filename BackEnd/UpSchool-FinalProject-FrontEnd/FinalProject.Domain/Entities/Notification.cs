using FinalProject.Domain.Common;
using FinalProject.Domain.Identity;

namespace FinalProject.Domain.Entities
{
    public class Notification:EntityBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsClicked { get; set; }
        public string UserId { get; set; }
    }
}
