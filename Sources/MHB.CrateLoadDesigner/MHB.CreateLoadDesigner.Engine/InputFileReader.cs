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
                                    Type dataTypeActual = null;
                                    string sDataTypeExpected = string.Empty;
                                    try
                                    {
                                        sDataTypeExpected = "string"; dataTypeActual = reader.GetFieldType(0);
                                        string projNameRow = string.Empty;
                                        if (null != dataTypeActual)
                                        {
                                            switch (dataTypeActual.ToString())
                                            {
                                                case "system.string": projNameRow = reader.GetString(0); break;
                                                default: projNameRow = reader.GetValue(0).ToString(); break;
                                            }
                                        }
                                        sDataTypeExpected = "string"; dataTypeActual = reader.GetFieldType(1);
                                        string brand = reader.GetString(1);
                                        sDataTypeExpected = "double"; dataTypeActual = reader.GetFieldType(2);
                                        int number = (int)reader.GetDouble(2);
                                        sDataTypeExpected = "double"; dataTypeActual = reader.GetFieldType(3);
                                        double width = reader.GetDouble(3);
                                        sDataTypeExpected = "double"; dataTypeActual = reader.GetFieldType(4);
                                        double height = reader.GetDouble(4);
                                        sDataTypeExpected = "string"; dataTypeActual = reader.GetFieldType(5);
                                        string description = reader.GetString(5);
                                        listFrames.Add(new DefFrame() { Brand = brand, Description = description, Width = width, Height = height, Number = number });
                                    }
                                    catch (Exception /*ex*/)
                                    {
                                        string sDataTypeActual = (null != dataTypeActual ? dataTypeActual.ToString() : "null");
                                        throw new Exception($"Sheet: {SheetNameFrame} - Row: {iRow} => Invalid field type -> Expected: {sDataTypeExpected}  Actual: {sDataTypeActual}");
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
                                if (iRow > 0)
                                {
                                    Type dataTypeActual = null;
                                    string sDataTypeExpected = string.Empty;

                                    try
                                    {

                                        sDataTypeExpected = "string"; dataTypeActual = reader.GetFieldType(0);
                                        string projNameRow = string.Empty;
                                        if (null != dataTypeActual)
                                        {
                                            switch (dataTypeActual.ToString())
                                            {
                                                case "system.string": projNameRow = reader.GetString(0); break;
                                                default: projNameRow = reader.GetValue(0).ToString(); break;
                                            }
                                        }
                                        sDataTypeExpected = "string"; dataTypeActual = reader.GetFieldType(1);
                                        string brand = reader.GetString(1);
                                        sDataTypeExpected = "double"; dataTypeActual = reader.GetFieldType(2);
                                        int number = (int)reader.GetDouble(2);
                                        sDataTypeExpected = "string"; dataTypeActual = reader.GetFieldType(3);
                                        double width = reader.GetDouble(3);
                                        sDataTypeExpected = "string"; dataTypeActual = reader.GetFieldType(4);
                                        double height = reader.GetDouble(4);
                                        listGlass.Add(new DefGlass() { Brand = brand, Width = width, Height = height, Number = number });
                                    }
                                    catch (Exception /*ex*/)
                                    {
                                        string sDataTypeActual = (null != dataTypeActual ? dataTypeActual.ToString() : "null");
                                        throw new Exception($"Sheet: {SheetNameFrame} - Row: {iRow} => Invalid field type -> Expected: {sDataTypeExpected}  Actual: {sDataTypeActual}");
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
