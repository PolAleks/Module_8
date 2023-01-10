using System.Runtime.Serialization.Formatters.Binary;

namespace Serializable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new Contact("Вася Пупкин", 89781234567, "vs.pupkin@ya.ru");
            Saveobject(contact);
        }
        static void Saveobject(Contact contact)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + '/';

            using (FileStream fstream = new FileStream($"{path}MyConact.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fstream, contact);
            }
        }
    }
}