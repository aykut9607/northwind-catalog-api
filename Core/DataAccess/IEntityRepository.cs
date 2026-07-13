using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        //generic constraint
        //class: referans tip olabilir
        //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir demek
        //boylelikle IEntity interface'i implement eden nesneler için kullanabiliriz.(Category,Customer ve Product classları yani)
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        /*
            public List<Product>GetAll()
            {
                return _productDal.GetAll(p=>p.CategoryId==2);
             yani GetAll methodu içinde fitreleme yapmak için bu methodu boyle yapıyoruz.
            burda mesela butun productları getirdikten sonra CategoryId si 2 olanları filtreleyip getiriyor.
            }         
         */
        //filtereleme olmadan da çalışabilmesi için filter=null yaptık.yani getall ile tüm verileri getirebiliriz fitreleme yapmadan.


        T Get(Expression<Func<T, bool>> filter);
        //filtereleme olmasını istiyorsak filter parametresi ile çalıştırabiliriz.ornek id ile getirme gibi
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
