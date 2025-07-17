using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;

namespace Conta_Certa.Forms;

public partial class ManageCliente : Form
{
    private readonly Cliente? clienteBase = null;

    public ManageCliente(Cliente? cliente = null)
    {
        InitializeComponent();
        clienteBase = cliente;

        if (cliente != null)
        {
            nomeTxt.Text = cliente.Nome;
            telefoneTxt.Text = cliente.Telefone;
            emailTxt.Text = cliente.Email;
            honorarioNumber.Value = (decimal) cliente.Honorario;
            vencimentoNumber.Value = cliente.VencimentoHonorario;

            cadastrarBtn.Text = "ALTERAR";
        }
    }

    private void Cadastrar_Click(object sender, EventArgs e)
    {
        string nome = nomeTxt.Text.Trim();
        string telefone = telefoneTxt.Text.Trim();
        string email = emailTxt.Text.Trim();
        float honorario = ((float)honorarioNumber.Value);
        int vencimento = ((int)vencimentoNumber.Value);

        // Verificações de valor
        if (telefoneTxt.Mask.Length != telefone.Length || nome.Length == 0)
        {
            MessageBox.Show(
                "Os campos marcados com * são obrigatórios!",
                "Faltam informações!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        else
        {
            if (clienteBase == null)
            {
                ClienteCadDTO cliente = new(nome, telefone, email, honorario, vencimento);
                ClienteDAO.InsertClientes(cliente);
            }

            else
            {
                Cliente cliente =
                    new(clienteBase.IdCliente, nome, telefone, email, honorario, vencimento);

                ClienteDAO.UpdateCliente(cliente);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
