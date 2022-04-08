// See https://aka.ms/new-console-template for more information
//Risposte test:
//1. a, b, e, g
//2. b, d
//3. c, d
using EnricaPittauWeek6;

Console.WriteLine("Gestione DB Agenti!");
RepositoriGestioneAgentiDbAdo repositoriGestioneAgentiDbAdo  = new RepositoriGestioneAgentiDbAdo(); 

bool continua = true;
while (continua)
{
    Console.WriteLine("---------------------------MENU-------------------");
    Console.WriteLine("1. Stampa tutti gli agenti");
    Console.WriteLine("2. Stampa gli agenti assegnati ad una determinata area geografica");
    Console.WriteLine("3. Stampa gli sgenti con anni di servizio maggiori o uguali ad un determinato dato di imput");
    Console.WriteLine("4. Inserire un nuovo agente se non presente");
    Console.WriteLine("\n0. Exit");

    int scelta;
    do
    {
        Console.WriteLine("scegli cosa fare!");
    } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

    switch (scelta)
    {
        case 1:
            StampaAgenti();
            break;
        case 2:
            Console.WriteLine("Inserisci l'area geografica come filtro di ricerca: ");
            string area = Console.ReadLine();
            repositoriGestioneAgentiDbAdo.GetAgenteByArea(area);
            break;
        case 3:
            //Riporta GetAgenteByAnniServizio();
            break;
        case 4:
            Console.WriteLine("Inserisci il CF: ");
            string cf = Console.ReadLine();
            Console.WriteLine("Inserisci il Nome: ");
            string n = Console.ReadLine();
            Console.WriteLine("Inserisci il Cognome: ");
            string c = Console.ReadLine();
            Console.WriteLine("Inserisci area di servizio: ");
            string areaser = Console.ReadLine();
            Console.WriteLine("Inserisci anno inizio attivita: ");
            int attiv = int.Parse(Console.ReadLine());
            repositoriGestioneAgentiDbAdo.InsertNewAgente(cf, n, c, areaser, attiv);
            //repository.InserisciFilm(t, gener, dur);
            break;       
        case 0:
            continua = false;
            Console.WriteLine("Arrivederci!");
            break;
    }
    
}
void StampaAgenti()
{
    Console.WriteLine("Gli agenti registrati sono:");
    repositoriGestioneAgentiDbAdo.GetAllAgenti();
}

