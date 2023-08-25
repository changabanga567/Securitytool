using System;
using FintechSecurityTool.WebApplicationScanner;

namespace FintechSecurityTool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the target URL for scanning:");
            var targetUrl = Console.ReadLine();

            var scanner = new Scanner();
            var scanId = await scanner.StartScan(targetUrl);
            Console.WriteLine($"Scan initiated with ID: {scanId}");

            string status;
            do
            {
                status = await scanner.GetScanStatus(scanId);
                Console.WriteLine($"Scan Status: {status}");
                await Task.Delay(5000); // Check status every 5 seconds
            }
            while (status != "100%"); // Wait until scan is complete

            var results = await scanner.GetScanResults(scanId);

            var reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport(results);

            Console.WriteLine("Scan completed. Report saved to scanReport.txt");
        }
    }
}
