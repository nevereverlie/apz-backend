using System;
using Apz_backend.Interfaces;

namespace Apz_backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IUserRepository Users { get; }
        public IAuthRepository Auth { get; }
        public UnitOfWork(
            DataContext context,
            IUserRepository userRepository,
            IAuthRepository authRepository)
        {
            _context = context;

            Users = userRepository;
            Auth = authRepository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}