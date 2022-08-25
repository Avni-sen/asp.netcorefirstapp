using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic Constraint (generic kısıtlama)
    //IEntity : IEntity olabilir ya da bu IEntity yi implament edeen bir nesne olabilir.
    //new() : new'lenebilir olmalı çünkü IEntity newlenemez böylece T parametresi yerine IEntity de yazılmasını engelledik!!!!
    public interface IEntityRepository<T> where T:class,IEntity,new()
        //T değerini sınırlandıralım!!
        //T where class demek T için referans tipi olarak class verebiliriz anlamına geliyor.
        //ve T sadece IEntity tipinde bir parametre alabilir bu şekilde T parametremizi sınırlandırdıl vve 
        //kontrol sağlamış olduk.

        //her bir entity nesnemiz için ayrı ayrı dal katmanı oluşturmak yerine tek bir IEntityRepository oluşturup T parametremizi vererek fazla kod yazma yükünden 
        //kurtulabiliriz.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        //bir expression oluşturarak iş katmanımızda verilerin listelenmesini sağlarken oluşabilecek sıkıntıları engellemek amacımız 
        // atıyorum categoryıd si 2 olanları listele gibi bir sorgu yazarken hata almamak için bu expressionu yazmalıyız.
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<Product> GetAllByCategory(int categoryId);
        // tukarıdaki expression kodlarını yazdıktan sonra bu kısma ihtiyacımız kalmadı.
    }
}
