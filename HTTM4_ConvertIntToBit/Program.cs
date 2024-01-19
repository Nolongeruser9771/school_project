namespace ConvertIntToBit
{
    class Convert
    {
        static void Main(string[] args)
        {
            showMenu();
        }

        static void showMenu()
        {
            Console.WriteLine("Please choose options below: ");
            Console.WriteLine("1. Read int to binary");
            Console.WriteLine("2. Display bit array from int");

            string functionChoice = Console.ReadLine();
            functionChoiceImpl(functionChoice);
        }

        static void functionChoiceImpl(string functionChoice)
        {
            switch (functionChoice)
            {
                case "1":
                    Console.WriteLine("INT -> BINARY NUMBER");
                    int intNumber = inputIntNumber();
                    intNumberToBinary(intNumber);
                    break;
                case "2":
                    Console.WriteLine("BIT ARRAY -> INT");
                    int[] bitArray = inputBitArray();
                    bitArrayToIntNumber(bitArray);
                    break;
                default:
                    Console.WriteLine("Invalid options");
                    break;
            }
        }

        private static int inputIntNumber()
        {
            string intNumberInput;
            do {
                Console.WriteLine("Enter int number (4-byte):");
                intNumberInput = Console.ReadLine();
            } while (!int.TryParse(intNumberInput, out int intNumber));
            return int.Parse(intNumberInput);
        }

        private static void intNumberToBinary(int intNumber)
        {
            string binaryNumber = "";
            int bitDigits = 32;
            for (int i = bitDigits-1; i >= 0; i--)
            {
                int bit = (intNumber >> i) & 1;
                binaryNumber += bit;
            }
            Console.WriteLine("Result: " + binaryNumber);
        }

        private static void bitArrayToIntNumber(int[] bitArray)
        {
            int binaryNumber = 0;
            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                if (bitArray[i] == 1)
                {
                    binaryNumber |= 1 << (bitArray.Length - 1 - i);
                }
            }
            Console.WriteLine("Result: " + binaryNumber);
        }

        private static int[] inputBitArray()
        {
            int[] bitArray = new int[32];
            int index = 0;

            Console.WriteLine("Enter 32-bit array");
            while (index < 32)
            {
                Console.Write("bitArray[" + (index + 1) + "] = ");
                string bitNumber = Console.ReadLine();
                if (bitNumber == "0" || bitNumber == "1")
                {
                    bitArray[index] = int.Parse(bitNumber);
                    index++;
                    continue;
                }
                Console.WriteLine("Invalid input. Try again.");
            }
            showBitArray(bitArray);
            return bitArray;
        }
        private static void showBitArray(int[] bitArray)
        {
            Console.Write("bitArray = [");
            for (int i = 0; i < bitArray.Length; i++)
            {
                Console.Write(bitArray[i]);
                Console.Write(i == bitArray.Length - 1 ? "]\n" : ",");
            }
        }
    }
}