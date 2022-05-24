using System.Data.SqlClient;


namespace csharp_db_connection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            string stringaDiConnessione = "Data Source=localhost;Integrated Security=True";



            using (SqlConnection conn = new SqlConnection(stringaDiConnessione))
            {
                conn.Open();

                using (SqlCommand insert = new SqlCommand(@"insert into Clienti (ID, nome, cognome, codice_cliente)
 values ( 2, 'MioNome', 'MioCognome', 464967)", conn))
                {
                    var numrows = insert.ExecuteNonQuery();

                    Console.WriteLine(numrows);
                }






                using (SqlCommand query = new SqlCommand("select * from sys.all_columns", conn))
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; ++i)
                                Console.Write("{0}, ", reader[i]);
                            Console.WriteLine();
                        }
                    }
                }



                conn.Close();
            }







        }
    }
}
