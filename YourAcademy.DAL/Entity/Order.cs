using YourAcademy.DAL.Enums;

namespace YourAcademy.DAL.Entity
{
    public class Order : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual List<Course> Courses { get; set; } 
        public virtual decimal TotalPrice { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CustomerEmail { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
