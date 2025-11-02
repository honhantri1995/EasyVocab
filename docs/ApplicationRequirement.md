# Goal
Making a cross-platform application for learning vocabulary. We call it "EasyVocab". It has the slogan "Master vocabulary with ease".  
The first version of the app only supports English vocabulary.

[Future Plan] In later versions, adding other language supports, in addition to the default English, might be considered.

# Programming Language and Framework
Language: JavaScript
Framework: NodeJS, Electron

# Cross Flatforms
Supported platforms: Windows, MacOS, iOS and Android

[IMPROTANT] One single codebase for cross platforms.

For the first version of the app:
- On Windows/MacOS: a desktop-style app using Electron
- On Mobile (iOS, Android): a web-app on a browser, I will wrap it for mobile stores myself

[Future Plan] In later versions, I might consider to convert it to native application (with React Native). But this is a plan for future.

# Features

## Vocabulary Management

### Edit Words

The app shall provide a `Edit` screen for the user to add/modify/delete words.

In particular, the app will find the word inputed by user from the database.  
If found, it displays all word fields. Now the user can modify any field. If not found, it displays nothing. Now the user should inpput word fields. 

Once done, click `Save` button to save the changes to the database, or `Clear/Delete` button to reset all fields to empty or remove the word from the database. For the deletion case, a popup is displayed for user to confirm once more time.

Each word consists of many fields, including:
- Mandatory fields:
  - *Word*: The word itself. For example: "provide"
  - *Definition*: Consist of one or more definitions of the word. Each has following sub fields:
    - *Meaning*: The meaning of the word. For example, "A place of residence or origin, the social unit of a family" is meaning of the word "provide".
    - *Word type*: The type of the word. For example, "verb" is type of the word "provide".  
      NOTE: Word types are fixed. User can choose, but cannot add new one. Following word types are supported: noun, verb, adjective, pronoun, adverb, preposition, conjunction, interjection, prefix, postfix, idiom, phrase.
    - *Tags*: The tag of the word. Tag can be a topic (e.g. sports, body activity, etc.), a level (basic, intermediate, advanced, etc.), a remark, or anything user wants. For example, "helps & supports" is topic of the word "provide"
    - *Pronunciation in US*: The pronunciation of the word in US accent. For example, /prəˈvaɪd/ is pronunciation in US of the word "provide"
    - *Pronunciation in UK*: The pronunciation of the word in UK accent. For example, /prəˈvaɪd/ is pronunciation in UK of the word "provide"
- Optional fields:
  - *Note*: A note for the word. It's user note, can be anything.
  - *Examples*: One or some examples for the word. For example: "Please provide the following information for polices." is an example of the word "provide"
  - *Synonyms*: A list of synonyms of the word. For example: "supply" and "accommodate" are two synonyms of the word "provide"
  - *Antonyms*: A list of antonyms of the word. For example: "take away" is an antonym of the word "provide"
  - *Collocations*: Consist of one or more collocations of the word. Each has following sub fields:
    - *Collocation*: A collocation of the word. For example: "to provide sb with sth" is a collocation of the word "provide"
    - *Meaning*: The meaning of the collocation.
    - *Examples*: One or more examples for the collocation of the word.
  - *Idioms*: Consist of one or more idioms of the word. Each has following sub fields:
    - *Idiom*: A idiom of the word.
    - *Meaning*: The meaning of the idiom.
    - *Examples*: One or more examples for the idiom of the word.
  - *Pictures*: One or more pictures that best describes the word. The field value is a file path.

Also there are some invisible word fields not displayed to user. They're used by the app backend, including:
- *Created date*: When the word is first added by users. Date is in YYYY-MM-DD format.
- *Modified date*: When the word is modified by users. This means the user added the word before, but now he modifies it. Date is in YYYY-MM-DD format.
- *Learnt count*: How many times a word is learnt before. Refer to the __Word Learning Plan__ session for more details.
- *Last learnt date*: When the last time a word is learnt. Refer to the __Word Learning Plan__ session for more details.
- *Color flag*: The color mark set for a word. Refer to the __Word Learning Plan__ session for more details.

