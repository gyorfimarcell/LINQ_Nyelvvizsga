public class Nyelv
{
    string nev;
    List<int> sikeres;
    List<int> sikertelen;

    public Nyelv(string nyelv, List<int> sikeres, List<int> sikertelen)
    {
        this.nev = nyelv;
        this.sikeres = sikeres;
        this.sikertelen = sikertelen;
    }

    public string Nev { get => nev; }
    public List<int> Sikeres { get => sikeres; }
    public List<int> Sikertelen { get => sikertelen; }

    public int Osszes { get => sikeres.Sum() + sikertelen.Sum(); }
    public double SikeresArany { get => Convert.ToDouble(sikeres.Sum()) / Osszes * 100; }
    
    public int osszesEv(int index) {
        return sikeres[index] + sikertelen[index];
    }

    public double sikertelenArany(int index) {
        if (osszesEv(index) == 0)
        {
            return 0;
        }
        return sikertelen[index] / Convert.ToDouble(osszesEv(index)) * 100;
    }
}