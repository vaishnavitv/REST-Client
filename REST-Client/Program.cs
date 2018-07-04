using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Client
{

    class Program
    {

        static void Main(string[] args)
        {
            /*
            LCBOClient client = new LCBOClient();
            foreach (LCBOClient.Store store in client.GetStores())
            {
                Console.WriteLine("Store: " + store.id + " Address: " + store.address_line_1);
            }
            foreach (var item in client.GetProducts())
            {
                Console.WriteLine("Product : " + item.id + " Name : " + item.name + " Category : " + item.primary_category);
            }
            foreach (var item in client.SearchProducts(new List<string>() { "blonde", "beer" }))
            {
                Console.WriteLine("Product : " + item.id + " Name : " + item.name + " Category : " + item.primary_category);
            }
            */

            AzureFunctionsClient azureClient = new AzureFunctionsClient();
            string azureVowelOutput = azureClient.RemoveVowels("Hey Mr.Kuruvi");
            Console.WriteLine(azureVowelOutput);
            
            Console.ReadLine();
        }
    }
}
