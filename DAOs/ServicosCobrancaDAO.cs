using System.Data.SQLite;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.Utils;

namespace Conta_Certa.DAOs;

public static class ServicosCobrancaDAO
{
    public static List<long> InsertServicosCobranca(params ServicoCobrancaCadDTO[] servicos)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO ServicosCobranca 
                            (idCobranca, nome, valor, quantidade) 
                           VALUES (@idCobranca, @nome, @valor, @quantidade);";

            List<long> ids = [];

            foreach (var servico in servicos)
            {
                using var cmd = new SQLiteCommand(sql, conn, transaction);

                cmd.Parameters.AddWithValue("@idCobranca", servico.IdCobranca);
                cmd.Parameters.AddWithValue("@idServico", servico.IdServico);
                cmd.Parameters.AddWithValue("@valor", servico.Valor);
                cmd.Parameters.AddWithValue("@quantidade", servico.Quantidade);

                cmd.ExecuteNonQuery();

                using var getIdCmd = new SQLiteCommand("SELECT last_insert_rowid();", conn, transaction);
                long id = (long)getIdCmd.ExecuteScalar();
                ids.Add(id);
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
                           SET valor = @valor, quantidade = @quantidade";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@valor", servicoCobranca.Servico.Valor);
            cmd.Parameters.AddWithValue("@quantidade", servicoCobranca.Quantidade);

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

            string sql = @"DELETE FROM ServicosCobrancas 
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
