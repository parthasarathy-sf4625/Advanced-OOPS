using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Outside;
namespace Inside
{
    public class Second:First
    {
        //fields
        internal protected int _internalNum = 50;
        public int ProtectedNumberOut{get {return protectedNumber;}}
    }
}