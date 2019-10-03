using System.Data.Entity;

namespace CadCliente.Data.Cliente
{
    public class ClienteContext : DbContext
    {
        public DbSet<Domain.Cliente.Entites.Cliente> Clientes { get; set; }
    }
}
