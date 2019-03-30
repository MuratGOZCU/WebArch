using System;
using YK.Core.Engine;
using FluentValidation;
using FluentValidation.Attributes;

namespace YK.Web.Framework
{
    public class AppValidatorFactory : AttributedValidatorFactory
    {
        public override IValidator GetValidator(Type type)
        {
            if (type == null)
                return null;

            var validatorAttribute = (ValidatorAttribute)Attribute.GetCustomAttribute(type, typeof(ValidatorAttribute));
            if (validatorAttribute == null || validatorAttribute.ValidatorType == null)
                return null;

            var instance = EngineContext.Current.IocManager.ResolveUnregistered(validatorAttribute.ValidatorType);

            return instance as IValidator;
        }
    }
}