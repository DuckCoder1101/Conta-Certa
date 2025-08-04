using System.Data.SQLite;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.Utils;

namespace Conta_Certa.DAOs;

public static class ServicoCobrancaDAO
{
    public static List<long?> InsertServicosCobranca(params ServicoCobrancaCadDTO[] servicos)
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
            List<long?> ids = [];

            foreach (var servico in servicos)
            {

                cmd.Parameters.AddWithValue("@idCobranca", servico.IdCobranca);
                cmd.Parameters.AddWithValue("@idServico", servico.IdServico);
                cmd.Parameters.AddWithValue("@valor", servico.Valor);
                cmd.Parameters.AddWithValue("@quantidade", servico.Quantidade);

                long idServicoCobranca = (long) cmd.ExecuteScalar();
                ids.Add(idServicoCobranca);

                cmd.Parameters.Clear();
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

    public static void UpdateServicoCobranca(ServicoCobranca servicoCobranca)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"UPDATE ServicosCobranca 
                           SET valor = @valor, quantidade = @quantidade 
                           WHERE idServicoCobranca = @idServicoCobranca;";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@valor", servicoCobranca.Servico.Valor);
            cmd.Parameters.AddWithValue("@quantidade", servicoCobranca.Quantidade);
            cmd.Parameters.AddWithValue("@idServicoCobranca", servicoCobranca.IdServicoCobranca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        { 
            Logger.LogException(ex); 
        }
    }

    public static void DeleteSerivocCobranca(ServicoCobranca servico)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"DELETE FROM ServicosCobranca 
                       WHERE idServicoCobranca = @idServicoCobranca";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idServicoCobranca", servico.IdServicoCobranca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }
}
