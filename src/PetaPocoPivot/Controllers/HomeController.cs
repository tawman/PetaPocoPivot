using System.Web.Mvc;
using DoddleReport;
using DoddleReport.Web;
using PetaPocoPivot.Services;

namespace PetaPocoPivot.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRepository _repository = new Repository();

		public ActionResult Index()
		{
			var results = _repository.GetEmployeeReport();
			return View(results);
		}

		public ReportResult PivotReport()
		{
			var results = _repository.GetEmployeeReport();
			var report = new Report(results.ToReportSource());
			return new ReportResult(report);
		}
	}
}
