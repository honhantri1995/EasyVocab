using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace VocabManager
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public class DictionaryApi_Data
    {
        private static DictionaryApi_Data _instance;

        public dynamic Word { get; set; }

        public static DictionaryApi_Data GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DictionaryApi_Data();
                return _instance;
            }
            return _instance;
        }

        private DictionaryApi_Data()
        {
        }
    }

    public class DictionaryApi
    {
        private Logger _logger = Logger.GetInstance();
        private DictionaryApi_Data _data = DictionaryApi_Data.GetInstance();

        public DictionaryApi()
        {
        }

        public dynamic GetWord(string word)
        {
            dynamic obj = null;

            try
            {
                string url = String.Format("https://api.dictionaryapi.dev/api/v2/entries/en/{0}", word);
                // string param = "";  // Eg: "?api_key=123";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    // Tell the server to send data in JSON format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // List data response
                    // NOTE: Blocking call (Program will wait here until a response is received or a timeout occurs)
                    HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();  
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body
                        // Note: Make sure to add a reference to System.Net.Http.Formatting.dll
                        string rsp = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        obj = JsonConvert.DeserializeObject(rsp);
                    }
                    else
                    {
                        _logger.Error(String.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                    }
                }

                // Save to member variable
                if (obj == null)
                {
                    _data.Word = null;
                    return null;
                }

                _data.Word = obj[0];      // Note: Only get the first definition
                return obj[0];
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to get word definition via restAPI. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return obj;
            }
        }

        public string GetPronunciation(string country, dynamic word=null)
        {
            if (word == null)
            {
                word = _data.Word;

                if (word == null)
                {
                    return "";
                }
            }

            // Best case: Get correct pronunciation according to country (US, UK)
            foreach (var phonetic in word.phonetics)
            {
                string audioUrl = phonetic.audio;

                if (!String.IsNullOrEmpty(audioUrl))
                {
                    if (audioUrl.ToLower().Contains("-" + country.ToLower()))
                    {
                        return phonetic.text == null ? "" : Utils.FixAIPFont(String.Format("{0}", phonetic.text));
                    }
                }
            }

            // Worst case: Get pronunciatino (might be wrong) without knowning country
            if (word.phonetic != null)
            {
                return Utils.FixAIPFont(String.Format("{0}", word.phonetic));
            }
            else
            {
                foreach (var phonetic in word.phonetics)
                {
                    if (phonetic.text != null)
                    {
                        return Utils.FixAIPFont(String.Format("{0}", phonetic.text));
                    }
                }
            }

            return "";
        }

        public string GetDefinition(string wordType, dynamic word = null)
        {
            if (word == null)
            {
                word = _data.Word;

                if (word == null)
                {
                    return "";
                }
            }

            foreach (var meaning in word.meanings)
            {
                string type = meaning.partOfSpeech;
                dynamic def = meaning.definitions[0];       // Note: Only get the first definition

                if (wordType.ToLower() == type.ToLower())
                {
                    return def.definition;
                }
            }
            return "";
        }

        public void PlayPronunciation_1(string word, string country)
        {
            string[] mp3Urls = {
                // Best case: Play correct pronunciation according to country (US, UK)
                String.Format("https://api.dictionaryapi.dev/media/pronunciations/en/{0}-{1}.mp3", word, country),
                // Worst case: Play pronunciatino (might be wrong) without knowning country
                String.Format("https://api.dictionaryapi.dev/media/pronunciations/en/{0}.mp3", word) };

            foreach (var mp3Url in mp3Urls)
            {
                if (Utils.IsUrlExist(mp3Url))
                {
                    var audioStream = new AudioStream();
                    audioStream.Play(mp3Url);
                    return;
                }
            }
        }

        // API: https://responsivevoice.org/app/?email=triho1110%40gmail.com&vgo_ee=8k4%2BGuA2yfvhRxmgCSQsy9gc%2BZ8azIR0ERRnZDhP7Vxvzvc%3D%3A8PdiK2RcR0LJNOZs2wPdfxVtUUeA8hwi
        // API Key: phTXl2cy
        // FIXME: lag for the first response (https://learn.microsoft.com/en-us/answers/questions/1044378/long-delay-on-tts-first-response)
        public void PreLoadPronunciation(string text, string country)
        {
            string mp3Url = String.Format(@"https://texttospeech.responsivevoice.org/v1/text:synthesize?text={0}&lang={1}&engine=g1&name=&pitch=0.5&rate=0.5&volume=1&key=phTXl2cy&gender=male", text, country);
            Utils.IsUrlExist(mp3Url);
        }
        public void PlayPronunciation_2(string text, string country)
        {
            string mp3Url = String.Format(@"https://texttospeech.responsivevoice.org/v1/text:synthesize?text={0}&lang={1}&engine=g1&name=&pitch=0.5&rate=0.5&volume=1&key=phTXl2cy&gender=male", text, country);

            if (Utils.IsUrlExist(mp3Url))
            {
                var audioStream = new AudioStream();
                audioStream.Play(mp3Url);
                return;
            }
        }

        //public void PlayPronunciation_2(string text, string country)
        //{
        //    var tts = new GoogleTextToSpeech();
        //    tts.TextToSpeech(text, country);
        //}
    }
}
