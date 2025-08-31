using Conta_Certa.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Conta_Certa.Relatories;

public class CobrancaRelatory : IDocument
{
    public List<CobrancaRelatoryDTO> Cobrancas { get; }

    public CobrancaRelatory(List<CobrancaRelatoryDTO> cobrancas)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Cobrancas = cobrancas;
    }

    private void ComposeTable(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(cols =>
            {
                cols.RelativeColumn();
                cols.RelativeColumn();
                cols.RelativeColumn();
                cols.RelativeColumn();
                cols.RelativeColumn();
            });

            table.Header(header =>
            {
                header.Cell().Element(CellStyle).Text("Cliente");
                header.Cell().Element(CellStyle).Text("Honorário");
                header.Cell().Element(CellStyle).Text("Status");
                header.Cell().Element(CellStyle).Text("Vencimento");
                header.Cell().Element(CellStyle).Text("Pago em");

                static IContainer CellStyle(IContainer container)
                {
                    return container.DefaultTextStyle(x => x.SemiBold())
                            .PaddingVertical(5)
                            .BorderBottom(1)
                            .BorderColor(Colors.Black);
                }
            });

            foreach (var item in Cobrancas)
            {
                table.Cell().Element(CellStyle).Text(item.Cliente);
                table.Cell().Element(CellStyle).Text(item.honorario.ToString("c"));
                table.Cell().Element(CellStyle).Text(item.Status.ToString());
                table.Cell().Element(CellStyle).Text(item.Vencimento.ToString("dd/MM/yy"));
                table.Cell().Element(CellStyle)
                    .Text(item.PagoEm != null
                        ? ((DateTime)(item.pagoEm!)).ToString("dd/MM/yy")
                        : "-");

                static IContainer CellStyle(IContainer container)
                {
                    return container.BorderBottom(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .PaddingVertical(5);
                }
            }
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.PaddingVertical(40).Column(column =>
        {
            column.Spacing(5);
            column.Item().Element(ComposeTable);
        });
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(1, Unit.Centimetre);

            page.Content().Element(ComposeContent);

            page.Footer().AlignCenter().Text(x =>
            {
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
            });
        });
    }
}