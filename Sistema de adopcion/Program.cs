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
            public int Dni { get; set; }

            private List<Animal> mascotas = new List<Animal>();
            public persona(string nombre, int dni)
            {
                this.Nombre = nombre;
                this.Dni = dni;
                mascotas = new List<Animal>();
            }
            public void adoptar(Animal animal)
            {
                mascotas.Add(animal);
            }
            public void Mostrar()
            {
                if(mascotas.Count == 0)
                {
                    Console.WriteLine("No adopto mascotas. :c");
                }
                else
                {
                    foreach (Animal animal in mascotas)
                    {
                        Console.WriteLine($"{animal.Nombre} ({animal.Raza})");
                    }

                }
            }
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
            List<Animal> animales = new List<Animal>()
            {
                new Perro("Dina", "Cocker Spaniel"), new Gato("Gringo", "Ginger"),new Perro("Coco", "Caniche")
            };
            List<persona> personas = new List<persona>()
            {
                new persona("Juan", 12333335),new persona("Ana", 45622223)
            };

            while (true) 
            { 
                    Console.WriteLine("1. Animales en adopcion");
                    Console.WriteLine("2. Registrar nueva persona");
                    Console.WriteLine("3. Adoptar una mascotita");
                    Console.WriteLine("4. Adoptantes (personas)");
                    Console.WriteLine("5. SALIR! ");

                int opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        for (int i = 0; i < animales.Count; i++)
                        {
                            Console.WriteLine($"\n{i + 1}. {animales[i].GetType().Name} - " + $"{animales[i].Nombre} - {animales[i].Raza} - " + $"{animales[i].HacerSonido()}");
                        }
                        break;
                    case 2:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("DNI: ");
                        int dni = int.Parse(Console.ReadLine());

                        personas.Add(new persona(nombre, dni));
                        break;
                    case 3:
                        Console.Write("Ingrese DNI: ");
                        int dniBuscado = int.Parse(Console.ReadLine());

                        persona persona = null;

                        foreach (persona p in personas)
                        {
                            if (p.Dni == dniBuscado)
                            {
                                persona = p;
                            }
                        }
                        if (persona == null)
                        {
                            Console.WriteLine("Persona no encontrada");
                            break;
                        }
                        for (int i = 0; i < animales.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {animales[i].Nombre}");
                        }
                        Console.Write("Seleccione animal: ");
                        int indice = int.Parse(Console.ReadLine()) - 1;

                        if (indice >= 0 && indice < animales.Count)
                        {
                            persona.adoptar(animales[indice]);
                            animales.RemoveAt(indice);
                            Console.WriteLine("Mascota adoptada");
                        }
                        else
                        {
                            Console.WriteLine("Animal inexistente");
                        }
                        break;
                    case 4:
                        foreach (persona p in personas)
                        {
                            Console.WriteLine($"\n{p.Nombre}");

                            p.Mostrar();
                        }
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
    }
}
