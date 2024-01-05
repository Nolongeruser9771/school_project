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
        var inputValue = "";

        switch (functionChoice)
        {
            case "1":
                inputValue = inputValueToConvert("DEC -> BINARY", "Please input dec");
                if (isNumber(inputValue))
                {
                    Console.WriteLine("Result " + decimalToBinary(int.Parse(inputValue)));
                    break;
                }
                Console.WriteLine("Input value is not valid binary");
                break;
            case "2":
                inputValue = inputValueToConvert("DEC -> HEX", "Please input dec");
                if (isNumber(inputValue))
                {
                    Console.WriteLine("Result " + decimalToHex(int.Parse(inputValue)));
                    break;
                }
                Console.WriteLine("Input value is not valid binary");
                break;
            case "3":
                inputValue = inputValueToConvert("HEX -> DEC", "Please input hex");
                Console.WriteLine("Result " + hexToDecimal(inputValue));
                break;
            case "4":
                inputValue = inputValueToConvert("BINARY -> DEC", "Please input binary");
                Console.WriteLine("Result " + binaryToDecimal(inputValue));
                break;
            case "5":
                inputValue = inputValueToConvert("BINARY -> HEX", "Please input binary");
                Console.WriteLine("Result " + binaryToHex(inputValue));
                break;
            case "6":
                inputValue = inputValueToConvert("HEX -> BINARY", "Please input hex");
                Console.WriteLine("Result " + hexToBinary(inputValue));
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please choose again.");
                break;
        }

        //input value
        static string inputValueToConvert(string inputTitle, string inputDescription)
        {
            Console.WriteLine(inputTitle);
            Console.WriteLine(inputDescription);
            var inputToConvert = Console.ReadLine();
            return inputToConvert;
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
            return binaryNumber.PadLeft(4,'0');
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
            return (long) decimalNumber;
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
            return (long) decimalNumber;
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