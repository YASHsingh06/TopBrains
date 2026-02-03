using NUnit.Framework;
using System;

namespace BankAccountTests
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            Program account = new Program(1000);

            account.Deposit(500);

            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Program account = new Program(1000);

            Assert.AreEqual(
                "Deposit amount cannot be negative",
                Assert.Throws<Exception>(() => account.Deposit(-100)).Message
            );
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            Program account = new Program(1000);

            account.Withdraw(300);

            Assert.AreEqual(700, account.Balance);
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Program account = new Program(400);

            Assert.AreEqual(
                "Insufficient funds.",
                Assert.Throws<Exception>(() => account.Withdraw(800)).Message
            );
        }
    }
}
