using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Domain.Contracts
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
    }
}
