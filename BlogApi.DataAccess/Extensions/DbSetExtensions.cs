using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlogApi.DataAccess.Extensions
{
    public static class DbSetExtensions
    {
        public static void AddEntity<T>(this DbContext context, T entity) where T : Entity
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        //public static void GetLookUp<T>(this DbContext context, T entity, string keyword) where T : Category, HashTag
        //{
        //    var query = context.Set<T>().AsQueryable();
        //    if(!string.IsNullOrEmpty(keyword))
        //    {
        //        query=query.Where(x=>x.)
        //    }
        //}
    }
}
