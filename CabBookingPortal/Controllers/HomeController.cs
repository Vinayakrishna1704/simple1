//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using CabBookingPortal.Utils;
//using CabBookingPortal.Repositories;
//using CabBookingPortal.ViewModels;

//namespace CabBookingPortal.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly UnitOfWork unitOfWork = new();
//        private readonly Dictionary<int, string> shiftsDict = new();

//        public HomeController()
//        {
//            foreach (Shift shift in unitOfWork.ShiftRepository.Get())
//            {
//                shiftsDict.Add(shift.ShiftId, $"{shift.ShiftName}|{shift.ShiftIn}|{shift.ShiftOut}");
//            }
//        }
//        //public IActionResult Index()
//        //{
//        //    return View();
//        //}

//        //public IActionResult Index(string fromdate,string toDate )
//        //{

//        //        if (LoginManager.User is null) return RedirectToAction("Login");

//        //        ViewData["shifts"] = shiftsDict;
//        //        Employee? emp = LoginManager.User;

//        //    //var dateTime = DateTime.Parse(fromdate);
//        //    //var start = DateOnly.FromDateTime(dateTime);
//        //    //var datetime2 = DateTime.Parse(toDate);
//        //    //var end = DateOnly.FromDateTime(datetime2);

//        //    //using (var context = new CabBookingPortalContext())
//        //    //{

//        //    //    var employees = context.Employees.FirstOrDefault(e => e.EmpId == emp.EmpId);
//        //    //    var shifts = context.Shifts.FirstOrDefault(e => e.ShiftId == emp.ShiftId);
//        //    //    var requests = context.Requests.FirstOrDefault(e=>e.EmpId==emp.EmpId);
//        //    //    var requestStatuses = context.RequestStatuses.FirstOrDefault(e => e.StatusId ==requests.ReqStatus);
//        //    //    var vehicles = context.Vehicles.FirstOrDefault(e => e.VehicleId==requests.VehicleId);
//        //    //    var drivers = context.Drivers.FirstOrDefault(e=>e.VehicleId==requests.VehicleId);

//        //    //// Create dictionaries for quick lookup
//        //    ////var vehicleDict = vehicles.ToDictionary(v => v.VehicleId);
//        //    ////    var driverDict = drivers.ToDictionary(d => d.DriverId);

//        //    //    MultipleViewModel viewModel = new MultipleViewModel()
//        //    //    {
//        //    //        RequestStatusess = requestStatuses,
//        //    //        Employees = employees,
//        //    //        shiftss = shifts,
//        //    //        vehicless = vehicles,
//        //    //        Driverss = drivers,
//        //    //        Requestss = requests
//        //    //        //VehicleDict = vehicleDict,
//        //    //        //DriverDict = driverDict
//        //    //    };

//        //    //    return View(viewModel);
//        //    //}

//        //    using (var context = new CabBookingPortalContext())
//        //    {
//        //        var query = from e in context.Employees
//        //                    join s in context.Shifts on e.ShiftId equals s.ShiftId
//        //                    join r in context.Requests on e.EmpId equals r.EmpId
//        //                    join v in context.Vehicles on r.VehicleId equals v.VehicleId
//        //                    join d in context.Drivers on v.VehicleId equals d.VehicleId
//        //                    join rs in context.RequestStatuses on r.ReqStatus equals rs.StatusId
//        //                    where e.EmpId == emp.EmpId 
//        //                    select new
//        //                    {
//        //                        Employee = e,
//        //                        Shift = s,
//        //                        Request = r,
//        //                        Vehicle = v,
//        //                        Driver = d,
//        //                        RequestStatus = rs
//        //                    };

//        //        var results = query.ToList();

//        //        var viewModel = new MultipleViewModel();

//        //        foreach (var result in results)
//        //        {
//        //            viewModel.Employees.Add(result.Employee);
//        //            viewModel.Shiftss.Add(result.Shift);
//        //            viewModel.Requestss.Add(result.Request);
//        //            viewModel.Vehicless.Add(result.Vehicle);
//        //            viewModel.Driverss.Add(result.Driver);
//        //            viewModel.RequestStatusess.Add(result.RequestStatus);
//        //        }

//        //        return View(viewModel);
//        //    }
//        //}

//        public IActionResult Index()
//        {
//            if (LoginManager.User is null) return RedirectToAction("Login");

//            ViewData["shifts"] = shiftsDict;
//            Employee? emp = LoginManager.User;

