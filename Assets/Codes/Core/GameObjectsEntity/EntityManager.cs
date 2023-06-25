using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Codes.Core.GameObjectsEntity
{
    class EntityManager
    {
        private Dictionary<EntityUid, Component>[] _entTraitArray = Array.Empty<Dictionary<EntityUid, Component>>();
        private static int ArrayIndexFor<T>() => CompArrayIndex<T>.Index;
        private static int _compIndexMaster = -1;

        public bool TryGetComponent<T>(EntityUid uid, [NotNullWhen(true)] out T component)
        {
            var dict = _entTraitArray[ArrayIndexFor<T>()];

            if (dict.TryGetValue(uid, out var comp))
            {
                    component = (T)(IComponent)comp;
                    return true;
                
            }

            component = default!;
            return false;
        }

        private static class CompArrayIndex<T>
        {
            // ReSharper disable once StaticMemberInGenericType
            public static readonly int Index = Interlocked.Increment(ref _compIndexMaster);
        }
    }
}
