using System.Collections.Generic;

namespace PetaPocoPivot.Services
{
	public interface IRepository
	{
		IEnumerable<dynamic> GetEmployeeReport();
	}
}