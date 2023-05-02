using Microsoft.AspNetCore.Mvc;
using OcsTestWork.Application.Models.Order;
using OcsTestWork.Application.Orders.Commands.Create;
using OcsTestWork.Application.Orders.Commands.Delete;
using OcsTestWork.Application.Orders.Commands.Update;
using OcsTestWork.Application.Orders.Queries.GetOrder;
using OcsTestWork.Domain.Entities;

namespace OcsTestWork.OrderApi.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : AppControllerBase
{
    /// <summary>
    /// Получение по id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderVm>> Get(Guid orderId)
    {
        var query = new GetOrderQuery(orderId);
        var result = await Sender.Send(query);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(result.Errors);
    }

    /// <summary>
    /// Создание
    /// </summary>
    /// <param name="orderCreateVm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<OrderVm>> Create(OrderCreateVm orderCreateVm)
    {
        var command = new CreateOrderCommand(orderCreateVm.id,
            orderCreateVm.lines.Select(l => new OrderedProduct(l.id, l.qty)));

        var result = await Sender.Send(command);
        
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(result.Errors);
    }
    
    [HttpPut]
    public async Task<ActionResult<OrderVm>> Update(OrderUpdateVm orderUpdateVm)
    {
        var command = new UpdateOrderCommand(orderUpdateVm.id,
            orderUpdateVm.status,
            orderUpdateVm.lines.Select(l => new OrderedProduct(l.id, l.qty)));

        var result = await Sender.Send(command);
        
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(result.Errors);
    }

    [HttpDelete]
    public async Task<ActionResult<int>> Delete(Guid id)
    {
        var command = new DeleteOrderCommand(id);

        var result = await Sender.Send(command);
        
        if (result.IsSuccess)
        {
            return Ok();
        }
        
        return BadRequest(result.Errors);
    }
}