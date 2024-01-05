namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            showMenu();
        }
        static void showMenu()
        {
            Console.WriteLine("Choose function to convert: 0 -> 6");
            Console.WriteLine("1. DEC -> BINARY");
            Console.WriteLine("2. DEC -> HEX");
            Console.WriteLine("3. HEX -> DEC");
            Console.WriteLine("4. BINARY -> DEC");
            Console.WriteLine("5. BINARY -> HEX");
            Console.WriteLine("6. HEX -> BINARY");
            Console.WriteLine("0. EXIT");

            var functionChoice = Console.ReadLine();
            functionChoiceImp(functionChoice);
        }

        static void functionChoiceImp(string functionChoice)
        {
            switch (functionChoice)
            {
                case "1":
                    hexToBinaryMenu();
                    break;
                case "2":
                    decimalToHexMenu();
                    break;
                case "3":
                    hexToDecMenu();
                    break;
                case "4":
                    binaryToDecMenu();
                    break;
                case "5":
                    binaryToHexMenu();
                    break;
                case "6":
                    hexToBinaryMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }

            //dec to binary menu
            static void decimalToBinaryMenu()
            {
                Console.WriteLine("DEC -> BINARY");
                Console.WriteLine("Please input dec");

                var inputValue = Console.ReadLine();
                if (isNumber(inputValue))
                {
                    Console.WriteLine("Result " + decimalToBinary(int.Parse(inputValue)));
                    return;
                }
                Console.WriteLine("Input value is not valid decimal");
            }

            //dec to hex menu
            static void decimalToHexMenu()
            {
                Console.WriteLine("DEC -> HEX");
                Console.WriteLine("Please input dec");

                var inputValue = Console.ReadLine();
                if (isNumber(inputValue))
                {
                    Console.WriteLine("Result " + decimalToHex(int.Parse(inputValue)));
                    return;
                }
                Console.WriteLine("Input value is not valid decimal");
            }

            //hex to dec menu
            static void hexToDecMenu()
            {
                Console.WriteLine("HEX -> DEC");
                Console.WriteLine("Please input hex");

                var inputValue = Console.ReadLine();
                Console.WriteLine("Result " + hexToDecimal(inputValue));
            }

            //binary to dec menu
            static void binaryToDecMenu()
            {
                Console.WriteLine("BINARY -> DEC");
                Console.WriteLine("Please input binary");

                var inputValue = Console.ReadLine();
                Console.WriteLine("Result " + hexToDecimal(inputValue));
            }

            //binary to hec menu
            static void binaryToHexMenu()
            {
                Console.WriteLine("BINARY -> HEX");
                Console.WriteLine("Please input binary");

                var inputValue = Console.ReadLine();
                Console.WriteLine("Result " + binaryToHex(inputValue));
            }

            //hex to binary menu
            static void hexToBinaryMenu()
            {
                Console.WriteLine("HEX -> BINARY");
                Console.WriteLine("Please input hex");

                var inputValue = Console.ReadLine();
                Console.WriteLine("Result " + hexToBinary(inputValue));
            }

            //validate number
            static bool isNumber(string inputValue)
            {
                return int.TryParse(inputValue, out int value);
            }

            //dec -> binary
            static string decimalToBinary(long decimalNumber)
            {
                long tempt = decimalNumber;
                string binaryNumber = "";
                while (tempt > 0)
                {
                    binaryNumber = tempt % 2 + binaryNumber;
                    tempt /= 2;
                }
                return binaryNumber.PadLeft(4, '0');
            }

            //dec -> hex
            static string decimalToHex(long decimalNumber)
            {
                long tempt = decimalNumber;
                long remain;
                string hexNumber = "";
                string hexDigit;
                while (tempt > 0)
                {
                    remain = tempt % 16;
                    tempt /= 16;
                    hexDigit = remain.ToString("X");
                    hexNumber = hexDigit + hexNumber;
                }
                return hexNumber;
            }

            //hex -> dec
            static long hexToDecimal(string hexNumber)
            {
                int n = hexNumber.Length;
                double decimalNumber = 0d;

                for (int i = 0; i < n; i++)
                {
                    int decimalDigit = 0;
                    char hexDigit = hexNumber[i];

                    if (char.IsDigit(hexDigit))
                    {
                        decimalDigit = hexDigit - '0';
                    }
                    else if (hexDigit >= 'A' && hexDigit <= 'F')
                    {
                        decimalDigit = hexDigit - 'A' + 10;
                    }
                    else
                    {
                        Console.WriteLine("Input value is not valid binary");
                        return -1;
                    }
                    decimalNumber += decimalDigit * Math.Pow(16, n - 1 - i);
                }
                return (long)decimalNumber;
            }

            //binary -> dec
            static long binaryToDecimal(string binaryNumber)
            {
                int n = binaryNumber.Length;
                double decimalNumber = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    if (binaryNumber[i] == '1')
                    {
                        decimalNumber += (binaryNumber[i] - '0') * Math.Pow(2, n - 1 - i);
                    }
                    if (binaryNumber[i] != '0' & binaryNumber[i] != '1')
                    {
                        Console.WriteLine("Input value is not valid binary");
                        return -1;
                    }
                }
                return (long)decimalNumber;
            }

            //binary -> hex
            static string binaryToHex(string binaryNumber)
            {
                //binary -> dec
                long decimalNumber = binaryToDecimal(binaryNumber);
                //dec -> hex
                return decimalToHex(decimalNumber);
            }

            //hex to binary
            static string hexToBinary(string hexNumber)
            {
                //hex to dec
                long decimalNumber = hexToDecimal(hexNumber);
                //dec to binary
                string binaryNumber = decimalToBinary(decimalNumber);
                return binaryNumber.PadLeft(4, '0');
            }
        }
    }
}