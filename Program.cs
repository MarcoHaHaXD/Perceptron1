using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            Neurona p = new Neurona(3);
            Random r = new Random();

          

            bool sw = false;
            while(!sw)
            {
                sw = true;
                
                                             
                Console.WriteLine("------------------------");
                Console.WriteLine("Peso 1: " + p.Pesos[0]);
                Console.WriteLine("Peso 2: " + p.Pesos[1]);
                Console.WriteLine("Peso 3: " + p.Pesos[2]);
                Console.WriteLine("Umbral: " + p.Umbral);
                Console.WriteLine("E1:1 E2:1 E3: 1 : " + p.salida(new float[3] { 1f, 1f, 1f}));
                Console.WriteLine("E1:1 E2:0 E3: 0 : " + p.salida(new float[3] { 1f, -1f, -1f}));
                Console.WriteLine("E1:0 E2:1 E3: 0 : " + p.salida(new float[3] { -1f, 1f, -1f }));
                Console.WriteLine("E1:0 E2:0 E3: 1 : " + p.salida(new float[3] { -1f, -1f, 1f }));
                Console.WriteLine("E1:1 E2:1 E3: 0 : " + p.salida(new float[3] { 1f, 1f, -1f }));
                Console.WriteLine("E1:0 E2:0 E3: 1 : " + p.salida(new float[3] { 1f, -1f, 1f }));
                Console.WriteLine("E1:0 E2:1 E3: 1 : " + p.salida(new float[3] { -1f, 1f, 1f }));
                Console.WriteLine("E1:0 E2:0 E3: 0 : " + p.salida(new float[3] { -1f, -1f, -1f }));
               
                if (p.salida(new float[3] { 1f, 1f, 1f }) !=1)
                {
                    p.Aprender(new float[3] { 1f, 1f, 1f}, 1);
                   sw = false;
                }
                if (p.salida(new float[3] { 1f, -1f, -1f }) != 0)
                {
                    p.Aprender(new float[3] { 1f, -1f, -1f}, 0);
                    sw = false;
                }
                if (p.salida(new float[3] { -1f, 1f, -1f}) != 0)
                {
                    p.Aprender(new float[3] { -1f, 1f, -1f}, 0);
                    sw = false;
                }
                if (p.salida(new float[3] { -1f, -1f, 1f}) != 0)
                {
                    p.Aprender(new float[3] { -1f, -1f, 1f}, 0);
                    sw = false;
                }
                if (p.salida(new float[3] { 1f, 1f, -1f }) != 0)
                {
                    p.Aprender(new float[3] { 1f, 1f, -1f }, 0);
                    sw = false;
                }
                if (p.salida(new float[3] { 1f, -1f, 1f }) != 0)
                {
                    p.Aprender(new float[3] { 1f, -1f, 1f }, 0);
                    sw = false;
                }
                if (p.salida(new float[3] { -1f, 1f, 1f }) != 0)
                {
                    p.Aprender(new float[3] { -1f, 1f, 1f }, 0);
                    sw = false;
                }
                if (p.salida(new float[3] { -1f, -1f, -1f }) != 0)
                {
                    p.Aprender(new float[3] { -1f, -1f, -1f }, 0);
                    sw = false;
                }


            }
            Console.ReadKey();

            //Console.Write(p.funcion(0));
            //

        }

        
    }

    public class Neurona
    {
        float[] PesosAnteriores;
        float UmbralAnterior;

        public float[] Pesos;
        public float Umbral;
        public float TasaDeAprendizaje = 0.3f;

        public Neurona(int NEntradas, float tasaDeAprendizaje = 0.3f)
        {
            TasaDeAprendizaje = tasaDeAprendizaje;
            Pesos = new float[NEntradas];
            PesosAnteriores = new float[NEntradas];
            Aprender();
        }

        public void Aprender()
        {
            Random r = new Random();
            for (int i = 0; i < PesosAnteriores.Length; i++)
            {
                PesosAnteriores[i] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
            }

            UmbralAnterior = Convert.ToSingle(r.NextDouble() - r.NextDouble());

            Pesos = PesosAnteriores;
            Umbral = UmbralAnterior;
        }
        public void Aprender (float[] entradas, float salidaEsperada)
        {
            if (PesosAnteriores != null)
            {
                float error = salidaEsperada - salida(entradas);
                for (int i = 0; i < Pesos.Length; i++)
                {
                    Pesos[i] = PesosAnteriores[i] + TasaDeAprendizaje * error * entradas[i];
                }
                Umbral = UmbralAnterior + TasaDeAprendizaje * error;

                PesosAnteriores = Pesos;
                UmbralAnterior = Umbral;
            }
            else
            {
                Random r = new Random();
                for (int i = 0; i < PesosAnteriores.Length; i++) 
                {
                    PesosAnteriores[i] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                }
                   
                UmbralAnterior = Convert.ToSingle(r.NextDouble() - r.NextDouble());

                Pesos = PesosAnteriores;
                Umbral = UmbralAnterior;

            }
        }


      public float salida(float[] entradas) 
        {
            return Sigmoid(neurona(entradas));
        }

        float neurona(float[] entradas)
        {
            float sum = 0;
            for (int i = 0; i< Pesos.Length; i++) 
            {
                sum += entradas[i] * Pesos[i];
            }
            sum += Umbral;
            return sum;
        }


        float Sigmoid(float d)
        {
            return d > 0 ? 1 : 0;
        }
    }
}
