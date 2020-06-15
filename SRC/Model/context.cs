using Microsoft.EntityFrameworkCore;
using SRC.Model;

namespace SRC.Model
{
    public class SRC : DbContext
    {
        public DbSet<ofx> ofxs { get; set; }      //propriedade DbSet da Classe<> acessa os dados da tabela
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)       //sobrescrever o metodo de configuraçao normal no EF
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Nibo;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //modelagem padrao das tabelas providas pelo EF
        {
            modelBuilder.ApplyConfiguration(new Mapofx()); // nos arquivos map foram mateados as entidades das tabelas
        }
    }
}
