using AluraTunes.Data;
using System;
using System.Linq;

namespace AluraTunes
{
    internal class LinqToEntitiesWhere
    {
        private void exemploLinqToEntitiesWhere()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var textoBusca = "Led";

                var query = from a in contexto.Artistas
                            where a.Nome.Contains(textoBusca)
                            select a;

                foreach (var artista in query)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }

                Console.WriteLine();

                var query2 = contexto.Artistas.Where(a => a.Nome.Contains(textoBusca));

                foreach (var artista in query2)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }

            }
            Console.ReadKey();
        }
    }
}
