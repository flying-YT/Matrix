using System;
namespace Matrix
{
    public static class MatrixCalclation
    {
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
                // ここから処理開始
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
                // 処理終了、戻り値を作成
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
            Console.WriteLine("[");
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int w = 0; w < x.GetLength(1); w++)
                {
                    Console.Write( " {0,5} ", x[i, w] );
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
    }
}
