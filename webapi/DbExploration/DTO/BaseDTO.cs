namespace DbExploration.DTO
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "";
        public string AddedBy { get; set; } = "";
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; } = 1;
    }
}