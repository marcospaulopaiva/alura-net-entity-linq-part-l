using AluraTunes.Data;
using System;
using System.Linq;
using System.Xml.Linq;

namespace AluraTunes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using(var contexto = new AluraTunesEntities())
            {
                var query = from g in contexto.Generos
                            select g;

                foreach (var genero in query) 
                {
                    Console.WriteLine("{0}\t{1}",genero.GeneroId, genero.Nome);
                }

                Console.WriteLine();

                var queryFaixaEGenero = from g in contexto.Generos
                                        join f in contexto.Faixas on g.GeneroId equals f.GeneroId
                                        select new { f, g };

                queryFaixaEGenero = queryFaixaEGenero.Take(10);

                contexto.Database.Log = Console.WriteLine;

                foreach (var item in queryFaixaEGenero)
                {
                    Console.WriteLine("{0}\t{1}",item.f.Nome, item.g.Nome);
                }

            }

           Console.ReadKey();
        }
    }
}
