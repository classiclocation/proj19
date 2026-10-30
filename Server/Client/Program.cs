using System.Net.Sockets;
using System.Text;

const string serverIp = "127.0.0.1";
const int port = 5000;

Console.WriteLine("1 - date");
Console.WriteLine("2 - time");
Console.Write("Choose a request: ");

string? choice = Console.ReadLine();
string request;

if (choice == "1")
{
    request = "DATE";
}
else if (choice == "2")
{
    request = "TIME";
}
else
{
    Console.WriteLine("Enter 1 or 2");
    return;
}

TcpClient client = new TcpClient(serverIp, port);
NetworkStream stream = client.GetStream();
StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
StreamReader reader = new StreamReader(stream, Encoding.UTF8);
writer.AutoFlush = true;

writer.WriteLine(request);
string? answer = reader.ReadLine();

Console.WriteLine("Server response: " + answer);

writer.Close();
reader.Close();
stream.Close();
client.Close();
