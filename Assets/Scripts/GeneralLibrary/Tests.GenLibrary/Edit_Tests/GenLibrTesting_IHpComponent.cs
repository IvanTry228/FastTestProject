using GenLibrary.GenValues;
using GenLibrary.HpComponents;
using NUnit.Framework;

namespace GenLibrary.Tests.Edit
{
    public class GenLibrTesting_IHpComponent
    {
        [Test]
        public void Test_IHpComponentValues_Decrement()
        {
            //Arrange
            IHpComponent<float> IhpComponent = new HpComponent();
            GeneralValuesMinMax<float> _hpValues = new GeneralValuesMinMax<float>(0f, 100f);
            IhpComponent.InitAndSet(_hpValues);

            //Act
            IhpComponent.DecrementValue(40f, out _);

            //Assert
            var readHpValues = IhpComponent.GetHpValuesRead();
            Assert.AreEqual(readHpValues.current, 60f);
            Assert.AreNotEqual(readHpValues.current, readHpValues.max);

            bool expectedAlive = true;
            Assert.AreEqual(IhpComponent.IsInAlive(), expectedAlive);
            Assert.AreEqual(IhpComponent.IsDead(), !expectedAlive);
        }

        [TestCaseSource(nameof(Params_DecrementAndDie))]
        public void Test_IHpComponentValues_DecrementAndDie(float _min, float _max, float _decrementValue, bool _expectedAlive)
        {
            //Arrange
            IHpComponent<float> IhpComponent = new HpComponent();
            GeneralValuesMinMax<float> _hpValues = new GeneralValuesMinMax<float>(_min, _max);
            IhpComponent.InitAndSet(_hpValues);

            //Act
            IhpComponent.DecrementValue(_decrementValue, out _);

            //Assert
            var readHpValues = IhpComponent.GetHpValuesRead();

            bool expectedAlive = _expectedAlive;

            if (!expectedAlive)
                Assert.AreEqual(readHpValues.current, readHpValues.min);

            Assert.AreEqual(IhpComponent.IsInAlive(), expectedAlive);
            Assert.AreEqual(IhpComponent.IsDead(), !expectedAlive);
        }

        static object[] Params_DecrementAndDie =
        {
            new object[] { 0f, 100f, 60f, true },
            new object[] { 0f, 50f, 60f, false },
            new object[] { 0f, 50f, 25f, true },
            new object[] { -1000f, 200f, 9000f, false },
        };
    }
}
