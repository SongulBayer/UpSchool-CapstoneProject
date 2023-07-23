using FinalProject.Domain.Common;
using FinalProject.Domain.Identity;

namespace FinalProject.Domain.Entities
{
    public class Setting:EntityBase<Guid>
    {
        public string UserId { get; set; }

        public bool? SendEmail { get; set; }
        public bool? SendNotification { get; set; }
    }
}
