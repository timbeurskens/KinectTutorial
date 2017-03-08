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
}
