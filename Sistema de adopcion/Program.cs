using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_adopcion.Program;

namespace Sistema_de_adopcion
{
    internal class Program
    {
        public class persona
        {
            public string Nombre { get; set; }
            public string Dni { get; set; }

            private List<Animal> .....
         

            public void adopcion()
            {

            }
        }
        public persona(string Nombre,string Dni)
        {
            this.Nombre = Nombre;
            this.dni = Dni;
        }
        public class Animal
        {
            public string Nombre { get; }
            public string Raza { get; }

            public Animal(string nombre, string raza)
            {
                this.Nombre = nombre;
                this.Raza = raza;
            }
            public virtual string HacerSonido()
            {
                return "sonidoGenerico";
            }
            public void Respirar()
            {
            }
        }
     
        public class Perro : Animal
        {

            public Perro(string nombre, string raza) : base(nombre, raza)
            {

            }
            public override string HacerSonido()
            {
                return "Ladra";
            }
        }
        public class Gato : Animal
        {

            public Gato(string nombre, string raza) : base(nombre, raza)
            {

            }
            public override string HacerSonido()
            {
                return "Maulla";
            }
        }
        static void Main(string[] args)
        {
            persona p = new persona("Ana", "22222222");
            Console.WriteLine($"{p.Nombre}: {p.Dni}");
            Animal[] animales = { new Perro("Boby", "Bulldog"), new Gato("Paca", "Rex") };
            foreach (var a in animales)
                Console.WriteLine($"{a.GetType()} {a.Nombre}: {a.HacerSonido()}");
        }
    }
}
