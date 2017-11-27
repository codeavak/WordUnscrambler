using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.data;
using WordUnscrambler.workers;


namespace WordUnscrambler
{
    class Program
    { 
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher=new WordMatcher();
        static void Main(string[] args)
        {
           try {
                bool continueDecision = true;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;
                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.WriteLine(Constants.EnterScrambledWordsViaFile);
                            PlayInFileMode();
                            break;
                        case Constants.Manual:
                            Console.WriteLine(Constants.EnterScrambledWordsManually);
                            PlayInManualMode();
                            break;
                        default:
                            Console.WriteLine(Constants.EnterScrambledWordsOptionNotRecognized);
                            break;
                    }

                    var continueLetter = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueLetter = (Console.ReadLine() ?? string.Empty);
                    }
                    while (
                    !continueLetter.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                    !continueLetter.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueDecision = continueLetter.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                }
                while (continueDecision == true);
            }
            catch (Exception ex)
            { Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message); }

        }

        private static void PlayInManualMode()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayUnscrambled(scrambledWords);
        }

        private static void PlayInFileMode()
        {
            try { 
            string fileName = Console.ReadLine()??string.Empty;
            string[] scrambledWords = _fileReader.Read(fileName);
            DisplayUnscrambled(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }

        private static void DisplayUnscrambled(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any()){
                foreach (var match in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, match.ScrambledWord,match.Word);
                }
            }
            else
            { Console.WriteLine(Constants.MatchNotFound); }
        }

  
    }
}
