using Microsoft.Kinect;
using System;
using System.Collections.Generic;

namespace KinectDemo
{
    /// <summary>
    /// Static example on how to read body data
    /// The programming paradigms used in this example are not recommended
    /// </summary>
    internal class Program
    {
        private delegate void BodyReadyEventHandler(Body b);
        private static KinectSensor _sensor;
        private static IList<Body> _bodies;
        private static event BodyReadyEventHandler BodyReady;

        private static void Main()
        {
            _sensor = KinectSensor.GetDefault(); // get singleton instance of the KinectSensor
            var bodyFrameReader = _sensor.BodyFrameSource.OpenReader(); // get body frame reader

            // event handlers
            bodyFrameReader.FrameArrived += Reader_FrameArrived;
            _sensor.IsAvailableChanged += Sensor_IsAvailableChanged;
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            BodyReady += Program_BodyReady;

            // open sensor
            _sensor.Open();

            while (_sensor.IsOpen)
            {
                // close button: x key
                if (Console.ReadKey().Key == ConsoleKey.X) _sensor.Close();
            }
        }

        /// <summary>
        /// Handles body data
        /// </summary>
        /// <param name="body">body data from kinect sensor</param>
        private static void Program_BodyReady(Body body)
        {
            foreach (var joint in body.Joints)
            {
                if (joint.Value.TrackingState == TrackingState.NotTracked || joint.Value.TrackingState == TrackingState.Inferred) continue; //joint is not tracked, so skip it for now

                // print 3D joint information
                Console.Write(joint.Key);
                Console.Write(" - ");
                Console.WriteLine("(" + joint.Value.Position.X + ", " + joint.Value.Position.Y + ", " + joint.Value.Position.Z + ")");
            }
        }

        private static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs args)
        {
            using (var bodyFrame = args.FrameReference.AcquireFrame())  //disposes variable after this block statement
            {
                _bodies = new Body[bodyFrame.BodyCount];

                bodyFrame.GetAndRefreshBodyData(_bodies); // fill _bodies list with body data

                foreach (var body in _bodies) // for every body
                {
                    if (!body.IsTracked) continue; // body is not tracked, skip body

                    BodyReady?.BeginInvoke(body, null, null);

                    break; //when one body is handled, break out of this loop
                }
            }
        }

        private static void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs args)
        {
            Console.WriteLine(args.IsAvailable);
        }

        private static void OnProcessExit(object sender, EventArgs args)
        {
            _sensor.Close();
        }
    }
}
