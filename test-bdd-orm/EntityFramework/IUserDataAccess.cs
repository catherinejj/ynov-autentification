namespace EntityFramework{
    public interface IUserDataAccess{
        Task<User> FindByEmail(string email);
        Task Save(User user);
    }
}