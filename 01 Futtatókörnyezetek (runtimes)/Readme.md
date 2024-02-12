# Többkomponensű alkalmazás, projekt és szerelvény referenciák

A MultiComponentApp.sln egy olyan solution, melyben három projekt van.
- HelloApp: alkalmazás, mely használná a két könyvtárban (Crypto és Math) levő osztályokat
- Math: könyvtár, matematikai műveletekhez
- Crypto: könyvtár, adattitkosítési műveletekhez

A kiinduló solutionben a HelloApp-ban (Program.cs) nem tudjuk használni a másik két könyvtárban levő műveleteket (fordítási hibát kapunk, ha megpróbáljuk), mert nincs még projekt vagy szerelvény referencia a könyvtárakra.

## Demo 1 - projekt referencia

A HelloApp projektben tegyünk projekt referenciát a Math projektre. Most már tudjuk használni a benne levő osztályt. Próbáljuk ki:
* A Main függvényben "#1" alatti kikommentezett kódot élesítsük. 
* A `HelloApp` legyen a startup projekt (csak egyszer kell megtenni: jobb katt a HelloApp projekten a Solution Explorerben, és "Set as Startup Project" kiválasztása).
* Debuggerben is futtassuk (pl. az `int sum = Math.BasicMath.Add(10, 20)` sorra töréspontot téve és az F5 billentyűvel indítva), bele is tudunk lépni debug során a könyvtárak kódjába a "Step Into" funkcióval.

## Demo 2 - szerelvény referencia

Feltesszük, hogy nincs meg a Crypto könyvtár forráskódja, csak lefordított formában kapjuk meg (pl. külső cégtől) meg a Crypto könyvtárat, vagyis csak a Crypto.dll áll rendelkezésünkre. Ez esetben szerelvény referenciát kell rá tenni. Távolítsuk el a Crypto projektet a solution-ből (azt szimulálva, hogy nincs meg a forrása), tegyünk szerelvény referenciát a Crypto.dll-re (a projekt kimeneti mappájában található). Próbáljuk ki, hogy valóban tudjuk a benne levő kódot használni (ehhez a Main függvényben "#2" alatti kód élesítése).

## Demo 3 - NuGet csomagok

A feladatunk CSV (vesszővel elválasztott értékeket tartalmazó) szövegfájlból adatok beolvasása .NET objektumokba. Mintafájl: HelloApp/Data/SampleFile.txt, ezt nézzük meg. A HelloApp Projektben levő Person osztály objektumaiba szeretnénk a CSV fájl tartalmát beolvasni. CSV fájlok feldolgozására van NuGet csomag, CsvHelper néven. A NuGet.org-on keressünk rá. Vegyük fel Visual Studio HelloApp projektbe:
- HelloApp projektre "Manage NuGet Packages".
- A Browse tab alatt CsvHelper-re keressünk rá
- Jobb oldalt a legfrissebbnél eggyel régebbi verzió kiválasztása
- Install
- Próbáljuk ki, hogy tényleg működik: Main függvényben "#3" alatti kód élesítése, fordítás, futtatás: kiírja a konzolra a beolvasott személyek adatait.

Frissítsük most a NuGet csomagot "Manage NuGet Packages" alatt a legfrissebb változatra, ez is kényelmesen megtehető.