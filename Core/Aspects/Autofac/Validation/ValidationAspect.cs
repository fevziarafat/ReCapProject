using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //aspect metodun herhangi bir yerinde çalışmasını istediğimiz kod
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensice coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Ivalidator mü
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //BrandValidator tipine çevir new le
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  //reflection kodu ile new lendi
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //validator edilecek entity i bul brand
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
