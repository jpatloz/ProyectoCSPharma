using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProyectoCSPharma.Roles
{
    [Authorize(Roles = "Empleados, Administradores")]
    public class Empleado : PageModel
    {
        public IActionResult Index()
        {
            return Page();
        }
    }
}

