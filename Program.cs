using System.Diagnostics;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> addressList = new List<Address>();
            List<Exception> exceptions = new List<Exception>();
            int counter = 0;
            try
            {
                StreamReader sr = File.OpenText("addresses.csv");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {

                    string[] line = sr.ReadLine().Split(",");
                    counter++;
                    try
                    {
                        if (line.Length > 6)
                        {
                            throw new Exception("sono stati inseriti troppi campi!");
                        }
                        else if (line.Length < 6)
                        {
                            throw new Exception("sono stati inseriti troppi pochi campi!");
                        }
                        else
                        {
                            foreach (string s in line)
                                if (s == String.Empty)
                                    throw new Exception("ci sono dei campi vuoti!");
                            addressList.Add(new Address(line[0], line[1], line[2], line[3], line[4], line[5]));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"A riga {counter} {ex.Message}");
                    }
                }
                sr.Close();
                foreach (Address address in addressList)
                {
                    address.Print();
                }
            }
            catch
            {
                Console.WriteLine("File non trovato!");
            }
        }
    }
}