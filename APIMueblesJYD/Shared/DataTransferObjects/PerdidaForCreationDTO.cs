using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class PerdidaForCreationDTO
    {
        public DateTime FechaPerdida { get; set; }
        public int Estado { get; set; }
        public float Total { get; set; }
        public PerdidaProductoDTO perdidaProductoDTO { get; set; }
    }
}
