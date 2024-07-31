using System;
using System.Linq;
using System.Xml.Linq;

namespace AluraTunes
{
    internal class LinqToXml
    {
        private void exemploLinqToXml()
        {
            string filePath = @"C:\arquivos\AluraTunes.xml";

            XElement root = XElement.Load(filePath);

            var queryXML =
                from g in root.Element("Generos").Elements("Genero")
                select g;

            foreach (var genero in queryXML)
            {
                Console.WriteLine("{0}\t{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
            }

            Console.WriteLine();

            var query =
                from g in root.Element("Generos").Elements("Genero")
                join m in root.Element("Musicas").Elements("Musica") on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                select new
                {
                    Musica = m.Element("Nome").Value,
                    Genero = g.Element("Nome").Value
                };

            foreach (var musicaEgenero in query)
            {
                Console.WriteLine("{0}\t{1}", musicaEgenero.Musica, musicaEgenero.Genero);
            }

            Console.ReadKey();
        }
    }
}
