using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaApp.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }

}