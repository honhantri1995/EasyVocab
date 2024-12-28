using System;
using Google.Cloud.TextToSpeech.V1;
using System.IO;

namespace VocabManager
{
    // https://codelabs.developers.google.com/codelabs/cloud-text-speech-csharp#2

    public class GoogleTextToSpeech
    {
        public void TextToSpeech(string text, string country)
        {
            var client = TextToSpeechClient.Create();

            // The input to be synthesized, can be provided as text or SSML.
            var input = new SynthesisInput
            {
                Text = text
            };

            // Build the voice request
            var voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = country,
                SsmlGender = SsmlVoiceGender.Female
            };

            // Specify the type of audio file
            var audioConfig = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Mp3
            };

            // Perform the text-to-speech request
            var response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Write the response to the output file
            using (var output = File.Create("output.mp3"))
            {
                response.AudioContent.WriteTo(output);
            }
        }
    }
}