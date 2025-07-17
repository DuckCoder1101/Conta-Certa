using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.Utils;
using System.Data.SQLite;

namespace Conta_Certa.DAOs;

public static class CobrancaDAO
{
    public static void InsertCobrancas(params CobrancaCadDTO[] cobrancas)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO Cobrancas 
                        (idCliente, honorario, status, vencimento, pagoEm)
                       VALUES (@idCliente, @honorario, @status, @vencimento, @pagoEm);";

            foreach (var cobranca in cobrancas)
            {
                using var cmd = new SQLiteCommand(sql, conn, transaction);

                cmd.Parameters.AddWithValue("@idCliente", cobranca.IdCliente);
                cmd.Parameters.AddWithValue("@honorario", cobranca.Honorario);
                cmd.Parameters.AddWithValue("@status", cobranca.Status.ToString());

                cmd.Parameters.AddWithValue("@vencimento", cobranca.Vencimento.ToString("dd/MM/yyyy"));

                cmd.Parameters.AddWithValue("@pagoEm",
                    cobranca.PagoEm.HasValue
                        ? cobranca.PagoEm.Value.ToString("dd/MM/yyyy")
                        : DBNull.Value);

                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void UpdateCobranca(Cobranca cobranca)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"UPDATE Cobrancas 
                           SET honorario = @honorario, status = @status, 
                               vencimento = @vencimento, pagoEm = @pagoEm  
                           WHERE idCobranca = @idCobranca;";

            string vencimento = cobranca.Vencimento.ToString("dd/MM/yyyy");

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@honorario", cobranca.Honorario);
            cmd.Parameters.AddWithValue("@status", cobranca.Status.ToString());
            cmd.Parameters.AddWithValue("@vencimento",
                cobranca.Vencimento.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@pagoEm",
                cobranca.PagoEm?.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@idCobranca", cobranca.IdCobranca);

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

    public static List<Cobranca> SelectAllCobrancas()
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT
                                co.idCobranca, 
                                co.idCliente, 
                                co.honorario, 
                                co.status, 
                                co.vencimento, 
                                co.pagoEm, 
                                cli.nome, 
                                sc.idServicoCobranca, 
                                sc.idServico, 
                                sc.valor, 
                                sc.quantidade, 
                                s.nome 
                           FROM Cobrancas AS co 
                           LEFT JOIN Clientes cli ON cli.idCliente = co.idCliente 
                           LEFT JOIN ServicosCobranca sc ON sc.idCobranca = co.idCobranca 
                           LEFT JOIN Servicos s ON s.idServico = sc.idServico;";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            List<Cobranca> cobrancas = [];

            while (reader.Read())
            {
                int idCobranca = reader.GetInt32(0);
                var cobranca = cobrancas.FirstOrDefault(c => c.IdCobranca == idCobranca);

                // Verifica se a cobrança ja foi adicionada à lista
                if (cobranca == null)
                {
                    cobranca = new(
                        idCobranca, 
                        cliente: new(
                            reader.GetInt32(1), 
                            reader.GetString(6)), 
                        honorario: reader.GetFloat(2), 
                        status: Enum.Parse<CobrancaStatus>(reader.GetString(3)), 
                        vencimento: DateTime.Parse(reader.GetString(4)),
                        pagoEm: reader.IsDBNull(4)
                            ? null
                            : DateTime.Parse(reader.GetString(5)));

                    cobrancas.Add(cobranca);
                }

                // Verifica a prenseça de serviços extras
                if (!reader.IsDBNull(7))
                {
                    cobranca.Servicos.Add(new(
                        idServicoCobranca: reader.GetInt32(7), 
                        idCobranca,
                        servico: new(
                            reader.GetInt32(8),
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

    public static List<Cobranca> SelectCobrancasByStatus(CobrancaStatus status)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT
                                co.idCobranca, 
                                co.idCliente, 
                                co.honorario, 
                                co.vencimento, 
                                co.pagoEm, 
                                cli.nome, 
                                sc.idServicoCobranca, 
                                sc.idServico, 
                                sc.valor, 
                                sc.quantidade, 
                                s.nome 
                           FROM Cobrancas AS co 
                           LEFT JOIN Clientes cli ON cli.idCliente = co.idCliente 
                           LEFT JOIN ServicosCobranca sc ON sc.idCobranca = co.idCobranca 
                           LEFT JOIN Servicos s ON s.idServico = sc.idServico;";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@status", status.ToString());

            using var reader = cmd.ExecuteReader();

            List<Cobranca> cobrancas = [];

            while (reader.Read())
            {
                int idCobranca = reader.GetInt32(0);
                var cobranca = cobrancas.FirstOrDefault(c => c.IdCobranca == idCobranca);

                // Verifica se a cobrança ja foi adicionada à lista
                if (cobranca == null)
                {   
                    cobranca = new(
                        idCobranca,
                        cliente: new(reader.GetInt32(1), reader.GetString(5)),
                        honorario: reader.GetFloat(2),
                        status,
                        vencimento: DateTime.Parse(reader.GetString(3)),
                        pagoEm: reader.IsDBNull(4) 
                            ? null
                            : DateTime.Parse(reader.GetString(4)));

                    cobrancas.Add(cobranca);
                }

                // Verifica a presença de serviços extras
                if (!reader.IsDBNull(6))
                {
                    cobranca.Servicos.Add(new(
                        idServicoCobranca: reader.GetInt32(6), 
                        idCobranca, 
                        servico: new(
                            reader.GetInt32(7), 
                            reader.GetString(10), 
                            reader.GetFloat(8)), 
                        quantidade: reader.GetInt32(9)));
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
}
