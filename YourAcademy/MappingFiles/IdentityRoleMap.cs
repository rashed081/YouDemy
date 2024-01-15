using FluentNHibernate.Mapping;
using Microsoft.AspNetCore.Identity;

namespace YourAcademy.MappingFiles
{
    public class IdentityRoleMap : ClassMap<IdentityRole>
    {
        public IdentityRoleMap()
        {
            Table("AspNetRoles");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.NormalizedName).Not.Nullable();
            Map(x => x.ConcurrencyStamp);
        }
    }
}
