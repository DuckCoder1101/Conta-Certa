using Conta_Certa.Utils;
using System.Data.SQLite;

namespace Conta_Certa.Models;

public static class Database
{
    public static string ConnStr { get; } = "Data Source=ContaCerta.db;Version=3;";

    private static readonly bool isDev = false;

    public static void CreateDatabase()
    {
        try
        {
            if (isDev)
            {
                DropTables();
            }

            CreateClientes();
            CreateCobrancas();
            CreateServicos();
            CreateServicosCobranca();
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }
    
    public static void DropTables()
    {
        using var conn = new SQLiteConnection(ConnStr);
        conn.Open();

        string sql = @"DROP TABLE IF EXISTS Clientes; 
                       DROP TABLE IF EXISTS Cobrancas; 
                       DROP TABLE IF EXISTS Servicos; 
                       DROP TABLE IF EXISTS ServicosCobranca;";

        foreach (var line in sql.Split(";"))
        {
            using var cmd = new SQLiteCommand(line, conn);
            cmd.ExecuteNonQuery();
        }
        
        conn.Close();
    }

    private static void CreateClientes()
    {
        using var conn = new SQLiteConnection(ConnStr);
        conn.Open();

        string sql = @"CREATE TABLE IF NOT EXISTS Clientes (
                            idCliente INTEGER PRIMARY KEY AUTOINCREMENT,
                            nome TEXT NOT NULL,
                            telefone TEXT NOT NULL,
                            email TEXT,
                            honorario NUMERIC NOT NULL,
                            vencimentoHonorario INTEGER NOT NULL);";

        using var cmd = new SQLiteCommand(sql, conn);

        cmd.ExecuteNonQuery();
        conn.Close();
    }

    private static void CreateCobrancas()
    {
        using var conn = new SQLiteConnection(ConnStr);
        conn.Open();

        string sql = @"CREATE TABLE IF NOT EXISTS Cobrancas ( 
                            idCobranca INTEGER PRIMARY KEY AUTOINCREMENT, 
                            idCliente INTEGER, 
                            honorario NUMERIC NOT NULL, 
                            status TEXT NOT NULL, 
                            vencimento TEXT NOT NULL, 
                            pagoEm TEXT, 
                                        
                            FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente)
                            ON DELETE CASCADE);";

        using var cmd = new SQLiteCommand(sql, conn);

        cmd.ExecuteNonQuery();
        conn.Close();
    }

    private static void CreateServicos()
    {
        using var conn = new SQLiteConnection(ConnStr);
        conn.Open();

        string sql = @"CREATE TABLE IF NOT EXISTS Servicos (
                            idServico INTEGER PRIMARY KEY AUTOINCREMENT,
                            nome TEXT NOT NULL,
                            valor NUMERIC NOT NULL);";

        using var cmd = new SQLiteCommand(sql, conn);

        cmd.ExecuteNonQuery();
        conn.Close();
    }

    private static void CreateServicosCobranca()
    {
        using var conn = new SQLiteConnection(ConnStr);
        conn.Open();

        string sql = @"CREATE TABLE IF NOT EXISTS ServicosCobranca ( 
                            idServicoCobranca INTEGER PRIMARY KEY AUTOINCREMENT, 
                            idCobranca INTEGER, 
                            idServico INTEGER NOT NULL, 
                            valor NUMERIC NOT NULL,
                            quantidade INTEGER NOT NULL DEFAULT 0,

                            FOREIGN KEY (idCobranca) REFERENCES Cobrancas(idCobranca)
                            ON DELETE CASCADE);";

        using var cmd = new SQLiteCommand(sql, conn);

        cmd.ExecuteNonQuery();
        conn.Close();
    }
}
