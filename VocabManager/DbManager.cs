using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabManager
{
    public class Word
    {
        public string word;
        public string pronunciation_us;
        public string pronunciation_uk;
        public string addedTime;
        public string editedTime;
        public string note;

        public Word(string w, string pUs, string pUk, string at, string et, string n)
        {
            word = w;
            pronunciation_us = pUs;
            pronunciation_uk = pUk;
            addedTime = at;
            editedTime = et;
            note = n;
        }
    }

    public class Meaning
    {
        public string word;
        public string wordType;
        public string definition;
        public string topic;
        public string example;
        public string synonym;
        public string antonym;

        public Meaning(string w, string t, string d, string s, string e, string syn, string a)
        {
            word = w;
            wordType = t;
            definition = d;
            topic = s;
            example = e;
            synonym = syn;
            antonym = a;
        }
    }

    public class Collocation
    {
        public string word;
        public string collocation;
        public string definition;
        public string example;

        public Collocation(string w, string c, string d, string e)
        {
            word = w;
            collocation = c;
            definition = d;
            example = e;
        }
    }

    public class Idiom
    {
        public string word;
        public string idiom;
        public string definition;
        public string example;

        public Idiom(string w, string i, string d, string e)
        {
            word = w;
            idiom = i;
            definition = d;
            example = e;
        }
    }

    public class Image
    {
        public string word;
        public string image;

        public Image(string w, string i)
        {
            word = w;
            image = i;
        }
    }

    public class StudyPlan
    {
        public string word;
        public string color;
        public string lastStudiedTime;
        public string nextStudiedTime;
        public int studiedCount;
        public string note1;
        public string note2;

        public StudyPlan(string w, string c, string lst, string nst, int sc, string n1, string n2)
        {
            word = w;
            color = c;
            lastStudiedTime = lst;
            nextStudiedTime = nst;
            studiedCount = sc;
            note1 = n1;
            note1 = n2;
        }
    }

    public class Word_n_Meaning
    {
        public string word;
        public string pronunciation_us;
        public string pronunciation_uk;
        public string addedTime;
        public string editedTime;
        public string note;
        public string type;
        public string definition;
        public string topic;
        public string example;
        public string synonym;
        public string antonym;

        public Word_n_Meaning(string w, string pUs, string pUk, string at, string et, string n,
                              string t, string d, string s, string e, string syn, string a)
        {
            word = w;
            pronunciation_us = pUs;
            pronunciation_uk = pUk;
            addedTime = at;
            editedTime = et;
            note = n;
            type = t;
            definition = d;
            topic = s;
            example = e;
            synonym = syn;
            antonym = a;
        }
    }

    public class Word_n_StudyPlan
    {
        public string word;
        public string addedTime;
        public string editedTime;
        public string color;
        public string lastStudiedTime;
        public string nextStudiedTime;
        public int studiedCount;
        public string note1;
        public string note2;

        public Word_n_StudyPlan(string w, string at, string et,
                                string c, string lst, string nst, int sc,
                                string n1, string n2)
        {
            word = w;
            addedTime = at;
            editedTime = et;
            color = c;
            lastStudiedTime = lst;
            nextStudiedTime = nst;
            studiedCount = sc;
            note1 = n1;
            note1 = n2;
        }
    }

    public class DbManager_Data
    {
        private static DbManager_Data _instance;
        private DbManager _dbManager;

        public List<string> Words { get; set; }
        public List<string> Topics { get; set; }
        public List<string> Definitions { get; set; }

        public static DbManager_Data GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DbManager_Data();
                return _instance;
            }
            return _instance;
        }

        private DbManager_Data()
        {
            _dbManager = DbManager.GetInstance();

            Words = _dbManager.Select_AllWords();
            Topics = _dbManager.Select_AllTopics();
            Definitions = _dbManager.Select_AllDefinitions();
        }
    }

    public class DbManager
    {
        private static DbManager _instance;

        private Logger _logger = Logger.GetInstance();

        public SQLiteConnection SqliteConn { get; set; }
        public SQLiteCommand SqliteCmd { get; set; }

        public static DbManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DbManager();
                return _instance;
            }
            return _instance;
        }

        private DbManager()
        {
        }

        public bool Open()
        {
            try
            {
                SqliteConn = new SQLiteConnection(String.Format("Data Source={0}; Version=3; New=True; Compress=True; ", Constants.PATH_DB_FILE));
                SqliteConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("Failed to connect to SQLite DB. Exception: {0}", ex.ToString()));
                return false;
            }
        }

        public void Close()
        {
            try
            {
                SqliteConn.Close();
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("Failed to close SQLite DB. Exception: {0}", ex.ToString()));
            }
        }

        public void CreateTable_Word_IfNotExists()
        {
            try
            {
                /*
                    Word
                    Pronunciation_US
                    Pronunciation_UK
                    AddedTime
                    EditedTime
                    Note
                */
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "CREATE TABLE IF NOT EXISTS Word " +
                                        "(Word TEXT NOT NULL UNIQUE, Pronunciation_US TEXT, Pronunciation_UK TEXT, AddedTime TEXT, EditedTime TEXT, Note TEXT)"; ;
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to create table Word. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateTable_Meaning_IfNotExists()
        {
            try
            {
                /*
                    ID
                    Word
                    Type
                    Definition
                    Topic
                    Example
                    Synonym
                    Antonym
                */
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "CREATE TABLE IF NOT EXISTS Meaning " +
                                        "(ID INT AUTO_INCREMENT, Word TEXT NOT NULL, Type TEXT NOT NULL, Definition TEXT NOT NULL, " +
                                        "Topic TEXT NOT NULL, Example TEXT, Synonym TEXT, Antonym TEXT, " +
                                        "PRIMARY KEY (ID), FOREIGN KEY (Word) REFERENCES Word(Word))"; ;
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to create table Meaning. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateTable_Collocation_IfNotExists()
        {
            try
            {
                /*
                    ID
                    Word
                    Collocation
                    Definition
                    Example
                */
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "CREATE TABLE IF NOT EXISTS Collocation " +
                                        "(ID INT AUTO_INCREMENT, Word TEXT NOT NULL, Collocation TEXT NOT NULL, Definition TEXT NOT NULL, Example TEXT, " +
                                        "PRIMARY KEY (ID), FOREIGN KEY (Word) REFERENCES Word(Word))"; ;
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to create table Collocation. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateTable_Idiom_IfNotExists()
        {
            try
            {
                /*
                    ID
                    Word
                    Idiom
                    Definition
                    Example
                */
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "CREATE TABLE IF NOT EXISTS Idiom " +
                                        "(ID INT AUTO_INCREMENT, Word TEXT NOT NULL, Idiom TEXT NOT NULL, Definition TEXT NOT NULL, Example TEXT, " +
                                        "PRIMARY KEY (ID), FOREIGN KEY (Word) REFERENCES Word(Word))"; ;
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to create table Idiom. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateTable_Image_IfNotExists()
        {
            try
            {
                /*
                    ID
                    Word
                    Image
                */
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "CREATE TABLE IF NOT EXISTS Image " +
                                        "(ID INT AUTO_INCREMENT, Word TEXT NOT NULL, Image TEXT NOT NULL, " +
                                        "PRIMARY KEY (ID), FOREIGN KEY (Word) REFERENCES Word(Word))"; ;
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to create table Image. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateTable_StudyPlan_IfNotExists()
        {
            try
            {
                /*
                    ID
                    Word
                    ColorMark
                    LastStudiedTime
                    NextStudiedTime
                    StudiedCount
                    Note1
                    Note2
                */
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "CREATE TABLE IF NOT EXISTS StudyPlan " +
                                        "(ID INT AUTO_INCREMENT, Word TEXT NOT NULL UNIQUE, ColorMark TEXT, LastStudiedTime TEXT, NextStudiedTime TEXT, StudiedCount INT, Note1 TEXT, Note2 TEXT, " +
                                        "PRIMARY KEY (ID), FOREIGN KEY (Word) REFERENCES Word(Word))"; ;
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to create table StudyPlan. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> Select_AllWords()
        {
            var words = new List<string>();

            try
            {

                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "SELECT Word FROM Word";
                SQLiteDataReader reader = SqliteCmd.ExecuteReader();

                while (reader.Read())
                {
                    words.Add(reader.GetString(0));
                }
                return words;
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to select all words from table Word. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return words;
            }
        }

        public Word Select_Word(string word)
        {
            Word w = null;

            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("SELECT * FROM Word WHERE Word = '{0}';", word);
                SQLiteDataReader reader = SqliteCmd.ExecuteReader();

                while (reader.Read())
                {
                    w = new Word(reader.GetString(0),
                                 reader.GetString(1),
                                 reader.GetString(2),
                                 reader.GetString(3),
                                 reader.GetString(4),
                                 reader.GetString(5));
                }
                return w;
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to select word from table Word. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return w;
            }
        }

        public List<Word> Select_LastNWords(int limit)
        {
            var words = new List<Word>();

            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("SELECT * FROM (SELECT * FROM Word ORDER BY EditedTime DESC) LIMIT {0};",
                                                      limit);
                SQLiteDataReader reader = SqliteCmd.ExecuteReader();

                while (reader.Read())
                {
                    var w = new Word(reader.GetString(0),
                                     reader.GetString(1),
                                     reader.GetString(2),
                                     reader.GetString(3),
                                     reader.GetString(4),
                                     reader.GetString(5));
                    words.Add(w);
                }
                return words;
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to select last N words from table Word. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return words;
            }
        }

        public List<Meaning> Select_Meanings(string word)
        {
            //word = word.Trim();
            var meanings = new List<Meaning>();

            SqliteCmd = SqliteConn.CreateCommand();
            SqliteCmd.CommandText = String.Format("SELECT * FROM Meaning WHERE Word = '{0}';", word);
            SQLiteDataReader reader = SqliteCmd.ExecuteReader();

            while (reader.Read())
            {
                meanings.Add( new Meaning(reader.GetString(1),
                                          reader.GetString(2),
                                          reader.GetString(3),
                                          reader.GetString(4),
                                          reader.GetString(5),
                                          reader.GetString(6),
                                          reader.GetString(7) ));
            }
            return meanings;
        }

        public List<Word_n_Meaning> Select_Word_n_Meaning_WithFilter(string topic, string definition, string wordType,
                                                                     int lastNWord_limit, bool isFollowingCreatedDate, bool isWholeWord)
        {
            var word_n_meaning_s = new List<Word_n_Meaning>();

            //// Join all tables
            //string cmd = "SELECT * FROM " +
            //    "(((Word INNER JOIN Meaning ON Word.Word = Meaning.Word) " +
            //    "        FULL JOIN Collocation ON Word.Word = Collocation.Word) " +
            //    "        FULL JOIN Idiom ON Word.Word = Idiom.Word)";

            // Join table Word and Meaning
            string cmd = "SELECT * FROM " +
                  "(Word INNER JOIN Meaning ON Word.Word = Meaning.Word)";

            if (!String.IsNullOrEmpty(topic) && !String.IsNullOrWhiteSpace(topic))
            {
                // Select based on Topic
                cmd = String.Format("SELECT * FROM ({0}) WHERE Topic = '{1}'", cmd, topic);
            }

            if (!String.IsNullOrEmpty(wordType) && !String.IsNullOrWhiteSpace(wordType))
            {
                // Select based on Word Type
                cmd = String.Format("SELECT * FROM ({0}) WHERE Type = '{1}'", cmd, wordType);
            }

            if (!String.IsNullOrEmpty(definition) && !String.IsNullOrWhiteSpace(definition))
            {
                // Select based on Definition
                if (isWholeWord)
                {
                    cmd = String.Format("SELECT * FROM ({0}) WHERE Definition LIKE '{1}' OR Definition LIKE '% {1} %' OR Definition LIKE '% {1}' OR Definition LIKE '{1} %'", cmd, definition);
                }
                else
                {
                    cmd = String.Format("SELECT * FROM ({0}) WHERE Definition LIKE '%{1}%'", cmd, definition);
                }
            }

            if (lastNWord_limit >= 0)
            {
                // Sort in Descending order of EditedTime
                cmd = String.Format("{0} ORDER BY {1} DESC", cmd, isFollowingCreatedDate ? "AddedTime" : "EditedTime");

                // Select based on limit
                cmd = String.Format("SELECT * FROM ({0}) LIMIT {1}", cmd, lastNWord_limit);
            }
            else
            {
                // Sort in Ascending order of Word
                cmd = String.Format("{0} ORDER BY Word ASC", cmd);
            }

            SqliteCmd = SqliteConn.CreateCommand();
            SqliteCmd.CommandText = cmd + ";";
            SQLiteDataReader reader = SqliteCmd.ExecuteReader();

            while (reader.Read())
            {
                word_n_meaning_s.Add(new Word_n_Meaning(reader.GetString(0),
                                                        reader.GetString(1),
                                                        reader.GetString(2),
                                                        reader.GetString(3),
                                                        reader.GetString(4),
                                                        reader.GetString(5),
                                                        reader.GetString(8),
                                                        reader.GetString(9),
                                                        reader.GetString(10),
                                                        reader.GetString(11),
                                                        reader.GetString(12),
                                                        reader.GetString(13)));
            }
            return word_n_meaning_s;
        }

        public List<Collocation> Select_Collocations(string word)
        {
            //word = word.Trim();
            var collocations = new List<Collocation>();

            SqliteCmd = SqliteConn.CreateCommand();
            SqliteCmd.CommandText = String.Format("SELECT * FROM Collocation WHERE Word = '{0}';", word);
            SQLiteDataReader reader = SqliteCmd.ExecuteReader();

            while (reader.Read())
            {
                collocations.Add(new Collocation(reader.GetString(1),
                                                 reader.GetString(2),
                                                 reader.GetString(3),
                                                 reader.GetString(4)));
            }
            return collocations;
        }

        public List<Idiom> Select_Idioms(string word)
        {
            //word = word.Trim();
            var idioms = new List<Idiom>();

            SqliteCmd = SqliteConn.CreateCommand();
            SqliteCmd.CommandText = String.Format("SELECT * FROM Idiom WHERE Word = '{0}';", word);
            SQLiteDataReader reader = SqliteCmd.ExecuteReader();

            while (reader.Read())
            {
                idioms.Add(new Idiom(reader.GetString(1),
                                     reader.GetString(2),
                                     reader.GetString(3),
                                     reader.GetString(4)));
            }
            return idioms;
        }

        public List<Image> Select_Images(string word)
        {
            //word = word.Trim();
            var images = new List<Image>();

            SqliteCmd = SqliteConn.CreateCommand();
            SqliteCmd.CommandText = String.Format("SELECT * FROM Image WHERE Word = '{0}';", word);
            SQLiteDataReader reader = SqliteCmd.ExecuteReader();

            while (reader.Read())
            {
                images.Add(new Image(reader.GetString(1),
                                     reader.GetString(2)));
            }
            return images;
        }

        public StudyPlan Select_StudyPlans(string word)
        {
            //word = word.Trim();

            SqliteCmd = SqliteConn.CreateCommand();
            SqliteCmd.CommandText = String.Format("SELECT * FROM StudyPlan WHERE Word = '{0}';", word);
            SQLiteDataReader reader = SqliteCmd.ExecuteReader();
            reader.Read();

            var plan = new StudyPlan(reader.GetString(1),
                                     reader.GetString(2),
                                     reader.GetString(3),
                                     reader.GetString(4),
                                     reader.GetInt32(5),
                                     reader.GetString(6),
                                     reader.GetString(7));

            return plan;
        }

        public List<string> Select_AllTopics()
        {
            var topics = new List<string>();

            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "SELECT DISTINCT Topic FROM Meaning ORDER BY Topic ASC;";
                SQLiteDataReader reader = SqliteCmd.ExecuteReader();

                while (reader.Read())
                {
                    topics.Add(reader.GetString(0));
                }
                return topics;
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to select all topics from table Meaning. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return topics;
            }
        }

        public List<string> Select_AllDefinitions()
        {
            var defs = new List<string>();

            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = "SELECT DISTINCT Definition FROM Meaning ORDER BY Definition ASC;";
                SQLiteDataReader reader = SqliteCmd.ExecuteReader();

                while (reader.Read())
                {
                    defs.Add(reader.GetString(0));
                }
                return defs;
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to select all definitions from table Meaning. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return defs;
            }
        }

        public List<Word_n_StudyPlan> Select_Word_n_StudyPlan_WithFilter(List<string> colorMarks)
        {
            var word_n_studyplan_s = new List<Word_n_StudyPlan>();

            // Join table Word and StudyPlan
            string cmd = "SELECT * FROM " +
                  "(Word FULL JOIN StudyPlan ON Word.Word = StudyPlan.Word)";

            if (colorMarks.Count > 0)
            {
                // Select based on Color Mark
                string condition = String.Format("ColorMark = '{0}'", colorMarks[0]);
                for (int i = 1; i < colorMarks.Count; i++)
                {
                    condition = String.Format("{0} OR ColorMark = '{1}'", condition, colorMarks[i]);
                }
                cmd = String.Format("SELECT * FROM ({0}) WHERE {1}", cmd, condition);
            }

            SqliteCmd = SqliteConn.CreateCommand();
            SqliteCmd.CommandText = cmd + ";";
            SQLiteDataReader reader = SqliteCmd.ExecuteReader();

            while (reader.Read())
            {
                word_n_studyplan_s.Add(new Word_n_StudyPlan(reader.GetString(0),
                                                            reader.GetString(3),
                                                            reader.GetString(4),
                                                            reader.GetString(8),
                                                            reader.GetString(9),
                                                            reader.GetString(10),
                                                            reader.GetInt32(11),
                                                            reader.GetString(12),
                                                            reader.GetString(13)));
            }
            return word_n_studyplan_s;
        }

        public void Insert_ToTable_Word(string word, string pronunciation_us, string pronunciation_uk, string addedTime, string editedTime, string note)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("INSERT INTO Word (Word, Pronunciation_US, Pronunciation_UK, AddedTime, EditedTime, Note ) " +
                                                      "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');",
                                                      word.Trim(), Utils.FixAIPFont(pronunciation_us.Trim()), Utils.FixAIPFont(pronunciation_uk.Trim()), addedTime, editedTime, note);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to insert to table Word. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert_ToTable_Meaning(string word, string type, string definition, string topic, string example, string synonym, string antonym)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("INSERT INTO Meaning (Word, Type, Definition, Topic, Example, Synonym, Antonym) " +
                                                      "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                                                      word.Trim(), type, Utils.SqlEscapeString(definition), topic.Trim(), Utils.SqlEscapeString(example), synonym.Trim(), antonym.Trim());
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to insert to table Meaning. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert_ToTable_Collocation(string word, string collocation, string definition, string example)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("INSERT INTO Collocation (Word, Collocation, Definition, Example) " +
                                                      "VALUES ('{0}', '{1}', '{2}', '{3}');",
                                                      word.Trim(), Utils.SqlEscapeString(collocation.Trim()), Utils.SqlEscapeString(definition), Utils.SqlEscapeString(example));
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to insert to table Collocation. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert_ToTable_Idiom(string word, string idiom, string definition, string example)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("INSERT INTO Idiom (Word, Idiom, Definition, Example) " +
                                                      "VALUES ('{0}', '{1}', '{2}', '{3}');",
                                                      word.Trim(), Utils.SqlEscapeString(idiom.Trim()), Utils.SqlEscapeString(definition), Utils.SqlEscapeString(example));
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to insert to table Collocation. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert_ToTable_Image(string word, string image)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("INSERT INTO Image (Word, Image) " +
                                                      "VALUES ('{0}', '{1}');",
                                                      word.Trim(), image.Trim());
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to insert to table Image. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert_ToTable_StudyPlan(string word, string colorMark, string lastStudiedTime, string nextStudiedTime, int studiedCount, string note1, string note2)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("INSERT INTO StudyPlan (Word, ColorMark, LastStudiedTime, NextStudiedTime, StudiedCount, Note1, Note2) " +
                                                      "VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}');",
                                                      word.Trim(), colorMark.Trim(), lastStudiedTime, nextStudiedTime, studiedCount, note1, note2);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to insert to table StudyPlan. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete_FromTable_Word(string word)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("DELETE FROM Word WHERE Word = '{0}';", word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to delete row in table Word. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete_FromTable_Meaning(string word)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("DELETE FROM Meaning WHERE Word = '{0}';", word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to delete from table Meaning. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete_FromTable_Collocation(string word)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("DELETE FROM Collocation WHERE Word = '{0}';", word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to delete from table Collocation. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete_FromTable_Idiom(string word)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("DELETE FROM Idiom WHERE Word = '{0}';", word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to delete from table Idiom. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete_FromTable_Image(string word)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("DELETE FROM Image WHERE Word = '{0}';", word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to delete from table Image. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete_FromTable_StudyPlan(string word)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("DELETE FROM StudyPlan WHERE Word = '{0}';", word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to delete from table StudyPlan. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update_InTable_Word(string word, string pronunciation_us, string pronunciation_uk, string editedTime, string note)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("UPDATE Word SET Pronunciation_US = '{0}', Pronunciation_UK = '{1}', EditedTime = '{2}', Note = '{3}' " +
                                                      "WHERE Word = '{4}';",
                                                       Utils.FixAIPFont(pronunciation_us.Trim()), Utils.FixAIPFont(pronunciation_uk.Trim()), editedTime, note, word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to update Edited Time in table Word. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update_InTable_Meaning(string word, string type, string definition, string topic, string example, string synonym, string antonym)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("UPDATE Meaning SET Type = '{0}', Definition = '{1}', Topic = '{2}', Example = '{3}', Synonym = '{4}', Antonym = '{5}' " +
                                                      "WHERE Word = '{6}';",
                                                       type, definition, topic, example, synonym, antonym, word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to update table Meaning. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update_InTable_Collocaton(string word, string collocation, string definition, string example)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("UPDATE Collocation SET Collocation = '{0}', Definition = '{1}', Example = '{2}' " +
                                                      "WHERE Word = '{3}';",
                                                       collocation, definition, example, word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to update table Collocation. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update_InTable_Idiom(string word, string idiom, string definition, string example)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("UPDATE Idiom SET Idiom = '{0}', Definition = '{1}', Example = '{2}' " +
                                                      "WHERE Word = '{3}';",
                                                       idiom, definition, example, word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to update table Idiom. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update_InTable_StudyPlan(string word, string colorMark, string lastStudiedTime, string nextStudiedTime, int studiedCount, string note1, string note2)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("UPDATE StudyPlan SET ColorMark = '{0}', LastStudiedTime = '{1}', NextStudiedTime = '{2}', StudiedCount = {3}, Note1 = '{4}' " +
                                                      "WHERE Word = '{5}';",
                                                       colorMark, lastStudiedTime, nextStudiedTime, studiedCount, note1, word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to update table Study Plan. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update_ColorMark_InTable_StudyPlan(string word, string colorMark)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("UPDATE StudyPlan SET ColorMark = '{0}' " +
                                                      "WHERE Word = '{1}';",
                                                       colorMark,  word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to update table Study Plan. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update_InTable_Image(string word, string image)
        {
            try
            {
                SqliteCmd = SqliteConn.CreateCommand();
                SqliteCmd.CommandText = String.Format("UPDATE Image SET image = '{0}' " +
                                                      "WHERE Word = '{1}';",
                                                       image, word);
                SqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = String.Format("Failed to update table Image. Exception: {0}", ex.ToString());
                _logger.Error(log);
                MessageBox.Show(log, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
