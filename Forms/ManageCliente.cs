using Conta_Certa.Components;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Forms;

public partial class ManageCliente : InputForm
{
    public Cliente? Cliente { get; private set; }

    public ManageCliente(Cliente? cliente = null)
    {
        InitializeComponent();

        if (cliente != null)
        {
            nomeTxt.Text = cliente.Nome;
            documentoTxt.Text = cliente.Documento;
            telefoneTxt.Text = cliente.Telefone;
            emailTxt.Text = cliente.Email;
            honorarioNumber.Value = (decimal)cliente.Honorario;
            vencimentoNumber.Value = cliente.VencimentoHonorario;

            cadastrarBtn.Text = "ALTERAR";
        }
    }

    public ManageCliente(ClienteCadDTO clienteDTO)
    {
        InitializeComponent();

        var textFields = new (string? valor, TextBox controle)[]
        {
            (clienteDTO.Nome, nomeTxt),
            (clienteDTO.Email, emailTxt),
            (clienteDTO.Documento, documentoTxt)
        };

        foreach (var (valor, controle) in textFields)
        {
            if (!string.IsNullOrWhiteSpace(valor))
            {
                controle.Text = valor;
            }
        }

        if (!string.IsNullOrEmpty(clienteDTO.Telefone))
        {
            telefoneTxt.Text = clienteDTO.Telefone;
        }

        if (clienteDTO.Honorario is float honorario)
        {
            honorarioNumber.Value = (decimal)honorario;
        }

        if (clienteDTO.VencimentoHonorario is int vencimento)
        {
            vencimentoNumber.Value = vencimento;
        }
    }

    private void Cadastrar_Click(object sender, EventArgs e)
    {
        string nome = nomeTxt.Text.Trim();
        string documento = documentoTxt.Text.Trim();
        string telefone = new([.. telefoneTxt.Text.Where(char.IsDigit)]);
        string email = emailTxt.Text.Trim();
        float honorario = ((float)honorarioNumber.Value);
        int vencimentoHonorario = ((int)vencimentoNumber.Value);

        // Verificações de documento, telefone e nome
        if (telefone.Length == 0 || nome.Length == 0)
        {
            MessageBox.Show(
                "Os campos marcados com * são obrigatórios!",
                "Faltam informações!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // Verificação do documento
        if (!Cliente.CheckDocumento(documento))
        {
            MessageBox.Show(
                "O CPF/CNPJ escrito é inválido!\nCorrija e tente novamente.",
                "Documento inválido!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        using AppDBContext _dbContext = new();
        Cliente = new(documento, nome, telefone, email, honorario, vencimentoHonorario);

        try
        {
            _dbContext.Clientes.Add(Cliente);
            _dbContext.SaveChanges();
        }

        catch (DbUpdateException)
        {
            _dbContext.Entry(Cliente).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        if (Modal)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        else
        {
            ClearInputs();
        }
    }

    private void DocumentoTxt_TextChanged(object sender, EventArgs e)
    {
        string digits = new([.. documentoTxt.Text.Where(char.IsDigit)]);
        if (digits != documentoTxt.Text)
        {
            documentoTxt.Text = digits;
            documentoTxt.SelectionStart = digits.Length;
        }
    }
}
