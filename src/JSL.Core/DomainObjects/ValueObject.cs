using FluentValidation.Results;
using System;

namespace JSL.Core.DomainObjects
{
    public abstract class ValueObject
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
