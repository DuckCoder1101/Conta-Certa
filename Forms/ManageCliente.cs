using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;

namespace Conta_Certa.Forms;

public partial class ManageCliente : Form
{
    public Cliente? Cliente { get; private set; }

    public ManageCliente(Cliente? cliente = null)
    {
        InitializeComponent();
        Cliente = cliente;

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
                controle.ReadOnly = true;
            }
        }

        if (!string.IsNullOrEmpty(clienteDTO.Telefone))
        {
            telefoneTxt.Text = clienteDTO.Telefone;
            telefoneTxt.ReadOnly = true;
        }

        if (clienteDTO.Honorario is float h)
        {
            honorarioNumber.Value = (decimal)h;
            honorarioNumber.Enabled = false;
        }

        if (clienteDTO.VencimentoHonorario is int v)
        {
            vencimentoNumber.Value = v;
            vencimentoNumber.Enabled = false;
        }

    }

    private void Cadastrar_Click(object sender, EventArgs e)
    {
        string nome = nomeTxt.Text.Trim();
        string documento = documentoTxt.Text.Trim();
        string telefone = telefoneTxt.Text.Trim();
        string email = emailTxt.Text.Trim();
        float honorario = ((float)honorarioNumber.Value);
        int vencimentoHonorario = ((int)vencimentoNumber.Value);

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
            if (Cliente == null)
            {
                ClienteCadDTO cliente =
                    new(nome, documento, telefone, email, honorario, vencimentoHonorario);

                var ids = ClienteDAO.InsertClientes(cliente);

                if (ids.Count != 0 && ids[0] != null)
                {
                    Cliente = new(
                        (long)ids[0]!,
                        documento,
                        nome,
                        telefone,
                        email,
                        honorario,
                        vencimentoHonorario);
                }
            }

            else
            {
                Cliente = new(
                    Cliente.IdCliente,
                    nome,
                    documento,
                    telefone,
                    email,
                    honorario,
                    vencimentoHonorario);

                ClienteDAO.UpdateCliente(Cliente);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
