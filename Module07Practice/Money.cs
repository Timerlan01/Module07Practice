using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Practice
{
    /// <summary>
    /// Task3
    /// </summary>
    public class Money
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency == b.Currency)
                return new Money(a.Amount + b.Amount, a.Currency);
            else
                throw new InvalidOperationException("Cannot add money in different currencies.");
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Currency == b.Currency && a.Amount == b.Amount;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                return this == other;
            }
            return false;
        }
    }

}
