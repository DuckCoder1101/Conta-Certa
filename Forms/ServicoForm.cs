using Microsoft.EntityFrameworkCore;
using Conta_Certa.Components;
using Conta_Certa.Models;

namespace Conta_Certa.Forms;

public partial class ManageServico : InputForm
{
    private long? _idServico;

    public Servico? Servico { get; private set; }

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
        float valor = (float)valorNb.Value;

        if (nome.Length == 0 || valor == 0)
        {
            MessageBox.Show(
                "Os campos marcados com * são obrigatórios!",
                "Faltam informações!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        using AppDBContext dbContext = new();
        Servico = new(nome, valor);

        if (_idServico != null)
        {
            Servico.IdServico = (long) _idServico;
        }

        try
        {
            dbContext.Servicos.Add(Servico);
            dbContext.SaveChanges();
        }

        catch (DbUpdateException)
        {
            dbContext.Entry(Servico).State = EntityState.Modified;
            dbContext.SaveChanges();
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
