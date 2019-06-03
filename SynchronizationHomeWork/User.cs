using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationHomeWork
{
    public class User
    {
        private int _money;
        private object lockObject = new object();
        
        public int Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }
    }
}
