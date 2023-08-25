Made a simple vulnerability assessment tool that works with OWASP ZAP for scanning fintech websites. Its automatec using ZAP's API and can save rsults to a text file.

You need to have ZAP and .NET Core SDK installeed and setup 

To use it you need to 
1.Clone the repo
2. Go to the project directory and go to the FintechSecurityTool package
3. Make sure ZAP is running in daemon mode (go to cmd and navigate to the file location then do zap.bat -daemon) 
run the application using dotnet run
