using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi10_Layout.Services.Interfaces
{
    public interface ITransientService
    {
        Guid GetID();
    }

    public interface IScopedService
    {
        Guid GetID();
    }

    public interface ISingletonService
    {
        Guid GetID();
    }

    public class MyService : ITransientService, IScopedService, ISingletonService
    {
        private Guid _guid;

        public MyService()
        {
            _guid = Guid.NewGuid();
        }

        public Guid GetID()
        {
            return _guid;
        }
    }
}
