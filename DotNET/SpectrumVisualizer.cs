using Microsoft.VisualStudio.DebuggerVisualizers;
using NationalInstruments;
using System;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(NationalInstruments.ApplicationsEngineering.Visualizers.SpectrumVisualizer<float>),
    typeof(VisualizerObjectSource),
    Target = typeof(Spectrum<float>))]

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(NationalInstruments.ApplicationsEngineering.Visualizers.SpectrumVisualizer<double>),
    typeof(VisualizerObjectSource),
    Target = typeof(Spectrum<double>))]

namespace NationalInstruments.ApplicationsEngineering.Visualizers
{
    class SpectrumVisualizer<T> : DialogDebuggerVisualizer where T : struct
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (typeof(T).Equals(typeof(float))) { }
            else if (typeof(T).Equals(typeof(double))) { }
            else throw new ArgumentException("Spectrum type must be System.Single or System.Double.");

            var spectrum = (Spectrum<T>)objectProvider.GetObject();
            double f0 = spectrum.StartFrequency;
            double df = spectrum.FrequencyIncrement;
            T[] data = spectrum.GetData();
            double[] power = data as double[];
            if (power == null)
                power = Array.ConvertAll(data as float[], item => (double)item);
            LabVIEWVisualizers.Spectrum(f0, df, power);
        }
    }
}
