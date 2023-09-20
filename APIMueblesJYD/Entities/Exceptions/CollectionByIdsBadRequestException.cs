using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CollectionByIdsBadRequestException : Exception
    {
        public CollectionByIdsBadRequestException()
            : base("Collection count mismatch comparing to ids")
        {
        }
    }
}
