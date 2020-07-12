using Moq;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace CH06_Moq
{
    [TestFixture]
    public class UnitTests
    {
        public bool AssertThrows<TException>(
            Action action,
            Func<TException, bool> exceptionCondition = null)
            where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException ex)
            {
                if (exceptionCondition != null)
                {
                    return exceptionCondition(ex);
                }

                return true;
            }
            catch
            {
                return false;
            }

            return false;
        }

        [Test]
        public void DoSomethingReturnsTrue()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            Assert.IsTrue(mock.Object.DoSomething("ping"));
        }

        [Test]
        public void DoSomethingReturnsFalse()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("tracert")).Returns(false);
            Assert.IsFalse(mock.Object.DoSomething("tracert"));
        }

        [Test]
        public void OutArguments()
        {
            var mock = new Mock<IFoo>();
            var outString = "ack";
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);
            Assert.AreEqual("ack", outString);
            Assert.IsTrue(mock.Object.TryParse("ping", out outString));
        }

        [Test]
        public void RefArguments()
        {
            var instance = new Bar();
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);
            Assert.AreEqual(true, mock.Object.Submit(ref instance));
        }

        [Test]
        public void AccessInvocationArguments()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomethingStringy(It.IsAny<string>()))
                .Returns((string s) => s.ToLower());
            Assert.AreEqual("i like oranges!", mock.Object.DoSomethingStringy("I LIKE ORANGES!"));
        }

        [Test]
        public void ThrowingWhenInvokedWithSpecificParameters()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));
            Assert.IsTrue(
                AssertThrows<InvalidOperationException>(
                    () => mock.Object.DoSomething("reset")
                )
            );
            Assert.IsTrue(
                AssertThrows<ArgumentException>(
                    () => mock.Object.DoSomething("")
                )
            );
            Assert.Throws(Is.TypeOf<ArgumentException>()
                            .And.Message.EqualTo("command"),
                            () => mock.Object.DoSomething("")
            );
        }
    }
}
