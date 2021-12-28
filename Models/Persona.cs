using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Models
{
    public class Persona : BaseEntity
    {
        /*
         ID INT PRIMARY KEY IDENTITY(1,1),
        NOMBRES VARCHAR(500),
        AP_PATERNO VARCHAR(500),
        AP_MATERNO VARCHAR(500),
        CARGO VARCHAR(300),
        ROL VARCHAR(50),
        NICK VARCHAR(500),
        PASS VARCHAR(500),
        -- AUDITORIA
        ESTADO BIT,
        FECHAREGISTRO DATETIME,
        FECHAMOD DATETIME,
        FECHAELI DATETIME
         
         */

        public string nombres { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string cargo { get; set; }
        public string rol { get; set; }
        public string username { get; set; }
        public string pass { get; set; }

        

    }
}
