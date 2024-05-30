using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        return Problem();
    }
}
