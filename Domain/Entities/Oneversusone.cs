using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Oneversusone: BaseEntity
    {
        public string Username { get; set; }
        public string? ConnectionID { get; set; }
    }
}
