using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class ClienteExcelImportDTO
{
    public ImportColumnMap Nome { get; }
    public ImportColumnMap Telefone { get; }
    public ImportColumnMap Email { get; }
    public ImportColumnMap Honorario { get; }
    public ImportColumnMap VencimentoHonorario { get; }

    public ClienteExcelImportDTO()
    {
        Nome = new("Nome", nameof(ClienteCadDTO.Nome), true, "Nome do cliente.");
        Telefone = new("Telefone", nameof(ClienteCadDTO.Telefone), true, "Telefone do cliente (11 dígitos).");
        Email = new("E-mail", nameof(ClienteCadDTO.Email), false, "Email do cliente.");
        Honorario = new("Honorário", nameof(ClienteCadDTO.Honorario), true, "Honorário mensal base do cliente.");
        VencimentoHonorario = new("Vencimento Honorário", nameof(ClienteCadDTO.VencimentoHonorario), true, "Dia padrão de vencimento do honorário (dd).");
    }

    public ClienteExcelImportDTO(ImportColumnMap nome, ImportColumnMap telefone, ImportColumnMap email, ImportColumnMap honorario, ImportColumnMap vencimentoHonorario)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Honorario = honorario;
        VencimentoHonorario = vencimentoHonorario;
    }

    public IEnumerable<ImportColumnMap> GetColumns()
    {
        yield return Nome;
        yield return Telefone;
        yield return Email;
        yield return Honorario;
        yield return VencimentoHonorario;
        yield break;
    }
}
