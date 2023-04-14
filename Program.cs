using System.Diagnostics;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> addressList = new List<Address>();
            List<LineException> exceptions = new List<LineException>();
            int counter = 1;
            try
            {
                StreamReader sr = File.OpenText("addresses.csv");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {

                    string[] line = sr.ReadLine().Split(",");
                    try
                    {
                        if (line.Length > 6)
                        {
                            throw new Exception("sono stati inseriti troppi campi");
                        }
                        else if (line.Length < 6)
                        {
                            throw new Exception("sono stati inseriti troppi pochi campi");
                        }
                        else
                        {
                            foreach (string s in line)
                                if (s == String.Empty)
                                    throw new Exception("ci sono dei campi vuoti");
                            addressList.Add(new Address(line[0], line[1], line[2], line[3], line[4], line[5]));
                        }
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(new LineException(counter, ex.Message));
                        Debug.WriteLine($"A riga {counter} {ex.Message}");
                    }
                    counter++;
                }
                sr.Close();
                Console.WriteLine("Indirizzi salvati:");
                foreach (Address address in addressList)
                {
                    address.Print();
                }
                Console.WriteLine("\nProblemi trovati:");
                foreach (LineException ex in exceptions)
                {
                    ex.Print();
                }
            }
            catch
            {
                Console.WriteLine("File non trovato!");
            }
        }
    }
}