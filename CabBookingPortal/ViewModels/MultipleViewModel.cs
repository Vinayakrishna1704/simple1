namespace CabBookingPortal.ViewModels;
using CabBookingPortal.Models;

public class MultipleViewModel
{
    public List<RequestStatus> RequestStatusess { get; set; } = new List<RequestStatus>();
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public List<Shift> Shiftss { get; set; } = new List<Shift>();
    public List<Vehicle> Vehicless { get; set; } = new List<Vehicle>();
    public List<Driver> Driverss { get; set; } = new List<Driver>();
    public List<Request> Requestss { get; set; } = new List<Request>();
    public List<Route> Routes { get; set; } = new List<Route>();
    public Employee Employee { get; set; }

    public Shift Shift { get; set; }

    

}
