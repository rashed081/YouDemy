namespace YourAcademy.DAL.Entity
{
    public class Cart :IEntity<Guid>
    {
        public virtual List<Course> CartItems { get; set; }
        public virtual Guid Id { get; set; }
    }
}
