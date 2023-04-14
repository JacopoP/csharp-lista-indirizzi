namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> addressList = new List<Address>();
            StreamReader sr = File.OpenText("addresses.csv");
            sr.ReadLine();
            int i = 0;
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(",");
                addressList.Add(new Address(line[0], line[1], line[2], line[3], line[4], line[5]));
                addressList[i].Print();
                i++;
            }
            sr.Close();
        }
    }
}