//            using (var context = new CabBookingPortalContext())
//            {
//                var query = from e in context.Employees
//                            join s in context.Shifts on e.ShiftId equals s.ShiftId
//                            join r in context.Requests on e.EmpId equals r.EmpId
//                            join v in context.Vehicles on r.VehicleId equals v.VehicleId
//                            join d in context.Drivers on v.VehicleId equals d.VehicleId
//                            join rs in context.RequestStatuses on r.ReqStatus equals rs.StatusId
//                            where e.EmpId == emp.EmpId
//                            select new 
//                            {
//                                Employee = e,
//                                Shift = s,
//                                Request = r,
//                                Vehicle = v,
//                                Driver = d,
//                                RequestStatus = rs
//                            };

//                var results = query.ToList();

//                var viewModel = new MultipleViewModel();

//                foreach (var result in results)
//                {
//                    viewModel.Employees.Add(result.Employee);
//                    viewModel.Shiftss.Add(result.Shift);
//                    viewModel.Requestss.Add(result.Request);
//                    viewModel.Vehicless.Add(result.Vehicle);
//                    viewModel.Driverss.Add(result.Driver);
//                    viewModel.RequestStatusess.Add(result.RequestStatus);
//                }

//                return View(viewModel);
//            }
//        }
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CabBookingPortal.Utils;
using CabBookingPortal.Repositories;
using CabBookingPortal.ViewModels;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CabBookingPortal.Controllers
{

    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork = new();
        private readonly Dictionary<int, string> shiftsDict = new();

        public HomeController()
        {
            foreach (Shift shift in unitOfWork.ShiftRepository.Get())
            {
                shiftsDict.Add(shift.ShiftId, $"{shift.ShiftName}|{shift.ShiftIn}|{shift.ShiftOut}");
            }
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    if (LoginManager.User is null) return RedirectToAction("Login");

        //    ViewData["shifts"] = shiftsDict;
        //    Employee? emp = LoginManager.User;
        //    var viewmodel = new MultipleViewModel();
        //    return View(viewmodel);
        //}
        //    //var start = DateOnly.Parse(fromDate);
        //    //var end = DateOnly.Parse(toDate);
        //    //Console.WriteLine(start);
        //    //Console.WriteLine(end); 

        //    using (var context = new CabBookingPortalContext())
        //    {
        //        var query = from e in context.Employees
        //                    join s in context.Shifts on e.ShiftId equals s.ShiftId
        //                    join r in context.Requests on e.EmpId equals r.EmpId
        //                    join v in context.Vehicles on r.VehicleId equals v.VehicleId
        //                    join d in context.Drivers on v.VehicleId equals d.VehicleId
        //                    join rs in context.RequestStatuses on r.ReqStatus equals rs.StatusId
        //                    where e.EmpId == emp.EmpId /*&& r.BookingDate>=start && r.BookingDate<=end*/
        //                    select new
        //                    {
        //                        Employee = e,
        //                        Shift = s,
        //                        Request = r,
        //                        Vehicle = v,
        //                        Driver = d,
        //                        RequestStatus = rs
        //                    };

        //        var results = query.ToList();

        //        var viewModel = new MultipleViewModel();

        //        foreach (var result in results)
        //        {
        //            viewModel.Employees.Add(result.Employee);
        //            viewModel.Shiftss.Add(result.Shift);
        //            viewModel.Requestss.Add(result.Request);
        //            viewModel.Vehicless.Add(result.Vehicle);
        //            viewModel.Driverss.Add(result.Driver);
        //            viewModel.RequestStatusess.Add(result.RequestStatus);
        //        }
        //        viewModel.Employee = emp;
        //        viewModel.Shift = context.Shifts.First(e => e.ShiftId == emp.ShiftId);

        //        return View(viewModel);
        //    }
        //}
        //[HttpGet("fromDate={fromDate}&toDate={toDate}")]
        //DateOnly fromDate,DateOnly toDate
        [HttpGet]
        public IActionResult Index(DateOnly? fromDate, DateOnly? toDate)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");

            ViewData["shifts"] = shiftsDict;
            Employee? emp = LoginManager.User;
            //string fromDate = Request["fromDate"].ToString();



            

            //if (!string.IsNullOrEmpty(fromDate))
            //{
            //    //if (Dat.TryParse(fromDate, out DateTime parsedStartDate))
            //    if(DateOnly.TryParse(fromDate,out DateOnly parsedstart))
            //    {
            //        start = parsedstart;
            //    }
            //}

            //if (!string.IsNullOrEmpty(toDate))
            //{
            //    if (DateOnly.TryParse(toDate, out DateOnly parsedend))
            //    {
            //        end = parsedend;
            //    }
            //}
            using (var context = new CabBookingPortalContext())
            {
                var query = from e in context.Employees
                            join s in context.Shifts on e.ShiftId equals s.ShiftId
                            join r in context.Requests on e.EmpId equals r.EmpId
                            join v in context.Vehicles on r.VehicleId equals v.VehicleId
                            join d in context.Drivers on v.VehicleId equals d.VehicleId
                            join rs in context.RequestStatuses on r.ReqStatus equals rs.StatusId
                            join ro in context.Routes on v.RouteName equals ro.RouteId
                            where e.EmpId == emp.EmpId 
                            orderby r.BookingDate
                            select new
                            {
                                Employee = e,
                                Shift = s,
                                Request = r,
                                Vehicle = v,
                                Driver = d,
                                RequestStatus = rs,
                                Routes=ro
                            };

                //Console.WriteLine($"{fromDate.ToString()} {toDate.ToString()}");
                if (fromDate.HasValue)
                {
                    if (toDate.HasValue)
                    {
                        query = query.Where(q => q.Request.BookingDate >= fromDate.Value && q.Request.BookingDate<=toDate.Value);
                    }
                    else
                    {
                        query = query.Where(q => q.Request.BookingDate >= fromDate.Value);
                    }
                }

                var results = query.ToList();

                var viewModel = new MultipleViewModel();

                foreach (var result in results)
                {
                    viewModel.Employees.Add(result.Employee);
                    viewModel.Shiftss.Add(result.Shift);
                    viewModel.Requestss.Add(result.Request);
                    viewModel.Vehicless.Add(result.Vehicle);
                    viewModel.Driverss.Add(result.Driver);
                    viewModel.RequestStatusess.Add(result.RequestStatus);
                    viewModel.Routes.Add(result.Routes);
                }
                viewModel.Employee = emp;
                viewModel.Shift = context.Shifts.First(e => e.ShiftId == emp.ShiftId);

                return View(viewModel);
            }

        }
        

       



        //[HttpPost]
        //public IActionResult Index(string fromDate,string toDate)
        //{
        //    if (LoginManager.User is null) return RedirectToAction("Login");

        //    ViewData["shifts"] = shiftsDict;
        //    Employee? emp = LoginManager.User;
        //    var start = DateOnly.Parse(fromDate);
        //    var end = DateOnly.Parse(toDate);
        //    //Console.WriteLine(start);
        //    //Console.WriteLine(end); 

        //    using (var context = new CabBookingPortalContext())
        //    {
        //        var query = from e in context.Employees
        //                    join s in context.Shifts on e.ShiftId equals s.ShiftId
        //                    join r in context.Requests on e.EmpId equals r.EmpId
        //                    join v in context.Vehicles on r.VehicleId equals v.VehicleId
        //                    join d in context.Drivers on v.VehicleId equals d.VehicleId
        //                    join rs in context.RequestStatuses on r.ReqStatus equals rs.StatusId
        //                    where e.EmpId == emp.EmpId /*&& r.BookingDate>=start && r.BookingDate<=end*/
        //                    select new
        //                    {
        //                        Employee = e,
        //                        Shift = s,
        //                        Request = r,
        //                        Vehicle = v,
        //                        Driver = d,
        //                        RequestStatus = rs
        //                    };

        //        var results = query.ToList();

        //        var viewModel = new MultipleViewModel();

        //        foreach (var result in results)
        //        {
        //            viewModel.Employees.Add(result.Employee);
        //            viewModel.Shiftss.Add(result.Shift);
        //            viewModel.Requestss.Add(result.Request);
        //            viewModel.Vehicless.Add(result.Vehicle);
        //            viewModel.Driverss.Add(result.Driver);
        //            viewModel.RequestStatusess.Add(result.RequestStatus);
        //        }
        //        viewModel.Employee = emp;
        //        viewModel.Shift=context.Shifts.First(e=>e.ShiftId==emp.ShiftId);

        //        return View(viewModel);
        //    }
        //}

        // Other action methods...









        public IActionResult CreateRequests()
        {
            if (LoginManager.User is null) return RedirectToAction("Login");

            return View();
        }

        public IActionResult EditRequests()
        {
            if (LoginManager.User is null) return RedirectToAction("Login");

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int empId, string password)
        {
            var employee = unitOfWork.EmployeeRepository.GetByID(empId);
       

            if (employee != null && employee.Password == password)
            {
                LoginManager.Login(employee);
                var req  = unitOfWork.RequestRepository.GetByID(empId);

                if (employee.IsAdmin) return RedirectToAction("Approval", "Admin");
                else return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Logout()
        {
            LoginManager.Logout();
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}