using CabBookingPortal.Models;

namespace CabBookingPortal.Repositories
{
    public class UnitOfWork: IDisposable
    {
        private CabBookingPortalContext context = new();
        private GenericRepository<Employee>? employeeRepository;
        private GenericRepository<Driver>? driverRepository;
        private GenericRepository<Models.Route>? routeRepository;
        private GenericRepository<Vehicle>? vehicleRepository;
        private GenericRepository<Request>? requestRepository;
        private GenericRepository<Shift>? shiftRepository;
        private GenericRepository<CostCenter>? costCenterRepository;

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                employeeRepository ??= new GenericRepository<Employee>(context);
                return employeeRepository;
            }
        }

        public GenericRepository<Driver> DriverRepository
        {
            get
            {
                driverRepository ??= new GenericRepository<Driver>(context);
                return driverRepository;
            }
        }

        public GenericRepository<Models.Route> RouteRepository
        {
            get
            {
                routeRepository ??= new GenericRepository<Models.Route>(context);
                return routeRepository;
            }
        }

        public GenericRepository<Vehicle> VehicleRepository
        {
            get
            {
                vehicleRepository ??= new GenericRepository<Vehicle>(context);
                return vehicleRepository;
            }
        }

        public GenericRepository<Request> RequestRepository
        {
            get
            {
                requestRepository ??= new GenericRepository<Request>(context);
                return requestRepository;
            }
        }

        public GenericRepository<Shift> ShiftRepository
        {
            get
            {
                shiftRepository ??= new GenericRepository<Shift>(context);
                return shiftRepository;
            }
        }

        public GenericRepository<CostCenter> CostCenterRepository
        {
            get
            {
                costCenterRepository ??= new GenericRepository<CostCenter>(context);
                return costCenterRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
