using FluentNHibernate.Mapping;
using YourAcademy.DAL.Entity;
using YourAcademy.DAL.Enums;

namespace YourAcademy.DAL.MappingFiles
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.OrderDate);
            Map(x => x.TotalPrice);
            Map(x => x.CustomerName);
            Map(x => x.CustomerEmail);
            Map(x => x.PaymentStatus).CustomType<PaymentStatus>();

            HasMany(x => x.Courses)
                .KeyColumn("OrderId")
                .Cascade.All()
                .Inverse();

            Table("Orders");
        }
    }

}
