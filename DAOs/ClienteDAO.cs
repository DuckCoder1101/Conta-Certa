 using System.Data.SQLite;
using Conta_Certa.Models;
using Conta_Certa.DTOs;
using Conta_Certa.Utils;

namespace Conta_Certa.DAOs;

public static class ClienteDAO
{
    public static List<long?> InsertClientes(params ClienteCadDTO[] clientes)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO Clientes 
                    (nome, documento, telefone, email, honorario, vencimentoHonorario) 
                VALUES 
                    (@nome, @documento, @telefone, @email, @honorario, @vencimentoHonorario)
                ON CONFLICT(documento) DO UPDATE SET
                    nome = excluded.nome,
                    documento = excluded.documento, 
                    telefone = excluded.telefone,
                    honorario = excluded.honorario,
                    vencimentoHonorario = excluded.vencimentoHonorario
                RETURNING idCliente;";

            using var cmd = new SQLiteCommand(sql, conn, transaction);
            List<long?> ids = [];

            foreach (var cliente in clientes)
            {
                if (cliente.IsFull())
                {
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);

                    cmd.Parameters.AddWithValue("@documento",
                        new string([.. cliente.Documento!.Where(char.IsDigit)]));

                    cmd.Parameters.AddWithValue("@telefone",
                        new string([.. cliente.Telefone!.Where(char.IsDigit)]));

                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cmd.Parameters.AddWithValue("@honorario", cliente.Honorario);
                    cmd.Parameters.AddWithValue("@vencimentoHonorario", cliente.VencimentoHonorario);

                    long idCliente = (long)cmd.ExecuteScalar();
                    ids.Add(idCliente);

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

    public static void UpdateCliente(Cliente cliente)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"UPDATE Clientes SET 
                                nome = @nome, 
                                documento = @documento, 
                                telefone = @telefone, 
                                email = @email, 
                                honorario = @honorario, 
                                vencimentoHonorario = @vencimentoHonorario
                           WHERE idCliente = @idCliente;";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@documento", cliente.Documento);
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
                var id = reader.GetInt64(0);
                var nome = reader.GetString(1);
                var documento = reader.GetString(2);
                var telefone = reader.GetString(3);
                var email = reader.GetString(4);
                var honorario = reader.GetFloat(5);
                var vencimentoHonorario = reader.GetInt32(6);

                clientes.Add(new(
                    id, 
                    nome,
                    documento, 
                    telefone, 
                    email, 
                    honorario, 
                    vencimentoHonorario));
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

    public static List<ClienteResumoDTO> SelectAllClientesResumos()
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = "SELECT idCliente, nome, documento FROM Clientes;";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            List<ClienteResumoDTO> clientes = [];

            while (reader.Read())
            {
                var id = reader.GetInt64(0);
                var nome = reader.GetString(1);
                var documento = reader.GetString(2);

                clientes.Add(new(
                    id,
                    nome,
                    documento));
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
                var documento = reader.GetString(2);
                var telefone = reader.GetString(3);
                var email = reader.GetString(4);
                var honorario = reader.GetFloat(5);
                var vencimentoHonorario = reader.GetInt32(6);

                return new(
                    id,
                    nome,
                    documento,
                    telefone, 
                    email, 
                    honorario, 
                    vencimentoHonorario);
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
