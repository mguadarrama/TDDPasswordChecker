using System.Linq;
using System.Security.Policy;
using FluentAssertions;
using NUnit.Framework;

namespace KataPasswordTest
{
    [TestFixture]
    class PasswordChecker
    {
        [Test]
        public void WithLessThan6_CheckFail()
        {
            bool result = IsValidPassword("Aa-45");
            result.Should().BeFalse();
        }

        [Test]
        public void WithMoreThan6_CheckPass()
        {
            IsValidPassword("Aa-456").Should().BeTrue();
        }

        [Test]
        public void WithoutUppercase_CheckFail()
        {
            IsValidPassword("aa-456").Should().BeFalse();
        }
        [Test]
        public void WithoutLowerCase_CheckFail()
        {
            IsValidPassword("AA-456").Should().BeFalse();
        }

        [Test]
        public void WithoutHyphen_CheckFail()
        {
            IsValidPassword("AA3456").Should().BeFalse();
        }

        private bool IsValidPassword(string password)
        {
            return (password.Length >= 6) &&
                   (password.Any(char.IsUpper)) &&
                   (password.Any(char.IsLower)) &&
                   (password.Contains("-")) &&
                   !(password.Length < 6); 
        }
    }
}
