using System;
using System.IO;
using System.IO.Pipes;
using System.Text.Json;

namespace WinFormsWithNamesPipe.service
{
    public class NamedPipeServer
    {
        // 用來更新GUI的事件handler
        public delegate void MessageReceivedHandler(string message);
        public static event MessageReceivedHandler OnMessageReceived;

        // 定義要接收來自Python的資料格式
        public class RecivedResult
        {
            public required string Status { get; set; }
            public required int StatusCode { get; set; }
            public required string Message { get; set; }
            
            // data any type
            public required object Data { get; set; }
        }

        public static void StartServer()
        {
            // 利用新執行序避免阻塞UI
            Task.Factory.StartNew(() =>
            {
                while (true) // 持續監聽新的連接
                {
                    using (var pipeServer = new NamedPipeServerStream(".NetPipe", PipeDirection.InOut, -1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
                    {
                        try
                        {
                            pipeServer.WaitForConnection();
                            using (var sr = new StreamReader(pipeServer))
                            using (var sw = new StreamWriter(pipeServer))
                            {
                                string request = sr.ReadLine();

                                // 將json字串轉換成物件
                                RecivedResult recivedResultObj = JsonSerializer.Deserialize<RecivedResult>(request);

                                // 取得各個欄位的值，重新拼成字串
                                string result = "Status: " + recivedResultObj.Status + "\r\n" +
                                                "StatusCode: " + recivedResultObj.StatusCode + "\r\n" +
                                                "Message: " + recivedResultObj.Message + "\r\n\r\n" +
                                                "Data: " + recivedResultObj.Data + "\r\n";

                                OnMessageReceived?.Invoke(result);
                            }
                        }
                        catch (IOException e)
                        {
                            // 處理管道關閉或其他IO異常
                            Console.WriteLine("Pipe closed: " + e.Message);
                        }
                        finally
                        {
                            if (pipeServer.IsConnected)
                                pipeServer.Disconnect();
                        }
                    }
                    // 短暫延遲，避免CPU佔用過高
                    Thread.Sleep(100);
                }
            });
        }
    }
}
