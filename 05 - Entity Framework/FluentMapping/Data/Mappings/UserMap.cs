using FluentMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapping.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>{
    
    public void Configure(EntityTypeBuilder<User> builder){
        
        //Table
        builder.ToTable("User");
        
        //Chave Primaria
        builder.HasKey(x => x.Id);
        
        //Identity
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        //Propriedades

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Slug)
            .IsRequired()// Not NULL
            .HasMaxLength(100)
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR");

        //Fazer para os demais atributos
        
        
        //Indices
        builder.HasIndex(x => x.Slug, "IX_User_Slug").IsUnique();
        
        
        
        //Relacionamento

        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_UserRole_RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                user => user
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_UserRole_UserId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
    
}