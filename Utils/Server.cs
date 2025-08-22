using Microsoft.Win32;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Conta_Certa.DTOs;
using Conta_Certa.Models;

namespace Conta_Certa.Utils;

public class Server
{
    private static readonly string ExtensionID = "ahelgipfokmhnfmgjfockapnfedenbod";

    private static int GetFreePort()
    {
        int port;

        TcpListener listener = new(IPAddress.Loopback, 0);
        listener.Start();

        port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();

        return port;
    }

    private static void StartServer(string json, int port)
    {
        HttpListener listener = new();
        listener.Prefixes.Add($"http://localhost:{port}/");
        listener.Start();

        var context = listener.GetContext();
        var res = context.Response;

        byte[] buffer = Encoding.UTF8.GetBytes(json);

        res.AddHeader("Access-Control-Allow-Origin", "*");
        res.AddHeader("Access-Control-Allow-Headers", "Content-Type");
        res.AddHeader("Access-Control-Allow-Methods", "GET");

        res.ContentType = "application/json";
        res.ContentEncoding = Encoding.UTF8;
        res.ContentLength64 = buffer.Length;

        // Escreve o body
        res.OutputStream.Write(buffer, 0, buffer.Length);
        res.Close();

        listener.Close();
    }

    public static void ConnectExtension(Cobranca[] cobrancas)
    {
        CobrancaWhatsappDTO[] dtos = [.. cobrancas.Select(c => new CobrancaWhatsappDTO(c))];
        string json = JsonSerializer.Serialize(dtos);

        try
        {
            // Coleta uma porta livre do sistema
            int port = GetFreePort();

            // Encontra o caminho do google chrome
            string? chromePath = (string?)Registry.GetValue(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe",
                "",
                null);

            if (chromePath != null)
            {
                Task.Run(() => StartServer(json, port));

                // Inicia o chrome
                Process.Start(chromePath,
                    $"--profile-directory=Default chrome-extension://{ExtensionID}/service/loader.html?port={port}");
            }
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show(
                "Não foi possível se comunicar com a extensão do Conta Certa.\nVerifique se a extensão está instalada e se o navegador Chrome está aberto e tente novamente!",
                "Erro de comunicação!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
