using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public class Logger
        {
            private ILogRepository repo;

            public Logger(ILogRepository repository)
            {
                repo = repository;
            }

            public void Error(String message)
            {
                repo.Save(message);
            }
        }

        public interface ILogRepository
        {
            void Save(string message);
        }
    }
}
