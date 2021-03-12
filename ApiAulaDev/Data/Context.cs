using ApiAulaDev.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAulaDev.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
