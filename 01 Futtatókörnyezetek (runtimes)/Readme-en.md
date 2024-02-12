# Multi-component application, project and assembly references

MultiComponentApp.sln is a solution with three projects.
- HelloApp: an application that is to use the classes in the two libraries (Crypto and Math)
- Math: library, for mathematical operations
- Crypto: library for data encryption operations

In the initial solution in HelloApp (Program.cs), we cannot use the classes in the other two libraries (we get a compilation error if we try) because there is no project or assembly reference to the libraries yet.

## Demo 1 - project reference

In the HelloApp project, make a project reference to the Math project. We can now use the class it contains. Let's try it:
* The code commented out under "#1" in the Main function should be activated. 
* The `HelloApp` should be the startup project (you only need to do it once: right click on the HelloApp project in Solution Explorer and select "Set as Startup Project").
* You can also run it in debugger (e.g. by placing a breakpoint on the `int sum = Math.BasicMath.Add(10, 20)` line and starting it with F5), you can step into the code of the libraries during debugging with the "Step Into" function.

## Demo 2 - assembly reference

Assume that we don't have the source code for the Crypto library, we only have the Crypto library in compiled form (e.g. from an external company), so we only have Crypto.dll. In this case, an assembly reference should be added (to Crypto.dll). Remove the Crypto project from the solution (simulating that it does not have its source), put the assembly reference to Crypto.dll (located in the output folder of the project). Let's try to make sure we can actually use the code in it (this is done by activating the code under "#2" in the Main function).

## Demo 3 - NuGet packages

Our task is to read data from a CSV (comma separated values) text file into .NET objects. Sample file: HelloApp/Data/SampleFile.txt, let's look at this. We want to read the contents of the CSV file into the objects of the Person class in the HelloApp project. For processing CSV files a NuGet package called CsvHelper exists. Search for it on NuGet.org. Reference it in the HelloApp project using Visual Studio:
- HelloApp project (right click), "Manage NuGet Packages".
- Under the Browse tab, look for CsvHelper
- Select one version older than the latest on the right
- Install
- Let's try it out and see if it really works: In the Main function, activate code under "#3", compile and run: it prints the data of the parsed persons to the console.

Upgrade your NuGet package to the latest version now under "Manage NuGet Packages", this can also be done conveniently from Visual Studio.