In case there are more than one definitions/collocations/idioms/pictures for a word, the user can click on `+` button. This will duplicate the UI components, so that the user can input more. By contrast, there is a `-` button to delete existing component.

NOTE: 
- [Webview Support] User can look up the word in predefined online directionaries right within the app. The URLs to dictionaries are defined by `onlineDicUrls` field in `settings.yaml`.

### Search Words
The app shall provides a `Search` screen for the user to search the word for its definition. 
If the word is found from the database, all word fields (mentioned in __Edit__ screen) are displayed. If not found, app displays a not-found message.

There are two search options:
- *By word*: User inputs the word. For example: "home".
- *By meaning*: User inputs part of a meaning of the word. For example: "residence". Because the part "residence" is found in the meaning of "home" which is "A place of residence or origin, the social unit of a family", it's a found search.

NOTES:
- Searching is always case-insensitive. 
- The app shall display all found results.
- [Webview Support] Similar to `Edit` screen, user can look up the word in predefined online directionaries right within the app.


## Word Learning Plan

In the `Learn` screen, the user can learn the words. But first he shall provide a list of words to learn based on which filter he chooses.

Filter options include:
- *By color flag*: This means all words from the specified color flag will be selected. 
- *By tag*: This means all words from the specified tag will be selected.
- *Since last N weeks* (where N is inputable): This means all words since the last N weeks (nearest) will be selected. Time base is *Modified date* of the word.
- *Since last N months* (where N is inputable): This means all words since the last N weeks (nearest) will be selected. Time base is *Modified date* of the word.
- *Since last N words* (where N is inputable): This means the last N words (nearest) will be selected. Time base is *Modified date* of the word.

After user chooses the filter option and clicks on `Start filter` button, the filter result will be displayed. It's a table with following columns:
- *Word*: The word
- *Tags*: The tags of the word.
- *Flag*: The color flag of the word.
- *Created*: The date in YYYY-MM-DD format where the word is first added
- *Edited*: The date in YYYY-MM-DD format where the word is edited

This table is sortable. So the user can sort any field in both accessing order.

There is a `Select all` button for user to select all words from the result table. Or user can click on each word for a single selection. Then user can click on `Start learning` button which will direct the user to the `Learn` screen where he can learn the word with various learning modes.

### Learning Mode
After the user selected words to learn the app shall support learning these words in various Learning Modes:

#### Word ➜ Definition
With this mode, the app shall display the word in English (for example: "home"), and the user shall guess the definition of the word (for example: "A place of residence or origin, the social unit of a family"). The user does not need to input anything, just guess the definition silently in his mind.

There will be cases where the user forget the definition at first glance, so the app shall provide some tips for user. Just click on the tip and it will show. Tips include:
- *Show word type*: The type of the word (e.g. verb, noun, etc.)
- *Show tags*: The tag of the word.
- *Show examples*: All examples of the word.
- *Show synonyms*: All synonyms of the word.
- *Show antonyms*: All antonyms of the word.

#### Definition ➜ Word
With this mode, the app shall display the definition of the word (for example: "A place of residence or origin, the social unit of a family"), and the user shall input the word (for example: "home").
While user is inputting the word, the app shall check grammar of the word. If it finds any wrong character, it will display a ❌ symbol. If all characters are correct, it will display a ✅ symbol.

There will be cases where the user forgets the word at first glance, so the app shall provide some tips for user. Just click on the tip and it will show. Tips include:
- *Show word type*: The type of the word (e.g. verb, noun, etc.)
- *Show letters*: A letter block (empty) of the word. For example, "home" has 4 blocks `▭▭▭▭` corresponding to 4 letters. First block is: `h▭▭▭`. Last block is: `▭▭▭e`. User can click on each block, and the letter at this block will be shown.
- *Show synonyms*: All synonyms of the word.
- *Show antonyms*: All antonyms of the word.

