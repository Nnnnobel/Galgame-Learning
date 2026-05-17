using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Text;


public class ExcelReader
{
    public struct ExcelData
    {
        public string Speaker;
        public string Content;
    }

    public static List<ExcelData> ReadExcel(string filePath)
{
    List<ExcelData> excelData = new List<ExcelData>();
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//支持中文日文编码

    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
    {
        using (var reader = ExcelReaderFactory.CreateReader(stream))
        {
            do
            {
                while (reader.Read())
                {
                    ExcelData data = new ExcelData();
                    data.Speaker = reader.GetString(0);
                    data.Content = reader.GetString(1);

                    excelData.Add(data);
                }

            } while (reader.NextResult());
        }
    }

    return excelData;
}
}
