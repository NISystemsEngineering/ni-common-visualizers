using Microsoft.VisualStudio.DebuggerVisualizers;
using NationalInstruments;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(NationalInstruments.ApplicationsEngineering.Visualizers.ComplexWaveformVisualizer<ComplexSingle>),
    typeof(VisualizerObjectSource),
    Target = typeof(ComplexWaveform<ComplexSingle>))]

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(NationalInstruments.ApplicationsEngineering.Visualizers.ComplexWaveformVisualizer<ComplexDouble>),
    typeof(VisualizerObjectSource),
    Target = typeof(ComplexWaveform<ComplexDouble>))]

namespace NationalInstruments.ApplicationsEngineering.Visualizers
{
    public class ComplexWaveformVisualizer<T> : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var wfm = (ComplexWaveform<T>)objectProvider.GetObject();
            double t0 = wfm.PrecisionTiming.TimeOffset.TotalSeconds;
            double dt = 1.0;
            try { dt = wfm.PrecisionTiming.SampleInterval.TotalSeconds; }
            catch { }
            double[] real = wfm.GetRealDataArray(true);
            double[] imag = wfm.GetImaginaryDataArray(true);
            LabVIEWVisualizers.ComplexWaveform(t0, dt, real, imag);
        }
    }
}
