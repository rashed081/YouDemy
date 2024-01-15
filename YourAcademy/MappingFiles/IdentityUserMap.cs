using FluentNHibernate.Mapping;
using Microsoft.AspNetCore.Identity;

namespace YourAcademy.MappingFiles
{
    public class IdentityUserMap : ClassMap<IdentityUser>
    {
        public IdentityUserMap()
        {
            Table("AspNetUsers");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.UserName).Not.Nullable();
            Map(x => x.NormalizedUserName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.NormalizedEmail).Not.Nullable();
            Map(x => x.EmailConfirmed).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.SecurityStamp);
            Map(x => x.ConcurrencyStamp);
            Map(x => x.PhoneNumber);
            Map(x => x.PhoneNumberConfirmed).Not.Nullable();
            Map(x => x.TwoFactorEnabled).Not.Nullable();
            Map(x => x.LockoutEnd);
            Map(x => x.LockoutEnabled).Not.Nullable();
            Map(x => x.AccessFailedCount).Not.Nullable();
        }
    }
}
