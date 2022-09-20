using ArchiMed.Models;

namespace ArchiMed.Services;

public class UserService : IUserService
{
    private readonly ArchiMedDB _context;

    public UserService(ArchiMedDB context)
        {
            _context = context;
        }
    
    public User Get(UserLogin userLogin)
    {
        User user = _context.Doctors.FirstOrDefault(o => o.email.Equals(userLogin.email, StringComparison.OrdinalIgnoreCase) && o.passwod.Equals(userLogin.password));
        return user;
    }
}