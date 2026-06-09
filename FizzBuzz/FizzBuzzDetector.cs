using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace FizzBuzz
{
    public class FizzBuzzDetector
    {
        public FizzBuzzDetector(){}

        public OutputObject getOverlappings(string input)
        {
            OutputObject output = new OutputObject();
            
            replaceAndCount(input, out output.OutputString, out output.Count);
            
            return output;
        }

        private void replaceAndCount(string input, out string outputString, out int count)
        {
            var tokens = tokenize(input);
            count = 0;
            if(detectEmpty(tokens)) {
                outputString = input;
                return;
            }

            for(int i = 0; i<tokens.Count; i++)
            {
                if ((i + 1) % 15 == 0)
                {
                    tokens[i] = replaceAndPreserveEndLine("FizzBuzz", tokens[i]);
                    count++;
                }
                else if((i + 1) % 3 == 0)
                {
                    tokens[i] = replaceAndPreserveEndLine("Fizz", tokens[i]);
                    count++;
                }
                else if ((i + 1) % 5 == 0)
                {
                    tokens[i] = replaceAndPreserveEndLine("Buzz", tokens[i]);
                    count++;
                }
            }

            outputString = buildOutputString(tokens);
        }

        private bool detectEmpty(List<string> tokens)
        {
            if(tokens.Count < 1)
            {
                return true;
            }

            foreach(var t in tokens)
            {
                if (t.All(char.IsWhiteSpace))
                {
                    return true;
                }
            }

            return false;
        }

        private string buildOutputString(List<string> tokens)
        {
            string outputString = "";
            bool previousTokHasNewline = true;
            foreach(var t in tokens)
            {
                if (!previousTokHasNewline)
                {
                    outputString += " ";
                }
                else
                {
                    previousTokHasNewline = false;
                }
                outputString += t;

                if (t.Contains('\n'))
                {
                    previousTokHasNewline = true;
                }
            }

            return outputString;
        }

        private string replaceAndPreserveEndLine(string replacement, string input)
        {
            bool containsEndLine = input[input.Length - 1] == '\n';

            return replacement + (containsEndLine ? "\n" : "");
        }

        private List<string> tokenize(string input)
        {
            List<string> outputTokens = new List<string>();
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach(var tok in tokens)
            {
                if (tok.Contains('\n'))
                {
                    var split = tok.Split('\n');
                    outputTokens.Add(split[0] + "\n");
                    if (!string.IsNullOrEmpty(split[1]))
                    {
                        outputTokens.Add(split[1]);
                    }
                } else
                {
                    outputTokens.Add(tok);
                }
            }

            return outputTokens;
        }
    }
}