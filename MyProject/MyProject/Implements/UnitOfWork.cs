using Microsoft.EntityFrameworkCore;
using MyProject.DataModels;
using MyProject.Interfaces;
using System;

namespace MyProject.Implements
{
    public class UnitOfWork : IUnitOfWork
    {

        public MyDbContext Context { get; }

        public UnitOfWork(MyDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
