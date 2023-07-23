using FinalProject.Domain.Enums;

namespace FinalProject.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdDto
    {
        public Guid Id { get; set; }
        public int RequestedAmount { get; set; }
        public int TotalFoundedAmount { get; set; }
        public ProductCrowlType ProductCrowlType { get; set; }
        public string UserId { get; set; }
    }
}
