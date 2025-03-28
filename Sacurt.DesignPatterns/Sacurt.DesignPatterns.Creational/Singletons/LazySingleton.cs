using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sacurt.DesignPatterns.Creational.Singletons
{
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazySingleton = new Lazy<LazySingleton>(() => new LazySingleton());
        public static LazySingleton Instance => lazySingleton.Value;
        public int Counter = 0;
        private static readonly object _lock = new object();
        private LazySingleton() { }

        public void IncrementCounter()
        {
            lock(_lock)
                Counter++;
        }
        public void DecrementCounter()
        {
            lock (_lock)
                Counter--;
        }

        public int GetCounter() => Counter;
        
        public void Reset()
        {
            lock (_lock)
                Counter = 0;
        }
    }
}
