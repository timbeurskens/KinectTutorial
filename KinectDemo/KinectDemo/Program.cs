using System;
using System.Threading;

namespace KinectDemo
{
    internal class Program
    {
        public delegate void MyEventDelegate(object sender, EventArgs e); // define how an event listener should look like

        public event MyEventDelegate MyEvent; // the event

        private static void Main()
        {
            var instance = new Program(); // create instance of program

            instance.MyEvent += Instance_MyEvent; // add an event-listener

            instance.Run(); // start program
        }

        /// <summary>
        /// Main method for the program instance
        /// </summary>
        public void Run()
        {
            //do some stuff
            Thread.Sleep(100);

            OnMyEvent(); //fire event
        }

        /// <summary>
        /// The event listener
        /// </summary>
        /// <param name="sender">Sender object of MyEvent</param>
        /// <param name="e">Event arguments, in this case empty</param>
        private static void Instance_MyEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Event!");
        }

        /// <summary>
        /// Fires the MyEvent event
        /// </summary>
        protected virtual void OnMyEvent()
        {
            MyEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
