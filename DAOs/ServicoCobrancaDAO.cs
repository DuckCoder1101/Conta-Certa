using System.Data.SQLite;
using Conta_Certa.DTOs;
using Conta_Certa.Utils;

namespace Conta_Certa.DAOs;

public static class ServicoCobrancaDAO
{
    public static void InsertServicosCobranca(params ServicoCobrancaCadDTO[] servicos)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO ServicosCobranca 
                                (idCobranca, idServico, valor, quantidade) 
                           VALUES (@idCobranca, @idServico, @valor, @quantidade)
                           ON CONFLICT (idCobranca, idServico) DO UPDATE SET 
                                valor = excluded.valor,
                                quantidade = excluded.quantidade
                           RETURNING idServicoCobranca;";

            using var cmd = new SQLiteCommand(sql, conn, transaction);
            foreach (var servico in servicos)
            {

                cmd.Parameters.AddWithValue("@idCobranca", servico.IdCobranca);
                cmd.Parameters.AddWithValue("@idServico", servico.IdServico);
                cmd.Parameters.AddWithValue("@valor", servico.Valor);
                cmd.Parameters.AddWithValue("@quantidade", servico.Quantidade);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            transaction.Commit();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void DeleteServicoCobranca(long idCobranca, long idServico)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"DELETE FROM ServicosCobranca 
                       WHERE idCobranca = @idCobranca AND idServico = @idServico";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idCobranca", idCobranca);
            cmd.Parameters.AddWithValue("@idServico", idServico);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }
}
