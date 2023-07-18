namespace FinalProject.Domain.Common
{
    public interface ICreatedByEntity
    {
        DateTimeOffset? CreatedOn { get; set; }
    }
}
