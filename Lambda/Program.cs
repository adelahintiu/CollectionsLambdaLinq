﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lambda.Delegate;
using System.Collections;

namespace Lambda
{
    class Program
    {
        private static void DelegateExample()
        {
            Console.WriteLine("=====Example 1 (Delegate)=====");

            //Create Delegate instances
            PerformCalculation sum_Function = new PerformCalculation(SpecialFunctions.Sum);
            PerformCalculation prod_Function = new PerformCalculation(SpecialFunctions.Product);

            double val1 = 2.0, val2 = 3.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine($"{val1} + {val2} = {sum_Result}");

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine($"{val1} * {val2} = {prod_Result}");

            //Using sum_function reference
            Console.Write($"{val1} + {val2} = ");
            SpecialFunctions.ExecuteFunction(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write($"{val1} * {val2} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);


            /**
             * TODO 0
             * Goto SpecialFunctions sources and resolve TODO 1, 2 and 3.
             */

            //TODO 4: Create an instance of NumberCheck (TODO 1)
            NumberCheck isEven_function = new NumberCheck(SpecialFunctions.IsEven);
            //TODO 5: Use function GetEvenNumbers to select the even numbers from numbersList collection
            List<int> numbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            List<int> evenList = SpecialFunctions.GetEvenNumbers(isEven_function, numbersList);
            //TODO 6: Print the resulting numbers
            Console.Write("The even numbers of this list are : ");
            foreach (int elem in evenList)
            {
                Console.Write($"{elem}  ");
            }

            Console.WriteLine();
        }

        private static void FuncDelegateExample()
        {
            Console.WriteLine("=====Example 2 (Func Delegate)=====");

            //Create Func Delegate instances
            Func<double, double, double> sum_Function = new Func<double, double, double>(SpecialFunctions.Sum);
            Func<double, double, double> prod_Function = new Func<double, double, double>(SpecialFunctions.Product);
            Func<int, bool> isOdd_Function = new Func<int, bool>(SpecialFunctions.IsEven);

            double val1 = 4.0, val2 = 5.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine($"{val1} + {val2} = {sum_Result}");

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine($"{val1} * {val2} = {prod_Result}");

            //Using sum_function reference
            Console.Write($"{val1} + {val2} = ");
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write($"{val1} * {val2} = ");
            SpecialFunctions.ExecuteFunctionUsingFunc(prod_Function, val1, val2);

            //Omitting the explicit creation of a Func instance
            Console.Write($"{val1} - {val2} = ");
            SpecialFunctions.ExecuteFunctionUsingFunc(SpecialFunctions.Diff, val1, val2);

            List<int> numbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            Console.Write("The odd numbers of this list are : ");
            foreach (int elem in numbersList)
            {
                if (isOdd_Function(elem) == false)
                    Console.Write($"{elem}  ");
            }
            
            /**
             * TODO 7 
             * Create an instance of function created at TODO 2 and use it to print the odd numbers from numbersList collection
             */

            Console.WriteLine();
        }

        private static void AnonymousFunctExample()
        {
            Console.WriteLine("=====Example 3 (Anonymous Functions)=====");

            //Create a Func Delegate instance
            Func<double, double, double> sum_Function = delegate (double var1, double var2)
            {
                return var1 + var2;
            };
            //Create a Delegate instance
            PerformCalculation prod_Function = delegate (double var1, double var2)
            {
                return var1 * var2;
            };

            NumberCheck odd_Function = delegate (int x)
            {
                if (x % 2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };


            double val1 = 4.0, val2 = 3.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine($"{val1} + {val2} = {sum_Result}");

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine($"{val1} * {val2} = {prod_Result}");

            //Using sum_function reference
            Console.Write($"{val1} + {val2} = ");
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write($"{val1} * {val2} = ");
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);

            //Omitting the explicit creation of a Func instance
            Console.Write($"{val1} + {val2} = ");
            SpecialFunctions.ExecuteFunctionUsingFunc(delegate (double var1, double var2) { return var1 + var2; },
                                                      val1,
                                                      val2);

            Console.WriteLine();

            /**
             * TODO 8 
             * Create an instance of function created at TODO 2 and use it to print the odd numbers from numbersList collection
             */

            

            List<int> numbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            Console.Write("The odd numbers of this list are : ");
            foreach (int elem in numbersList)
            {
                bool isOdd = odd_Function(elem);
                if (isOdd)
                {
                    Console.Write($"{elem} ");
                }
            }
            Console.WriteLine();
        }

        private static void LambdaExample()
        {
            Console.WriteLine("=====Example 4 (Lambda example)=====");

            //Use lamba expression to create a Func delegate instance
            Func<double, double, double> sum_Function = (double var1, double var2) => { return var1 + var2; };

            //Use lambda expression without data type to create a Func delegate instance
            Func<double, double, double> sum_Function_withoutType = (var1, var2) => var1 + var2;

            //Use lamba expression to create a delegate instance
            PerformCalculation prod_Function = (double var1, double var2) => var1 * var2;

            //Use lamba expression without data type to create a delegate instance
            PerformCalculation prod_Function_withoutType = (var1, var2) => var1 * var2;

            double val1 = 4.0, val2 = 3.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine($"{val1} + {val2} = {sum_Result}");

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine($"{val1} * {val2} = {prod_Result}");

            //Using sum_function reference
            Console.Write($"{val1} + {val2} = ");
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write($"{val1} * {val2} = ");
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);

            //Omitting the explicit creation of a Func instance
            Console.Write($"{val1} - {val2} = ");
            SpecialFunctions.ExecuteFunctionUsingFunc((var1, var2) => var1 - var2, val1, val2);

            //Omitting the explicit creation of a delegate instance
            Console.Write($"{val1} - {val2} = ");
            SpecialFunctions.ExecuteFunction((var1, var2) => var1 - var2, val1, val2);

            List<int> numbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            /**
             * TODO 9
             *
             * Create a lambda expression which receives two parameters and returns the biggest number
             * and use it to extract the biggest number from numbersList collection.
             */

            Func<int, int, int> getMax = (var1, var2) => var2 > var1 ? var2 : var1;
            int max = 0;
            for (int i = 0; i < numbersList.Count - 1; i++)
            {
                for(int j = i; j < numbersList.Count; j++)
                {
                    max = getMax(numbersList[i], numbersList[j]);
                }
            }
            Console.WriteLine($"The biggest element of this list is : {max}");

            /**
             * TODO 10 (for home)
             * Use the lambda expression from TODO 9  to sort the collection ascending.
             */

            int aux = 0;
            for (int i = 0; i < numbersList.Count - 1; i++)
            {
                for (int j = i; j < numbersList.Count; j++)
                {
                    aux = getMax(numbersList[i], numbersList[j]);
                    if(aux == numbersList[i] && numbersList[i] != numbersList[j])
                    {
                        aux = numbersList[j];
                        numbersList[j] = numbersList[i];
                        numbersList[i] = aux;
                    }
                }
            }

            Console.Write("Elements in ascending order : ");
            foreach(int elem in numbersList)
            {
                Console.Write($"{elem} ");
            }

            Console.WriteLine();
        }

        private static Func<int, int> GetIncFunc()
        {
            var incrementedValue = 0;
            Func<int, int> inc = delegate (int var1)
            {
                incrementedValue = incrementedValue + 1;
                return var1 + incrementedValue;
            };
            return inc;
        }

        private static void ClosureExample()
        {
            Console.WriteLine("=====Example 5 (Closure example)=====");

            Func<int, int> incFunction = GetIncFunc();
            Console.WriteLine(incFunction(2));
            Console.WriteLine(incFunction(4));
            Console.WriteLine(GetIncFunc()(5));

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //DelegateExample();
            //FuncDelegateExample();
            //AnonymousFunctExample();
            //LambdaExample();
            ClosureExample();

            Console.ReadKey();
        }
    }
}
