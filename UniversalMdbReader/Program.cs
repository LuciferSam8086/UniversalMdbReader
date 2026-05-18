using System.Data.OleDb;

namespace UniversalMdbReader
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Driver OleDB installati nel sistema:");
            Console.WriteLine("-------------------------------------");

            // OleDbEnumerator restituisce una DataTable con tutti i provider registrati
            OleDbEnumerator enumerator = new OleDbEnumerator();
            System.Data.DataTable table = enumerator.GetElements();

            foreach (System.Data.DataRow row in table.Rows)
            {
                // SOURCES_NAME contiene il nome del Provider (es. Microsoft.ACE.OLEDB.16.0)
                // SOURCES_DESCRIPTION contiene la descrizione testuale
                string name = row["SOURCES_NAME"].ToString();
                string description = row["SOURCES_DESCRIPTION"].ToString();

                // Filtriamo solo i veri e propri Provider (tipo = 1)
                if (row["SOURCES_TYPE"].ToString() == "1")
                {
                    Console.WriteLine($"-> Nome: {name}");
                    Console.WriteLine($"   Descrizione: {description}\n");
                }
            }
        }
    }
}

