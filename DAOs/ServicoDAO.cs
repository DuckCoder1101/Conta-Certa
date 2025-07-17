using System.Data.SQLite;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.Utils;

namespace Conta_Certa.DAOs;

public static class ServicoDAO
{
    public static void InsertServico(params ServicoCadDTO[] servicos)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO Servicos (nome, valor) VALUES (@nome, @valor);";

            foreach (var servico in servicos)
            {
                using var cmd = new SQLiteCommand(sql, conn, transaction);

                cmd.Parameters.AddWithValue("@nome", servico.Nome);
                cmd.Parameters.AddWithValue("@valor", servico.Valor);

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

    public static void UpdateServico(Servico servico)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"UPDATE Servicos SET 
                            nome = @nome, valor = @valor
                       WHERE idServico = @idServico;";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nome", servico.Nome);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);
            cmd.Parameters.AddWithValue("@idServico", servico.IdServico);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void DeleteServico(Servico servico)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"DELETE FROM Servicos WHERE idServico = @idServico;";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idServico", servico.IdServico);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static List<Servico> SelectAllServicos()
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT * FROM Servicos;";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            List<Servico> servicos = [];

            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var nome = reader.GetString(1);
                var valor = reader.GetFloat(2);

                servicos.Add(new(id, nome, valor));
            }

            conn.Close();

            return servicos;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return [];
        }
    }
}
