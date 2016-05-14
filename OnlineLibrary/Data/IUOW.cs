namespace Data
{
    public interface IUOW
    {
        IRepository<T> Repository<T>() where T : class;
    }
}
