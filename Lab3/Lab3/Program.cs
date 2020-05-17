using System;
using System.IO;
using Xceed.Words.NET;
using Xceed.PDFCreator.NET;
using System.Drawing;
using Xceed.Document.NET;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            DocX wordDoc = DocX.Create("Bill.docx");

            Table requisites = wordDoc.AddTable(7, 4);
            requisites.SetColumnWidth(0, 170);
            requisites.SetColumnWidth(1, 110);
            requisites.SetColumnWidth(2, 70);
            requisites.SetColumnWidth(3, 110);

            requisites.Rows[0].Cells[0].Paragraphs[0].Append("АО \"Банк Санкт-Петербург\" \n\n\nБанк получателя ").FontSize(10);
            requisites.Rows[0].Cells[2].Paragraphs[0].Append("БИК").FontSize(10);
            requisites.Rows[0].Cells[3].Paragraphs[0].Append("79348530456446").FontSize(10);

            requisites.Rows[1].Cells[2].Paragraphs[0].Append("Сч. №").FontSize(10);
            requisites.Rows[1].Cells[3].Paragraphs[0].Append("795802340934").FontSize(10);


            requisites.Rows[3].Cells[0].Paragraphs[0].Append("ИНН: 3908098034").FontSize(10);
            requisites.Rows[3].Cells[1].Paragraphs[0].Append("КПП: 3458908309").FontSize(10);
            requisites.Rows[3].Cells[2].Paragraphs[0].Append("Сч. №").FontSize(10);
            requisites.Rows[3].Cells[3].Paragraphs[0].Append("897970903424").FontSize(10);

            requisites.Rows[4].Cells[0].Paragraphs[0].Append("ООО \"МТН\"\nПолучатель").FontSize(10);

            requisites.Rows[2].MergeCells(2, 3);
            requisites.Rows[4].MergeCells(2, 3);
            requisites.Rows[5].MergeCells(2, 3);
            requisites.Rows[6].MergeCells(2, 3);
            requisites.MergeCellsInColumn(2, 4, 6);
            requisites.Rows[0].MergeCells(0, 1);
            requisites.Rows[1].MergeCells(0, 1);
            requisites.Rows[2].MergeCells(0, 1);
            
            requisites.MergeCellsInColumn(0, 0, 2);
            requisites.Rows[4].MergeCells(0, 1);
            requisites.Rows[5].MergeCells(0, 1);
            requisites.Rows[6].MergeCells(0, 1);
            requisites.MergeCellsInColumn(0, 4, 6);

            wordDoc.InsertTable(requisites);

            var Header = wordDoc.InsertParagraph("Счет № 556677 от 17.05.2020 г.");
            Header.Bold().FontSize(14);
            Header.Alignment = Alignment.center;
            Header.LineSpacingBefore = 10;
            wordDoc.InsertParagraph("__________________________________________________________________________________").Bold();

            Table parties = wordDoc.AddTable(3, 2);
            parties.SetColumnWidth(1, 350);
            parties.Design = TableDesign.Custom;
            parties.Rows[0].Cells[0].Paragraphs[0].Append("Поставщик").FontSize(10);
            parties.Rows[0].Cells[1].Paragraphs[0].Append("ООО \"МТН\", ИНН 45645563, КПП 564564563, 3450849080, г. Санкт-Петербург, ул. Ленина ул., д. 99, тел.: 4859083083").FontSize(10).Bold();
            parties.Rows[1].Cells[0].Paragraphs[0].Append("Заказчик").FontSize(10);
            parties.Rows[1].Cells[1].Paragraphs[0].Append("Копосова Юлия Николаевна").FontSize(10).Bold();
            parties.Rows[2].Cells[0].Paragraphs[0].Append("Основание").FontSize(10);
            parties.Rows[2].Cells[1].Paragraphs[0].Append("Услуги связи").FontSize(10).Bold();
            wordDoc.InsertParagraph().InsertTableAfterSelf(parties);

            Table bill = wordDoc.AddTable(7, 6);
            bill.SetColumnWidth(0, 25);
            bill.SetColumnWidth(1, 150);
            bill.SetColumnWidth(2, 50);
            bill.SetColumnWidth(3, 35);
            bill.SetColumnWidth(4, 150);
            bill.SetColumnWidth(5, 50);

            bill.Rows[0].Cells[0].Paragraphs[0].Append("№").Bold().FontSize(10);
            bill.Rows[1].Cells[0].Paragraphs[0].Append("1").FontSize(10);
            bill.Rows[2].Cells[0].Paragraphs[0].Append("2").FontSize(10);
            bill.Rows[3].Cells[0].Paragraphs[0].Append("3").FontSize(10);
            bill.Rows[4].Cells[0].Paragraphs[0].Append("4").FontSize(10);
            bill.Rows[5].Cells[0].Paragraphs[0].Append("5").FontSize(10);
            bill.Rows[6].Cells[0].Paragraphs[0].Append("6").FontSize(10);

            bill.Rows[0].Cells[1].Paragraphs[0].Append("Наименование услуг").Bold().FontSize(10);
            bill.Rows[1].Cells[1].Paragraphs[0].Append("CМС").FontSize(10);
            bill.Rows[2].Cells[1].Paragraphs[0].Append("Входящие звонки").FontSize(10);
            bill.Rows[3].Cells[1].Paragraphs[0].Append("Исходящие звонки").FontSize(10);
            bill.Rows[4].Cells[1].Paragraphs[0].Append("Исходящие звонки").FontSize(10);
            bill.Rows[5].Cells[1].Paragraphs[0].Append("Трафик").FontSize(10);
            bill.Rows[6].Cells[1].Paragraphs[0].Append("Трафик").FontSize(10);

            bill.Rows[0].Cells[2].Paragraphs[0].Append("Кол-во").Bold().FontSize(10);
            bill.Rows[1].Cells[2].Paragraphs[0].Append("73").FontSize(10);
            bill.Rows[2].Cells[2].Paragraphs[0].Append("110,44").FontSize(10);
            bill.Rows[3].Cells[2].Paragraphs[0].Append("20").FontSize(10);
            bill.Rows[4].Cells[2].Paragraphs[0].Append("63,22").FontSize(10);
            bill.Rows[5].Cells[2].Paragraphs[0].Append("1000").FontSize(10);
            bill.Rows[6].Cells[2].Paragraphs[0].Append("12704").FontSize(10);

            bill.Rows[0].Cells[3].Paragraphs[0].Append("Ед.").Bold().FontSize(10);
            bill.Rows[1].Cells[3].Paragraphs[0].Append("шт.").FontSize(10);
            bill.Rows[2].Cells[3].Paragraphs[0].Append("мин.").FontSize(10);
            bill.Rows[3].Cells[3].Paragraphs[0].Append("мин.").FontSize(10);
            bill.Rows[4].Cells[3].Paragraphs[0].Append("мин.").FontSize(10);
            bill.Rows[5].Cells[3].Paragraphs[0].Append("Кб").FontSize(10);
            bill.Rows[6].Cells[3].Paragraphs[0].Append("Кб").FontSize(10);

            bill.Rows[0].Cells[4].Paragraphs[0].Append("Цена, руб").Bold().FontSize(10);
            bill.Rows[1].Cells[4].Paragraphs[0].Append("2").FontSize(10);
            bill.Rows[2].Cells[4].Paragraphs[0].Append("0").FontSize(10);
            bill.Rows[3].Cells[4].Paragraphs[0].Append("0").FontSize(10);
            bill.Rows[4].Cells[4].Paragraphs[0].Append("2").FontSize(10);
            bill.Rows[5].Cells[4].Paragraphs[0].Append("0").FontSize(10);
            bill.Rows[6].Cells[4].Paragraphs[0].Append("0,5").FontSize(10);

            bill.Rows[0].Cells[5].Paragraphs[0].Append("Сумма").Bold().FontSize(10);
            bill.Rows[1].Cells[5].Paragraphs[0].Append("146").FontSize(10);
            bill.Rows[2].Cells[5].Paragraphs[0].Append("0").FontSize(10);
            bill.Rows[3].Cells[5].Paragraphs[0].Append("0").FontSize(10);
            bill.Rows[4].Cells[5].Paragraphs[0].Append("126,44").FontSize(10);
            bill.Rows[5].Cells[5].Paragraphs[0].Append("0").FontSize(10);
            bill.Rows[6].Cells[5].Paragraphs[0].Append("6352").FontSize(10);

            wordDoc.InsertParagraph().InsertTableAfterSelf(bill);

            Table total = wordDoc.AddTable(3, 3);
            total.SetColumnWidth(0, 300);
            total.Design = TableDesign.Custom;

            total.Rows[0].Cells[1].Paragraphs[0].Append("Итого:").Bold().FontSize(10).Alignment = Alignment.right;
            total.Rows[0].Cells[2].Paragraphs[0].Append("6624,44").FontSize(10);
            total.Rows[1].Cells[1].Paragraphs[0].Append("Без НДС:").Bold().FontSize(10).Alignment = Alignment.right;
            total.Rows[1].Cells[2].Paragraphs[0].Append("-").FontSize(10);
            total.Rows[2].Cells[1].Paragraphs[0].Append("Всего к оплате:").Bold().FontSize(10).Alignment = Alignment.right;
            total.Rows[2].Cells[2].Paragraphs[0].Append("6624,44").FontSize(10);

            wordDoc.InsertParagraph().InsertTableAfterSelf(total);

            wordDoc.InsertParagraph("Всего наименований 6, на сумму 6624,44 руб.");
            wordDoc.InsertParagraph("Шесть тысяч шестьсот двадцать четыре рубля сорок четыре копейки").Bold();
            wordDoc.InsertParagraph("Внимание!").LineSpacingBefore = 10;
            wordDoc.InsertParagraph("Оплата данного счета означает согласие с условиями поставки товара.\n" +
                "Уведомление об оплате обязательно, в противном случае не гарантируется наличие товара на складе.\n" +
                "Товар отпускается по факту прихода денег на р / с Поставщика, самовывозом, при наличии доверенности и паспорта.");
            wordDoc.InsertParagraph("__________________________________________________________________________________").Bold();
            wordDoc.InsertParagraph("Руководитель\tКопосова Ю.Н. \nБухгалтер\tКопосова Ю.Н.").LineSpacingBefore = 10;

            DocX.ConvertToPdf(wordDoc, "Bill.pdf");
        }
    }
}
