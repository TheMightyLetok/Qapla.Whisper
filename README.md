Qapla.Whisper
Overview

Qapla.Whisper is a powerful Windows application designed to streamline the process of transcribing spoken audio into text using the OpenAI Whisper API. With its intuitive interface, it simplifies audio-to-text transcription and makes the resulting text readily available on your clipboard for convenient use.
Key Features

    Seamless conversion of spoken audio to text with the OpenAI Whisper API.
    Automatic copying of transcribed text to the clipboard.
    User-friendly and efficient design for an effortless user experience.

Getting Started
Prerequisites

Before you get started, ensure you have the following prerequisites in place:

    Windows operating system.
    .NET Framework installed on your computer.
    A valid OpenAI API key. If you don't have one, you can obtain it by signing up at OpenAI.

Installation

    Clone this repository to your local machine:

    bash

git clone https://github.com/TheMightyLetok/Qapla.Whisper.git

Navigate to the project directory:

bash

cd Qapla.Whisper

Open the project using your preferred development environment.

Add your OpenAI API key to the appsettings.json file:

json

    {
      "OpenAIApiKey": "YOUR_API_KEY_HERE"
    }

    Build the application.

    Launch the application.

Usage

    Start the Qapla.Whisper application.

    Click the "Start Listening" button to initiate the audio transcription process.

    Speak into your microphone to capture the audio you want to transcribe.

    The transcribed text will be automatically copied to your clipboard.

    You can now paste the copied text into any text editor, document, or application as needed.

Troubleshooting

    If you encounter any difficulties or have questions, please refer to the FAQ for comprehensive troubleshooting instructions.

License

This project is licensed under the MIT License. For full license details, please refer to the LICENSE file.
Acknowledgments

    Special thanks to OpenAI for providing the Whisper API.
    The inspiration for this project arose from the demand for rapid and accurate audio-to-text transcription.
