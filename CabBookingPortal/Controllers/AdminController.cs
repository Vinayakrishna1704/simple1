using System.Text;
using Microsoft.AspNetCore.Mvc;
using CabBookingPortal.Utils;
using CabBookingPortal.Repositories;

namespace CabBookingPortal.Controllers
{
    public class AdminController : Controller
    {
        private readonly UnitOfWork unitOfWork = new();
        private Dictionary<int, string> shiftsDict = [];
        private Dictionary<int, string> routesDict = [];

        public AdminController()
        {
            foreach (Shift shift in unitOfWork.ShiftRepository.Get().ToArray()) shiftsDict.Add(shift.ShiftId, shift.ShiftName);
            foreach (Models.Route route in unitOfWork.RouteRepository.Get().ToArray()) routesDict.Add(route.RouteId, route.RouteName);
        }

        public IActionResult Approval()
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult AssignDriver()
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            ViewData["routes"] = routesDict;
            return View(unitOfWork.VehicleRepository.Get());
        }

        [HttpPost]
        public IActionResult AssignDriver(string vehicleNumber, string routeName, string driverName, string driverNumber, int driverId)
        {
            Vehicle[] vehicles = unitOfWork.VehicleRepository.Get().ToArray();
            Models.Route[] routes = unitOfWork.RouteRepository.Get().ToArray();

            Vehicle? selectedVehicle = Array.Find(vehicles, v => v.VehicleNumber == vehicleNumber);
            Models.Route? selectedRoute = Array.Find(routes, r => r.RouteName == routeName);

            if (selectedVehicle is null || selectedRoute is null) return View();

            Driver newDriver = new()
            {
                DriverId = driverId,
                DriverName = driverName,
                VehicleId = selectedVehicle.VehicleId,
                DriverGender = "M",
                DriverPhone = driverNumber,
                DriverStatus = true,
                DriverBloodgrp = "AB+",
            };

            selectedVehicle.RouteName = selectedRoute.RouteId;
            unitOfWork.VehicleRepository.Update(selectedVehicle);
            unitOfWork.DriverRepository.Insert(newDriver);
            unitOfWork.Save();

            return RedirectToAction("AssignDriver", "Admin");
        }

        public IActionResult Vehicles()
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            ViewData["shifts"] = shiftsDict;
            ViewData["routes"] = routesDict;
            return View(unitOfWork.VehicleRepository.Get());
        }

        public IActionResult DeleteVehicle(int id)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            unitOfWork.VehicleRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Vehicles", "Admin");
        }

        [HttpPost]
        public IActionResult Vehicles(string vehicleNumber, int maxCapacity, string shiftId)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            Vehicle vehicleToAdd = new()
            {
                VehicleNumber = vehicleNumber,
                MaxCapacity = maxCapacity,
                ShiftId = Convert.ToInt32(shiftId),
            };

            unitOfWork.VehicleRepository.Insert(vehicleToAdd);
            unitOfWork.Save();

            return RedirectToAction("Vehicles", "Admin");
        }

        public IActionResult UpdateVehicles(int vehicleId, string newVehicleNumber, int newVehicleCapacity, string shiftId)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            Vehicle? vehicle = unitOfWork.VehicleRepository.GetByID(vehicleId)!;
            vehicle.VehicleNumber = newVehicleNumber;
            vehicle.MaxCapacity = newVehicleCapacity;
            vehicle.ShiftId = Convert.ToInt32(shiftId);
            unitOfWork.VehicleRepository.Update(vehicle);
            unitOfWork.Save();

            return RedirectToAction("Vehicles", "Admin");
        }

        public IActionResult Routes()
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            return View(unitOfWork.RouteRepository.Get());
        }

        public IActionResult UpdateRoute(int routeId, string newRoute)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            Console.WriteLine($"{routeId}, {newRoute}");
            Models.Route route = unitOfWork.RouteRepository.GetByID(routeId)!;
            route.RouteName = newRoute;
            unitOfWork.RouteRepository.Update(route);
            unitOfWork.Save();
            return RedirectToAction("Routes", "Admin");
        }

        [HttpPost]
        public IActionResult Routes(String route)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            Models.Route newRoute = new()
            {
                RouteName = route
            };
            unitOfWork.RouteRepository.Insert(newRoute);
            unitOfWork.Save();

            return RedirectToAction("Routes", "Admin");
        }

        public IActionResult DeleteRoute(int id)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            unitOfWork.RouteRepository.Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Routes", "Admin");
        }

        public IActionResult Report()
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpGet]
        public IActionResult GetReport(string document)
        {
            if (LoginManager.User is null) return RedirectToAction("Login");
            if (!LoginManager.User.IsAdmin) return RedirectToAction("Index", "Home");

            var _db = new CabBookingPortalContext();

            List<Employee>? employees = unitOfWork.EmployeeRepository.Get() as List<Employee>;

            List<CabBooking> bookings = new List<CabBooking>();

            try
            {
                foreach (var emp in employees!)
                {
                    CabBooking booking = new CabBooking();
                    booking.EmployeeName = emp.Username;
                    booking.Department = emp.Department;
                    booking.DatesAvailed = _db.Requests.Where(r => r.EmpId == emp.EmpId).ToList().ToString();
                    if (booking.DatesAvailed!.Equals("")) continue;
                    bookings.Add(booking);
                }

                // Build CSV content
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BookingID,PassengerName,DriverName,BookingDate");
                foreach (var booking in bookings)
                {
                    sb.AppendLine($"{booking.EmployeeName},{booking.Department},{booking.DatesAvailed}");
                }

                // Convert the CSV data to bytes
                byte[] csvBytes = Encoding.UTF8.GetBytes(sb.ToString());

                // Return the CSV file for download
                return File(csvBytes, "text/csv", "CabBookings.csv");
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or display an error message)
                return BadRequest($"Error generating CSV: {ex.Message}");
            }
        }
    }
}