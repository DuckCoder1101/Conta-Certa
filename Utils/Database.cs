using System.Data.SQLite;

namespace Conta_Certa.Utils;

public static class Database
{
    public static string ConnStr { get; } = "Data Source=ContaCerta.db;Version=3;Foreign keys=true;";

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

        string sql = @"
                       DROP TABLE IF EXISTS ServicosCobranca; 
                       DROP TABLE IF EXISTS Servicos;
                       DROP TABLE IF EXISTS Cobrancas;
                       DROP TABLE IF EXISTS Clientes;";

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
                            documento TEXT PRIMARY KEY CHECK(length(documento) <= 14),
                            nome TEXT NOT NULL,
                            telefone TEXT NOT NULL CHECK(length(telefone) = 11),
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
                            documentoCliente TEXT NOT NULL, 
                            honorario NUMERIC NOT NULL, 
                            status TEXT NOT NULL, 
                            vencimento TEXT NOT NULL, 
                            pagoEm TEXT, 
                                        
                            FOREIGN KEY (documentoCliente) REFERENCES Clientes(documento)
                            ON DELETE CASCADE 
                            UNIQUE (documentoCliente, vencimento));";

        using var cmd = new SQLiteCommand(sql, conn);
        cmd.ExecuteNonQuery();

        string indexSql = @"CREATE UNIQUE INDEX IF NOT EXISTS idx_cliente_vencimento 
                            ON Cobrancas(documentoCliente, vencimento);";

        cmd.CommandText = indexSql;
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
                            ON DELETE CASCADE 
                            FOREIGN KEY (idServico) REFERENCES Servicos(idServico) 
                            ON DELETE CASCADE
                            UNIQUE (idCobranca, idServico));";

        using var cmd = new SQLiteCommand(sql, conn);
        cmd.ExecuteNonQuery();

        string uniqueSql = @"CREATE UNIQUE INDEX IF NOT EXISTS idx_cobranca_servico
                            ON ServicosCobranca(idCobranca, idServico);";

        cmd.CommandText = uniqueSql;
        cmd.ExecuteNonQuery();

        conn.Close();
    }
}
