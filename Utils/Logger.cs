namespace Conta_Certa.Utils;

public static class Logger
{
    public static void LogException(Exception ex)
    {
        var logsPath = Path.Combine(Application.UserAppDataPath, "/logs");

        if (!Directory.Exists(logsPath))
        {
            Directory.CreateDirectory(logsPath);
        }

        string now = DateTime.Now.ToString("dd-MM-yy - HH-mm");
        var fileName = Path.Combine(logsPath, $"{now}.log");

        File.WriteAllText(fileName, ex.ToString());

        // Mostra o erro na tela
        MessageBox.Show(
            $"Um erro inesperado aconteceu: ${ex.Message}.",
            "Erro inesperado!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
