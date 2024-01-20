using NAudio.Wave;
using NAudio.Lame;

namespace Qapla.Whisper;

public class AudioRecorder
{
    private WaveInEvent waveIn;
    private WaveFileWriter? writer;
    private string outputFilename;

    public AudioRecorder(string filename)
    {
        outputFilename = filename;
        waveIn = new WaveInEvent();
        waveIn.DataAvailable += OnDataAvailable;
        waveIn.WaveFormat = new WaveFormat(44100, 1);
    }

    public void StartRecording()
    {
        writer = new WaveFileWriter(Path.ChangeExtension(outputFilename, ".wav"), waveIn.WaveFormat);
        waveIn.StartRecording();
    }

    public void StopRecording()
    {
        waveIn.StopRecording();
        writer?.Dispose();

        ConvertToMp3(outputFilename);
    }

    private void OnDataAvailable(object sender, WaveInEventArgs e)
    {
        writer?.Write(e.Buffer, 0, e.BytesRecorded);
    }

    private static void ConvertToMp3(string filename)
    {
        string wavFile = Path.ChangeExtension(filename, ".wav");
        string mp3File = Path.ChangeExtension(filename, ".mp3");

        using (var reader = new AudioFileReader(wavFile))
        using (var mp3Writer = new LameMP3FileWriter(mp3File, reader.WaveFormat, LAMEPreset.STANDARD))
        {
            reader.CopyTo(mp3Writer);
        }

        File.Delete(wavFile);
    }
}
