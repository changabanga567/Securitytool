using System.IO;

namespace FintechSecurityTool.WebApplicationScanner
{
    public class ReportGenerator
    {
        public void GenerateReport(string scanResults, string reportPath = "./scanReport.txt")
        {
            File.WriteAllText(reportPath, scanResults);
        }
    }
}
