using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.Utils;
using System.Data.SQLite;
using System.Diagnostics;

namespace Conta_Certa.DAOs;

public static class CobrancaDAO
{
    public static List<long?> InsertCobrancas(params CobrancaCadDTO[] dtos)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO Cobrancas 
                                (documentoCliente, honorario, status, vencimento, pagoEm)
                           VALUES (@documentoCliente, @honorario, @status, @vencimento, @pagoEm) 
                           ON CONFLICT (documentoCliente, vencimento) DO UPDATE SET 
                                honorario = excluded.honorario, 
                                status = excluded.status,
                                pagoEm = excluded.pagoEm
                           RETURNING idCobranca;";

            using var cmd = new SQLiteCommand(sql, conn, transaction);
            List<long?> ids = [];

            foreach (var dto in dtos)
            {
                if (dto.IsFull())
                {
                    var vencimento = dto.Vencimento?.ToString("yyyy-MM-dd");
                    var pagoEm = dto.PagoEm?.ToString("yyyy-MM-dd");

                    cmd.Parameters.AddWithValue("@documentoCliente", dto.DocumentoCliente);
                    cmd.Parameters.AddWithValue("@honorario", dto.Honorario);
                    cmd.Parameters.AddWithValue("@status", dto.Status.ToString());
                    cmd.Parameters.AddWithValue("@vencimento", vencimento);
                    cmd.Parameters.AddWithValue("@pagoEm", pagoEm);

                    long idCobranca = (long)cmd.ExecuteScalar();
                    ids.Add(idCobranca);

                    cmd.Parameters.Clear();
                }

                else
                {
                    ids.Add(null);
                }
            }

            transaction.Commit();
            conn.Close();

