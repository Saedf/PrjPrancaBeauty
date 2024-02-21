using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Domain
{
    public interface IEntity<T>:IBaseEntity<T>
    {

    }
    public interface IEntity : IEntity<Guid>
    {

    }
}
