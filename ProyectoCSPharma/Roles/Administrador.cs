using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProyectoCSPharma.Roles
{
    [Authorize(Roles = "Administradores")]
    public class Administrador : PageModel
    {
        public IActionResult Index()
        {
            return Page();
        }
    }
}
