using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaApp.Domain.BaseEntity
{
    public interface IAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }

        //Author
        public string CreatedBy { get; set; }


        public DateTime? ModifiedOn { get; set; }

        //Editor
        public string? ModifieddBy { get; set; }
    }
}