using System;

namespace SDAssignment3Q4
{

    public class DecimalToRoman
    {
        static void Main(string[] args)
        {
            int number = 0;
            Console.WriteLine("Please enter the valid number between 0 to 4999:");
            try
            {
                number = Int32.Parse(Console.ReadLine());
                Console.WriteLine(Conversion(number));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            // Wait for user

            Console.ReadKey();
        }

        //Check Whether the given number is valid or not
        public static bool IsValidNumber(int number)
        {
            if (number > 0 && number < 5000)
                return true;
            else
                return false;
        }

        public static String Conversion(int number)
        {
            Expression[] expressions = new Expression[]
               {
                   new RomanThousandExpression(),
                    new RomanHundredExpression(),
                    new RomanTenExpression(),
                    new RomanOneExpression()
               };

            if (IsValidNumber(number))
            {
                var context = new RomanContext(number);

                foreach (var expression in expressions)
                {
                    expression.Interpret(context);
                }
                return "Decimal equivalent of " + number + " is " + context.Output;
            }
            else
            {
                return "The Number provided is not in a required range.";
            }

        }

    }

    public class RomanContext
    {
        public RomanContext(int input)
        {
            Input = input;
        }

        public int Input { get; set; }

        public string Output { get; set; }
    }

    public abstract class Expression
    {
        public abstract void Interpret(RomanContext value);
    }

    public class RomanOneExpression : Expression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 9) >= 0)
            {
                value.Output += "IX";

                value.Input -= 9;
            }

            while ((value.Input - 5) >= 0)
            {
                value.Output += "V";

                value.Input -= 5;
            }

            while ((value.Input - 4) >= 0)
            {
                value.Output += "IV";

                value.Input -= 4;
            }

            while ((value.Input - 3) >= 0)
            {
                value.Output += "III";

                value.Input -= 3;
            }

            while ((value.Input - 2) >= 0)
            {
                value.Output += "II";

                value.Input -= 2;
            }

            while ((value.Input - 1) >= 0)
            {
                value.Output += "I";

                value.Input -= 1;
            }
        }
    }

    public class RomanTenExpression : Expression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 90) >= 0)
            {
                value.Output += "XC";

                value.Input -= 90;
            }

            while ((value.Input - 50) >= 0)
            {
                value.Output += "L";

                value.Input -= 50;
            }

            while ((value.Input - 40) >= 0)
            {
                value.Output += "XL";

                value.Input -= 40;
            }

            while ((value.Input - 30) >= 0)
            {
                value.Output += "XXX";

                value.Input -= 30;
            }

            while ((value.Input - 20) >= 0)
            {
                value.Output += "XX";

                value.Input -= 20;
            }

            while ((value.Input - 10) >= 0)
            {
                value.Output += "X";

                value.Input -= 10;
            }
        }
    }

    public class RomanHundredExpression : Expression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 900) >= 0)
            {
                value.Output += "CM";

                value.Input -= 900;
            }

            while ((value.Input - 500) >= 0)
            {
                value.Output += "D";

                value.Input -= 500;
            }

            while ((value.Input - 400) >= 0)
            {
                value.Output += "CD";

                value.Input -= 400;
            }

            while ((value.Input - 300) >= 0)
            {
                value.Output += "CCC";

                value.Input -= 300;
            }

            while ((value.Input - 200) >= 0)
            {
                value.Output += "CC";

                value.Input -= 200;
            }

            while ((value.Input - 100) >= 0)
            {
                value.Output += "C";

                value.Input -= 100;
            }
        }
    }

    public class RomanThousandExpression : Expression
    {
        public override void Interpret(RomanContext value)
        {

            while ((value.Input - 1000) >= 0)
            {
                value.Output += "M";

                value.Input -= 1000;
            }
        }
    }
}
