internal class Program
{
    private static void Main(string[] args)
    {
        List<Nyelv> nyelvek = new();

        //1.
        List<string> sikeresSorok = File.ReadAllLines("sikeres.csv").Skip(1).ToList();
        List<string> sikertelenSorok = File.ReadAllLines("sikertelen.csv").Skip(1).ToList();
        for (int i = 0; i < sikeresSorok.Count; i++)
        {
            string[] sikeresMezok = sikeresSorok[i].Split(';');
            string[] sikertelenMezok = sikertelenSorok[i].Split(';');

            nyelvek.Add(new Nyelv(
                sikeresMezok[0],
                sikeresMezok.Skip(1).Select(x => Convert.ToInt32(x)).ToList(),
                sikertelenMezok.Skip(1).Select(x => Convert.ToInt32(x)).ToList()
            ));
        }

        //2.
        Console.WriteLine("2. feladat: Legnépszerűbb nyelvek:");
        nyelvek.OrderByDescending(x => x.Osszes).Take(3).ToList().ForEach(x => Console.WriteLine("\t" + x.Nev));

        //3.
        Console.Write("3. feladat:\n\tVizsgálandó év: ");
        int ev = Convert.ToInt32(Console.ReadLine());
        if (ev < 2009 || ev > 2017)
        {
            return;
        }
        int evIndex = ev - 2009;

        //4.
        Console.WriteLine("4. feladat:");
        Nyelv legnagyobbArany = nyelvek.OrderBy(x => x.sikertelenArany(evIndex)).First();
        Console.WriteLine($"\t{ev}-ben {legnagyobbArany.Nev} nyelvből a sikertelen vizsgák aránya: {Math.Round(legnagyobbArany.sikertelenArany(evIndex), 2)}");

        //5.
        Console.WriteLine("5. feladat:");
        List<Nyelv> nemVolt = nyelvek.Where(x => x.osszesEv(evIndex) == 0).ToList();
        if (nemVolt.Count == 0)
        {
            Console.WriteLine("\tMinden nyelvből volt vizsgázsó");
        }
        else
        {
            nemVolt.ForEach(x => Console.WriteLine("\t" + x.Nev));
        }

        //6.
        File.WriteAllLines("osszesites.csv", nyelvek.Select(x => $"{x.Nev};{x.Osszes};{Math.Round(x.SikeresArany, 2)}%"));
    }
}