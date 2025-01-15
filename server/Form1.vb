Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Public Class Form1
    Private serverThread As Thread
    Private server As TcpListener = Nothing
    Private isRunning As Boolean = False
    Private isSent As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        serverThread = New Thread(AddressOf StartServer)
        serverThread.IsBackground = True
        serverThread.Start()
    End Sub

    Private Sub btnShutdown_Click(sender As Object, e As EventArgs) Handles btnShutdown.Click
        Call ShutdownServer()
    End Sub

    Private Sub StartServer()
        Try
            Dim port As Int32 = 13000
            Dim localAddr As IPAddress = IPAddress.Parse("127.0.0.1")

            server = New TcpListener(localAddr, port)
            server.Start()
            isRunning = True
            AppendTextToConsole("Server started on " & localAddr.ToString() & ":" & port.ToString())

            Dim bytes(1024) As Byte
            Dim data As String = Nothing

            While isRunning

                If Not isSent Then
                    AppendTextToConsole("Waiting for connection...")
                    isSent = True
                End If


                ' Check if the server is still running before accepting a client
                If server.Pending() Then
                    Try
                        Dim client As TcpClient = server.AcceptTcpClient()
                        AppendTextToConsole("Connected!")

                        data = Nothing
                        Dim stream As NetworkStream = client.GetStream()

                        Dim i As Int32
                        i = stream.Read(bytes, 0, bytes.Length)

                        While (i <> 0)
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                            AppendTextToConsole("Received: " & data)

                            data = data.ToUpper()
                            Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)

                            ' Send back a response.
                            stream.Write(msg, 0, msg.Length)
                            AppendTextToConsole("Sent: " & data)

                            i = stream.Read(bytes, 0, bytes.Length)
                        End While

                        client.Close()
                        AppendTextToConsole("Client disconnected.")
                    Catch ex As Exception
                        AppendTextToConsole("Error accepting client: " & ex.Message)
                    End Try
                End If
            End While
        Catch ex As SocketException
            AppendTextToConsole("SocketException: " & ex.Message)
        Finally
            ShutdownServer()
        End Try
    End Sub

    Private Sub ShutdownServer()
        If server Is Nothing Then
            AppendTextToConsole("The server is not running!")
            Return
        End If

        If server IsNot Nothing Then
            If isRunning Then
                serverThread.Abort() ' Abort the server thread first
                server.Stop() ' Stop the TcpListener
                isRunning = False ' Update the running state
                server = Nothing ' Set server to Nothing after stopping
                If isSent Then
                    isSent = False
                End If
                AppendTextToConsole("Server stopped.")
            End If
        End If
    End Sub

    Private Sub AppendTextToConsole(text As String)
        ' Use Invoke to update the UI from a different thread
        If console.InvokeRequired Then
            console.Invoke(New Action(Of String)(AddressOf AppendTextToConsole), text)
        Else
            console.AppendText(text & Environment.NewLine)
        End If
    End Sub
End Class
