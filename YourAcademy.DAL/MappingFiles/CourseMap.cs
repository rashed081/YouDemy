using FluentNHibernate.Mapping;
using YourAcademy.DAL.Entity;

namespace YourAcademy.DAL.MappingFiles
{
    public class CourseMap :ClassMap<Course>
    {
        public CourseMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.Image);
            Map(x => x.Instructor);
            Map(x => x.Rating);
            Table("Course");
        }
    }
}
