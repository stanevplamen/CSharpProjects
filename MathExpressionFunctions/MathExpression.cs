using System;
using System.Collections.Generic;
using System.Text;

class MathExpression
{
    static string expression;
    static HashSet<char> functionsToSolve = new HashSet<char> { 'l', 's', 'p' };
    static Dictionary<char, int> standardOperators = new Dictionary<char, int> { {'+', 1} , {'-', 2 }, {'*', 3}, {'/', 4} };
    static HashSet<char> allDigits = new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.' };
    static Queue<string> outputQueye;
    static Stack<char> operatorsStack;

    static void Main()
    {
        //expression = "(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)";
        expression = "pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) ";
        //expression = "(2+1)*(4-2)/3";
        double result = ShuntingYardSolve(expression);
        Console.WriteLine("The result is {0:0.000}", result);
    }

    private static double ShuntingYardSolve(string expression)
    {
        operatorsStack = new Stack<char>();
        outputQueye = new Queue<string>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (functionsToSolve.Contains(expression[i]))
            {
                i = GetTheNumberToQueyeFromFunction(i, expression[i]);
            }
            else if (allDigits.Contains(expression[i]))
            {
                i = GetTheNumberToQueye(i);
            }
            else if (standardOperators.ContainsKey(expression[i]))
            {
                if (operatorsStack.Count == 0)
                {
                    operatorsStack.Push(expression[i]);            
                }
                else
                {
                    char tempChar = operatorsStack.Pop();
                    bool isBreak = false;
                    while (tempChar != '(' && standardOperators[expression[i]] < standardOperators[tempChar])
                    {
                        outputQueye.Enqueue(tempChar.ToString());
                        if (operatorsStack.Count > 0)
                        {
                            tempChar = operatorsStack.Pop();
                        }
                        else
                        {
                            isBreak = true;
                            break;
                        }
                    }
                    if (isBreak == true)
                    {
                        operatorsStack.Push(expression[i]);
                        isBreak = false;
                    }
                    else
                    {
                        operatorsStack.Push(tempChar);
                        operatorsStack.Push(expression[i]); 
                    }

                }
            }
            else if (expression[i] == '(')
            {
                operatorsStack.Push(expression[i]);  
            }
            else if (expression[i] == ')')
            {
                char tempChar = operatorsStack.Pop();
                while (tempChar != '(')
                {
                    outputQueye.Enqueue(tempChar.ToString());
                    tempChar = operatorsStack.Pop();
                }
            }
            else
            {
                continue;
            }
        }

        MoveFromStackToTheQueue();

        double result = Calculation();

        return result;
    }

    private static double Calculation()
    {
        while (outputQueye.Count > 1)
        {
            List<double> twoNumbers = new List<double>();
            List<char> oneChar = new List<char>();
            while (twoNumbers.Count < 2 || oneChar.Count < 1)
            {
                string currentToken = outputQueye.Dequeue();
                if (allDigits.Contains(currentToken[0]))
                {
                    twoNumbers.Add(double.Parse(currentToken));
                }
                else
                {
                    oneChar.Add(char.Parse(currentToken));
                }
            }

            int numbersToReturn = twoNumbers.Count - 2;
            int queueElements = outputQueye.Count;
            for (int i = 0; i < numbersToReturn; i++)
            {
                outputQueye.Enqueue(twoNumbers[i].ToString());
            }
            double result = ProvideOperation(twoNumbers[twoNumbers.Count - 1], twoNumbers[twoNumbers.Count - 2], oneChar[0]);
            outputQueye.Enqueue(result.ToString());
            for (int i = 0; i < queueElements; i++)
            {
                string tempElement = outputQueye.Dequeue();
                outputQueye.Enqueue(tempElement);
            }
        }
        double resultToReturn = double.Parse(outputQueye.Dequeue());
        return resultToReturn;
    }

    private static double ProvideOperation(double firstTempNumber, double secondTempNumber, char currentChar)
    {
        double numberToReturn = 0.0;
        if (currentChar == '-')
        {
            numberToReturn = secondTempNumber - firstTempNumber;
        }
        else if (currentChar == '+')
        {
            numberToReturn = secondTempNumber + firstTempNumber;
        }
        else if (currentChar == '*')
        {
            numberToReturn = secondTempNumber * firstTempNumber;
        }
        else if (currentChar == '/')
        {
            numberToReturn = secondTempNumber / firstTempNumber;
        }
        return numberToReturn;
    }

    private static void MoveFromStackToTheQueue()
    {
        while (operatorsStack.Count > 0)
        {
            char tempChar = operatorsStack.Pop();
            outputQueye.Enqueue(tempChar.ToString());
        }
    }

    private static int GetTheNumberToQueye(int index)
    {
        StringBuilder sb = new StringBuilder();
        int i;
        string numbToExport = String.Empty;
        for (i = index; i < expression.Length; i++)
        {
            if (allDigits.Contains(expression[i]))
            {
                sb.Append(expression[i]);
            }
            else 
            {
                break;
            }
        }
        numbToExport = sb.ToString();
        outputQueye.Enqueue(numbToExport);
        return i - 1;       
    }

    private static int GetTheNumberToQueyeFromFunction(int index, char currentChar)
    {
        int i = 0;
        StringBuilder sb = new StringBuilder();
        string numbToExport = String.Empty;
        if (currentChar == 'l')
        {
            for (i = index + 3; i < expression.Length; i++)
            {
                if (allDigits.Contains(expression[i]))
                {
                    sb.Append(expression[i]);
                }
                else
                {
                    break;
                }
            }
            numbToExport = sb.ToString();
            double tempNumber = double.Parse(numbToExport);
            tempNumber = Math.Log(tempNumber);
            outputQueye.Enqueue(tempNumber.ToString());
        }
        else if (currentChar == 's')
        {
            for (i = index + 5; i < expression.Length; i++)
            {
                if (allDigits.Contains(expression[i]))
                {
                    sb.Append(expression[i]);
                }
                else
                {
                    break;
                }
            }
            numbToExport = sb.ToString();
            double tempNumber = double.Parse(numbToExport);
            tempNumber = Math.Sqrt(tempNumber);
            outputQueye.Enqueue(tempNumber.ToString());
        }
        else if (currentChar == 'p')
        {
            for (i = index + 4; i < expression.Length; i++)
            {
                if (allDigits.Contains(expression[i]))
                {
                    sb.Append(expression[i]);
                }
                else
                {
                    break;
                }
            }
            string firstStr = sb.ToString();
            double firstNumber = double.Parse(firstStr);
            index = i;
            sb.Clear();
            for (i = index + 1; i < expression.Length; i++)
            {
                if (allDigits.Contains(expression[i]) || expression[i] == '-')
                {
                    sb.Append(expression[i]);
                }
                else if (expression[i] == ' ')
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            string secondStr = sb.ToString();
            double secondNumber = double.Parse(secondStr);
            double resultNumb = Math.Pow(firstNumber, secondNumber); ;
            outputQueye.Enqueue(resultNumb.ToString());
        }
        return i;
    }
}


/* 
Stack for operator
Queue for the numbers and output
input string

while there are tokens
read abstract token
- if number to queue
- if operator
  - while there is an operator on top of the stack with greater precedence: pop operators from the stack to the output queue
  - push the current operator
- if ( bracket - to the stack
- if ) bracket
  - while there is not abstract left bracket Attribute the top of the stack: pop operators from the stack to the output queye
  - pop the left bracket ( from the stack and discard iterator

while there are operators on the stack pop them to the queye*/