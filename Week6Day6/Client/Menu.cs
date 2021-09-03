using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day6.Core.Models;
using Week6Day6.EF.Repositories;
using Week6Day6.ADO.Repositories;

namespace Week6Day6.Client
{
    class Menu
    {
        private static MainBL mainBL = new MainBL(new CustomerRepository(), new PolicyRepository());

       //Sono state implementate le prime due opzioni del menù con ADO
       // private static MainBL mainBL = new MainBL(new ADOCustomerRepository(), new ADOPolicyRepository());
        
        internal static void Start()
        {
            Console.WriteLine("Benvenuto!");

            char choice;

            do
            {
                Console.WriteLine("Premi 1 per inserire un nuovo cliente.");
                Console.WriteLine("Premi 2 per inserire una polizza per un cliente già esistente.");
                Console.WriteLine("Premi 3 per visualizzare le polizze di un cliente.");
                Console.WriteLine("Premi 4 per posticipare la data di scadenza.");
                Console.WriteLine("Premi 5 per visualizzare tutti i clienti che hanno una polizza vita.");
                Console.WriteLine("Premi Q per uscire");

                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        //Inserisci un nuovo cliente
                        Console.WriteLine();
                        AddNewCustomer();
                        Console.WriteLine();
                        break;
                    case '2':
                        //Inserisci una polizza per un cliente esistente
                        Console.WriteLine();
                        AddPolicyToExistingCustomer();
                        Console.WriteLine();
                        break;
                    case '3':
                        //Visualizza le polizze di un cliente
                        Console.WriteLine();
                        ShowCustomerPolicy();
                        Console.WriteLine();
                        break;
                    case '4':
                        //Posticipa la data di scadenza
                        Console.WriteLine();
                        PostponeExpirationDate();
                        Console.WriteLine();
                        break;
                    case '5':
                        //Visualizza i clienti che hanno una polizza vita
                        Console.WriteLine();
                        ShowCustomerByLifePolicy();
                        Console.WriteLine();
                        break;
                    case 'Q':
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile");
                        break;
                }
            }
            while (!(choice == 'Q'));
        }

        private static void ShowCustomerByLifePolicy()
        {
           var customers = mainBL.FetchCustomerByLifePolicy();
           if(customers.Count != 0) { 
                foreach (var c in customers)
                {
                Console.WriteLine($"Codice fiscale: { c.FiscalCode} Nome: {c.FirstName } Cognome: {c.LastName } ");
                }
            }
            else
                Console.WriteLine("Non ci sono clienti con una polizza vita.");
        }

        private static void PostponeExpirationDate()
        {
            //Inserisci il codice fiscale di un cliente
            //Stampa tutte le polizze e fai scegliere una polizza
            //Cambia la data di scadenza con una successiva a quella già esistente
            Console.WriteLine("Di quale cliente vuoi modificare la data di scadenza delle polizze?");
            string code = InsertFiscalCode();
            Customer customer = mainBL.GetCustomerByFiscalCode(code);
            if (customer != null)
            {
                var customerPolicies = mainBL.FetchPoliciesByCustomer(customer);              
                int i;
                int choice;
                do
                {
                    i = 1;
                    foreach (var p in customerPolicies)
                    {
                        Console.WriteLine($"Digita {i} per selezionare la seguente polizza:");
                        Console.WriteLine($"Numero della polizza: {p.PolicyNumber} Data di scadenza: {p.ExpirationDate} Rata mensile: { p.MonthlyPayment} " +
                          $"Tipo: { p.Type} Codice fiscale cliente: {p.Customer.FiscalCode}");
                        i++;
                    }
                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > (i-1));

                Policy chosenPolicy = customerPolicies.ElementAt(choice - 1);
                Console.WriteLine("La polizza scelta è:");
                Console.WriteLine($"Numero della polizza: {chosenPolicy.PolicyNumber} Data di scadenza: {chosenPolicy.ExpirationDate} Rata mensile: { chosenPolicy.MonthlyPayment} " +
                     $"Tipo: { chosenPolicy.Type} Codice fiscale cliente: {chosenPolicy.Customer.FiscalCode}");

                Console.WriteLine("Inserisci la nuova data di scadenza successiva a quella esistente.");
                chosenPolicy.ExpirationDate = InsertNewExpirationDate(chosenPolicy);
               bool isUpdate= mainBL.UpdatePolicy(chosenPolicy);              
                if (isUpdate)
                    Console.WriteLine("Modifica avvenuta con successo");
                else
                    Console.WriteLine("Qualcosa è andato storto");
            }
            else
                Console.WriteLine("Il codice fiscale inserito non corrisponde a nessun cliente.");          
        }

