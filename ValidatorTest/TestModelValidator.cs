using ModelValidator.Interfaces;
using System;
using System.Collections.Generic;

namespace ValidatorTest
{
    public sealed class TestModelValidator : IModelValidator
    {
        private IEvaluateField _validFields;
        private readonly TestModel _testModel;

        public TestModelValidator(TestModel model)
        {
            _testModel = model;
            _validFields = new TestEvaluateField(_testModel.TestField);
        }

        public void Validate(Action OnSuccess, Action<string> OnFailed)
        {
            bool isValid = _validFields.Check();

            if (isValid)
            {
                OnSuccess();
            }
            else
            {
                _validFields.Interrupt();
                OnFailed(_validFields.GetErrorMessage());
                return;
            }
        }
    }
}
