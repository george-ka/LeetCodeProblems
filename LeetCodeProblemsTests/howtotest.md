## How to test

run 
dotnet test --logger trx

to get results in trx format,
Install TRX viwer extension  to view TRX results
and .NET Core Test Explorer for VSCode to run tests selectively.

To debug a test you may use
while(!Debugger.IsAttached) Thread.Sleep(500);

and then attach with vscode debugger