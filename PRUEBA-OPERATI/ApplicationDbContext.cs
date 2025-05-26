using PRUEBA_OPERATI.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using SystemClaim = System.Security.Claims.Claim;

namespace GESTION_PAGOS 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PotenciaParticipante> PotenciasParticipantes { get; set; }

    }
}
