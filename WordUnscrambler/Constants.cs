using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords="Please enter F for file input and M for manual input";
        public const string OptionsOnContinuingTheProgram = "Do you want to continue? Y/N";

        public const string EnterScrambledWordsViaFile = "Enter scrambled words filename";
        public const string EnterScrambledWordsManually = "Enter scrambled words separated by comma";
        public const string EnterScrambledWordsOptionNotRecognized = "Option was not recognized";

        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because there was an error";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated";

        public const string MatchFound = "Match found for {0} : {1}";
        public const string MatchNotFound = "No matches were found!";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const String wordListFileName = "wordlist.txt";



    }
}
