﻿
namespace Core.Interfaces.Services
{
    public interface IService<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
