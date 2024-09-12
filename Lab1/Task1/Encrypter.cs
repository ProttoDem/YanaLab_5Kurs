namespace Task1;

public class Encrypter
{
    private char[] EnglishAlphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
    private char[] RandomizedAlphabet = ['N', 'A', 'K', 'E', 'L', 'S', 'T', 'C', 'O', 'P', 'X', 'I', 'R', 'Y', 'Q', 'Z', 'H', 'J', 'F', 'V', 'D', 'U', 'W', 'B', 'G', 'M'];
    
    public void Task1_1(string word)
    {
        string newWord = "";

        foreach (var letter in word)
        {
            var index = Array.IndexOf(EnglishAlphabet, letter);
            newWord = newWord + RandomizedAlphabet[index];
        }
        
        Console.WriteLine($"Encrypted : {newWord}");

        string decryptedWord = "";
        
        foreach (var letter in newWord)
        {
            var index = Array.IndexOf(RandomizedAlphabet, letter);
            decryptedWord = decryptedWord + EnglishAlphabet[index];
        }
        
        Console.WriteLine($"Decrypted : {decryptedWord}");
    }

    public void Task1_2(string word)
    {
        var encryptedWord = "";
        var n = (int)Math.Ceiling(Math.Sqrt(EnglishAlphabet.Length));
        var square = new char[n, n];
        var index = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (index < EnglishAlphabet.Length)
                {
                    square[i, j] = EnglishAlphabet[index];
                    index++;
                }
            }
        }
        
        var wordLength = word.Length;
        var coordinates = new int[wordLength * 2];
        for (int i = 0; i < wordLength; i++)
        {
            var l = square.GetUpperBound(0) + 1;
            for (int h = 0; h < l; h++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (square[h, j] == word[i])
                    {
                        coordinates[i] = j;
                        coordinates[i + wordLength] = h;
                    }
                }
            }
        }

        for (int i = 0; i < wordLength * 2; i += 2)
        {
            encryptedWord += square[coordinates[i + 1], coordinates[i]];
        }
        
        Console.WriteLine($"Encrypted: {encryptedWord}");

        var decryptedWord = "";
        
        wordLength = encryptedWord.Length;
        coordinates = new int[wordLength * 2];
        
        var indexer = 0;
        for (int i = 0; i < wordLength; i++)
        {
            var l = square.GetUpperBound(0) + 1;
            for (int h = 0; h < l; h++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (square[h, j] == encryptedWord[i])
                    {
                        coordinates[indexer] = j;
                        coordinates[indexer + 1] = h;
                    }
                }
            }
            indexer += 2;
        }

        for (int i = 0; i < wordLength; i++)
        {
            decryptedWord += square[coordinates[i + wordLength], coordinates[i]];
        }
        
        Console.WriteLine($"Decrypted: {decryptedWord}");
    }

    public void Task2_1(string word)
    {
        var key = new int[word.Length];
        
        for (int i = 0; i < key.Length; i++)
        {
            key[i] = i + 1;
        }

        key.Shuffle();

        Console.Write("Key: ");
        for (int i = 0; i < key.Length; i++)
        {
            if (i != key.Length - 1)
            {
                Console.Write(key[i] + ", ");
            }
            else
            {
                Console.WriteLine(key[i].ToString());
            }
        }

        for (int i = 0; i < word.Length % key.Length; i++)
        {
            word += word[i];
        }
 
        string encryptedWord = "";
 
        for (int i = 0; i < word.Length; i += key.Length)
        {
            char[] transposition = new char[key.Length];
 
            for (int j = 0; j < key.Length; j++)
                transposition[key[j] - 1] = word[i + j];
 
            for (int j = 0; j < key.Length; j++)
                encryptedWord += transposition[j];
        }
        
        Console.WriteLine($"Encrypted: {encryptedWord}");
        
        string decryptedWord = "";
        
        for (int i = 0; i < encryptedWord.Length; i += key.Length)
        {
            char[] transposition = new char[key.Length];
 
            for (int j = 0; j < key.Length; j++)
                transposition[j] = encryptedWord[i + key[j] - 1];
 
            for (int j = 0; j < key.Length; j++)
                decryptedWord += transposition[j];
        }
        
        Console.WriteLine($"Decrypted: {decryptedWord}");
    }
    
    public void Task2_2(string word)
    {
        var A = new Random().Next(10);
        var B = new Random().Next(10);
        var C = new Random().Next(10);
        var indexes = new int[word.Length];

        for (int i = 0; i < word.Length; i++)
        {
            indexes[i] = (Array.IndexOf(EnglishAlphabet, word[i]) + CountKey(i)) % EnglishAlphabet.Length;
        }

        var encryptedWord = "";

        for (int i = 0; i < indexes.Length; i++)
        {
            encryptedWord += EnglishAlphabet[indexes[i]];
        }
        
        Console.WriteLine($"Encrypted: {encryptedWord}");
        
        indexes = new int[encryptedWord.Length];
        
        for (int i = 0; i < encryptedWord.Length; i++)
        {
            var value = Array.IndexOf(EnglishAlphabet, encryptedWord[i]) - CountKey(i);
            while (value < 0)
            {
                value += EnglishAlphabet.Length;
            }
            indexes[i] = value % EnglishAlphabet.Length;
        }
        
        var decryptedWord = "";
        
        for (int i = 0; i < indexes.Length; i++)
        { 
            decryptedWord += EnglishAlphabet[indexes[i]];
        }
        
        Console.WriteLine($"Decrypted: {decryptedWord}");

        int CountKey(int position)
        {
            return A * position * position + B * position + C;
        }
    }
}