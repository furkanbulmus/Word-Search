// Miss Polly had a poor dolly, who was sick. She called for the talled doctor Solly to come quick. He knocked on the DOOR like a actor in the healthcare sector.
            string sentence, sentence_2, sentence_3, pattern, pattern_2, ctrl_word;
            int letter_number = 0, i;
            bool flag;
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            do  // Retrieving text information from the user.
            {
                Console.Write("Please enter a sentence. (Sentence cannot contain punctuations except dot and comma.): ");
                sentence = Console.ReadLine();  // Checking symbols other than dots and commas.
            } while (sentence.Contains('?') || sentence.Contains('!') || sentence.Contains('*') || sentence.Contains('/') || sentence.Contains('£') || sentence.Contains('=') || sentence.Contains('(') || sentence.Contains(')') || sentence.Contains('[') || sentence.Contains(']') || sentence.Contains('{') || sentence.Contains('}') || sentence.Contains('"') || sentence.Contains('+') || sentence.Contains('-') || sentence.Contains('%') || sentence.Contains('&') || sentence.Contains('_') || sentence.Contains('^') || sentence.Contains('#') || sentence.Contains('$') || sentence.Contains(':') || sentence.Contains(';'));

            do  // Getting pattern information from the user.
            {
                Console.Write("Please enter the pattern you want to scan in the text. (It must contain a dash ('-') or a asterisk ('*'): ");
                pattern = Console.ReadLine();
            } while (!(pattern.Contains('*') || pattern.Contains('-')));  // Checking for asterisks and dashes.

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Text: " + sentence);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Pattern: " + pattern);
            Console.WriteLine(" ");

            pattern_2 = pattern.ToLower();  // The entered text and pattern are brought to the desired format.
            sentence_2 = sentence.ToLower();
            sentence_3 = sentence_2.Replace(".", "").Replace(",", "");

            string[] words;  // The words in the text are assigned to the array.
            words = sentence_3.Split(' ');
                       
            for (i = 0; i < pattern_2.Length; i++)
            {   // If there is a asterisk in the pattern, it is determined which letter it corresponds to.
                if (pattern_2[i] == '*') 
                {
                    letter_number = i;
                }                               
            }
            // It will throw an error if the pattern contains both asterisks and dashes.
            if (pattern_2.Contains('*') && pattern_2.Contains('-'))
                Console.WriteLine("ERROR!! Pattern cannot contain both stars and dashes.");

            if (pattern_2[letter_number] == '*')
            {   // In the for loop, the words in the text are scanned.
                for (i = 0; i < words.Length; i++)  
                {
                    flag = true;
                    ctrl_word = words[i];

                    if (ctrl_word.Length >= pattern_2.Length)  // Word length is checked.
                    {
                        for (int j = 0; j < letter_number; j++)
                        {   // Here, the part from the first letter to the asterisk is checked.
                            if (pattern_2[j] != ctrl_word[j])
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag == true)
                        {
                            for (int k = 1; k < pattern_2.Length - letter_number; k++)
                            {   // Here, the part from the end to the asterisk is checked.
                                if (pattern_2[pattern_2.Length - k] != ctrl_word[ctrl_word.Length - k])
                                {
                                    flag = false;
                                    break;
                                }
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        if (flag == true)  // The words are printed.
                            Console.WriteLine(ctrl_word);
                    }
                }
            }

            else if (letter_number == 0)
            {
                for (i = 0; i < words.Length; i++)
                {
                    flag = true;
                    ctrl_word = words[i];

                    if (ctrl_word.Length == pattern_2.Length) // Letters are checked except where there is a dash.
                    {
                        for (int b = 0; b < ctrl_word.Length; b++)
                        {
                            if (pattern_2[b] != '-' && pattern_2[b] != ctrl_word[b])
                            {
                                flag = false;
                                break;
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        if (flag == true)  //  // The words are printed.
                            Console.WriteLine(ctrl_word);
                    }
                }
            }
            
            Console.ReadLine();

