using Microsoft.Data.SqlClient;

namespace AdoNet;

internal class Program
{
    static void Main(string[] args)
    {
        TermekLista();

        // TermekLista("Termék1");

        // TermekLista("Termék1';DROP Table ImportantData --");

        //Console.WriteLine("Termék azonosító");
        //int termekid = int.Parse(Console.ReadLine());
        //Console.WriteLine("Név");
        //string temerkNev = Console.ReadLine();
        //Console.WriteLine("Ár");
        //int ar = int.Parse(Console.ReadLine());
        // TermekBeszuras(termekid, temerkNev, ar);

        // TermekLista();

        Console.ReadKey();
    }

    private static void TermekLista(string termekSzuro = null)
    {
        SqlConnection conn = null;
        SqlDataReader reader = null;

        try
        {
            // Kapcsolat objektum létrehozása
            conn = new SqlConnection("Data Source=.\\MSSQ2019;Initial Catalog=SzoftechDB;Integrated Security=True;TrustServerCertificate=true");

            // Az adatbázis parancs létrehozása
            // Így nem szabad, SQL injection !!!!
            // Helyette sql paraméterek, lásd alább beszúrás (TermekBeszuras) függvény példa.
            SqlCommand command
                = new SqlCommand("SELECT TermekID, Nev, Ar FROM Termek"
                 + (termekSzuro == null ? "" : " where Nev='" + termekSzuro + "'"), conn);

            // A kapcsolat megnyitása
            conn.Open();

            // A második formátum paraméter az mondja meg, hány karaktert foglaljon el az adott mező
            Console.WriteLine($"{"TermekID",8}{"Nev",15}{"Ar",15}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Az adatok lekérdezése és kiiratása
            reader = command.ExecuteReader();

            while (reader.Read())
                Console.WriteLine($"{reader["TermekID"].ToString(),8}" +
                    $"{reader["Nev"].ToString(),15}" +
                    $"{reader["Ar"].ToString(),15}");

        }
        catch (Exception ex)
        {
            // Kivétel szövegének kiiratása
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (reader != null) reader.Close();
            if (conn != null) conn.Close();
        }
    }


    private static void TermekBeszuras(int termkekId, string nev, double ar)
    {
        SqlConnection conn = null;

        try
        {
            // Kapcsolódás azadatbázishoz
            conn = new SqlConnection("Data Source=.\\MSSQ2019;Initial Catalog=SzoftechDB;Integrated Security=True;TrustServerCertificate=true");

            // A kapcsolat megnyitása
            conn.Open();

            //Paraméterek SQL-INJECTION!!!
            SqlParameter pTermekId = new SqlParameter("@TermekId", termkekId);
            SqlParameter pNev = new SqlParameter("@Nev", nev);
            SqlParameter pAr = new SqlParameter("@Ar", ar);
            // Az adatbázis parancs létrehozása
            SqlCommand command = new SqlCommand("INSERT INTO Termek(TermekId, Nev, Ar) VALUES(@TermekId, @Nev, @Ar)");

            command.Parameters.Add(pTermekId);
            command.Parameters.Add(pNev);
            command.Parameters.Add(pAr);

            // Adatbázis kapcsolat megadása
            command.Connection = conn;

            // Visszatérési érték
            int res = command.ExecuteNonQuery();

        }
        finally
        {
            if (conn != null) conn.Close();
        }
    }
}