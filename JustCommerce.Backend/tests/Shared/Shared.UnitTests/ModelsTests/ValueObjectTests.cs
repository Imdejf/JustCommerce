using JustCommerce.Shared.Abstract;
using System;
using System.Collections.Generic;
using Xunit;

namespace Shared.UnitTests.ModelsTests
{
    public sealed class ValueObjectTests
    {
        internal class ValueObj1 : ValueObject
        {
            public int X { get; set; }
            public string Y { get; set; }
            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return X;
                yield return Y;
            }
        }
        internal class ValueObj2 : ValueObject
        {
            public int X { get; set; }
            public string Y { get; set; }
            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return X;
                yield return Y;
            }
        }

        [Fact]
        public void Two_Equal_ValueObject_Of_Same_Type_Are_Value_Equal()
        {
            var obj1 = new ValueObj1()
            {
                X = 10,
                Y = "TEST"
            };
            var obj2 = new ValueObj1()
            {
                X = 10,
                Y = "TEST"
            };

            Assert.Equal(obj1, obj2);
        }

        [Fact]
        public void Two_Diffrent_ValueObject_Of_Same_Type_Are_Not_Value_Equal()
        {
            var obj1 = new ValueObj1()
            {
                X = 12,
                Y = "TEST"
            };
            var obj2 = new ValueObj1()
            {
                X = 10,
                Y = "TEST"
            };

            Assert.NotEqual(obj1, obj2);
        }

        [Fact]
        public void Compare_Of_Two_ValueObjects_With_Diffrent_Types_Rises_Exception()
        {
            var obj1 = new ValueObj1()
            {
                X = 10,
                Y = "TEST"
            };
            var obj2 = new ValueObj2()
            {
                X = 10,
                Y = "TEST"
            };

            Assert.Throws<ArgumentException>(() => obj1 == obj2);
        }

        [Fact]
        public void Compare_Of_Two_Null_ValueObjects_Returns_True()
        {
            ValueObj1 obj1 = null;
            ValueObj1 obj2 = null;

            Assert.True(obj1 == obj2);
        }

        [Fact]
        public void Compare_With_One_Null_ValueObject_Returns_False()
        {
            ValueObj1 obj1 = new ValueObj1()
            {
                X = 10,
                Y = "TEST"
            };
            ValueObj1 obj2 = null;

            Assert.False(obj1 == obj2);
        }
    }
}
