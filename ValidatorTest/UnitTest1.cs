using Models.Authirization;
using ModelValidator;
using ModelValidator.ModelsValidator;
using NUnit.Framework;
using System;

namespace ValidatorTest
{
    public class Tests
    {
        Validator v = new Validator(new TestModel());

        [SetUp]
        public void Setup()
        {
            v.OnSuccess += () => Console.WriteLine("Всё ок!");
            v.OnFailed += (m) => throw new Exception(m);
        }

        [Test]
        public void Test1()
        {
            v.CompareWith(new TestModelValidator(new TestModel() { TestField = "121212" }));
        }

        [Test]
        public void Test2()
        {
            v.CompareWith(new TestModelValidator(new TestModel() { TestField = "" }));
            Assert.Pass(); 
        }
    }
}