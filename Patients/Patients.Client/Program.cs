using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Patients.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("If you want add new patient press 1. If you want check all patients click 2");
            string choose = Console.ReadLine();

            if (choose.Equals("1"))
            {
                Console.WriteLine("Please enter first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Please enter last name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Please enter age:");
                string age = Console.ReadLine();

                Patient patient = new Patient()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = int.Parse(age),
                    TestPositiveDate = DateTime.Now.ToString("MM/dd/yyyy")
                };

                string patientJson = JsonSerializer.Serialize(patient);

                HttpResponseMessage postMessage = await client.PostAsync("https://localhost:5001/api/patients",
                    new StringContent(patientJson,
                    Encoding.UTF8,
                    "application/json"));
            }
            else
            {
                //HttpResponseMessage getMessage = await client.GetAsync("https://localhost:5001/api/patients");
                //getMessage.EnsureSuccessStatusCode();
                //await getMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Imie: Hanna, nazwisko: Kowalska, wiek: 21, data: 04-11-2020");
            }
        }

    }
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string TestPositiveDate { get; set; }
    }
}
