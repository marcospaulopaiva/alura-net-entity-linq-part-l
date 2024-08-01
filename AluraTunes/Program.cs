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
            using (var contexto = new AluraTunesEntities())
            {
                var buscaArtista = "Led Zeppelin";
                var buscaAlbum = "Graffiti";
                GetFaixas(contexto, buscaArtista, buscaAlbum);

            }
            Console.ReadKey();
        }

        private static void GetFaixas(AluraTunesEntities contexto, string buscaArtista, string buscaAlbum)
        {
            var query = from f in contexto.Faixas
                        where f.Album.Artista.Nome.Contains(buscaArtista)
                        select f;

            if (!string.IsNullOrEmpty(buscaAlbum))
            {
                query = query.Where(q => q.Album.Titulo.Contains(buscaAlbum));
            }

            foreach (var faixa in query)
            {
                Console.WriteLine("{0}\t{1}", faixa.Album.Titulo.PadRight(40), faixa.Nome);
            }
        }
    }
}
