
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
                    Console.WriteLine("INT -> BIT ARRAY");
                    Console.WriteLine("Enter int number (4-byte):");
                    int intNumber = int.Parse(Console.ReadLine());

                    //int to bit 
                    intNumberToBinary(intNumber);
                    break;
                case "2":
                    Console.WriteLine("BIT ARRAY -> INT");
                    Console.WriteLine("Enter 32-bit array");
                    //enter bit array
                    int[] bitArray = inputBitArray();

                    //int to bit 
                    bitArrayToIntNumber(bitArray);
                    break;
                default:
                    Console.WriteLine("Invalid options");
                    break;
            }
        }

        private static void bitArrayToIntNumber(int[] bitArray)
        {
            throw new NotImplementedException();
        }

        private static void intNumberToBinary(int intNumber)
        {
            throw new NotImplementedException();
        }

        static int[] inputBitArray()
        {
            int[] bitArray = new int[32];
            int index = 0;
            while (index < 32)
            {
                Console.Write("bitArray[" + index + "] = ");
                int bitNumber = int.Parse(Console.ReadLine());
                if (bitNumber == 0 || bitNumber == 1)
                {
                    bitArray[index] = bitNumber;
                    index++;
                    continue;
                }
                Console.WriteLine("Invalid input. Try again.");
            }
            showBitArray(bitArray);
            return bitArray;
        }
        static void showBitArray(int[] bitArray)
        {
            Console.Write("bitArray = [");
            foreach (int bit in bitArray)
            {
                Console.Write(bit + ",");
            }
            Console.Write("]");
        }
    }
}