namespace Conta_Certa.Utils;

public static class Logger
{
    public static void LogException(Exception ex)
    {
        var logsPath = Application.UserAppDataPath + "/logs";

        if (!Directory.Exists(logsPath))
        {
            Directory.CreateDirectory(logsPath);
        }

        string now = DateTime.Now.ToString("dd-MM-yy - HH-mm");
        string fileName = Path.Combine(logsPath, $"{now}.log");

        File.WriteAllText(fileName, ex.ToString());

        MessageBox.Show(
            $"Um erro inesperado aconteceu: {ex.Message}.",
            "Erro inesperado!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
