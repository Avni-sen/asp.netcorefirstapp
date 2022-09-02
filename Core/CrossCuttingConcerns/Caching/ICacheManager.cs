using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //get için ben sana bir key vereyim sen veritabanından T ile getir.
        T Get<T>(string key);

        //key - value ve kac dk duracağını belirtmek için duration tutcaz.
        void Add(string key , object value,int duration);

        object Get(string key);

        //verileri getirirken cache de var mı kontrol için 
        bool IsAdd(string key);

        //cache den silmek için 
        void Remove(string key);

        //cache den belli bir desene göre kaldırmak için.
        void RemoveByPattern(string pattern);
    }
}
