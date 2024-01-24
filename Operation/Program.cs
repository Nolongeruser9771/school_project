
namespace Operation
{
    class Operation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two two's complement binary numbers:");

            Console.Write("Binary Number 1: ");
            string binaryNum1 = Console.ReadLine();

            Console.Write("Binary Number 2: ");
            string binaryNum2 = Console.ReadLine();

            // Addition
            string additionResult = BinaryAddition(binaryNum1, binaryNum2);
            Console.WriteLine($"Addition: {additionResult}");

            // Subtraction
            string subtractionResult = BinarySubtraction(binaryNum1, binaryNum2);
            Console.WriteLine($"Subtraction: {subtractionResult}");

            // Multiplication
            string multiplicationResult = BinaryMultiplication(binaryNum1, binaryNum2);
            Console.WriteLine($"Multiplication: {multiplicationResult}");

            // Division
            string divisionResult = BinaryDivision(binaryNum1, binaryNum2);
            Console.WriteLine($"Division: {divisionResult}");
        }


        private static string BinaryAddition(string? binaryNum1, string? binaryNum2)
        {
            //0011 & 0001
            int bitDigits = 8;

            char[] result = new char[bitDigits];
            int carryBit = 0;

            for (int i = bitDigits - 1; i >= 0; i--)
            {
                //get digits of 2 binary numbers
                //+ or - '0' to correctly convert to ASCII
                int bit1 = binaryNum1[i] - '0';
                int bit2 = binaryNum2[i] - '0';

                int sum = bit1 + bit2 + carryBit;
                //(0+0)%2 = 0
                //(1+0) | (0+1) %2 = 1
                //(1+1)%2 = 0
                result[i] = (char)(sum % 2 + '0');

                //0+0 = 0 --> carryBit = 0
                //0+1 | 1+0 = 1 --> carryBit = (int) 0.5 = 0
                //1+1 = 2 --> carryBit = 2/1 = 1
                carryBit = sum / 2;
            }

            string additionResult = new string(result);

            //check if overflow
            if (additionResult.Length > bitDigits)
            {
                return "Overflow";
            }
            return additionResult;
        }
        private static string BinarySubtraction(string? binaryNum1, string? binaryNum2)
        {
            //get negatedBinaryNum2
            string negationBinaryNum2 = NegateBinary(binaryNum2);
            //addition of binaryNum1 and negation of binaryNum2
            string result = BinaryAddition(binaryNum1, negationBinaryNum2);
            return result;
        }
        private static string BinaryMultiplication(string? binaryNum1, string? binaryNum2)
        {
            string A = "00000000";
            int digits = 8;

            //add bit 0 to end of binaryNum2
            int k = digits;
            string Q = binaryNum2;
            string M = binaryNum1;
            char Q_1 = '0';
            string shiftedA = "";

            while (k > 0)
            {
                if (Q[digits - 1] == '1' & Q_1 == '0')
                {
                    A = BinarySubtraction(A, M);
                }
                if (Q[digits - 1] == '0' & Q_1 == '1')
                {
                    A = BinaryAddition(A, M);
                }
                //shift right
                shiftedA = ((A[0] == '1' ? '1' : '0') + A + Q + Q_1).Substring(0, 2 * digits + 1);
                A = shiftedA.Substring(0, digits);
                Q = shiftedA.Substring(digits, digits);
                Q_1 = (char)shiftedA[digits * 2];
                k = k - 1;
            }
            return (A + Q).Substring(digits, digits);
        }
        private static string BinaryDivision(string? binaryNum1, string? binaryNum2)
        {
            string Q = binaryNum2;
            string M = binaryNum1;
            string A = Q[0] == '1' ? "11111111" : "00000000";
            int k = 8;
            string shiftedA = "";
            while (k > 0)
            {
                //shift left
                shiftedA = (A + Q + '0');

                A = shiftedA.Substring(1, 8);
                Q = shiftedA.Substring(9, 8);
                A = BinarySubtraction(A, M);

                if (A[0] == '1')
                {
                    Q = Q.Substring(0, 7) + '0';
                    A = BinaryAddition(A, M);
                }
                else
                {
                    Q = Q.Substring(0, 7) + '1';
                }
                k = k - 1;
            }
            return "Q = " + Q + "; A = " + A;
        }

        private static string NegateBinary(string? binaryNum)
        {
            string result = "";
            //reverse bits & 1
            for (int i = 0; i < 8; i++)
            {
                result += (binaryNum[i] == '0') ? '1' : '0';
            }
            result = BinaryAddition(result, "00000001");
            return result;
        }
    }
}