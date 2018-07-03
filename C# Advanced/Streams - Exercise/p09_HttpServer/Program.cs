namespace p09_HttpServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class Program
    {
        private const int Port = 8181;
        private const string HtmlFilesPath = @".\pages";

        public static void Main()
        {
            var localAddress = IPAddress.Parse("127.0.0.1");
            var server = new TcpListener(localAddress, Port);
            server.Start();
            Console.WriteLine($"Waiting for a connection on {localAddress}:{Port} ... ");

            while (true)
            {
                using (var stream = server.AcceptTcpClient().GetStream())
                {
                    var request = new byte[4096];
                    var readBytes = stream.Read(request, 0, request.Length);
                    var requestDetails = Encoding.UTF8.GetString(request, 0, readBytes);
                    Console.WriteLine(requestDetails);

                    var requestFirstLine = requestDetails.Substring(0, requestDetails.IndexOf(Environment.NewLine, StringComparison.Ordinal))
                        .Split();
                    var url = requestFirstLine[1];
                    var headerStatusLine = $"{requestFirstLine[2]} 200 OK";
                    var requestedPage = string.Empty;

                    if (url.Equals("/"))
                    {
                        requestedPage = $"{HtmlFilesPath}/index.html";
                    }
                    else
                    {
                        requestedPage = $"{HtmlFilesPath}{url.Substring(url.IndexOf('/'))}";

                        if (!requestedPage.EndsWith(".html"))
                        {
                            requestedPage += ".html";
                        }

                        if (!File.Exists(requestedPage))
                        {
                            requestedPage = $"{HtmlFilesPath}/error.html";
                        }
                        else
                        {
                            headerStatusLine = "HTTP/1.0 404 Not Found";
                        }
                    }

                    var responseHeader = new StringBuilder();
                    responseHeader.Append($"{headerStatusLine}{Environment.NewLine}");
                    responseHeader.Append($"Accept-Ranges: bytes{Environment.NewLine}");

                    var responseMessage = new StringBuilder();

                    using (var reader = new StreamReader(requestedPage))
                    {
                        var line = reader.ReadLine();
                        while (line != null)
                        {
                            responseMessage.Append(line);
                            line = reader.ReadLine();
                        }
                    }

                    if (requestedPage.EndsWith("info.html"))
                    {
                        responseMessage
                            .Replace("{0}", DateTime.Now.ToString("ddd, MMM d, yyyy"))
                            .Replace("{1}", Environment.ProcessorCount.ToString());
                    }

                    var contentLength = Encoding.UTF8.GetBytes(responseMessage.ToString()).Length;

                    responseHeader.Append($"ContentLength: {contentLength}{Environment.NewLine}");
                    responseHeader.Append($"Connection: close{Environment.NewLine}");
                    responseHeader.Append($"Content-Type: text/html{Environment.NewLine}");
                    responseHeader.Append(Environment.NewLine);

                    responseMessage.Insert(0, responseHeader);

                    var responseBytes = Encoding.UTF8.GetBytes(responseMessage.ToString());

                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
    }
}