        private static DateTime InsertNewExpirationDate(Policy policy)
        {
            Console.WriteLine($"Inserisci una data di scadenza successiva a {policy.ExpirationDate}.");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date) || date < policy.ExpirationDate)
            {
                Console.WriteLine("Inserisci una data valida.");
            }
            return date;
        }

        private static void ShowCustomerPolicy()
        {
            Console.WriteLine("Di quale cliente vuoi visualizzare le polizze?");
            string code = InsertFiscalCode();
            Customer customer = mainBL.GetCustomerByFiscalCode(code);
            if (customer != null)
            {
                var customerPolicies = mainBL.FetchPoliciesByCustomer(customer);

                foreach (var p in customerPolicies)
                {
                    Console.WriteLine($"Numero della polizza: {p.PolicyNumber} Data di scadenza: {p.ExpirationDate} Rata mensile: { p.MonthlyPayment} " +
                      $"Tipo: { p.Type} Codice fiscale cliente: {p.Customer.FiscalCode}");
                }
            }
            else
                Console.WriteLine("Il codice fiscale inserito non corrisponde a nessun cliente.");
        }

        private static void AddPolicyToExistingCustomer()
        {
            Console.WriteLine("Inserisci una polizza per un cliente presente nel database.");
            string code = InsertFiscalCode();
            Customer customer = mainBL.GetCustomerByFiscalCode(code);
            if (customer != null)
            {
                Policy newPolicy = new Policy
                {
                    PolicyNumber = InserPolicyNumber(),
                    ExpirationDate = InsertExpirationDate(),
                    MonthlyPayment = InsertMonthlyPayment(),
                    Type = InsertType(),
                    CustomerId = customer.Id,
                };

                bool isAdded = mainBL.AddPolicy(newPolicy);
                if (isAdded)
                    Console.WriteLine("Polizza aggiunta con successo");
                else
                    Console.WriteLine("Qualcosa è andato storto");
            }
            else Console.WriteLine("Il codice fiscale inserito non corrisponde a nessun cliente.");
            
        }

        private static decimal InsertMonthlyPayment()
        {
            Console.WriteLine("Inserisci il valore della rata mensile.");
            decimal monthlyPayment;
            while (!decimal.TryParse(Console.ReadLine(), out monthlyPayment) || monthlyPayment <= 0)
            {
                Console.WriteLine("Errore. Devi inserire un numero > 0.");
            }
            return monthlyPayment;
        }

        private static DateTime InsertExpirationDate()
        {
            Console.WriteLine("Inserisci una data di scadenza successiva ad oggi.");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date) || date < DateTime.Today)
            {
                Console.WriteLine("Inserisci una data valida.");
            }
            return date;
        }

        private static TypePolicy InsertType()
        {
            int type = 0;
            do
            {
                Console.WriteLine("Inserisci il tipo di polizza.");
                foreach (var typePol in Enum.GetValues(typeof(TypePolicy)))
                {
                    Console.WriteLine($"Premi {(int)typePol} per {(TypePolicy)typePol}");
                }

            } while (!int.TryParse(Console.ReadLine(), out type) || type < 0 || type > 2);
            return (TypePolicy)type;
        }

        private static int InserPolicyNumber()
        {
            Console.WriteLine("Inserisci il numero della polizza.");
            int policyNumber;
            while (!int.TryParse(Console.ReadLine(), out policyNumber) || policyNumber < 1 )
            {
                Console.WriteLine("Errore. Devi inserire un numero > 0.");
            }
            return policyNumber;
        }

        private static void AddNewCustomer()
        {
            string fiscalCode, firstName, lastName;

            fiscalCode = InsertFiscalCode();
            //Controllo se esiste quel cliente
            Customer existingCustomer = mainBL.GetCustomerByFiscalCode(fiscalCode);
            if (existingCustomer == null)
            {
                firstName = InsertFirstName();
                lastName = InsertLastName();

                Customer newCustomer = new Customer
                {
                    FiscalCode = fiscalCode,
                    FirstName = firstName,
                    LastName = lastName,
                };


                bool isAdded = mainBL.AddCustomer(newCustomer);
                if (isAdded)
                    Console.WriteLine("Cliente aggiunto con successo");
                else
                    Console.WriteLine("Qualcosa è andato storto");
            }
            else
                Console.WriteLine("Cliente già presente nel database.");
        }

        private static string InsertFirstName()
        {
            Console.WriteLine($"Inserisci il nome del cliente.");
            string firstName = Console.ReadLine();
            while (firstName.Length == 0 || firstName.Length > 30) 
            {
                Console.WriteLine("Errore. Devi inserire una stringa con al massimo 30 caratteri.");
                firstName = Console.ReadLine();
            }
            return firstName;
        }

        private static string InsertLastName()
        {
            Console.WriteLine($"Inserisci il cognome del cliente.");
            string lastName = Console.ReadLine();
            while (lastName.Length == 0 || lastName.Length > 20)
            {
                Console.WriteLine("Errore. Devi inserire una stringa con al massimo 20 caratteri.");
                lastName = Console.ReadLine();
            }
            return lastName;
        }

        private static string InsertFiscalCode()
        {
            Console.WriteLine("Inserisci il codice fiscale.");
            string fiscalCode = Console.ReadLine();
            while (fiscalCode.Length == 0 || fiscalCode.Length != 16) 
            {
                Console.WriteLine("Errore. Devi inserire una stringa di 16 caratteri.");
                fiscalCode = Console.ReadLine();
            }
            return fiscalCode;
        }
    }
}

