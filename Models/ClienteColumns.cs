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
        Nome = new("Nome", nameof(ClienteCadDTO.Nome), "Nome do cliente.");
        Documento = new("Documento (CPF/CNPJ)", nameof(ClienteCadDTO.Documento), "Documento do cliente.");
        Telefone = new("Telefone", nameof(ClienteCadDTO.Telefone), "Telefone do cliente (11 dígitos).");
        Email = new("E-mail", nameof(ClienteCadDTO.Email), "Email do cliente.");
        Honorario = new("Honorário", nameof(ClienteCadDTO.Honorario), "Honorário mensal base do cliente.");
        VencimentoHonorario = new("Vencimento Honorário", nameof(ClienteCadDTO.VencimentoHonorario), "Dia padrão de vencimento do honorário (dd).");
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
