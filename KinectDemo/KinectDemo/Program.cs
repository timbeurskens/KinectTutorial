using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectDemo
{
    class Program
    {
        static KinectSensor sensor = null;

        static void Main(string[] args)
        {
            //get the singleton instance of SomeObject.
            SomeObject someInstance = SomeObject.GetInstance();

            //note that the following is not possible because of the private constructor:
            //SomeObject anotherInstance = new SomeObject();

            sensor = KinectSensor.GetDefault(); // get singleton instance of the KinectSensor
            BodyFrameReader bodyFrameReader = sensor.BodyFrameSource.OpenReader(); // get body frame reader

            // event handlers
            bodyFrameReader.FrameArrived += Reader_FrameArrived;
            sensor.IsAvailableChanged += Sensor_IsAvailableChanged;
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            // open sensor
            sensor.Open();           
        }

        static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs args)
        {
            Console.WriteLine(args.FrameReference.AcquireFrame().BodyCount);
        }

        static void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs args)
        {
            Console.WriteLine(args.IsAvailable);
        }

        static void OnProcessExit(object sender, EventArgs args)
        {
            sensor.Close();
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
