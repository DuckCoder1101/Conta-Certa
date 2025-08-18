using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;

namespace Conta_Certa.Utils;

public static class CobrancasScheduler
{

    public static void GenCobrancasDoMes()
    {
        var cobrancasDoMes = CobrancaDAO.GetCobrancasDoMes();
        var clientes = ClienteDAO.GetAllClientes();

        List<CobrancaCadDTO> novasCobrancas = [];

        foreach (var cliente in clientes)
        {
            if (!cobrancasDoMes.Any(c => c.Cliente.Documento == cliente.Documento))
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

        CobrancaDAO.InsertCobrancas([.. novasCobrancas]);

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
