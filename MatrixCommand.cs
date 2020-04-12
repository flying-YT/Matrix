using System;
using System.Collections.Generic;

namespace Matrix
{
    public class MatrixCommand
    {
        double[,] matrix1 = null;
        double[,] matrix2 = null;
        double[,] matrix3 = null;
        private bool finishCheck = true;

        public void MainProgram()
        {
            while (finishCheck)
            {
                Console.WriteLine("");
                Console.WriteLine("Plase command or \"exit\"");
                string str = Console.ReadLine();
                if (str == "exit")
                {
                    finishCheck = false;
                    Console.WriteLine("Bye");
                }
                else
                {
                    string[] del = { "->" };
                    string[] readStr = str.Split(del, StringSplitOptions.None);
                    if (readStr[0] == "MakeMatrix")
                    {
                        try
                        {
                            if (readStr[1] == "A")
                            {
                                matrix1 = MakeMatrix();
                            }
                            else if (readStr[1] == "B")
                            {
                                matrix2 = MakeMatrix();
                            }
                            else if (readStr[1] == "C")
                            {
                                matrix3 = MakeMatrix();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please write matrix name. A or B or C.");
                        }
                    }
                    else if (readStr[0] == "Print")
                    {
                        if (readStr[1] == "A")
                        {
                            if (matrix1 != null)
                            {
                                MatrixCalculation.MatrixPrint(matrix1);
                            }
                        }
                        else if (readStr[1] == "B")
                        {
                            if (matrix2 != null)
                            {
                                MatrixCalculation.MatrixPrint(matrix2);
                            }
                        }
                        else if (readStr[1] == "C")
                        {
                            if (matrix3 != null)
                            {
                                MatrixCalculation.MatrixPrint(matrix3);
                            }
                        }
                    }
                    else if (readStr[0] == "Sum")
                    {
                        try
                        {
                            string[] chooseMatrix = readStr[1].Split(',');
                            double[,] A = ReturnMatrix(chooseMatrix[0]);
                            double[,] B = ReturnMatrix(chooseMatrix[1]);
                            try
                            {
                                if (readStr[2] == "A")
                                {
                                    matrix1 = MatrixCalculation.MatrixSum(A, B);
                                }
                                else if (readStr[2] == "B")
                                {
                                    matrix2 = MatrixCalculation.MatrixSum(A, B);
                                }
                                else if (readStr[2] == "C")
                                {
                                    matrix3 = MatrixCalculation.MatrixSum(A, B);
                                }
                            }
                            catch
                            {
                                MatrixCalculation.MatrixPrint(MatrixCalculation.MatrixSum(A, B));
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Not enough arguments.");
                        }
                    }
                    else if (readStr[0] == "Product")
                    {
                        try
                        {
                            string[] chooseMatrix = readStr[1].Split(',');
                            double[,] A = ReturnMatrix(chooseMatrix[0]);
                            double[,] B = ReturnMatrix(chooseMatrix[1]);
                            try
                            {
                                if (readStr[2] == "A")
                                {
                                    matrix1 = MatrixCalculation.MatrixProduct(A, B);
                                }
                                else if (readStr[2] == "B")
                                {
                                    matrix2 = MatrixCalculation.MatrixProduct(A, B);
                                }
                                else if (readStr[2] == "C")
                                {
                                    matrix3 = MatrixCalculation.MatrixProduct(A, B);
                                }
                            }
                            catch
                            {
                                MatrixCalculation.MatrixPrint(MatrixCalculation.MatrixProduct(A, B));
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Not enough arguments.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(readStr[0] + " is not comand.");
                    }
                }
            }
        }

        private double[,] MakeMatrix()
        {
            double[,] returnValue = null;
            List<double[]> matrix = new List<double[]>();
            List<string> readStringArray = new List<string>();
            int maxLine = 0;
            int maxColumn = 0;
            Console.WriteLine("[");
            while (finishCheck)
            {
                string str = Console.ReadLine();
                if (str == "]")
                {
                    break;
                }
                readStringArray.Add(str);
                maxColumn++;
            }
            foreach (string x in readStringArray)
            {
                try
                {
                    string[] strArray = x.Split(',');
                    if (maxLine < strArray.Length)
                    {
                        maxLine = strArray.Length;
                    }
                    double[] doubleArray = new double[strArray.Length];
                    int count = 0;
                    foreach (string y in strArray)
                    {
                        doubleArray[count] = int.Parse(y);
                        count++;
                    }
                    matrix.Add(doubleArray);
                }
                catch
                {
                    Console.WriteLine("You make a mistake entering data");
                }
            }
            returnValue = new double[maxColumn, maxLine];
            int column = 0;
            int line = 0;
            try
            {
                foreach (double[] y in matrix)
                {
                    foreach (double z in y)
                    {
                        returnValue[column, line] = z;
                        line++;
                    }
                    line = 0;
                    column++;
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            return returnValue;
        }

        private double[,] ReturnMatrix(string x)
        {
            double[,] y = null;
            if (x == "A")
            {
                y = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int w = 0; w < matrix1.GetLength(1); w++)
                    {
                        y[i, w] = matrix1[i, w];
                    }
                }
            }
            else if (x == "B")
            {
                y = new double[matrix2.GetLength(0), matrix2.GetLength(1)];
                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int w = 0; w < matrix2.GetLength(1); w++)
                    {
                        y[i, w] = matrix2[i, w];
                    }
                }
            }
            else if (x == "C")
            {
                y = new double[matrix3.GetLength(0), matrix3.GetLength(1)];
                for (int i = 0; i < matrix3.GetLength(0); i++)
                {
                    for (int w = 0; w < matrix3.GetLength(1); w++)
                    {
                        y[i, w] = matrix3[i, w];
                    }
                }
            }
            return y;
        }
    }
}
