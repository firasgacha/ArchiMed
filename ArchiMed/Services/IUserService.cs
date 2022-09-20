using ArchiMed.Models;

namespace ArchiMed.Services;

public interface IUserService
{
        public User Get(UserLogin userLogin);
} 