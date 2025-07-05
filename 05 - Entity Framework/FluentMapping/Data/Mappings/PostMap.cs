using FluentMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapping.Data.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>{
    public void Configure(EntityTypeBuilder<Post> builder){
        //Table
        builder.ToTable("Post");
        
        //Chave Primaria
        builder.HasKey(x => x.Id);
        
        //Identity
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        //Propriedades

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnName("LastUpdateDate") // DATETIME NOT NULL DEFAULT(GETDATE())
            .HasColumnType("SMALLDATETIME")
            //.HasDefaultValueSql("GETDATE()") // Sera gerado pela função do SQL
            .HasDefaultValue(DateTime.Now.ToUniversalTime()); // Sera gerado pelo .C#
        
        builder.Property(x => x.Slug)
            .IsRequired()// Not NULL
            .HasMaxLength(100)
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR");

        
        //Fazer para os demais atributos
        
        
        //Indices
        builder.HasIndex(x => x.Slug, "IX_Post_Slug").IsUnique();
        
        
        //Relacionamentos
        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.Posts) //Realação 1 p/ muitos
            .HasConstraintName("FK_Post_Author"); // Gera o nome da Constraint
        //.OnDelete(DeleteBehavior.Cascade); // Se Deletar um Post, ira deletar junto o autor dele (CUIDADO)

        
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Posts) //Realação 1 p/ muitos
            .HasConstraintName("FK_Post_Category"); // Gera o nome da Constraint
        //.OnDelete(DeleteBehavior.Cascade); // Se Deletar um Post, ira deletar junto o autor dele (CUIDADO)


        //Relacionamento N/N -> Gera tabela
        builder
            .HasMany(x => x.Tags)
            .WithMany(x=>x.Posts)
            .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post=>post
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag=> tag
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                   
                );


    }
}