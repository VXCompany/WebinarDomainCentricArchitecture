namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