            return ids;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return [];
        }
    }

    public static void UpdateCobranca(long idCobranca, CobrancaCadDTO cobrancaDTO)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"UPDATE Cobrancas 
                           SET honorario = @honorario, status = @status, 
                               vencimento = @vencimento, pagoEm = @pagoEm, 
                               documentoCliente = @documentoCliente
                           WHERE idCobranca = @idCobranca;";

            var vencimento = cobrancaDTO.Vencimento?.ToString("yyyy-MM-dd");
            var pagoEm = cobrancaDTO.PagoEm?.ToString("yyyy-MM-dd");

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("documentoCliente", cobrancaDTO.DocumentoCliente);
            cmd.Parameters.AddWithValue("@honorario", cobrancaDTO.Honorario);
            cmd.Parameters.AddWithValue("@status", cobrancaDTO.Status.ToString());
            cmd.Parameters.AddWithValue("@vencimento", vencimento);
            cmd.Parameters.AddWithValue("@pagoEm", pagoEm);
            cmd.Parameters.AddWithValue("@idCobranca", idCobranca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void DeleteCobranca(Cobranca cobranca)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"DELETE FROM Cobrancas WHERE idCobranca = @idCobranca;";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idCobranca", cobranca.IdCobranca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static List<Cobranca> GetAllCobrancas()
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT
                                co.idCobranca, 
                                co.documentoCliente, 
                                co.honorario, 
                                co.status, 
                                co.vencimento, 
                                co.pagoEm, 
                                cli.nome,
                                cli.telefone, 
                                sc.idServicoCobranca, 
                                sc.idServico, 
                                sc.valor, 
                                sc.quantidade, 
                                s.nome 
                           FROM Cobrancas AS co 
                           LEFT JOIN Clientes cli ON cli.documento = co.documentoCliente 
                           LEFT JOIN ServicosCobranca sc ON sc.idCobranca = co.idCobranca 
                           LEFT JOIN Servicos s ON s.idServico = sc.idServico;";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            List<Cobranca> cobrancas = [];

            while (reader.Read())
            {
                long idCobranca = reader.GetInt64(0);
                var cobranca = cobrancas.FirstOrDefault(c => c.IdCobranca == idCobranca);

                // Verifica se a cobrança ja foi adicionada à lista
                if (cobranca == null)
                {
                    cobranca = new(
                        idCobranca, 
                        cliente: new(
                            reader.GetString(1), 
                            reader.GetString(6),
                            reader.GetString(7)), 
                        honorario: reader.GetFloat(2), 
                        status: Enum.Parse<CobrancaStatus>(reader.GetString(3)), 
                        vencimento: DateTime.Parse(reader.GetString(4)),
                        pagoEm: reader.IsDBNull(5)
                            ? null
                            : DateTime.Parse(reader.GetString(5)));

                    cobrancas.Add(cobranca);
                }

                // Verifica os serviços extras
                if (!reader.IsDBNull(8))
                {
                    cobranca.ServicosCobranca.Add(new(
                        idServicoCobranca: reader.GetInt64(8), 
                        idCobranca,
                        servico: new(
                            reader.GetInt64(9),
                            reader.GetString(12),
                            reader.GetFloat(10)), 
                        quantidade: reader.GetInt32(11)));
                }
            }

            return cobrancas;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return [];
        }
    }

    public static List<Cobranca> GetCobrancasByStatus(CobrancaStatus status)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT
                                co.idCobranca, 
                                co.documentoCliente, 
                                co.honorario, 
                                co.vencimento, 
                                co.pagoEm, 
                                cli.nome, 
                                cli.telefone, 
                                sc.idServicoCobranca, 
                                sc.idServico, 
                                sc.valor, 
                                sc.quantidade, 
                                s.nome 
                           FROM Cobrancas AS co 
                           LEFT JOIN Clientes cli ON cli.documento = co.documentoCliente 
                           LEFT JOIN ServicosCobranca sc ON sc.idCobranca = co.idCobranca 
                           LEFT JOIN Servicos s ON s.idServico = sc.idServico 
                           WHERE co.status = @status;";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@status", status.ToString());

            using var reader = cmd.ExecuteReader();

            List<Cobranca> cobrancas = [];

            while (reader.Read())
            {
                long idCobranca = reader.GetInt64(0);
                var cobranca = cobrancas.FirstOrDefault(c => c.IdCobranca == idCobranca);

                // Verifica se a cobrança ja foi adicionada à lista
                if (cobranca == null)
                {   
                    cobranca = new(
                        idCobranca,
                        cliente: new(
                            reader.GetString(1), 
                            reader.GetString(5),
                            reader.GetString(6)),
                        honorario: reader.GetFloat(2),
                        status,
                        vencimento: DateTime.Parse(reader.GetString(3)),
                        pagoEm: reader.IsDBNull(4) 
                            ? null
                            : DateTime.Parse(reader.GetString(4)));

                    cobrancas.Add(cobranca);
                }

                // Verifica a presença de serviços extras
                if (!reader.IsDBNull(7))
                {
                    cobranca.ServicosCobranca.Add(new(
                        idServicoCobranca: reader.GetInt64(7), 
                        idCobranca, 
                        servico: new(
                            reader.GetInt64(8), 
                            reader.GetString(11), 
                            reader.GetFloat(9)), 
                        quantidade: reader.GetInt32(10)));
                }
            }


            return cobrancas;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return [];
        }
    }

    public static List<Cobranca> GetCobrancasDoMes()
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT
                                co.idCobranca, 
                                co.documentoCliente, 
                                co.honorario, 
                                co.status, 
                                co.vencimento AS vencimento, 
                                co.pagoEm, 
                                cli.nome,
                                cli.telefone, 
                                sc.idServicoCobranca, 
                                sc.idServico, 
                                sc.valor, 
                                sc.quantidade, 
                                s.nome 
                           FROM Cobrancas AS co 
                           LEFT JOIN Clientes cli ON cli.documento = co.documentoCliente 
                           LEFT JOIN ServicosCobranca sc ON sc.idCobranca = co.idCobranca 
                           LEFT JOIN Servicos s ON s.idServico = sc.idServico 
                           WHERE strftime('%m', co.vencimento) = strftime('%m', 'now')
                           AND strftime('%Y', co.vencimento) = strftime('%Y', 'now');";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            List<Cobranca> cobrancas = [];

            while (reader.Read())
            {
                long idCobranca = reader.GetInt64(0);
                var cobranca = cobrancas.FirstOrDefault(c => c.IdCobranca == idCobranca);

                // Verifica se a cobrança ja foi adicionada à lista
                if (cobranca == null)
                {
                    cobranca = new(
                        idCobranca,
                        cliente: new(
                            reader.GetString(1),
                            reader.GetString(6),
                            reader.GetString(7)),
                        honorario: reader.GetFloat(2),
                        status: Enum.Parse<CobrancaStatus>(reader.GetString(3)),
                        vencimento: DateTime.Parse(reader.GetString(4)),
                        pagoEm: reader.IsDBNull(5)
                            ? null
                            : DateTime.Parse(reader.GetString(5)));

                    cobrancas.Add(cobranca);
                }

                // Verifica os serviços extras
                if (!reader.IsDBNull(8))
                {
                    cobranca.ServicosCobranca.Add(new(
                        idServicoCobranca: reader.GetInt64(8),
                        idCobranca,
                        servico: new(
                            reader.GetInt64(9),
                            reader.GetString(12),
                            reader.GetFloat(10)),
                        quantidade: reader.GetInt32(11)));
                }
            }

            return cobrancas;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return [];
        }
    }

    public static List<CobrancaRelatoryDTO> GetRelatory(CobrancaStatus status)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT
                                co.idCobranca, 
                                co.honorario, 
                                co.vencimento, 
                                co.pagoEm, 
                                cli.nome, 
                                sc.valor, 
                                sc.quantidade 
                           FROM Cobrancas AS co 
                           LEFT JOIN Clientes cli ON cli.documento = co.documentoCliente 
                           LEFT JOIN ServicosCobranca sc ON sc.idCobranca = co.idCobranca 
                           LEFT JOIN Servicos s ON s.idServico = sc.idServico 
                           WHERE co.status = @status;";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@status", status.ToString());

            using var reader = cmd.ExecuteReader();

            List<CobrancaRelatoryDTO> cobrancas = [];

            while (reader.Read())
            {
                long idCobranca = reader.GetInt64(0);
                var cobranca = cobrancas.FirstOrDefault(c => c.IdCobranca == idCobranca);

                // Verifica se a cobrança ja foi adicionada à lista
                if (cobranca == null)
                {
                    cobranca = new(
                        idCobranca,
                        reader.GetString(4),
                        reader.GetFloat(1),
                        status,
                        DateTime.Parse(reader.GetString(2)),
                        reader.IsDBNull(3) 
                            ? null
                            : reader.GetDateTime(3));

                    cobrancas.Add(cobranca);
                }

                // Verifica a presença de serviços extras
                if (!reader.IsDBNull(5))
                {
                    cobranca.HonorarioTotal +=
                        reader.GetFloat(5) * reader.GetInt32(6);
                }
            }

            // Adiciona o valor total ao final do relatorio
            float valorTotal = cobrancas.Sum(c => c.HonorarioTotal);
            cobrancas.Add(new(-1, "Total: ", valorTotal, status, null, null));

            return cobrancas;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return [];
        }
    }
}
