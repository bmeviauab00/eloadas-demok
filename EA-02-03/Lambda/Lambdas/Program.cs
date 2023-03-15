using System.Collections;

namespace Lambdas;

class Program
{
    static void Main(string[] args)
    {
        #region Klasszikus delegate alapú megoldás

        ArrayList list = new ArrayList();
        list.Add(new Complex(3, 2));
        list.Add(new Complex(4, 4));
        list.Add(new Complex(1, 2));

        // Megoldás klasszikus delegate-tel
        Sorter.HyperSort(list, FirstIsSmaller_Complex);

        #endregion

        #region Bevezető lambda kifejezés/expression

        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

        // Lehetőség van névtelen (anonymous) függvények definiálására
        // Ehhet a lambda deklaráció operátort használjuk: =>
        // A => operátor bal oldalán kell megadni a paramétereket, a jobb oldalán pedig:
        // * UTASÍTÁS/STATEMENT lambda változat esetén {} között utasítások/statementek sorozatát (vagy egyetlen utasítást)
        //   Szintaktika: (input-parameters) => { <sequence-of-statements> }
        // * KIFEJEZÉS/EXPRESSION lambda változat esetén {} nélkül egyetlen kifejezést
        //   (input-parameters) => expression
        #endregion

        #region UTASÍTÁS/STATEMENT lambda változat definiálása és eltárolása egy lokális változóban

        // A fis0 lokális változót a FirstIsSmaller_Complex "klasszikus", névvel rendelkező
        // függvényre állítjuk. Eddig erre láttunk példákat.
        FirstIsSmallerDelegate fis0 = FirstIsSmaller_Complex;

        // De nem mindig akarunk egy függvényt bevezetni ilyen esetben.
        // A következő lépésben egy hasonló lokális változót egy név nélküli, helyben definiált,
        // lambda kifejezés formájában adott "függvényre" állítjuk.

        // A utasítás/statement lambda változat esetében {} között akárhány utasítás állhat:
        // ez az általános szintaktika: (input-parameters) => { <sequence-of-statements> }
        // A gyakorlatban 2-4 sornál hosszabbat ritkán szoktunk.
        // Lambda kifejezés definiálása és eltárolása egy lokális változóban példa:
        // A lambda kifejezés paraméterei az a és a b, a törzse a => után található.
        // Ez egy névtelen függvény, így hogy használni tudjuk, eltároltuk egy
        // delegate változóban egy hivatkozást rá.

        FirstIsSmallerDelegate fis1 = (object a, object b) =>
            {
                Complex ca = (Complex)a;
                Complex cb = (Complex)b;
                return ca.Re < cb.Re;
            };
        // Átadjuk paraméterként a függvénynek, pont úgy, mint egy delegate objektumot
        Sorter.HyperSort(list, fis1);

        // helyben is meghívható, pont úgy, mint egy delegate
        bool b1 = fis1(new Complex(1, 2), new Complex(1, 2));

        #endregion

        #region UTASÍTÁS/STATEMENT lambda változat - "inline" definíció

        // Itt most paraméterként adtuk át egy függvénynek, és a hívás helyén helyben definiáltuk
        Sorter.HyperSort(list,
                (object a, object b) =>
                {
                    return ((Complex)a).Re < ((Complex)b).Re;
                }
            );

        // A paraméterek típusát nem kell kiírni, a fordító kikövetkezteti. Mostantól nem írjuk ki
        // csak akkor, ha a fordító panaszkodik, hogy valamilyen okból nem tudja kikövetkeztetni
        Sorter.HyperSort(list,
                (a, b) =>
                {
                    return ((Complex)a).Re < ((Complex)b).Re;
                }
            );

        #endregion

        #region KIFEJEZÉS/EXPRESSION lambda változat: akkor használható, ha csak egyetlen utasításból áll, rövidebb/átláthatóbb

        // Nincs { }, csak egyetlen kifejezésből áll, ennek értékével tér vissza ("return" sem kell, sőt nem is használható).
        Sorter.HyperSort(list, (a, b) => ((Complex)a).Re < ((Complex)b).Re);
        // Alább még lesznek példák

        #endregion

        #region Beépített Func<...> generikus delegate használata

        // Sorter2 paramétere egy Func, lásd a Sorter2 definícióját a AlgoLib_Func.cs-ben
        Sorter2.HyperSort(list, (a, b) => ((Complex)a).Re < ((Complex)b).Re);

        // A Func teljes értékű típus/delegate, lehet paraméter/tagváltozó/lokális változó is belőle
        // Lokális változó példa:
        Func<object, object, bool> fis2 = (a, b) => ((Complex)a).Re < ((Complex)b).Re;
        Sorter2.HyperSort(list, fis2);

        #endregion

        #region Beépített Action<...> generikus delegate használata

        // Amennyiben egy delegate-nek nincs visszatérése (vagyis void), akkor a Func<...>
        // helyett az Action<...> használandó. Generikus paraméterben a delegate paramétereket
        // kell megadni vesszővel elválasztva. Ha nincs paraméter, akkor a sima, nem generikus
        // Action delegate használható.

        // Példa 1:
        Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
        greet("World"); // Kiírja, hogy "Hello World"

        // Példa 2:
        Action<string, string> labelAndTextWriter = (label, text) => Console.WriteLine($"{label}:\t{text}");
        labelAndTextWriter("Név", "Ennio Morricone");
        labelAndTextWriter("Szül. év", "1928");

        #endregion

        #region Paraméterek szintaktikája

        // Ha nincs paraméter, üres zárójel
        Action line = () => Console.WriteLine();

        // Ha egy paraméter van, a zárójel opcionális (nem szoktuk kiírni)
        Func<double, double> cube = x => x * x * x;

        // Ha több paraméter is van, ()-ek között vesszővel elválasztva soroljuk fel,
        // lásd fenti példák, illetve:
        Func<int, int, bool> testForEquality = (x, y) => x == y;

        // Emlékezzünk: ha a fordító nem tudja kikövetkeztetni a paraméterek típusát
        // akkor adjuk meg a típusokat is (ebben a példában egyébként ki tudná):
        Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;

        #endregion
    }

    public static bool FirstIsSmaller_Complex(object a, object b)
    {
        return ((Complex)a).Re < ((Complex)b).Re;
    }
}
