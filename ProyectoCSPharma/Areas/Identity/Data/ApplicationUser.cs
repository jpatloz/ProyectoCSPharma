﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProyectoCSPharma.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
    public string Nombre { get; set; }

    public string Apellidos { get; set; }
}

