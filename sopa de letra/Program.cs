using System;

class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese las palabras para la sopa de letras (separadas por coma):");
        string[] palabras = Console.ReadLine().Split(',');

        // Eliminar espacios en blanco alrededor de las palabras
        for (int i = 0; i < palabras.Length; i++)
        {
            palabras[i] = palabras[i].Trim();
        }

        Console.WriteLine("Ingrese el tamaño de la sopa de letras (número de filas y columnas):");
        int size = Convert.ToInt32(Console.ReadLine());

        char[,] sopaLetras = new char[size, size];

        // Llenar la sopa de letras con letras aleatorias
        LlenarSopaDeLetras(sopaLetras);

        // Insertar palabras en la sopa de letras en direcciones diversas
        InsertarPalabras(sopaLetras, palabras);

        // Mostrar la sopa de letras
        MostrarSopaDeLetras(sopaLetras);
    }

    static void LlenarSopaDeLetras(char[,] sopa)
    {
        int size = sopa.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                // Generar letra aleatoria entre 'A' y 'Z'
                sopa[i, j] = (char)(random.Next(26) + 'A');
            }
        }
    }

    static void InsertarPalabras(char[,] sopa, string[] palabras)
    {
        foreach (string palabra in palabras)
        {
            int size = sopa.GetLength(0);
            int length = palabra.Length;

            // Seleccionar una dirección aleatoria (horizontal, vertical, diagonal)
            int direccion = random.Next(3);

            int filaInicial = random.Next(size);
            int columnaInicial = random.Next(size);

            switch (direccion)
            {
                case 0: // Horizontal
                    if (columnaInicial + length <= size)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            sopa[filaInicial, columnaInicial + j] = palabra[j];
                        }
                    }
                    break;
                case 1: // Vertical
                    if (filaInicial + length <= size)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            sopa[filaInicial + i, columnaInicial] = palabra[i];
                        }
                    }
                    break;
                case 2: // Diagonal
                    if (filaInicial + length <= size && columnaInicial + length <= size)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            sopa[filaInicial + k, columnaInicial + k] = palabra[k];
                        }
                    }
                    break;
            }
        }
    }

    static void MostrarSopaDeLetras(char[,] sopa)
    {
        int size = sopa.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(sopa[i, j] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
