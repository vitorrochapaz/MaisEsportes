using maisesportes.Shared.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace maisesportes.Shared.Dados;

    public class maisEsportesContext: DbContext
    {
        public DbSet<Aluno> Alunos {  get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }


        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=maisEsportesV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
               
    }