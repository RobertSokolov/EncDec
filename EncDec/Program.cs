using System;

class EncryptionDecryptionSystem
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    static void Main(string[] args)
    {
        Console.WriteLine("Encrypt or Decrypt(E/D):");
        string choose = Console.ReadLine();
        string inputText = "";
        int key = 0;
        string encryptedText = "";
        if (choose == "E")
        {
            Console.WriteLine("Enter your text:");
            inputText = Console.ReadLine();

            Console.WriteLine("Enter the key (offset):");
            key = int.Parse(Console.ReadLine());

            encryptedText = Encrypt(inputText, key);
            Console.WriteLine("Encrypted text: " + encryptedText);
        }
        else if (choose == "D")
        {
            Console.WriteLine("Enter your Code:");
            inputText = Console.ReadLine();

            Console.WriteLine("Enter the key (offset):");
            key = int.Parse(Console.ReadLine());

            string decryptedText = Decrypt(inputText, key);
            Console.WriteLine("Decrypted text: " + decryptedText);
        }


    }

    static string Encrypt(string input, int key)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char character = input[i];
            if (char.IsLetterOrDigit(character))
            {
                int index = Alphabet.IndexOf(char.ToUpper(character));
                int encryptedIndex = (index + key) % Alphabet.Length;
                result[i] = Alphabet[encryptedIndex];
            }
            else
            {
                result[i] = character;
            }
        }

        return new string(result);
    }

    static string Decrypt(string input, int key)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char character = input[i];
            if (char.IsLetterOrDigit(character))
            {
                int index = Alphabet.IndexOf(char.ToUpper(character));
                int decryptedIndex = (index - key + Alphabet.Length) % Alphabet.Length;
                result[i] = Alphabet[decryptedIndex];
            }
            else
            {
                result[i] = character;
            }
        }

        return new string(result);
    }
}