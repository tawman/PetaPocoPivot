PetaPoco DoddleReport Dynamic PIVOT Query Example
=================================================

This sample project is meant to demonstrate how PetaPoco and DoddleReport can work with C# dynamic objects created from a PIVOT query and export the results to HTML and Excel.

Example Source Data
-------------------
I am using the AdventureWorks example database from Microsoft, but more specifically the view named HumanResources.vEmployeeDepartmentHistory.

The [AdventureWorks Database](http://msftdbprodsamples.codeplex.com/releases/view/55926 "Download AdventureWorks Page") is available for download on the CodePlex web site.

Sample Data Loaded for this Example
----------------------------------------------
    SELECT *
    FROM (SELECT EmployeeID, LastName, FirstName, Department, StartDate
          FROM HumanResources.vEmployeeDepartmentHistory) As EmployeeData
    PIVOT (MIN(StartDate) FOR Department IN ({0})) as EmployeePivot

Where *{0}* is substituted with the joined results from this query:

    SELECT DISTINCT '[' + Department + ']'
    FROM HumanResources.vEmployeeDepartmentHistory
    ORDER BY 1

How To Build It?
----------------

From a command window run: *build.bat*

Otherwise, open the Solution file in Visual Studio 2010 and Build

How Do You View It?
-------------------

From the Start menu, click Run, then type *inetmgr* to open the Internet Information Services (IIS) MMC snap-in.

1. Right mouse click on the Default Web Site and Select "Add Application"
2. Enter an Alias for the Site (i.e. *PetaPocoPivot*)
3. Enter the Physical Path (i.e. *C:\PetaPocoPivot\src\PetaPocoPivot*)
4. Open a web browser to: http://localhost/PetaPocoPivot/

Alternatively, Open the PetaPocoPivot.sln Solution in Visual Studio 2010 and explore.

Thanks
------
This software is Open Source and check the LICENSE.txt file for more details.

Todd A. Wood
([@iToddWood](https://twitter.com/#!/iToddWood "Follow me on Twitter"))
Visit [Implement IToddWood](http://www.woodcp.com "Wood Consulting Practice, LLC")
