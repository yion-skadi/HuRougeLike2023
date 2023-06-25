using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Codes.Core.GameObjectsEntity
{
    public readonly struct EntityUid : IEquatable<EntityUid>, IComparable<EntityUid>
    {
        readonly int _uid;

        public int CompareTo(EntityUid other)
        {
            return _uid.CompareTo(other._uid);
        }

        public bool Equals(EntityUid other)
        {
            return _uid == other._uid;
        }
    }
}
