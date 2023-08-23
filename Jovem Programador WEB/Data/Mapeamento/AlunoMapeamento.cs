


using JovemProgramadorWeb7.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Alunos");



        builder.HasKey(t => t.Id);



        builder.Property(t => t.Nome).HasColumnType("varchar(50)");


    }
}