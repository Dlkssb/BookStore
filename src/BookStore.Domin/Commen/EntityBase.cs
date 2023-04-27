using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domin.Commen
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = new Guid();
        public int Code { get; set; }
    }
}
