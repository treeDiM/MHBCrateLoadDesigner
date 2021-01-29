#region Using directives
using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

using MHB.CrateLoadDesigner.Engine;
using MHB.CrateLoadDesigner.Exporters.Properties;
#endregion

namespace MHB.CrateLoadDesigner.Exporters
{
    public class ExporterTableOfContents : Exporter
    {
        public string TemplateFilePath => Settings.Default.FilePathTemplateTableOfContents;
        public string SheetName(short index) => $"Partlist - Crate - {index}";
        public bool QuitApp { get; set; } = false;

        public override void Export(Project proj, string outputFilePath)
        {
            // copy template
            if (!File.Exists(TemplateFilePath))
                throw new FileNotFoundException(TemplateFilePath);
            File.Copy(TemplateFilePath, outputFilePath, true);

            Application xlApp = new Application
            {
                Visible = true,
                DisplayAlerts = false
            };
            Workbooks xlWorkBooks = xlApp.Workbooks;
            Workbook xlWorkBook = xlWorkBooks.Open(outputFilePath, Type.Missing, false);

            short crateIndex = 1;
            foreach (var crate in proj.ListCrateFrame)
            {
                Worksheet xlWorkSheet = xlWorkBook.Worksheets.get_Item(crateIndex) as Worksheet;

                int iRow = 18;

                var dictContent = crate.ContentDict;
                foreach (var defFrame in dictContent.Keys)
                {
                    // cell Part batch Nr
                    Range cellPartBatchNr = xlWorkSheet.get_Range("b" + iRow, "b" + iRow);
                    cellPartBatchNr.Value = defFrame.Brand;
                    // cell mark reg
                    Range cellMarkReg = xlWorkSheet.get_Range("c" + iRow, "c" + iRow);
                    cellMarkReg.Value = defFrame.Description;
                    // width
                    Range cellWidth =  xlWorkSheet.get_Range("e" + iRow, "e" + iRow);
                    cellWidth.Value = $"{defFrame.Width}";
                    // height
                    Range cellHeight =  xlWorkSheet.get_Range("g" + iRow, "g" + iRow);
                    cellHeight.Value = $"{defFrame.Height}";
                    // thickness
                    Range cellThickness =  xlWorkSheet.get_Range("i" + iRow, "i" + iRow);
                    cellThickness.Value = $"{Project.FrameThickness}";
                    // quantity
                    Range cellPacked = xlWorkSheet.get_Range("j" + iRow, "j" + iRow);
                    cellPacked.Value = $"{dictContent[defFrame]}";
                    ++iRow;
                }
                ++crateIndex;
            }
            foreach (var crate in proj.ListCrateGlass)
            {
                Worksheet xlWorkSheet = xlWorkBook.Worksheets.get_Item(crateIndex) as Worksheet;

                int iRow = 18;

                var dictContent = crate.ContentDict;
                foreach (var defGlass in dictContent.Keys)
                {
                    // cell Part batch Nr
                    Range cellPartBatchNr = xlWorkSheet.get_Range("b" + iRow, "b" + iRow);
                    cellPartBatchNr.Value = defGlass.Brand;
                    // width
                    Range cellWidth = xlWorkSheet.get_Range("e" + iRow, "e" + iRow);
                    cellWidth.Value = $"{defGlass.Width}";
                    // height
                    Range cellHeight = xlWorkSheet.get_Range("g" + iRow, "g" + iRow);
                    cellHeight.Value = $"{defGlass.Height}";
                    // thickness
                    Range cellThickness = xlWorkSheet.get_Range("i" + iRow, "i" + iRow);
                    cellThickness.Value = $"{Project.FrameThickness}";
                    // quantity
                    Range cellPacked = xlWorkSheet.get_Range("j" + iRow, "j" + iRow);
                    cellPacked.Value = $"{dictContent[defGlass]}";

                    ++iRow;
                }
                ++crateIndex;
            }
            xlWorkBook.Save();

 
            xlWorkBook.Close();
            if (QuitApp)
                xlApp.Quit();

            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
