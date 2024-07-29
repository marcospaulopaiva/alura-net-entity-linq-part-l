using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lista os gêneros rock
            var generos = new List<Genero>
            {
                new Genero { Id = 1, Nome = "Rock"},
                new Genero { Id = 2, Nome = "Reggae"},
                new Genero { Id = 3, Nome = "Rock Progressivo"},
                new Genero { Id = 4, Nome = "Punk Rock"},
                new Genero { Id = 5, Nome = "Clássica"}
            };

            foreach (var genero in generos) 
            {
                if (genero.Nome.Contains("Rock"))
                {
                    Console.WriteLine("{0}\t{1}",genero.Id, genero.Nome);
                }
            }

            Console.WriteLine();

            //select * from generos

            var query = from g in generos
                        where g.Nome.Contains("Rock")
                        select g;


            foreach (var genero in query)
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            }


            Console.ReadKey();
        }
    }

    class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
