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
                using (Stream ms = new MemoryStream())
                {
                    using (Stream stream = WebRequest.Create(url)
                        .GetResponse().GetResponseStream())
                    {
                        byte[] buffer = new byte[32768];
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                    }

                    ms.Position = 0;
                    using (var blockAlignedStream = new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
                    {
                        using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                        {
                            waveOut.Init(blockAlignedStream);
                            waveOut.Play();
                            while (waveOut.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