**Despite Learning Modes, the app shall always supports**:
- Increase the *Learnt count* field of the word by 1.
- Update the value of the *Last learnt date* field of the word with the today date.
- A `Color Flag` button for each word. User can choose a color to mark the word.
- A `Next` button for user to move to the next word from the selected list. 
- A `Back` button for user to move back to the previous word from the selected list.
- A `Show` button for user to be re-directed to the __Search Worsd__ screen in which the selected word is dislayed with all fields.
- A 🔊 symbol for user to click on to hear the word pronunciation.
- AUTO PLAY: Every time a new word is shown up (either by `Next` or `Back` button), app auto plays the pronunciation. But only one pronunciation (either US or UK) is choosen depending on the `defaultAccent` in the app settings.

### Learning Plan
The app shall save learning history of each word in its database. A word is considered as "learned" when the user learn it from ANY Learning Mode.

As mentioned in the __Edit Words__ session, learn history includes following fields:
- **Last learnt date**: The last time a word is learned. Format: YYYY-MM-DD
- **Learnt count**: How many times a word is learned. For example, first time the user lears the word with "Word ➜ Definition" mode, the count is 1. Then, the user learns it again with "Definition ➜ Word" mode, the count is 2.

For each word, there will be a learning plan managed by the app.

After the user completes the last word in the selected list in the Learning Mode, the app shall provide a popup to suggest the next learn date.  
This date is choosen by the app automatically based on *Learnt count* and *Last learnt date* fields, as well as the `nextLearnDatePeriods` setting defined in `settings.yaml`.  
The calculation is: next learn date = *Last learnt date* + a date offset in `nextLearnDatePeriods` corresponding to the *Learnt count*.
For example:
  - If `settings.yaml` defines `nextLearnDatePeriods` = `3, 6, 12, 24` (note: this is a list)
    - If *Learnt count* = `1`, then next learn date offset is `3` (note: this is an item in the list)
      - If *Last learnt date* = `2024-14-10`, then the next learn date will be `2024-14-13`.  
        Suppose the user learned the word on `2024-14-13` as planned, now *Learnt count* changes to `2`.
    - If *Learnt count* = `2`, then next learn date offset is `6` (note: this is an item in the list)
      - Because *Last learnt date* = `2024-14-13`, now the next learn date will be `2024-14-19`.
    
However, use can manually select another date if he wants. In this case, the next learn date is overwritten by user. But the next of the next learn date is not affected. It's still calculated as the above fomular.
For example:
  - If `settings.yaml` defines `nextLearnDatePeriods` = `3, 6, 12, 24` (note: this is a list)
    - If *Learnt count* = `1`, then next learn date offset is `3` (note: this is an item in the list)
      - If *Last learnt date* = `2024-14-10`, then the next learn date will be `2024-14-13`.
        - But if user chooses another date, such as `2024-14-14`, then the next learn date will be overwritten to `2024-14-14`
          Suppose the user learned the word on `2024-14-14` as planned, now *Learnt count* changes to `2`.  
    - If *Learnt count* = `2`, then next learn date offset is `6` (note: this is an item in the list)
      - Because *Last learnt date* = `2024-14-14`, then the next learn date will be `2024-14-20`.

### Learning Remind
The app shall remind the user (by notification) based on the learning plan. In other words, when the date comes, the app will remind.
All words having the plan on the same date will be notified with one single notification.
The reminder time is defined by `reminderTime` field in `settings.yaml`.

### Word Color Flag
The user has the option to set a flag for each word. A flag is purely a color mark. Following colors are supported: red, yellow, green, gray.
- **Red** means that the user feels he did not remember anything about the word.
- **Yellow** means that the user feels he can remember the word, but with a bit struggling. In most cases, Yellow is for words within the learning plan.
- **Green** means that the user remembers the word easily. In most cases, Green is for words with a complete learning plan.
- **Gray** means there is no flag set for the word yet. In most cases, Gray is for brand-new word. It's actually a default value.

