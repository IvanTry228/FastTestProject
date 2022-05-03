using System.Collections;
using GenLibrary.GenValues;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace GenLibrary.Tests.Edit
{
    public class GenLibrTesting_GeneralValuesMinMax
    {
        [TestCaseSource(nameof(TestingMinMaxCUrrentExpected))]
        public void Test_GetInverseLerp_CoeffBetween(float _min, float _max, float _current, float _expected)
        {
            //Arrange
            var _generalValues = new GeneralValuesMinMax<float>(_min, _max, _current);

            //Act
            _generalValues.SetForciblyCurrentValue(_current);

            //Assert
            Assert.AreEqual(_expected, _generalValues.GetInverseLerp_CoeffBetween());
        }

        static object[] TestingMinMaxCUrrentExpected =
        {
            new object[] { 0f, 100f, 60f, 0.6f },
            new object[] { 0f, 50f, 60f, 1f },
            new object[] { 0f, 50f, 25f, 0.5f },
            new object[] { 100f, 200f, 900f, 1f },
            new object[] { 0f, 300f, -20f, 0f },
            new object[] { -200f, 100f, -50f, 0.5f }
        };

        [Test]
        public void Test_ConstructorMax()
        {
            var _generalValues = new GeneralValuesMinMax<float>(0f, 100f);

            Assert.AreEqual(_generalValues.max, _generalValues.current);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GenLibrTestingWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
