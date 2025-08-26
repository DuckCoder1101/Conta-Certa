using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.Utils;
using System.Data.SQLite;
using System.Diagnostics;

namespace Conta_Certa.DAOs;

public static class ClienteDAO
{
    public static void InsertClientes(params ClienteCadDTO[] dtos)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            using var transaction = conn.BeginTransaction();

            string sql = @"INSERT INTO Clientes 
                    (documento, nome, telefone, email, honorario, vencimentoHonorario) 
                VALUES 
                    (@documento, @nome, @telefone, @email, @honorario, @vencimentoHonorario)
                ON CONFLICT(documento) DO UPDATE SET
                    nome = excluded.nome,
                    telefone = excluded.telefone,
                    honorario = excluded.honorario,
                    vencimentoHonorario = excluded.vencimentoHonorario;";

            using var cmd = new SQLiteCommand(sql, conn, transaction);

            foreach (var clienteDTO in dtos)
            {
                if (clienteDTO.IsFull())
                {
                    cmd.Parameters.AddWithValue("@documento",
                        new string([.. clienteDTO.Documento!.Where(char.IsDigit)]));

                    cmd.Parameters.AddWithValue("@nome", clienteDTO.Nome);
                    cmd.Parameters.AddWithValue("@telefone",
                        new string([.. clienteDTO.Telefone!.Where(char.IsDigit)]));

                    cmd.Parameters.AddWithValue("@email", clienteDTO.Email);
                    cmd.Parameters.AddWithValue("@honorario", clienteDTO.Honorario);
                    cmd.Parameters.AddWithValue("@vencimentoHonorario", clienteDTO.VencimentoHonorario);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            transaction.Commit();
            conn.Close();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
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
                                telefone = @telefone, 
                                email = @email, 
                                honorario = @honorario, 
                                vencimentoHonorario = @vencimentoHonorario
                           WHERE documento = @documento;";

            using var cmd = new SQLiteCommand(sql, conn);

            Debug.WriteLine(cliente.Telefone);

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@honorario", cliente.Honorario);
            cmd.Parameters.AddWithValue("@vencimentoHonorario", cliente.VencimentoHonorario);
            cmd.Parameters.AddWithValue("@documento", cliente.Documento);

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

            string sql = @"DELETE FROM Clientes WHERE documento = @documento;";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@documento", cliente.Documento);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }

    public static List<Cliente> GetAllClientes()
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
                var documento = reader.GetString(0);
                var nome = reader.GetString(1);
                var telefone = reader.GetString(2);
                var email = reader.GetString(3);
                var honorario = reader.GetFloat(4);
                var vencimentoHonorario = reader.GetInt32(5);

                clientes.Add(new(
                    documento,
                    nome,
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

            string sql = "SELECT documento, nome, telefone FROM Clientes;";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            List<ClienteResumoDTO> clientes = [];

            while (reader.Read())
            {
                var documento = reader.GetString(0);
                var nome = reader.GetString(1);
                var telefone = reader.GetString(2);

                clientes.Add(new(
                    documento,
                    nome,
                    telefone));
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

    public static Cliente? GetClienteByDocumento(string documento)
    {
        try
        {
            using var conn = new SQLiteConnection(Database.ConnStr);
            conn.Open();

            string sql = @"SELECT * FROM Clientes WHERE documento = @documento";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@documento", documento);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var nome = reader.GetString(1);
                var telefone = reader.GetString(2);
                var email = reader.GetString(3);
                var honorario = reader.GetFloat(4);
                var vencimentoHonorario = reader.GetInt32(5);

                return new(
                    documento,
                    nome,
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
