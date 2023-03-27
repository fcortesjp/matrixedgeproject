using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace matrixedgeproject
{
    class Program
    {
        //Nombre del estudiante: Francisco Cortes
        //Grupo: 
        //Número y Texto del programa
        //Código Fuente: autoría propia

        //declare a public variables
        public static int maxRows = 5, maxColumns = 5;
        public static int[,] matrix = new int[maxRows, maxColumns];
        public static int[] edgeValues = new int[(maxRows*4) - 4];
        public static int sum = 0;
        public static double average = 0;

        public static int getNumberForMatrix()
        {
            int intPos;
            while (true)
            {
                string intPosString = Console.ReadLine();

                // revise si el numero esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(intPosString))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El numero no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el numero puede ser un entero
                bool canBeInt = int.TryParse(intPosString, out intPos);
                if (canBeInt == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El numero ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }
                //revise si el numero es menor de 10 o mayor de 90
                if ((intPos < 10) || (intPos > 90))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: el numero debe estar entre 10 y 90");
                    //regrese al inicio del loop
                    continue;
                }
                break;
            }
            return intPos;
        }
        public static void obtenerValores()
        {
            // atraviese las filas
            for (int row = 0; row < maxRows; row++)
            {
                // atraviese las columnas
                for (int column = 0; column < maxColumns; column++)
                {
                    Console.Write("Ingrese un entero para la posicion: [" + row + "," + column + "]: ");
                    int intNumberForMatrix = getNumberForMatrix();
                    //guarde el valor en el array
                    matrix[row, column] = intNumberForMatrix;
                    Console.WriteLine("El valor " + intNumberForMatrix + " ha guardado en la matriz en posicion [" + row + "," + column + "]\n");
                }
                Console.Write("\n");
            }
        }

        public static void obtenerValoresDePerimitro()
        {
            int i = 0;
            // atraviese las filas
            for (int row = 0; row < maxRows; row++)
            {
                // atraviese las columnas
                for (int column = 0; column < maxColumns; column++)
                {
                    if (row == 0 || row == (maxRows - 1) || column == 0 || column == (maxColumns - 1))
                    {
                        edgeValues[i] = matrix[row, column];
                        i++;
                    }
                }
            }
            //for (int j = 0; j< edgeValues.Length; j++) { Console.Write(edgeValues[j] + "\n"); }
        }

        public static void sumaValoresdelPerimetro()
        {
            for (int j = 0; j < edgeValues.Length; j++){ 
                sum += edgeValues[j]; 
            }
            //Console.Write(sum+"\n");
        }

        public static void promedioValoresdelPerimetro()
        {
            average = sum / edgeValues.Length;
            //Console.Write(average+"\n");
        }

        public static void mostrarResultados()
        {
            Console.Write("Resultados:\n");

            //Muestre la matriz
            Console.Write("Matriz:\n");
            // atraviese las filas
            for (int row = 0; row < maxRows; row++)
            {
                // atraviese las columnas
                for (int column = 0; column < maxColumns; column++)
                {
                    Console.Write(matrix[row, column]); //escriba el valor 
                    Console.Write(" "); //agrege un espacio entre valores
                }
                Console.Write("\n"); //agregue un carriage return para pasar a la siguiente linea
            }
            Console.Write("\n");

            //Muestre los valores del borde
            Console.Write("Valores de Borde:\n");
            Console.Write("[\n");
            for (int h = 0; h < edgeValues.Length; h++)
            {
                Console.Write(edgeValues[h]);
                Console.Write(" ");
            }
            Console.Write("\n");
            Console.Write("]");
            Console.Write("\n");

            //Muestre Suma de los valores del borde
            Console.Write("Suma de Valores de Borde:\n");
            Console.Write(sum);
            Console.Write("\n");

            //Muestre Promedio de los valores del borde
            Console.Write("Promedio de Valores de Borde:\n");
            Console.Write(average);
            Console.Write("\n");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Este Programa Calcula suma y promedio de valores bordes de una matriz de 5x5");
            obtenerValores();
            obtenerValoresDePerimitro();
            sumaValoresdelPerimetro();
            promedioValoresdelPerimetro();
            mostrarResultados();
            Console.WriteLine("Presione enter para finalizar...");
            Console.ReadLine();
        }
    }
}
