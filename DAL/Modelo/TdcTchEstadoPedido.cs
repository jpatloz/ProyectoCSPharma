﻿using System;
using System.Collections.Generic;

namespace DAL.Modelo;

public partial class TdcTchEstadoPedido
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string? CodEstadoEnvio { get; set; }

    public string? CodEstadoPago { get; set; }

    public string? CodEstadoDevolucion { get; set; }

    public string CodPedido { get; set; } = null!;

    public string CodLinea { get; set; } = null!;
}
