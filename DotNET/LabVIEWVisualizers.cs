using System;
using System.Runtime.InteropServices;

namespace NationalInstruments.ApplicationsEngineering.Visualizers
{
    internal static class LabVIEWVisualizers
    {
        public static void ComplexWaveform(double t0, double dt, double[] real, double[] imag)
        {
            if (real.Length != imag.Length)
                throw new ArgumentException("Real and imaginary arrays must be the same length.");
            int errorCode = ComplexWaveformVisualizer(t0, dt, real, imag, real.Length);
            if (errorCode != 0)
                throw new ExternalException("An error occured in the lvnetviz dll.", errorCode);
        }

        public static void Spectrum(double f0, double df, double[] power)
        {
            int errorCode = SpectrumVisualizer(f0, df, power, power.Length);
            if (errorCode != 0)
                throw new ExternalException("An error occured in the lvnetviz dll.", errorCode);
        }

        [DllImport("lvnetviz.dll",
            EntryPoint = "ComplexWaveformVisualizer",
            CallingConvention = CallingConvention.Cdecl)]
        private static extern int ComplexWaveformVisualizer(double t0, double dt, double[] real, double[] imag, int length);

        [DllImport("lvnetviz.dll",
            EntryPoint = "SpectrumVisualizer",
            CallingConvention = CallingConvention.Cdecl)]
        private static extern int SpectrumVisualizer(double t0, double dt, double[] power, int length);
    }
}
