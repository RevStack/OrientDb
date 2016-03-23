using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevStack.Pattern;

namespace RevStack.OrientDb
{
    public class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
        public virtual string _class { get { return GetType().Name; } }
        public string _rid { get; set; }
    }
}
