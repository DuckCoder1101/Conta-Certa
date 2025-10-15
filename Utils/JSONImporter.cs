using System.Diagnostics;
using System.Text.Json;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Utils;

public static class JSONImporter
{
    private static readonly JsonSerializerOptions _jsonOptions = new();

    private static void ImportClientes(AppDBContext dbContext, ICollection<ClienteJSONDTO> clientes)
    {
        foreach (var dto in clientes)
        {
            var clienteExistente = dbContext.Clientes
                .FirstOrDefault(c => c.Documento == dto.Documento);

            if (clienteExistente != null)
            {
                clienteExistente.Telefone = dto.Telefone;
                clienteExistente.Email = dto.Email;
                clienteExistente.VencimentoHonorario = dto.VencimentoHonorario;
                clienteExistente.Honorario = dto.Honorario;

                dbContext.Update(clienteExistente);
            }

            else
            {
                Cliente cliente = new(dto);
                dbContext.Add(cliente);
            }
        }

        dbContext.SaveChanges();
    }

    private static void ImportCobrancas(AppDBContext dbContext, ICollection<CobrancaJSONDTO> cobrancas)
    {
        foreach (var dto in cobrancas)
        {
            var cobrancaExistente = dbContext.Cobrancas
                .Include(c => c.ServicosCobranca)
                .FirstOrDefault(c => 
                    c.DocumentoCliente == dto.DocumentoCliente &&
                    (
                        c.Vencimento.Month == dto.Vencimento.Month && 
                        c.Vencimento.Year == dto.Vencimento.Year
                    )
                );

            if (cobrancaExistente != null)
            {
                cobrancaExistente.Honorario = dto.Honorario;
                cobrancaExistente.Status = dto.Status;
                cobrancaExistente.PagoEm = dto.PagoEm;

                dbContext.ServicosCobranca.RemoveRange(cobrancaExistente.ServicosCobranca);
                cobrancaExistente.ServicosCobranca = [.. dto.ServicosCobranca.Select(dto => new ServicoCobranca(dto))];

                dbContext.Update(cobrancaExistente);
            }

            else
            {
                Cobranca cobranca = new(dto);
                dbContext.Add(cobranca);
            }
        }

        dbContext.SaveChanges();
    }

    private static Dictionary<long, long> ImportServicos(AppDBContext dbContext, ICollection<ServicoJSONDTO> servicos)
    {
        var entidades = new List<Servico>();

        foreach (var dto in servicos)
        {
            var servico = dbContext.Servicos
                .FirstOrDefault(s => s.Nome == dto.Nome);

            if (servico != null)
            {
                servico.Valor = dto.Valor;
            }
            else
            {
                servico = new Servico(dto);
                dbContext.Servicos.Add(servico);
            }

            entidades.Add(servico);
        }

        dbContext.SaveChanges();

        var mappedIds = servicos.Zip(entidades, (dto, entity) => new
            {
                OldId = dto.TransitionIdServico,
                NewId = entity.IdServico
            })
            .ToDictionary(x => x.OldId, x => x.NewId);

        foreach (var id in mappedIds)
        {
            Debug.WriteLine($"{id.Key} - {id.Value}");
        }

        return mappedIds;
    }

    public static void ExportToJSON(string filePath)
    {
        try
        {
            AppData appData = new();
            string json = JsonSerializer.Serialize(appData, _jsonOptions);

            File.WriteAllText(filePath, json, System.Text.Encoding.UTF8);

            MessageBox.Show(
                "Os dados foram exportados com sucesso!",
                "Exportação concluída!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void ImportFromJson(string filePath)
    {
        try
        {
            using AppDBContext dbContext = new();

            var result = MessageBox.Show(
                        "Deseja mesmo importar os dados?\nOs registros iguais serão sobrescritos.",
                        "Importar os dados?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string json = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
                AppData? appData = JsonSerializer.Deserialize<AppData>(json);

                if (appData != null)
                {
                    ImportClientes(dbContext, appData.Clientes);

                    // Mapeia os IDs dos servicos
                    var mappedIds = ImportServicos(dbContext, appData.Servicos);
                    foreach (var cobranca in appData.Cobrancas)
                    {
                        foreach (var sc in cobranca.ServicosCobranca)
                        {
                            if (mappedIds.TryGetValue(sc.TransitionIdServicoOrigem, out long newId))
                            {
                                sc.TransitionIdServicoOrigem = newId;
                            }
                        }
                    }

                    ImportCobrancas(dbContext, appData.Cobrancas);

                    MessageBox.Show(
                        "Os dados foram importados com sucesso!",
                        "Importação concluída!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show(
                        "Não foi possível traduzir os dados!",
                        "Importação falhada!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        catch (UnauthorizedAccessException)
        {
            MessageBox.Show(
                "Esse arquivo está sendo usado por outro programa.\nFeche-o e tente novamente!",
                "Arquivo em uso!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        catch (JsonException)
        {
            MessageBox.Show(
                "O arquivo lido não está no padrão esperado.\nTente novamente com outro arquivo!",
                "Arquivo ilegível!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }
}
