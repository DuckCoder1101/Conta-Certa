using Conta_Certa.DTOs;

namespace Conta_Certa.Models;

public class ClienteColumns
{
    public ColumnMap Nome { get; }
    public ColumnMap Documento { get; }
    public ColumnMap Telefone { get; }
    public ColumnMap Email { get; }
    public ColumnMap Honorario { get; }
    public ColumnMap VencimentoHonorario { get; }

    public ClienteColumns()
    {
        Nome = new("Nome", nameof(ClienteCadDTO.Nome), true, "Nome do cliente.");
        Documento = new("Documento (CPF/CNPJ)", nameof(ClienteCadDTO.Documento), true, "Documento do cliente.");
        Telefone = new("Telefone", nameof(ClienteCadDTO.Telefone), true, "Telefone do cliente (11 dígitos).");
        Email = new("E-mail", nameof(ClienteCadDTO.Email), false, "Email do cliente.");
        Honorario = new("Honorário", nameof(ClienteCadDTO.Honorario), true, "Honorário mensal base do cliente.");
        VencimentoHonorario = new("Vencimento Honorário", nameof(ClienteCadDTO.VencimentoHonorario), true, "Dia padrão de vencimento do honorário (dd).");
    }

    public IEnumerable<ColumnMap> GetColumns()
    {
        yield return Nome;
        yield return Documento;
        yield return Telefone;
        yield return Email;
        yield return Honorario;
        yield return VencimentoHonorario;
        yield break;
    }
}
