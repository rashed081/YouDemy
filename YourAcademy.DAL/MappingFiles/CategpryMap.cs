using FluentNHibernate.Mapping;
using YourAcademy.DAL.Entity;

namespace YourAcademy.DAL.MappingFiles
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Title);
            Table("Category");
        }
    }
}

