using System.Security.Cryptography.X509Certificates;

bool runProgram = true;
while (runProgram)
{
    Console.WriteLine("Please enter a word or phrase.");
    string input = Console.ReadLine().ToLower().Trim();
    List<string> words = input.Split(' ').ToList();
    List<char> characters = null;
    string pigWords = null;
    string isVowel = "aeiou";
    string isPuncuation = ",.!?'\";()";
    foreach(string w in words)
    {
        string updateWord = w;
        char puncuation = ' ';
        int charIndex = -1;
        if (w.Any(ch => isPuncuation.Contains(ch)))
        {
            for(charIndex = 0 ; charIndex <= w.Length; charIndex++)
            {
                if (isPuncuation.Contains(w[charIndex]))
                {
                    puncuation = (w[charIndex]);                    
                    string a = w.Substring(0, charIndex);                    
                    string b = w.Substring(charIndex + 1);
                    updateWord = a + b;
                    break;
                }
            }
        }
        if(updateWord.All(ch => char.IsLetter(ch)))
        {           
            if (isVowel.Contains(updateWord[0]))
            {
                updateWord = updateWord + "way";
                if (puncuation != ' ')
                {
                    if(charIndex == w.Length-1)
                    {
                        updateWord = updateWord.Insert(charIndex + 3, puncuation.ToString());
                    }
                    else
                    {
                        updateWord = updateWord.Insert(charIndex, puncuation.ToString());
                    }
                    
                }
                pigWords += updateWord + " ";
            }
            else
            {
                for(int i = 0; i <= updateWord.Length; i++)
                {
                    if (isVowel.Contains(updateWord[i]) || updateWord[i] == 'y')
                    {                        
                        string a = updateWord.Substring(i);
                        string b = updateWord.Substring(0, i);
                        updateWord = a + b + "ay";
                        if (charIndex == w.Length-1)
                        {
                            updateWord = updateWord.Insert(charIndex + 2, puncuation.ToString());
                        }
                        else if(charIndex == 0)
                        {
                            updateWord = updateWord.Insert(charIndex, puncuation.ToString());

                        }
                        else if(puncuation != ' ')
                        {
                            updateWord = updateWord.Insert(charIndex - i, puncuation.ToString());
                        }
                        pigWords += updateWord + " ";
                        break;
                    }
                }
            }
        }
        else
        {
            pigWords += updateWord + " ";
        }
        

        
    }

    Console.WriteLine(pigWords);
    
    
}