using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Web
{
    public interface IActivityAccessor
    {
        Activity Current { get; }
    }

    public class ActivityAccessor : IActivityAccessor
    {
        public Activity Current => Activity.Current;
    }
}
