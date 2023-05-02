using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OcsTestWork.OrderApi.Controllers;

public class AppControllerBase : ControllerBase
{
    private ISender _sender { get; set; }
    
    protected ISender Sender =>
        _sender ??= HttpContext.RequestServices.GetService<ISender>();
}