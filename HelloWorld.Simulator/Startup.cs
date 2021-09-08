using OpenSilver.Simulator;
using System;

namespace HelloWorld.Simulator
{
    static class Startup
    {
        [STAThread]
        static int Main(string[] args)
        {
            return SimulatorLauncher.Start(typeof(HelloWorld.App));
        }
    }
}
