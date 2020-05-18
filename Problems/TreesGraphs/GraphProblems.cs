using System.Collections.Generic;
using System.Linq;
using Common.Utils;

namespace Problems.TreesGraphs
{
    public class GraphProblems
    {
        public int LadderLengthBruteForce(string beginWord, string endWord, IList<string> wordList) 
        {
            if (string.IsNullOrEmpty(beginWord) || string.IsNullOrEmpty(endWord) || 
                wordList == null || wordList.Count < 1) 
            {
                return 0;
            }
        
            var foundEndWord = false;
        
            // O(n)
            foreach (var w in wordList) 
            {
                if (!foundEndWord && w.Equals(endWord)) 
                {
                    foundEndWord = true;
                }
            }
        
            if (!foundEndWord) 
            {
                return 0;
            }
            
            var results = new List<IList<string>>();
            
            LadderLoop(beginWord, endWord, wordList, new List<string>() { beginWord }, results);

            if (results.Count < 1)
            {
                return 0;
            }

            return results.Select(words => words.Count).Min();
        }
    
        private void LadderLoop(string currentWord, string endWord, IList<string> wordList, IList<string> currentWords, List<IList<string>> results) 
        {
            // if the current word matches the end word add path list to the results.
            if (currentWord.Equals(endWord)) 
            {
                results.Add(currentWords);
                return;
            }

            // if we are at a dead end return.
            if (wordList == null || wordList.Count < 1) 
            {
                return;
            }

            // loop through find any word that matches.
            foreach (var word in wordList)
            {
                if (countDiff(currentWord, word) == 1) 
                {
                    LadderLoop(
                        word, 
                        endWord, 
                        wordList.Where(w => !w.Equals(word)).ToList(), 
                        currentWords.Append(word).ToList(), 
                        results
                    );
                }
            }
        }
        
        private int countDiff(string w1, string w2) 
        {
            int count = 0;
        
            for (var i = 0; i < w1.Length; i++) 
            {
                if (w1[i] != w2[i]) 
                {
                    count++;
                }
            }
        
            return count;
        }
        
        public int LadderLength(string beginWord, string endWord, IList<string> wordList) 
        {
            if (string.IsNullOrEmpty(beginWord) || string.IsNullOrEmpty(endWord) || wordList == null || wordList.Count < 1) 
            {
                return 0;
            }
        
            var foundEndWord = false;
            
            // "hit" and "hot" would be:
            //     "*it" -> ["hit"],
            //     "*ot" => ["hot"]
            //     "h*t" -> ["hit", "hot"],
            //     "hi*" => ["hit"]
            //     "ho*" => ["hot"]
            var patternLookup = new Dictionary<string, List<string>>();
            
            
            // "hit" -> ["*it", "h*t", "hi*"]
            var symbolLookup = new Dictionary<string, List<string>>();

            var newList = new List<string>(wordList);

            if (!newList.Contains(beginWord))
            {
                newList.Add(beginWord);
            }
            
            foreach (var w in newList) 
            {
                if (!foundEndWord && w.Equals(endWord)) 
                {
                    foundEndWord = true;
                }

                for (var i = 0; i < w.Length; i++)
                {
                    var s = StringUtility.ReplaceCharAt(w, i, '*');

                    if (patternLookup.ContainsKey(s))
                    {
                        patternLookup[s].Add(w);
                    }
                    else
                    {
                        patternLookup.Add(s, new List<string>() { w });
                    }

                    if (symbolLookup.ContainsKey(w))
                    {
                        symbolLookup[w].Add(s);
                    }
                    else
                    {
                        symbolLookup.Add(w, new List<string>() { s });
                    }
                }
            }
            
            var adjacencyList = new Dictionary<string, List<string>>();
            
            // join the symbol lookup with the adjacency lookup to get a flatmap of each word.
            // word -> adjacent words.
            foreach (var word in newList)
            {
                if (!adjacencyList.ContainsKey(word))
                {
                    adjacencyList.Add(word, symbolLookup[word].SelectMany(p => patternLookup[p].Where(w => !w.Equals(word)).ToList()).ToList());
                }
            }
        
            if (!foundEndWord) 
            {
                return 0;
            }
            
            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            var count = 1;
            var visitedWords = new Dictionary<string, int>();
            
            while (queue.Count > 0)
            {
                var length = queue.Count;

                for (var i = 0; i < length; i++)
                {
                    var currentWord = queue.Dequeue();

                    if (!visitedWords.ContainsKey(currentWord))
                    {
                        visitedWords.Add(currentWord, count);
                        
                        var words = adjacencyList[currentWord];

                        foreach (var word in words)
                        {
                            if (word.Equals(endWord))
                            {
                                return count + 1;
                            }

                            if (!visitedWords.ContainsKey(word))
                            {
                                queue.Enqueue(word);
                            }
                        }
                    }
                }
                
                count++;
            }

            return 0;
        }
    }
}