using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //aspect
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)//constractor a bir validator type verdik
        {
            //defensive coding savunma bazlı kodlama...
            //gönderilen validator type bir IValidator type mı kontrolünü yaptık.eğer işlem true ise 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu Bir Doğrulama sınıfı değildir.");
            }
            //eşitleme yaptık.
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {

            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //reflection --> productvalidator u newledik.CreateInstance ile o anlık kullanılırken newledik.

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //ProductValidator ün BaseTypeını seç Yani AbstractValidator<Product> ın GenericArgumanlarından 1.sini seç o da Product...

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //daha sonra invocation un yani Add-Update-Delete gibi işlemlerin  PARAMETRELERİNİ Gez , eğer oradaki type entityType(bir üstteki) ne eşitse
            //onları foreach ile döndür.

            //KODUN EN İYİ ANLAŞILABİLECEĞİ HALİ BU.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
                //VALİDATORTOOL UN VALİDATE FONK. 2 PARAMETRE GÖNDERDİK (ProductValidor ve Product olarak);
            }
        }


    }
}
