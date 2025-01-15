Imports System.Net
Imports System.Net.Sockets
Public Class Server
    Public Shared Sub Main()
        Dim server As TcpListener
        server = Nothing
        Try
            Dim port As Int32 = 13000
            Dim localAddr As IPAddress = IPAddress.Parse("127.0.0.1")

            server = New TcpListener(localAddr, port)

            server.Start()

            Dim bytes(1024) As Byte
            Dim data As String = Nothing

            While True
                Console.WriteLine("Waiting for connectiong...")

                Dim client As TcpClient = server.AcceptTcpClient()
                Console.WriteLine("Connected!")

                data = Nothing

                Dim stream As NetworkStream = client.GetStream()

                Dim i As Int32

                i = stream.Read(bytes, 0, bytes.Length)
                While (i <> 0)
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                    Console.WriteLine("Received: {0}", data)

                    data = data.ToUpper()
                    Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)

                    ' Send back a response.
                    stream.Write(msg, 0, msg.Length)
                    Console.WriteLine("Sent: {0}", data)

                    i = stream.Read(bytes, 0, bytes.Length)
                End While

                client.Close()
            End While
        Catch e As SocketException
            Console.WriteLine("SocketException: {0}", e)
        Finally
            server.Stop()
        End Try
        Console.WriteLine(ControlChars.Cr + "Hit enter to continue....")
        Console.Read()
    End Sub
End Class
