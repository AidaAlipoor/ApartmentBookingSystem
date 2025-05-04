using Book.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(200)
                .HasConversion(user => user.firstName, name => new FirstName(name));          
            
            builder.Property(user => user.LastName)
                .HasMaxLength(200)
                .HasConversion(user => user.lastName, name => new LastName(name));            
            
            builder.Property(user => user.Email)
                .HasMaxLength(400)
                .HasConversion(user => user.email, email => new Domain.Users.Email(email));

            builder.HasIndex(user => user.Email).IsUnique();
            builder.ToTable("Users");   
        }
    }
}
