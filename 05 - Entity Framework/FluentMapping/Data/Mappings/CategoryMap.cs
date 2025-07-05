using FluentMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapping.Data.Mappings;

public class CategoryMap: IEntityTypeConfiguration<Category>{
    
    public void Configure(EntityTypeBuilder<Category> builder){
        
        builder.ToTable("Category"); //Tabela
        builder.HasKey(x=> x.Id); // Primary Key (Se o Banco ja esta criado, nao precisa definir mais nada)
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();// Identity (1,1) (nao necessario caso o banco tenha sido criado via SQL)
        
        //Propriedades
        builder.Property(x => x.Name)
            .IsRequired()// Not NULL
            .HasMaxLength(100)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR");
        
        builder.Property(x => x.Slug)
            .IsRequired()// Not NULL
            .HasMaxLength(100)
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR");
        
        //Indices
        builder.HasIndex(x => x.Slug, "IX_Category_Slug").IsUnique();
    }
}