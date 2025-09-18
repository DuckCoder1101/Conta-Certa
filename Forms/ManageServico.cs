using Conta_Certa.Components;
using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;

namespace Conta_Certa.Forms;

public partial class ManageServico : InputForm
{
    public Servico? Result { get; private set; }

    private readonly long? _idServico;

    public ManageServico(Servico? servico = null)
    {
        InitializeComponent();

        if (servico != null)
        {
            _idServico = servico.IdServico;

            nomeTxt.Text = servico.Nome;
            valorNb.Value = (decimal)servico.Valor;

            cadastrarBtn.Text = "ALTERAR";
        }
    }

    private void CadastrarBtn_Click(object sender, EventArgs e)
    {
        string nome = nomeTxt.Text.Trim();
        float valor = (float) valorNb.Value;

        if (nome.Length == 0 || valor == 0)
        {
            MessageBox.Show(
                "Os campos marcados com * são obrigatórios!",
                "Faltam informações!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (_idServico == null)
        {
            ServicoCadDTO servicoCadDTO = new(nome, valor);
            long? id = ServicoDAO.InsertServicos(servicoCadDTO).ElementAtOrDefault(0);

            if (id != null)
            {
                Result = new((long) id, nome, valor);
            }
        }

        else
        {
            Servico servico = new(
                (long) _idServico,
                nome,
                valor);

            ServicoDAO.UpdateServico(servico);
            Result = servico;
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
}
