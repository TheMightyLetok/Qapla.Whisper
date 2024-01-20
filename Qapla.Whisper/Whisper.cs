using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Qapla.Whisper;

public partial class Whisper : Form
{
    private bool _isRecording = false;
    private readonly AudioRecorder _recorder;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    private System.Windows.Forms.Timer _messageTimer;

    private IConfiguration _configuration { get; }

    public Whisper(IConfiguration configuration)
    {
        InitializeComponent();
        TopMost = true;
        
        _recorder = new AudioRecorder("test.mp3");
        _configuration = configuration;

        // Initialize the timer
        _messageTimer = new System.Windows.Forms.Timer();
        _messageTimer.Interval = 1000;
        _messageTimer.Tick += MessageTimer_Tick;
    }

    private void RecordButton_Click(object sender, EventArgs e)
    {
        if (_isRecording)
        {
            _recorder.StopRecording();

            _isRecording = false;
            recordButton.Text = "Processing...";

            var transcription = SendToWhisperAPI("test.wav");
            Clipboard.SetText(transcription);
            resultText.Text = transcription;
            recordButton.Text = "Copied to clipboard";
            _messageTimer.Start(); // Start the timer
        }
        else
        {
            _recorder.StartRecording();
            _isRecording = true;
            recordButton.Text = "Stop Recording";
        }
    }

    private string SendToWhisperAPI(string flacFilePath)
    {
        var client = new RestClient("https://api.openai.com/v1/audio");
        var request = new RestRequest("transcriptions", Method.Post);
        request.AddHeader("Authorization", $"Bearer {_configuration["OpenAISecretKey"]}");
        request.AddHeader("Content-Type", "multipart/form-data");
        request.AddFile("file", @"test.mp3");
        request.AddParameter("model", "whisper-1", ParameterType.RequestBody);


        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            var content = response.Content;

            var options = _jsonSerializerOptions;
            var transcriptionResponse = JsonSerializer.Deserialize<TranscriptionResponse>(content, options);
            Console.WriteLine(transcriptionResponse?.Text);
            return transcriptionResponse?.Text ?? string.Empty;
        }

        return $"Error: {response.ErrorMessage}";
    }

    private void MessageTimer_Tick(object sender, EventArgs e)
    {
        recordButton.Text = "Start Recording";
        _messageTimer.Stop();
    }
}

public class TranscriptionResponse
{
    public required string Text { get; set; }
}

