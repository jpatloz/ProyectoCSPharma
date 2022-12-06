using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoCSPharma.Areas.Identity.Data;

namespace ProyectoCSPharma.Areas.Identity.Data;

public class LoginRegisterContext : IdentityDbContext<ApplicationUser>
{
    public LoginRegisterContext(DbContextOptions<LoginRegisterContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
 
        builder.ApplyConfiguration(new UserEntityConfiguration());

        builder.HasDefaultSchema("dlk_torrecontrol");

        builder.Entity<IdentityUser>().ToTable("Dlk_cat_acc_empleados");
    }

    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(usuario => usuario.Nombre).HasMaxLength(255);
            builder.Property(usuario => usuario.Apellidos).HasMaxLength(255);
        }
    }
}
