using Microsoft.EntityFrameworkCore;
using Senac.ADS.PPFA.SenacEduca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senac.ADS.PPFA.SenacEduca.Repositories
{
    public class SenacEducaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public SenacEducaContext(DbContextOptions<SenacEducaContext> options)
          : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(aluno => aluno.Id);

                entity.Property(aluno => aluno.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(aluno => aluno.Nome)
                      .HasColumnName("nome");

                entity.Property(aluno => aluno.CPF)
                      .HasColumnName("CPF");

                entity.Property(aluno => aluno.Telefone)
                      .HasColumnName("telefone");

                entity.Property(aluno => aluno.TurmaId)
                      .HasColumnName("turmaid");

                entity.HasOne(aluno => aluno.Turma)
                    .WithMany(turma => turma.Alunos)
                    .HasForeignKey(aluno => aluno.TurmaId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.HasKey(disciplina => disciplina.Id);

                entity.Property(disciplina => disciplina.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(disciplina => disciplina.Descricao)
                      .HasColumnName("descricao");

                entity.Property(disciplina => disciplina.CargaHoraia)
                      .HasColumnName("cargahoraria");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(grade => grade.Id);

                entity.Property(grade => grade.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(grade => grade.TurmaId)
                      .HasColumnName("turmaid");

                entity.Property(grade => grade.DisciplinaId)
                      .HasColumnName("disciplinaid");

                entity.Property(grade => grade.ProfessorId)
                      .HasColumnName("professorid");

                entity.HasOne(grade => grade.Turma)
                    .WithMany(turma => turma.Grades)
                    .HasForeignKey(grade => grade.TurmaId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(grade => grade.Disciplina)
                    .WithMany(disciplina => disciplina.Grades)
                    .HasForeignKey(grade => grade.DisciplinaId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(grade => grade.Professor)
                    .WithMany(professor => professor.Grades)
                    .HasForeignKey(grade => grade.ProfessorId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

           modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(professor => professor.Id);

                entity.Property(professor => professor.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(professor => professor.Nome)
                      .HasColumnName("nome");

                entity.Property(professor => professor.Formacao)
                      .HasColumnName("formacao");

                entity.Property(professor => professor.CPF)
                      .HasColumnName("CPF"); 
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(turma => turma.Id);

                entity.Property(turma => turma.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(turma => turma.Descricao)
                      .HasColumnName("descricao");

                entity.Property(turma => turma.Periodo)
                      .HasColumnName("periodo");
            });
        }
    }
}
