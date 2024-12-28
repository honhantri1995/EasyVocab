using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace VocabManager
{
    static class Utils
    {
        public static string ConvertFullWordTypeToShorthandWordType(string type)
        {
            string shorthand = String.Empty;

            switch (type)
            {
                case WORD_TYPE.N:
                    shorthand = SHORT_WORD_TYPE.N;
                    break;
                case WORD_TYPE.V:
                    shorthand = SHORT_WORD_TYPE.V;
                    break;
                case WORD_TYPE.ADJ:
                    shorthand = SHORT_WORD_TYPE.ADJ;
                    break;
                case WORD_TYPE.ADV:
                    shorthand = SHORT_WORD_TYPE.ADV;
                    break;
                case WORD_TYPE.PN:
                    shorthand = SHORT_WORD_TYPE.PN;
                    break;
                case WORD_TYPE.PP:
                    shorthand = SHORT_WORD_TYPE.PP;
                    break;
                case WORD_TYPE.C:
                    shorthand = SHORT_WORD_TYPE.C;
                    break;
                case WORD_TYPE.I:
                    shorthand = SHORT_WORD_TYPE.I;
                    break;
                case WORD_TYPE.PRF:
                    shorthand = SHORT_WORD_TYPE.PRF;
                    break;
                case WORD_TYPE.POF:
                    shorthand = SHORT_WORD_TYPE.POF;
                    break;
                case WORD_TYPE.ID:
                    shorthand = SHORT_WORD_TYPE.ID;
                    break;
                case WORD_TYPE.PHRASE:
                    shorthand = SHORT_WORD_TYPE.PHRASE;
                    break;
            }

            return shorthand;
        }

        public static string ConvertShorthandWordTypeToFullWordType(string type)
        {
            string full = String.Empty;

            switch (type)
            {
                case SHORT_WORD_TYPE.N:
                    full = WORD_TYPE.N;
                    break;
                case SHORT_WORD_TYPE.V:
                    full = WORD_TYPE.V;
                    break;
                case SHORT_WORD_TYPE.ADJ:
                    full = WORD_TYPE.ADJ;
                    break;
                case SHORT_WORD_TYPE.ADV:
                    full = WORD_TYPE.ADV;
                    break;
                case SHORT_WORD_TYPE.PN:
                    full = WORD_TYPE.PN;
                    break;
                case SHORT_WORD_TYPE.PP:
                    full = WORD_TYPE.PP;
                    break;
                case SHORT_WORD_TYPE.C:
                    full = WORD_TYPE.C;
                    break;
                case SHORT_WORD_TYPE.I:
                    full = WORD_TYPE.I;
                    break;
                case SHORT_WORD_TYPE.PRF:
                    full = WORD_TYPE.PRF;
                    break;
                case SHORT_WORD_TYPE.POF:
                    full = WORD_TYPE.POF;
                    break;
                case SHORT_WORD_TYPE.ID:
                    full = WORD_TYPE.ID;
                    break;
                case SHORT_WORD_TYPE.PHRASE:
                    full = WORD_TYPE.PHRASE;
                    break;
            }

            return full;
        }

        public static bool IsUrlExist(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                // Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";

                // Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                // Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        public static string SqlEscapeString(string str)
        {
            string outStr = str.Replace("'", "''");
            return outStr;
        }

        public static string FixAIPFont(string str)
        {
            string outStr = str.Replace("ɹ", "r");
            outStr = outStr.Replace("'", "ˈ");
            outStr = outStr.Replace("ɛ", "e");
            outStr = outStr.Replace("ɚ", "ə"); 
            // outStr = outStr.Replace(".", "");
            return outStr;
        }

        public static List<string> Shuffle(List<string> list)
        {
           List<string> outList = list.OrderBy(a => Guid.NewGuid()).ToList();
           return outList;
        }
    }
}
