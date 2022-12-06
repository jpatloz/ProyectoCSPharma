using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProyectoCSPharma.Roles
{
    [Authorize(Roles = "Usuarios, Empleados, Administradores")]
    public class Usuario : PageModel
    {
        public IActionResult Index()
        {
            return Page();
        }
    }
}
