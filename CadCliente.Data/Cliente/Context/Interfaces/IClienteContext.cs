using System.Data.Entity;
using System.Threading.Tasks;

namespace CadCliente.Data.Cliente.Context.Interfaces
{
    public interface IClienteContext
    {
        DbSet<Domain.Cliente.Entites.Cliente> Clientes { get; set; }
        Task<int> SaveChangesAsync();
    }
}
