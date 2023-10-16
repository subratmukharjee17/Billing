using Billing.RepositoryPattern.DAL.DbContexts;
using Billing.RepositoryPattern.Shared.Interfaces;

namespace Billing.RepositoryPattern.Api.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly ApplicationDbContext _dbContext;
        //public UnitOfWorkService(ApplicationDbContext dbContext, IStudentRepository studentRepository, IStudentSportRepository studentSportRepository, IStudentAddressRepository studentAddressRepository)
        //{
        //    _dbContext = dbContext;
        //    Student = studentRepository;
        //    StudentSport = studentSportRepository;
        //    StudentAddress = studentAddressRepository;
        //}

        public UnitOfWorkService(ApplicationDbContext dbContext, IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _dbContext = dbContext;
            User = userRepository;
            Address = addressRepository;
        }

        public IStudentRepository Student { get; set; }
        public IStudentSportRepository StudentSport { get; set; }
        public IStudentAddressRepository StudentAddress { get; set; }

        public IUserRepository User { get; set; }
        public IAddressRepository Address { get; set; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
