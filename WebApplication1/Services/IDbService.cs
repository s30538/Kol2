using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IDbService
{

    Task<ClientDTO> GetClient(int CustmerId, String type);
    Task AddWAshing(WashingDTO dto);
}