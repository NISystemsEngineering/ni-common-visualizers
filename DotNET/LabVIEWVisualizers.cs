using System.Runtime.InteropServices;

namespace NationalInstruments.ApplicationsEngineering.Visualizers
{
    internal static class LabVIEWVisualizers
    {
        public static void ComplexWaveform(double t0, double dt, double[] real, double[] imag, int length)
        {
            int errorCode = ComplexWaveformVisualizer(t0, dt, real, imag, length);
            if (errorCode != 0)
                throw new ExternalException("An error occured in the lvnetviz dll.", errorCode);
        }

        [DllImport("lvnetviz.dll",
            EntryPoint = "ComplexWaveformVisualizer",
            CallingConvention = CallingConvention.Cdecl)]
        private static extern int ComplexWaveformVisualizer(double t0, double dt, double[] real, double[] imag, int length);
    }
}
