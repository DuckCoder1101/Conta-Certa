using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using System.Text.Json;

namespace Conta_Certa.Utils;

public static class ExportImportData
{
    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        WriteIndented = true,
    };

    public static void ExportToJSON(string filePath)
    {
        try
        {
            AppData appData = new();
            string json = JsonSerializer.Serialize(appData, jsonOptions);

            File.WriteAllText(filePath, json, System.Text.Encoding.UTF8);
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void ImportFromJson(string filePath)
    {
        //try
        //{
        //    string json = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
        //    AppData? appData = JsonSerializer.Deserialize<AppData>(json);

        //    if (appData != null)
        //    {
        //        List<CadClienteDTO> dtos = [];

        //        foreach (var cliente in appData.Clientes.OrderBy(c => c.IdCliente))
        //        {
        //            dtos.Add(new(
        //                cliente.Nome,
        //                cliente.Telefone,
        //                cliente.Email,
        //                cliente.Honorario,
        //                cliente.VencimentoHonorario));
        //        }

        //        List<long> idsClientes = ClienteDAO.InsertClientes([.. dtos]);
                
        //        foreach (var servico in appData.Servicos)
        //        {

        //        }
        //    }
        //}
    }
}
