using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class FinancialResource
    {
        public static FinancialResource operator +(FinancialResource right, FinancialResource left)
        {
            if (right != null)
                if (left != null)
                    if (right.Currency == left.Currency)
                        return new FinancialResource(right.Value + left.Value, right.Currency);
                    else
                        throw new ArgumentException("The provided financial resource operands must have the same currency!");
                else
                    throw new ArgumentNullException("The provided value for left operand cannot be null!");
            else
                throw new ArgumentNullException("The provided value for right operand cannot be null!");
        }

        public static FinancialResource operator +(FinancialResource right, uint left)
        {
            if (right != null)
                return new FinancialResource(right.Value + left, right.Currency);
            else
                throw new ArgumentNullException("The provided value for right operand cannot be null!");
        }

        public static FinancialResource operator +(uint right, FinancialResource left)
        {
            return left + right;
        }

        public static FinancialResource operator -(FinancialResource right, FinancialResource left)
        {
            if (right != null)
                if (left != null)
                    if (right.Currency == left.Currency)
                        return new FinancialResource(right.Value - left.Value, right.Currency);
                    else
                        throw new ArgumentException("The provided financial resource operands must have the same currency!");
                else
                    throw new ArgumentNullException("The provided value for left operand cannot be null!");
            else
                throw new ArgumentNullException("The provided value for right operand cannot be null!");
        }

        public static FinancialResource operator -(FinancialResource right, uint left)
        {
            if (right != null)
                return new FinancialResource(right.Value - left, right.Currency);
            else
                throw new ArgumentNullException("The provided value for right operand cannot be null!");
        }

        public static FinancialResource operator -(uint right, FinancialResource left)
        {
            if (right != null)
                return new FinancialResource(right - left.Value, left.Currency);
            else
                throw new ArgumentNullException("The provided value for right operand cannot be null!");
        }

        public uint Value { get; private set; }

        public Currency Currency { get; private set; }

        public FinancialResource(uint value, Currency currency)
        {
            if (value > 0)
            {
                Value = value;
                Currency = currency;
            }
            else
                throw new ArgumentException("The provided value for financial resource cannot be 0 (zero)!");
        }
    }
}
