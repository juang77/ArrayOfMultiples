using System;
using ArrayOfMultiples.DTOs;

namespace ArrayOfMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro value = CaptarNumeros();
            Console.WriteLine("[{0}]", string.Join(", ", CreateArray(value)));
            Console.ReadLine();
        }

        public static Intro CaptarNumeros() {
            Console.WriteLine("Esta es la aplicacion de listado de multiplos.");
            Console.WriteLine("Introduzca el valor inicial");
            String textoInicial;
            textoInicial = Console.ReadLine();

            Console.WriteLine("Introduzca la cantidad de multiplos");
            String textoCantidad;
            textoCantidad = Console.ReadLine();
            Intro value = new Intro();
            try
            {
                value.Initial = int.Parse(textoInicial);
                value.Many = int.Parse(textoCantidad);
                string result = ValidateIntro(value);
                if (result != "Ok")
                {
                    Console.WriteLine("**********************************************************************************");
                    Console.WriteLine("Iniciemos nuevamente el ingreso de valores.");
                    Console.WriteLine("Ninguno de los valores puede ser menos o igual a 0.");
                    Console.WriteLine("Solo seran admitidos numeros enteros.");
                    Console.WriteLine("Oprima Enter cuando este listo:");
                    Console.WriteLine("**********************************************************************************");
                    textoCantidad = Console.ReadLine();
                    value = CaptarNumeros();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Iniciemos nuevamente el ingreso de valores (Ninguno de los valores puede ser menos o igual a 0), Oprima Enter cuando este listo:");
                textoCantidad = Console.ReadLine();
                value = CaptarNumeros();
            }

            return value;
        }

        public static string ValidateIntro(Intro value) {
            string result = "Ok";
            if (value.Initial <= 0 || value.Many <= 0) { result = "Error"; }
            return result;
        }

        public static int[] CreateArray(Intro Value) {
            int[] ArrayOut = new int[Value.Many];
            ArrayOut[0] = Value.Initial;
            for (int i = 1; i < Value.Many; i++)
            {
                ArrayOut[i] = ArrayOut[i - 1] + Value.Initial;
            }
            return ArrayOut;
        }
    }


}
