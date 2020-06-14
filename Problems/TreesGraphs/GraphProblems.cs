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

        public bool ValidateJumpPaths(string[] arr, int[] steps)
        {
            if (arr == null || steps == null || (arr.Length < 1 && steps.Length > 0))
            {
                return false;
            }

            if (arr.Length < 1 && steps.Length < 1)
            {
                return true;
            }

            var arrLength = arr.Length;
            var currentArrIndex = 0;

            for (var i = 0; i < steps.Length; i++)
            {
                var step = steps[i];
                var rightNeighbor = (currentArrIndex < arrLength - 1) ? currentArrIndex + 1 : -1;
                var leftNeighbor = (currentArrIndex > 0) ? currentArrIndex - 1 : -1;

                var stepIsInArrRange = (steps[i] >= 0 && steps[i] < arrLength);

                if (!stepIsInArrRange)
                {
                    return false;
                }

                var isStepEqualToRightNeighbor = (rightNeighbor > -1 && rightNeighbor == step);
                var isStepEqualToLeftNeighbor = (leftNeighbor > -1 && leftNeighbor == step);
                var stepValueEqualsCurrentArrValue = (stepIsInArrRange && arr[step] == arr[currentArrIndex]);

                if (!isStepEqualToLeftNeighbor && !isStepEqualToRightNeighbor && !stepValueEqualsCurrentArrValue)
                {
                    return false;
                }

                currentArrIndex = step;
            }

            return (currentArrIndex == arrLength -1);
        }

        public int[] GenerateMinJumpPath(string[] arr)
        {
            if (arr == null || arr.Length < 1)
            {
                return new int[] {};
            }

            var arrLength = arr.Length;

            // string -> [current index, right neighbor, left neighbor, matched index, and it's neighbors]
            var adjacencyList = new Dictionary<string, List<int>>();

            // generate adjacency list.

            for (var i = 0; i < arrLength; i++)
            {
                var doesStringExist = adjacencyList.ContainsKey(arr[i]);

                var rightNeighbor = (i < arrLength - 1) ? i + 1 : -1;
                var leftNeighbor = (i > 0) ? i - 1 : -1;

                // we are matching an extra index.
                if (doesStringExist)
                {
                    if (rightNeighbor > -1)
                    {
                        adjacencyList[arr[i]].Add(rightNeighbor);
                    }

                    if (leftNeighbor > -1)
                    {
                        adjacencyList[arr[i]].Add(leftNeighbor);
                    }

                    // add current index
                    adjacencyList[arr[i]].Add(i);
                }
                else
                {
                    var indexes = new List<int>();

                    if (rightNeighbor > -1)
                    {
                        indexes.Add(rightNeighbor);
                    }

                    if (leftNeighbor > -1)
                    {
                        indexes.Add(leftNeighbor);
                    }

                    // add current index
                    indexes.Add(i);

                    adjacencyList.Add(arr[i], indexes);
                }
            }

            var steps = new List<int>();

            //stepsGenerator(arr, adjacencyList, steps, 0);

            var currentArrIndex = 0;
            var adjacentMoves = new Queue<int>();

            // enqueue all the current moves from start to seed the queue.
            foreach (var move in adjacencyList[arr[currentArrIndex]])
            {
                adjacentMoves.Enqueue(move);
            }

            while (adjacentMoves.Count > 0)
            {

            }

            return steps.ToArray();
        }

        private void stepsGenerator(string[] arr, Dictionary<string, List<int>> adjacencyList, List<int> steps, int currentIndex)
        {
            if (currentIndex >= arr.Length - 1)
            {
                return;
            }

            foreach (var move in adjacencyList[arr[currentIndex]])
            {

            }

        }
    }
}