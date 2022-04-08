using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnricaPittauWeek6
{
    internal class RepositoriGestioneAgentiDbAdo : IRepositoryGestioneAgenti
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void GetAgenteByAnniServizio(int anniServizio)
        {
            throw new NotImplementedException();
        }

        public void GetAgenteByArea(string areaGeografica)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where AreaGeografica=@area";
                command.Parameters.AddWithValue("@area", areaGeografica);
                SqlDataReader reader = command.ExecuteReader();
                //continua a cercare sintanto che trovo campi valorizzati:
                while (reader.Read())
                {
                    var cf = reader["Cf"]; //risultato[0]
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    //var areaGeografica = reader["AreaGeografica"];
                    var annoInizioAttivita = reader["AnnoDiInizioAttivita"];
                    Agente ag = new Agente();
                    ag.CodiceFiscaleDellAgente = (string)cf;
                    ag.Nome = (string)nome;
                    ag.Cognome = (string)cognome;
                    ag.AreaGeografica = (string)areaGeografica;
                    ag.AnnoDiInizioAttivita = (int)annoInizioAttivita;
                    Console.WriteLine(ag.ToString());
                }
                connection.Close();
            }
        }

        public void GetAllAgenti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var cf = reader["Cf"]; //risultato[0]
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var areaGeografica = reader["AreaGeografica"];
                    var annoInizioAttivita = reader["AnnoDiInizioAttivita"];
                    Agente ag = new Agente();
                    ag.CodiceFiscaleDellAgente = (string)cf;
                    ag.Nome = (string)nome;
                    ag.Cognome = (string)cognome;
                    ag.AreaGeografica = (string)areaGeografica;
                    ag.AnnoDiInizioAttivita = (int)annoInizioAttivita;
                    Console.WriteLine(ag.ToString());
                }
                connection.Close();
            }
        }      
        public void InsertNewAgente(string codiceFiscaleDellAgente, string nome, string cognome, string areaGeografica, int annoDiInizioAttivita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Agente values(@CodiceFiscaleDellAgente, @Nome, @Cognome, @AreaGeografica, @AnnoDiInizioAttivita)";
                command.Parameters.AddWithValue("@CodiceFiscaleDellAgente", codiceFiscaleDellAgente);
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Cognome", cognome);
                command.Parameters.AddWithValue("@AreaGeografica", areaGeografica);
                command.Parameters.AddWithValue("@AnnoDiInizioAttivita", annoDiInizioAttivita);
                

                int rigaInserita = command.ExecuteNonQuery();

                if (rigaInserita == 1)
                {
                    Console.WriteLine("Agente inserito correttamente");
                }
                else
                {
                    Console.WriteLine("Errore. Non è stato possibile inserire l'agente.");
                }
                connection.Close();
            }
        }
    }
}
