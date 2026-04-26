using GoodHamburger.Application.DTOs.Orders;
using GoodHamburger.Application.DTOs.Orders.Requests;
using GoodHamburger.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderServices _orderServices;

    public OrderController(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll()
    {
        var orders = await _orderServices.GetAllAsync();

        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDTO>> GetById(int id)
    {
        var order = await _orderServices.GetByIdAsync(id);
  
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDTO>> Create([FromBody] CreateOrderDTO createOrderDTO)
    {
        var created = await _orderServices.CreateAsync(createOrderDTO);

        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDTO updateOrderDTO)
    {
        await _orderServices.UpdateAsync(id, updateOrderDTO);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderServices.DeleteAsync(id);

        return NoContent();
    }
}