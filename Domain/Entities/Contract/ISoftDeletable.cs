namespace Domain.Entities.Contract
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public void Delete()
        {
            IsDeleted = true;
            DeletedDate = DateTime.UtcNow;
        }

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedDate = null;
        }
    }
}
