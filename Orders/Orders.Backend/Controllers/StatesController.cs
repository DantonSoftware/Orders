using Microsoft.AspNetCore.Mvc;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    public StatesController(UnitsOfWork.Interfaces.IGenericUnitOfWork<State> unitOfWork) : base(unitOfWork)
    {
    }
}