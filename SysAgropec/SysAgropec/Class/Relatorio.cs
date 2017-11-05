using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SysAgropec.Class;
using SysAgropec.Models;

namespace SysAgropec.Class
{
    public class Relatorio : RelatorioHelper
    {

        public override void MontaCorpoDados()
        {
            base.MontaCorpoDados();
            
            PdfPTable table = new PdfPTable(5);
            BaseColor preto = new BaseColor(0, 0, 0);
            BaseColor fundo = new BaseColor(200, 200, 200);
            Font font = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
            Font titulo = FontFactory.GetFont("Verdana", 8, Font.BOLD, preto);

            float[] colsW = { 10, 10, 10, 10, 10 };
            table.SetWidths(colsW);
            table.HeaderRows = 1;
            table.WidthPercentage = 100f;

            table.DefaultCell.Border = PdfPCell.BOTTOM_BORDER;
            table.DefaultCell.BorderColor = preto;
            table.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
            table.DefaultCell.Padding = 10;

            
            if (TipoRelatorio == 0) {

                table.AddCell(getNewCell("Animal", titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Registro", titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Tatuagem", titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Sexo", titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Cadastrado Em:", titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER, preto, fundo));


                AnimalViewModel a = new AnimalViewModel();

                var animais = a.RelatorioAnimais(datIni, datFin);

                var animalOLD = 0;

                foreach(var an in animais)
                {

                    if (an.Raca_ID != animalOLD)
                    {
                        var cell = getNewCell("Raça: " + an.nomeraca, titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER);
                        cell.Colspan = 5;
                        table.AddCell(cell);
                        animalOLD = an.Raca_ID;
                    }

                    table.AddCell(getNewCell(an.Descricao, font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(an.Registro, font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(an.Tatuagem, font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(an.descriSexo, font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(an.Datacadastro.ToString("dd/MM/yyyy"), font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));

                }

                var cell2 = getNewCell("Filtros de Pesquisa " + Filtros, titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER);
                cell2.Colspan = 5;
                table.AddCell(cell2);


            }
            else if(TipoRelatorio == 1)
            {
                table.AddCell(getNewCell("Medicamento", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Qtd Mínima", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Qtd Atual", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Estocado Em:", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));

                Estoque_MedicamentoViewModel a = new Estoque_MedicamentoViewModel();

                var es = a.RelatorioEstoque(datIni, datFin);
                
                foreach (var an in es)
                {
  
                    table.AddCell(getNewCell(an.nomeMedicamento, font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(Convert.ToString(an.Quantidademinima), font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(Convert.ToString(an.Quantidadeatual), font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(an.Data_Estocado.ToString("dd/MM/yyyy"), font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell("", font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    
                }

                var cell2 = getNewCell("Filtros de Pesquisa " + Filtros, titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER);
                cell2.Colspan = 5;
                table.AddCell(cell2);
            }
            else
            {
                table.AddCell(getNewCell("Data de Produção", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Qtd (L)", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("Observação", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));
                table.AddCell(getNewCell("", titulo, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER, preto, fundo));

                ProducaoViewModel prod = new ProducaoViewModel();

                var prods = prod.RelatorioAnimais(datIni, datFin);

                var prodOLD = 0;

                double totalProduzido = 0;
                int contador = 0;
                foreach (var pr in prods)
                {
                    int quantidadeRegistros = prods.Count;
                    contador++;

                    if (pr.Animail_ID != prodOLD)
                    {
                        if (totalProduzido > 0)
                        {
                            var cell1 = getNewCell("Total produzido: " + totalProduzido, titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER);
                            cell1.Colspan = 5;
                            table.AddCell(cell1);

                        }

                        var cell = getNewCell("Animal: " + pr.nomeAnimal, titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER);
                        cell.Colspan = 5;
                        table.AddCell(cell);
                        prodOLD = pr.Animail_ID;

                        totalProduzido = 0;
                    }

                    table.AddCell(getNewCell(pr.Datarealizada.ToShortDateString(), font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(Convert.ToString(pr.Quantidade), font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell(pr.Observacao, font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell("", font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    table.AddCell(getNewCell("", font, Element.ALIGN_LEFT, 5, PdfPCell.BOTTOM_BORDER));
                    totalProduzido = totalProduzido + pr.Quantidade;

                    if (contador == quantidadeRegistros)
                    {
                        var cell1 = getNewCell("Total produzido: " + totalProduzido, titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER);
                        cell1.Colspan = 5;
                        table.AddCell(cell1);
                    }

                }

                var cell2 = getNewCell("Filtros de Pesquisa " + Filtros, titulo, Element.ALIGN_LEFT, 10, PdfPCell.BOTTOM_BORDER);
                cell2.Colspan = 5;
                table.AddCell(cell2);
                

            }


            doc.Add(table);
        }

        
    }
}