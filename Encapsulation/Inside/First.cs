using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Outside;
namespace Inside
{
    public class First:Third
    {
        private int _privateNumber = 10; //Field
        public int publicNumber = 16;

        protected int protectedNumber =23;

        internal int internalNum = 50;
        public int PrivateOut 
        {
            get
            {
                return _privateNumber;

            }
        }

        public int InternalProtectedOut
        {
            get
            {
                return internalProtected; 
            }
        }     
    }
}