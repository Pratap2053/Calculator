using System;

class SimpleCalculator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Simple Calculator!");

        // Main program loop
        bool continueCalculation = true;
        while (continueCalculation)
        {
            int operation = SelectOperation();
            double num1 = AskNumber("Enter the first number: ");
            double num2 = AskNumber("Enter the second number: ");
            double result = PerformCalculation(operation, num1, num2);
            PrintResult(operation, num1, num2, result);

            // Ask if the user wants to perform another calculation
            Console.Write("Do you want to perform another calculation? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            if (response != "yes")
            {
                continueCalculation = false;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    // Function to select the operation
    static int SelectOperation()
    {
        int operation;
        while (true)
        {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.Write("Enter your choice (1-4): ");

            if (int.TryParse(Console.ReadLine(), out operation) && operation >= 1 && operation <= 4)
            {
                return operation;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }
    }

    // Function to ask for a number and validate the input
    static double AskNumber(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    // Function to perform the selected calculation
    static double PerformCalculation(int operation, double num1, double num2)
    {
        switch (operation)
        {
            case 1:
                return Add(num1, num2);
            case 2:
                return Subtract(num1, num2);
            case 3:
                return Multiply(num1, num2);
            case 4:
                return Divide(num1, num2);
            default:
                throw new InvalidOperationException("Invalid operation.");
        }
    }

    // Functions for calculations
    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;

    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return double.NaN; // Not a Number, indicating an invalid result
        }
        return a / b;
    }

    // Function to print the result of the calculation
    static void PrintResult(int operation, double num1, double num2, double result)
    {
        string operationSymbol = operation switch
        {
            1 => "+",
            2 => "-",
            3 => "*",
            4 => "/",
            _ => "?"
        };

        if (double.IsNaN(result))
        {
            Console.WriteLine("The operation could not be completed.");
        }
        else
        {
            Console.WriteLine($"Result: {num1} {operationSymbol} {num2} = {result}");
        }
    }
}

