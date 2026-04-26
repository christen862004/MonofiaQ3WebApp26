namespace MonofiaQ3WebApp26.Repository
{
    public interface IRepository<T>
    {
        //CRUD
        public List<T> GetAll();
        public T GetById(int id);
        public void Add(T obj);//memory 
        public void Update(T obj);//memory 
        public void Delete(int id);//memory 
        public void Save();//SaveChange
    }
}
