using System.Collections.Generic;
using PetaPoco;

namespace PetaPocoPivot.Services
{
	public class Repository : IRepository
	{
		private readonly Database _database = new Database("AdventureWorks");

		public IEnumerable<dynamic> GetEmployeeReport()
		{
			var pivotColumns = GetDepartments();

			var pivotQuery =
				string.Format(@"SELECT *
								FROM (SELECT EmployeeID, LastName, FirstName, Department, StartDate
									  FROM HumanResources.vEmployeeDepartmentHistory) As EmployeeData
								PIVOT (MIN(StartDate) FOR Department IN ({0})) as EmployeePivot", pivotColumns);

			return _database.Query<dynamic>(pivotQuery);
		}


		private string GetDepartments()
		{
			var query = Sql.Builder
				.Select("DISTINCT '[' + Department + ']'")
				.From("HumanResources.vEmployeeDepartmentHistory")
				.OrderBy("1");

			return string.Join(",", _database.Query<string>(query));
		}
	}
}