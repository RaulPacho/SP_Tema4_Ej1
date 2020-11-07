using System;

namespace SP_Tema4_Ej1
{
    public delegate void MyDelegate ();
    /*Desarrolla una función para la realización de cualquier menú mediante delegados. Dicha función se
      denominará MenuGenerator y tendrá dos parámetros: El primero un vector de strings con los
      nombres de las opciones. El segundo un vector de delegados (hazlos que devuelvan void y sin
      parámetros y el nombre del delegado que sea MyDelegate) que serán las funciones que correspondan
      a cada opción del menú.


      Al ejecutar MenuGenerator saldrá un menú clásico con las opciones indicadas por el primer vector y
      una última opción Exit. Si se introduce una opción no válida (fuera del rango) dará un mensaje de
      error y vuelve a pedirlo.
      Para probarlo utiliza las siguientes funciones y siguiente programa principal.
    
     */
    class Program
    {
        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }
        static void Main(string[] args)
        {
            /*I can handle myself in English*/
            MenuGenerator(new string[] { "Op1", "Op2", "Op3" },
            new MyDelegate[] { f1, f2, f3 });
            Console.ReadKey();
        }


        public static void MenuGenerator(string[] optName, MyDelegate[] del)
        {
            bool fuckedUp = false;
            int opt = 0;
            if(optName.Length != del.Length)
            {
                throw new ArgumentException();
            }
            do
            {
                    Console.WriteLine("___Menu___");
                int i;
                for (i = 1; i <= optName.Length; i ++)
                {
                    Console.WriteLine(i + ". " + optName[i-1]);
                }
                Console.WriteLine(i + ". We kiss in the cheeks and say goodbye.");
                Console.WriteLine("_Choose whisely..._");

                if (!int.TryParse(Console.ReadLine(), out opt))
                {
                    opt = -2;
                }

                opt--;

                if(opt < 0 || opt > optName.Length)
                {
                    Console.WriteLine("That... was a number out of range or even a freaking letter");
                    fuckedUp = true;
                }
            } while (fuckedUp);

            if(optName.Length == opt)
            {
                Console.WriteLine("Oh... Okey... Hope I'll se you again... T-T");
            }
            else
            {
                del[opt]();
            }

        }
    }
}
