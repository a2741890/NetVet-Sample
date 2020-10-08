using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVet.Domain.Entities
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
