using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Enterprise.Domain;

namespace Enterprise.Persistence.Data
{
     public class EnterpriseContext : DbContext
    {
        public EnterpriseContext(DbContextOptions<EnterpriseContext> options) : base (options) { } 
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Depto> Deptos { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
                modelBuilder.Entity<Depto>()
                    .HasData(new List<Depto>(){
                        new Depto(1,"Venda", "VEN"),
                        new Depto(2,"Recurso Humanos", "RH"),
                        new Depto(3,"Logistica", "LOG"),
                });

                modelBuilder.Entity<Funcionario>()
                    .HasData(new List<Funcionario>(){
                        new Funcionario (1, "Marta Souza", "idfjidjf", "87878787", 1),
                        new Funcionario (2, "Leticia Muriel", "idfjidjf", "87878787", 2),
                        new Funcionario (3, "Renato Silva", "idfjidjf", "87878787", 3),
                        new Funcionario (4, "Noel Lucas Souza", "idfjidjf", "87878787", 3),
                        new Funcionario (5, "Manoel Barbosa", "idfjidjf", "87878787", 3),
                        new Funcionario (6, "João Cardoso", "idfjidjf", "87878787", 1),
                    });            
            
        }
    }
}