This data is important because the user can filter their words based on the result flag so that he can decide to learn it with his own plan.

## Text To Speach
The app shall speak the word pronunciation out loud when the user clicks on the 🔊 symbol. The word pronuciation is fetched from Speech APIs.
User can choose voice gender by `voiceGender` field in `settings.yaml`.

# Setting File
When startup, the application must read all settings from a setting file, named `settings.yaml`. There are following settings:
``` yaml
- audio:
  - defaultAccent: us
  - voiceGender: man
- display:
  - theme: modern clean
- notification:
  - reminderTime: 10:00 AM
- learningPlan:
  - nextLearnDatePeriods: [3, 6, 12, 24]
- webview:
  - onlineDicUrls:
    - https://dictionary.cambridge.org/dictionary/english/{}
    - https://www.oxfordlearnersdictionaries.com/us/definition/english/{}
    - https://www.collinsdictionary.com/us/dictionary/english/{}
    - https://www.google.com/search?q={}
    - https://www.thefreedictionary.com/{}
    - https://ozdic.com/collocation/{}
    - https://app.ludwig.guru/s/{}
    - https://thesaurus.yourdictionary.com/{}
    - https://sentence.yourdictionary.com/{}
    - https://www.freepik.com/search?format=search&query={}
    - http://tratu.coviet.vn/hoc-tieng-anh/tu-dien/lac-viet/A-V/{}.html
```
Explanation:
- `defaultAccent`: Choose preferred accent for audio pronunciation. Value is `us` or `uk`
- `voiceGender`: Choose the gender for the audio pronunciation. Value is `man` or `woman`
- `theme`: Choose your preferred app theme. Value is <!-- FIXME -->
- `reminderTime`: When should we remind you to practice? Value is a time clock in HH:MM format
- `nextLearnDatePeriods`: The date offset in which the app shall remind you to learn the word. Value is a list of positive integers. For example, the value `3, 6, 12, 24` means that user should learn the word again after 3 days since the created/edited date (Learnt count is 0). Then learn it again after 6 days more, then learn it again after 12 days more, then learn it again after 24 days more. So when the time comes to these day, the app shall notify the user.
- `onlineDicUrls`: List of urls to online dictionary. The app will append the word to the "{}" part of the URL.

NOTE: These settings are located in the `Settings` screen.

## Import and Export

In the `Settings` screen, there are a button to import words and a button to export words. User can click on each, and browse to the local database file on user's device to import/export.
- Once importing successfully, all words from the local database file will be copied to the remote database.
- Once exporting successfully, all words from the remote database will be copied to the local database file.


# GUI
I already design the GUI wireframe and its component explanation for the app at `docs\Design\GUI`. YOU HAVE TO FOLLOW IT.
BUT note that the documment contains purely concepts and ideas. If you find somethings that need improvement, improve them as long as you KEEP THE ULTIMATE GOALS:
- **Configurable themes**: My users have different preference, so the app should provide some themes. Although I only need theme in the first version of the app, you have to prepare a dropdown list for theme selection.
- **Modern-looking UI**: All themes shall share a common trait: modern design principle. I LOVE modern-looking and minimalized applications, while at the same time have nice annimations.
- **Repsonsive UI**: The app will run on different platforms, so its UI should be hightly responsive.
- **Just enough annimations**: UI should be smooth and fast. So do not put too many unnecessary annimations to prevent low-performance issues.
- **Consistent coloring**: UI components should share a few common consistent colors. Do not put too many colors.

# Database
## Firebase
Because the app runs across platforms, its database must be syncronized between platforms in real time. I choose Firebase.

<!-- How firebase manages user account -->

## Database Design
I already design the database for the app.
<!-- FIXME -->