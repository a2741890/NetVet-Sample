using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVet.Domain.Entities
{
    public class Animal
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; }
        public AnimalSizes Size { get; set; }
    }
}
