using QuestPDF.Companion;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;

namespace Conta_Certa.Utils;

public static class RelatorioManager
{
    public static void CreateRelatorio()
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {

            });
        });

        document.GeneratePdfAndShow();
        document.ShowInCompanion();
    }
}
