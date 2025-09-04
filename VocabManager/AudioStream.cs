using System;
using System.IO;
using System.Net;
using System.Threading;
using NAudio.Wave;

namespace VocabManager
{
    public class AudioStream
    {
        public void Play(string url)
        {
            try
            {
                // Ensure modern TLS for HTTPS
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 ;

                // 1) Download the MP3 fully into memory
                using var ms = new MemoryStream();
                using (var client = new WebClient())
                {
                    var data = client.DownloadData(url);
                    ms.Write(data, 0, data.Length);
                }
                ms.Position = 0;

                // 2) Decode MP3 to PCM in memory
                using var mp3Reader = new Mp3FileReader(ms);
                var pcmFormat = mp3Reader.WaveFormat;

                // 3) Create a buffered provider to hold decoded PCM
                var bufferedProvider = new BufferedWaveProvider(pcmFormat)
                {
                    BufferDuration = TimeSpan.FromSeconds(5), // generous buffer
                    DiscardOnBufferOverflow = true
                };

                // 4) Read all decoded PCM into the buffer
                byte[] buffer = new byte[pcmFormat.AverageBytesPerSecond];
                int bytesRead;
                while ((bytesRead = mp3Reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bufferedProvider.AddSamples(buffer, 0, bytesRead);
                }

                // 5) Wait until we have at least 300ms of audio in the buffer
                int minBytes = (int)(pcmFormat.AverageBytesPerSecond * 0.3);
                while (bufferedProvider.BufferedBytes < minBytes)
                {
                    Thread.Sleep(10);
                }

                // 6) Play from the buffered provider
                using var waveOut = new WaveOutEvent();
                using var playbackDone = new AutoResetEvent(false);

                waveOut.Init(bufferedProvider);
                waveOut.PlaybackStopped += (s, e) => playbackDone.Set();
                waveOut.Play();

                // Wait until playback finishes
                playbackDone.WaitOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Playback error: " + ex.Message);
            }
        }
    }
}