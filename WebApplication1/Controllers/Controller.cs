using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IDbService _dbService;

    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddWAshing(WashingDTO dto)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [HttpGet("{orderId}/purchase")]
    public async Task<IActionResult> GetClient(WashingDTO dto)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }
    
}