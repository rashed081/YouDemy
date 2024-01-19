using FluentNHibernate.Mapping;
using YourAcademy.DAL.Entity;

namespace YourAcademy.DAL.MappingFiles
{
    public class CartMap : ClassMap<Cart>
    {
        public CartMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();

            HasManyToMany<Course>(x => x.CartItems)
                .Table("CartItems")
                .ParentKeyColumn("CartId")
                .ChildKeyColumn("CourseId")
                .Cascade.All();

            Table("Cart");
        }
    }

}
