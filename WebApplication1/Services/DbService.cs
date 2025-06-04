using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ClientDTO> GetClient(int CustmerId, String type)
    {


        return null;
        //za duzo bledow przy migracji było i nie starczyło czasu
    }

    public Task AddWAshing(WashingDTO dto)
    {
        return null;
    }
}