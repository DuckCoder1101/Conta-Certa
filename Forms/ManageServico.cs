using Conta_Certa.Components;
using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;

namespace Conta_Certa.Forms
{
    public partial class ManageServico : InputForm
    {
        private readonly Servico? servicoBase;

        public ManageServico(Servico? servico = null)
        {
            InitializeComponent();

            if (servico != null)
            {
                servicoBase = servico;

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

            if (servicoBase == null)
            {
                ServicoCadDTO servicoCadDTO = new(nome, valor);
                ServicoDAO.InsertServicos(servicoCadDTO);
            }

            else
            {
                Servico servico = new(
                    servicoBase.IdServico,
                    nome,
                    valor);

                ServicoDAO.UpdateServico(servico);
            }

            DialogResult = DialogResult.OK;

            if (Modal)
            {
                Close();
            }

            else
            {
                ClearInputs();
            }
        }
    }
}
