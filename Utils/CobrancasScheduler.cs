using Conta_Certa.Models;

namespace Conta_Certa.Utils;

public static class CobrancasScheduler
{
    public static void GenCobrancasDoMes()
    {
        using AppDBContext dbContext = new();

        DateTime inicioMes = new(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime inicioProxMes = inicioMes.AddMonths(1);

        var clientes = dbContext.Clientes.ToList();
        var cobrancasDoMes = dbContext.Cobrancas
            .Where(c => c.Vencimento >= inicioMes && c.Vencimento < inicioProxMes)
            .ToList();

        List<Cobranca> novasCobrancas = [];

        foreach (var cliente in clientes)
        {
            if (!cobrancasDoMes.Any(c => c.DocumentoCliente == cliente.Documento))
            {
                DateTime vencimento = new(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    cliente.VencimentoHonorario);

                novasCobrancas.Add(new(
                    cliente.Documento,
                    cliente.Honorario,
                    CobrancaStatus.Pendente,
                    vencimento,
                    null));
            }
        }

        dbContext.Cobrancas.AddRange(novasCobrancas);
        dbContext.SaveChanges();

        if (novasCobrancas.Count > 0)
        {
            MessageBox.Show(
                $"{novasCobrancas.Count} novas cobranças cadastradas automaticamente!",
                "Cobranças atualizadas!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
