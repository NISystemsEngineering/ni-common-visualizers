# LabVIEW Visualizers for Visual Studio
## Debugging Tools for NI .NET Types

The LabVIEW Visualizers for Visual Studio integrate directly into the Visual Studio IDE to provide a richer debugging experience when working with NI .NET types.

### Screenshots:
Hovering over types in the editor will show a magnifying glass. The same icon will be available in the watch window as well.
![](images/magnifying_glass.png "")
Clicking the magnifying glass icon will open the type in the appropriate LabVIEW Visualizer.
![](images/rfvisualizer.png "")

### Dependencies:
- .NET Framework 4.0
- LabVIEW Runtime Engine 2018 (32 bit)

### Installation Instructions:
1. Unpack the latest release into the Visual Studio 20xx Visualizers folder located in the user Documents folder. The full path will be similar to C:\Users\<YOUR USERNAME>\Documents\Visual Studio 20xx\Visualizers.
2. Restart Visual Studio

### Currently supported types:
- ComplexWaveform\<ComplexSingle\>
- ComplexWaveform\<ComplexDouble\>
- ComplexSingle[]
- ComplexDouble[]