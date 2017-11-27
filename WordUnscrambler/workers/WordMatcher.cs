using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.data;

namespace WordUnscrambler.workers
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var myList = new List<MatchedWord>();
            foreach(string scrambledWord in scrambledWords)
                foreach (var word in wordList)
                { 
                    if (scrambledWord.Equals(word,StringComparison.OrdinalIgnoreCase))
                    {
                        myList.Add(BuildMatchedWord(scrambledWord,word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);
                        var sortedScrambled = new String(scrambledWordArray);
                        var sortedWord = new String(wordArray);
                        if (sortedScrambled.Equals(sortedWord,StringComparison.OrdinalIgnoreCase))
                            myList.Add(BuildMatchedWord(scrambledWord, word));
                    }

                }
            return myList;

        }
        private MatchedWord BuildMatchedWord(string scrambled, string word)
        {
            MatchedWord newMatch = new MatchedWord
            { ScrambledWord = scrambled,
              Word = word
        };
            
            return newMatch;
        }
    }
}
