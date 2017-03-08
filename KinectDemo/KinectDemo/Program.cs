using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the singleton instance of SomeObject.
            SomeObject someInstance = SomeObject.GetInstance();

            //note that the following is not possible because of the private constructor:
            //SomeObject anotherInstance = new SomeObject();
        }
    }

    class SomeObject
    {
        private static SomeObject instance = null;

        /// <summary>
        /// Private constructor for SomeObject.
        /// Note that the constructor is private, thus external classes cannot create
        /// new instances of this object.
        /// </summary>
        private SomeObject()
        {
            //initialize the object
        }

        /// <summary>
        /// Gets the singleton instance of the SomeObject class.
        /// </summary>
        /// <returns>The singleton instance of SomeObject.</returns>
        public static SomeObject GetInstance()
        {
            if(instance == null) // instance is not yet initialized
            {
                instance = new SomeObject();
            }

            return instance;
        }
    }
}
