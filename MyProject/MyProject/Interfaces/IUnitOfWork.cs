
using Microsoft.EntityFrameworkCore;
using MyProject.DataModels;
using System;

namespace MyProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        MyDbContext Context { get; }
        void Commit();
    }
}
