using System;
namespace Matrix
{
    public static class MatrixCalclation
    {
        public static double Det( double[,] x )
        {
            double returnvalue = 0;
            if ( x.GetLength(0) == x.GetLength(1) )
            {
                double[,] l = new double[x.GetLength(0), x.GetLength(1)];
                double[,] u = new double[x.GetLength(0), x.GetLength(1)];
                for (int i=0;i<x.GetLength(0);i++)
                {
                    l[i, i] = 1;
                    u[0, i] = x[0, i];
                }
                double n = 0;
                int count = 1;
                int line = 1;
                int column = 1;
                while( count <= (x.GetLength(0)-1)*2)
                {
                    if (count%2 != 0)
                    {
                        for (int i=line;i<x.GetLength(0);i++)
                        {
                            for (int w = 0; w < x.GetLength(1); w++)
                            {
                                if( w != (line-1))
                                {
                                    n += l[i, w] * u[w, line-1];
                                }
                            }
                            l[i, column - 1] = (x[i, column - 1] - n) / u[line - 1, column - 1];
                            n = 0;
                        }
                        column++;
                    }
                    else
                    {
                        for(int i=(column-1);i<x.GetLength(1);i++)
                        {
                            for(int w=0;w<x.GetLength(0);w++)
                            {
                                if (w != (column-1))
                                {
                                    n += l[column-1, w] * u[w, i];
                                }
                            }
                            u[line, i] = (x[line, i] - n) / l[line, column-1];
                            n = 0;
                        }
                        line++;
                    }
                    count++;
                }
                double detU = 1;
                for (int i=0;i<x.GetLength(0);i++)
                {
                    detU = detU * u[i, i];
                }
                double detL = 1;
                returnvalue = detL * detU;
            }
            else
            {
                Console.WriteLine("It's not Square matrix.");
            }
            return returnvalue;
        }

        public static double[,] IdentityMatrix(int n)
        {
            double[,] e = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int w = 0; w < n; w++)
                {
                    if (i == w)
                    {
                        e[i, w] = 1;
                    }
                    else
                    {
                        e[i, w] = 0;
                    }
                }
            }
            return e;
        }

        public static double[,] MatrixInverse( double[,] x )
        {
            if( x.GetLength(0) == x.GetLength(1) )
            {
                double[,] returnMatrix = new double[x.GetLength(0), x.GetLength(1)];
                double[,] xi = new double[x.GetLength(0), x.GetLength(1) * 2];
                double[,] i = IdentityMatrix(x.GetLength(0));
                for (int v = 0; v < xi.GetLength(0); v++)
                {
                    for (int w = 0; w < xi.GetLength(1); w++)
                    {
                        if (w < x.GetLength(1))
                        {
                            xi[v, w] = x[v, w];
                        }
                        else
                        {
                            xi[v, w] = i[v, (w - x.GetLength(1))];
                        }
                    }
                }
                // start process
                int column = 0;
                for (int v = 0; v < xi.GetLength(0); v++)
                {
                    if (xi[v, column] != 0)
                    {
                        double y = xi[v, column];
                        for (int w = 0; w < xi.GetLength(1); w++)
                        {
                            xi[v, w] = xi[v, w] / y;
                        }
                        for (int w=0;w<xi.GetLength(0);w++)
                        {
                            y = xi[w, column];
                            for (int n=0;n<xi.GetLength(1);n++)
                            {
                                if(v != w)
                                {
                                    xi[w, n] -= (xi[v, n] * y);
                                }
                            }
                        }
                        column++;
                    }
                    else
                    {
                        for(int w = v+1;w<xi.GetLength(0);w++)
                        {
                            if (xi[w, column] != 0)
                            {
                                double z = 0;
                                for (int n=0;n<xi.GetLength(1);n++)
                                {
                                    z = xi[v, n];
                                    xi[v, n] = xi[w, n];
                                    xi[w, n] = z;
                                }
                            }
                        }
                        v--;
                    }
                }
                // finish process and make return value
                for (int v=0;v<x.GetLength(0);v++)
                {
                    for(int w=0;w<x.GetLength(1);w++)
                    {
                        returnMatrix[v, w] = xi[v, w+x.GetLength(1)];
                    }
                }
                return returnMatrix;
            }
            else
            {
                Console.WriteLine("It's not Square matrix.");
                return x;
            }
        }

        public static void MatrixPrint(double[,] x)
        {
            int n = MaxDigit(x);
            Console.WriteLine("[");
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int w = 0; w < x.GetLength(1); w++)
                {
                    Console.Write( " {0," + n + "} ", x[i, w] );
                }
                Console.WriteLine( "" );
            }
            Console.WriteLine( " ]" );
        }

       　public static double[,] MatrixProduct( double[,] x, double[,] y )
         {
            if( x.GetLength(1) == y.GetLength(0) )
            {
                double[,] product = new double[x.GetLength(0),y.GetLength(1)];
                for(int i=0;i<x.GetLength(0);i++)
                {
                    for(int w=0;w<y.GetLength(1);w++)
                    {
                        for(int v=0;v<x.GetLength(1);v++)
                        {
                            product[i, w] += x[i, v] * y[v, w];
                        }
                    }
                }
                return product;
            }
            else
            {
                Console.WriteLine( "Matrix type mismatch." );
                return x;
            }
         }

         public static double[,] MatrixSum( double[,] x, double[,] y )
         {
            if( x.GetLength(0) == y.GetLength(0) && x.GetLength(1) == y.GetLength(1) )
            {
                for (int i=0;i<x.GetLength(0);i++)
                {
                    for (int w=0;w<x.GetLength(1);w++)
                    {
                        x[i, w] = x[i, w] + y[i, w];
                    }
                }
            }
            else
            {
                Console.WriteLine( "Matrix type mismatch." );
            }
            return x;
         }

        private static int MaxDigit( double[,] x )
        {
            int max = 0;
            for(int i=0;i<x.GetLength(0);i++)
            {
                for(int w=0;w<x.GetLength(1);w++)
                {
                    if(max < x[i, w].ToString().Length)
                    {
                        max = x[i, w].ToString().Length;
                    }
                }
            }
            return max;
        }
    }
}
