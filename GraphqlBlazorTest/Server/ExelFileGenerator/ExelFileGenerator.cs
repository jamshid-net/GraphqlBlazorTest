using ClosedXML.Excel;
using GraphqlBlazorTest.Server.Data;
using System.Data;

namespace GraphqlBlazorTest.Server.ExelFileGenerator;
public  class ExelFileGenerator<T>
{
   

    public  async Task<ExcelReportResponse> Handle(List<T> lists,string fileName)
    {
        using (XLWorkbook wb = new XLWorkbook())
        {
            var userData = await GetDatatable(lists);
            var sheet1 = wb.AddWorksheet(userData, typeof(T).Name);

            sheet1.Columns().AdjustToContents(20.0, 80.0);
            sheet1.RowHeight = 20;
            using (MemoryStream ms = new MemoryStream())
            {
                wb.SaveAs(ms);
                return new ExcelReportResponse(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{fileName}.xlsx");

            }
        }
    }
    private async Task<DataTable> GetDatatable(List<T> values)
    {
        var props = typeof(T).GetProperties();
  
        DataTable dt = new DataTable();
        dt.TableName = typeof(T).Name;

        foreach (var item in props)
            dt.Columns.Add(item.Name, item.PropertyType);
        
        if(values.Count > 0)
        {
            foreach (var item in values)
            {
                
                object?[]? vals = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                     vals[i] = props[i].GetValue(item);
                
                dt.Rows.Add(vals);
                vals = null;    
                
            }
        }
      
        return await Task.FromResult(dt);
    }
}
public record ExcelReportResponse(byte[] FileContents, string Option, string FileName);