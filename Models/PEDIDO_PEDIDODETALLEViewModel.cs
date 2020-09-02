using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXIWARE.Models
{
    public class PEDIDO_PEDIDODETALLEViewModel
    {
        // Información de tabla pedido
        public PEDIDO _PEDIDO { get; set; }

        // Información de tabla pedido_detalle
        public List<PEDIDO_DETALLE> _PEDIDO_DETALLE { get; set; }


    }
}