using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabManager
{
    public static class Constants
    {
        public const string PARENT_DIR = @"";
        public const string PATH_LOG_DIR = PARENT_DIR + @"log/";
        public const string PATH_LOG_FILE = PATH_LOG_DIR + @"VocabManager.log";

        public const string PATH_DB_FILE = PARENT_DIR + @"db.sqlite";

        public const string PATH_IMAGE_DIR = PARENT_DIR + @"images/";

        public const string DATETIME_FORMAT = "MM/dd/yyyy HH:mm:ss";
    }

    public static class LOG_LEVEL
    {
        public const string DEBUG = "DEBUG";
        public const string INFO = "INFO";
        public const string INFO2 = "INFO2";
        public const string INFO3 = "INFO3";
        public const string WARNING = "WARNING";
        public const string ERROR = "ERROR";
        public const string URGENT = "URGENT";
    }

    public static class WORD_TYPE
    {
        public const string N = "Noun";
        public const string PN = "Pronoun";
        public const string V = "Verb";
        public const string ADJ = "Adjective";
        public const string ADV = "Adverb";
        public const string PP = "Preposition"; // beneath, beside, between, from, in front of, inside, near, off, out of, through, toward, under, within ...
        public const string C = "Conjunction";  // because, although, whereas, but, besides, unlike, therefore, despite ...
        public const string I = "Interjection"; // Hoorah!, Congratulations!, Oh!, Yeah!, Jesus!, Good!, Hey!, Yes!
        public const string PRF = "Prefix";
        public const string POF = "Postfix";
        public const string ID = "Idiom";
        public const string PHRASE = "Phrase";
    }

    public static class SHORT_WORD_TYPE
    {
        public const string N = "N";
        public const string PN = "PN";
        public const string V = "V";
        public const string ADJ = "ADJ";
        public const string ADV = "ADV";
        public const string PP = "PP";
        public const string C = "C";
        public const string I = "I";
        public const string PRF = "PRF";
        public const string POF = "POF";
        public const string ID = "Idiom";
        public const string PHRASE = "Phrase";
    }

    public static class PRONUNCIATION_COUNTRY_1
    {
        public const string US = "us";
        public const string UK = "uk";
    }

    public static class PRONUNCIATION_COUNTRY_2
    {
        public const string US = "en-US";
        public const string UK = "en-GB";
    }

    public static class WORD_DETAILS
    {
        public const string WORD = "Word";
        public const string TYPE = "Type";
        public const string DEFINITION = "Definition";
        public const string TOPIC = "Topic";
        public const string EXAMPLE = "Examples";
        public const string SYNONYM = "Synonyms";
        public const string ANTONYM = "Antonyms";
        public const string COLLOCATION = "Collocations";
        public const string IDIOM = "Idioms";
    }

    enum DISPLAY_TYPE
    {
        NORMAL,
        BOLD,
        ITALIC,
        BOLD_n_UNDERLINE,
    }

    public static class WEBSITE
    {
        public const string OXFORD = "Oxford";
        public const string CAMBRIDGE = "Cambridge";
        public const string COLLINS = "Collins";
        public const string OZDIC = "OZDict";
        public const string GOOGLE = "Google";
        public const string THEFREEDICT = "The Free Dictionary";
        public const string COVIET = "Coviet";
        public const string LUGWID = "Lugwid";
        public const string THESAURUS = "Thesaurus";
        public const string SENTENCE = "Sentence";
        public const string FREEPICTURE = "Free Pictures";
    }

    public static class COLOR_MARK
    {
        public const string WHITE = "White";
        public const string GREEN = "Green";    // Study 100%
        public const string RED = "Red";        // Cannot remember after many times of studying
        public const string YELLOW = "Yellow";  // Being in studying
    }
}