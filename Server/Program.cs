using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 5000;
TcpListener server = new TcpListener(IPAddress.Any, port);
server.Start();

Console.WriteLine("Server started on port " + port);

while (true)
{
    TcpClient client = server.AcceptTcpClient();
    Console.WriteLine("Client connected.");

    NetworkStream stream = client.GetStream();
    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
    StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
    writer.AutoFlush = true;

    string? request = reader.ReadLine();
    string answer;

    if (request == "DATE")
    {
        answer = DateTime.Now.ToShortDateString();
    }
    else if (request == "TIME")
    {
        answer = DateTime.Now.ToLongTimeString();
    }
    else
    {
        answer = "Unknown request";
    }

    writer.WriteLine(answer);
    Console.WriteLine("Sent: " + answer);

    writer.Close();
    reader.Close();
    stream.Close();
    client.Close();
}
