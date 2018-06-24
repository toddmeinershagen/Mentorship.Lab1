using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Mentorship.Lab1.UnitTests
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void given_a_repository_when_logging_an_error_then_should_save_the_error()
        {
            var repository = Substitute.For<ILogRepository>();
            var logger = new Logger(repository);

            var message = "TestMessage";
            logger.Error(message);

            repository.Received(1).Save(message);
        }

        [Test]
        public void given_a_repository_that_returns_1_on_save_when_logging_an_error_then_should_throw()
        {
            var message = "TestMessage";
            var repository = Substitute.For<ILogRepository>();
            repository.Save(message).Returns(1);

            var logger = new Logger(repository);

            Action action = () => logger.Error(message);

            action
                .ShouldThrow<ArgumentException>()
                .WithMessage("What the heck!");
        }

        [Test]
        public void given_a_repository_that_returns_0_on_save_when_logging_an_error_then_should_succeed()
        {
            var message = "TestMessage";
            var repository = Substitute.For<ILogRepository>();
            repository.Save(message).Returns(0);
            //var repository = new TestLogRepository(0);

            var logger = new Logger(repository);
            Action action = () => logger.Error(message);

            action.ShouldNotThrow();
        }

        public class Logger
        {
            private ILogRepository repo;

            public Logger(ILogRepository repository)
            {
                repo = repository;
            }

            public void Error(String message)
            {
                var result = repo.Save(message);

                if (result == 1)
                {
                    throw new ArgumentException("What the heck!");
                }
                
            }
        }

        public interface ILogRepository
        {
            int Save(string message);
        }

        public class TestLogRepository : ILogRepository
        {
            private readonly int _result;

            public TestLogRepository(int result)
            {
                _result = result;
            }
            public int Save(string message)
            {
                return _result;
            }
        }
    }
}
