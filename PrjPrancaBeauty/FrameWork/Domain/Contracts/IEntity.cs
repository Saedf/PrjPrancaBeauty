using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Domain.Contracts
{
    public interface IEntity<T>:IBaseEntity<T>
    {

    }
    public interface IEntity : IEntity<Guid>
    {

    }
}
