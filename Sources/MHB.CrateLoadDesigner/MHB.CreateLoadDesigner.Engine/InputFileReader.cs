#region Using directives
using System;
using System.Collections.Generic;
using System.IO;

using ExcelDataReader;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    internal class InputFileReader : IDisposable
    {
        public bool LoadFile(string filePath, ref string projName, List<DefFrame> listFrames, List<DefGlass> listGlass)
        {
            listFrames.Clear();
            listGlass.Clear();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Use the reader methods
                    do
                    {
                        if (string.Equals(reader.Name, SheetNameFrame, StringComparison.InvariantCultureIgnoreCase))
                        {
                            int iRow = 0;
                            while (reader.Read())
                            {
                                if (iRow == 0)
                                    projName = reader.GetString(1);

                                if (iRow > 2)
                                {
                                    string sDataTypeActual = string.Empty;
                                    string sDataTypeExpected = string.Empty;
                                    try
                                    {
                                        sDataTypeExpected = "string"; sDataTypeExpected = reader.GetFieldType(0).ToString();
                                        string projNameRow = reader.GetString(0);  
                                        sDataTypeExpected = "string"; sDataTypeExpected = reader.GetFieldType(1).ToString();
                                        string brand = reader.GetString(1);
                                        sDataTypeExpected = "double"; sDataTypeExpected = reader.GetFieldType(2).ToString();
                                        int number = (int)reader.GetDouble(2);
                                        sDataTypeExpected = "double"; sDataTypeExpected = reader.GetFieldType(3).ToString();
                                        double width = reader.GetDouble(3);
                                        sDataTypeExpected = "double"; sDataTypeExpected = reader.GetFieldType(4).ToString();
                                        double height = reader.GetDouble(4);
                                        sDataTypeExpected = "string"; sDataTypeExpected = reader.GetFieldType(5).ToString();
                                        string description = reader.GetString(5);
                                        listFrames.Add(new DefFrame() { Brand = brand, Description = description, Width = width, Height = height, Number = number });
                                    }
                                    catch (Exception /*ex*/)
                                    {
                                        throw new Exception($"Sheet: {SheetNameFrame} - Row: {iRow} => Invalid field type -> Expected : Actual : {sDataTypeActual}");
                                    }
                                }
                                ++iRow;
                            }
                        }
                        else if (string.Equals(reader.Name, SheetNameGlass, StringComparison.InvariantCultureIgnoreCase))
                        {
                            int iRow = 0;
                            while (reader.Read())
                            {
                                if (iRow > 1)
                                {
                                    string sDataTypeActual = string.Empty;
                                    string sDataTypeExpected = string.Empty;

                                    try
                                    {
                                        sDataTypeExpected = "string"; sDataTypeExpected = reader.GetFieldType(0).ToString();
                                        string projNameRow = reader.GetString(0);
                                        sDataTypeExpected = "string"; sDataTypeExpected = reader.GetFieldType(1).ToString();
                                        string brand = reader.GetString(1);
                                        sDataTypeExpected = "double"; sDataTypeExpected = reader.GetFieldType(2).ToString();
                                        int number = (int)reader.GetDouble(2);
                                        sDataTypeExpected = "string"; sDataTypeExpected = reader.GetFieldType(3).ToString();
                                        double width = reader.GetDouble(3);
                                        sDataTypeExpected = "string"; sDataTypeExpected = reader.GetFieldType(4).ToString();
                                        double height = reader.GetDouble(4);
                                        listGlass.Add(new DefGlass() { Brand = brand, Width = width, Height = height, Number = number });
                                    }
                                    catch (Exception /*ex*/)
                                    {
                                        throw new Exception($"Sheet: {SheetNameFrame} - Row: {iRow} => Invalid field type -> Expected : Actual : {sDataTypeActual}");
                                    }
                                }
                                ++iRow;
                            }
                        }
                    } while (reader.NextResult());
                }
            }
            return true;
        }

        public void Dispose()
        {
        }

        internal string SheetNameFrame { get; set; } = "Puidelen";
        internal string SheetNameGlass { get; set; } = "Glass";
    }
}
