using Apz_backend.Interfaces;

namespace Apz_backend.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository Users { get; }
         IAuthRepository Auth { get; }
         IMedicationRepository Medications { get; }
         int SaveChanges();
    }
}