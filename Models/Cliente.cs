using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Conta_Certa.Models;

public class Cliente
{
    [Key]
    [MaxLength(14)]
    public string Documento { get; private set; } = string.Empty;

    [Required]
    public string Nome { get; private set; } = string.Empty;

    [Required]
    [Index(IsUnique = true)]
    public string Telefone { get; private set; } = string.Empty;

    [Required]
    [Index(IsUnique = true)]
    public string? Email { get; private set; }

    [Required]
    public float Honorario { get; private set; }

    [Required]
    public int VencimentoHonorario { get; private set; }

    // Relacionamento com Cobranca
    public ICollection<Cobranca> Cobrancas { get; private set; } = [];

    // Construtor vazio para EF
    protected Cliente() { }

    [JsonConstructor]
    public Cliente(string documento, string nome, string telefone, string email, float honorario, int vencimentoHonorario)
    {
        Documento = documento;
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Honorario = honorario;
        VencimentoHonorario = vencimentoHonorario;
    }

    public static bool CheckDocumento(string documento)
    {
        string numeros = new string(documento.Where(char.IsDigit).ToArray());

        return numeros.Length switch
        {
            11 => CheckCPF(numeros),
            14 => CheckCPNJ(numeros),
            _ => false
        };
    }

    private static bool CheckCPF(string cpf)
    {
        if (cpf.Distinct().Count() == 1) return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf[..9];
        int soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        }

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCpf += digito1;
        soma = 0;

        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        }

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return cpf.EndsWith($"{digito1}{digito2}");
    }

    private static bool CheckCPNJ(string cnpj)
    {
        if (cnpj.Distinct().Count() == 1) return false;

        int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj[..12];
        int soma = 0;

        for (int i = 0; i < 12; i++)
        {
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        }

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCnpj += digito1;
        soma = 0;

        for (int i = 0; i < 13; i++)
        {
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        }

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return cnpj.EndsWith($"{digito1}{digito2}");
    }

    public static string FormatDocumento(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento)) return string.Empty;

        var digits = new string(documento.Where(char.IsDigit).ToArray());

        return digits.Length switch
        {
            11 => Convert.ToUInt64(digits).ToString(@"000\.000\.000\-00"),
            14 => Convert.ToUInt64(digits).ToString(@"00\.000\.000\/0000\-00"),
            _ => documento
        };
    }

    public static bool CheckTelefone(string telefone)
    {
        var digits = new string(telefone.Where(char.IsDigit).ToArray());

        if (digits.Length < 10 || digits.Length > 11) return false;

        if (digits.Length == 11 && digits[2] != '9') return false;
        if (digits.Length == 10 && !"2345".Contains(digits[2])) return false;

        return true;
    }

    public static string FormatTelefone(string telefone)
    {
        var digits = new string(telefone.Where(char.IsDigit).ToArray());

        return digits.Length switch
        {
            10 => Regex.Replace(digits, @"(\d{2})(\d{4})(\d{4})", "($1) $2-$3"),
            11 => Regex.Replace(digits, @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3"),
            _ => telefone
        };
    }

    public override string ToString()
    {
        return $"{Documento} - {Nome}";
    }
}
