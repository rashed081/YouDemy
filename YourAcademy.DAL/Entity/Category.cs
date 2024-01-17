namespace YourAcademy.DAL.Entity
{
    public class Category:IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string? Title { get; set; }
    }
}
