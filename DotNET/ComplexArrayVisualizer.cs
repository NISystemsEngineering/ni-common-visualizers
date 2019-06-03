using Microsoft.VisualStudio.DebuggerVisualizers;
using NationalInstruments;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(NationalInstruments.ApplicationsEngineering.Visualizers.ComplexArrayVisualizer<ComplexSingle>),
    typeof(VisualizerObjectSource),
    Target = typeof(ComplexSingle[]))]

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(NationalInstruments.ApplicationsEngineering.Visualizers.ComplexArrayVisualizer<ComplexDouble>),
    typeof(VisualizerObjectSource),
    Target = typeof(ComplexDouble[]))]

namespace NationalInstruments.ApplicationsEngineering.Visualizers
{
    public class ComplexArrayVisualizer<T> : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var complexArray = (T[])objectProvider.GetObject();
            double t0 = 0.0;
            double dt = 1.0;
            var wfm = ComplexWaveform<T>.FromArray1D(complexArray);
            double[] real = wfm.GetRealDataArray(true);
            double[] imag = wfm.GetImaginaryDataArray(true);
            LabVIEWVisualizers.ComplexWaveform(t0, dt, real, imag, wfm.SampleCount);
        }
    }
}
