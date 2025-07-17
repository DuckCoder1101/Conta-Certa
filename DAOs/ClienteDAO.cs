using System.Data.SQLite;
using Conta_Certa.Models;
using Conta_Certa.DTOs;
using Conta_Certa.Utils;

namespace Conta_Certa.DAOs;

public static class ClienteDAO
{
    public static List<long> InsertClientes(params ClienteCadDTO[] clientes)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO Clientes 
                            (nome, telefone, email, honorario, vencimentoHonorario) 
                           VALUES (@nome, @telefone, @email, @honorario, @vencimentoHonorario);";

            List<long> ids = [];

            foreach (var cliente in clientes)
            {
                using var cmd = new SQLiteCommand(sql, conn, transaction);

                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@honorario", cliente.Honorario);
                cmd.Parameters.AddWithValue("@vencimentoHonorario", cliente.VencimentoHonorario);

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

    public static void UpdateCliente(Cliente cliente)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"UPDATE Clientes SET nome = @nome, telefone = @telefone, 
                                email = @email, honorario = @honorario, 
                                vencimentoHonorario = @vencimentoHonorario
                           WHERE idCliente = @idCliente;";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@honorario", cliente.Honorario);
            cmd.Parameters.AddWithValue("idCliente", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@vencimentoHonorario", cliente.VencimentoHonorario);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void DeleteCliente(Cliente cliente)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"DELETE FROM Clientes WHERE idCliente = @idCliente;";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("idCliente", cliente.IdCliente);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    public static List<Cliente> SelectAllClientes()
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = "SELECT * FROM Clientes;";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            List<Cliente> clientes = [];

            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var nome = reader.GetString(1);
                var telefone = reader.GetString(2);
                var email = reader.GetString(3);
                var honorario = reader.GetFloat(4);
                var vencimentoHonoraio = reader.GetInt32(5);

                clientes.Add(new(id, nome, telefone, email, honorario, vencimentoHonoraio));
            }

            conn.Close();

            return clientes;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return [];
        }
    }

    public static Cliente? GetClienteByID(long id)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT * FROM Clientes WHERE idCliente = @idCliente";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idCliente", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var nome = reader.GetString(1);
                var telefone = reader.GetString(2);
                var email = reader.GetString(3);
                var honorario = reader.GetFloat(4);
                var vencimentoHonoraio = reader.GetInt32(5);

                return new(
                    id, 
                    nome, 
                    telefone, 
                    email, 
                    honorario, 
                    vencimentoHonoraio);
            }

            return null;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return null;
        }
    }
}
