using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Codes.Core.GameObjectsEntity
{
    public interface IComponent
    {
        EntityUid Owner { get; }

        string Name { get; }
    }

    public abstract class Component : IComponent
    {
        public EntityUid Owner { get; set; }

        public abstract string Name { get; }
    }
}
