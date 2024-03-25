using classes.Exceptions;
using System;


namespace BankManagement
{
    public class HMBank
    {
        public void TransferAmount(long fromAccountNumber, long toAccountNumber, float amount)
        {
            // Check if accounts are valid
            if (!IsAccountValid(fromAccountNumber) || !IsAccountValid(toAccountNumber))
            {
                throw new InvalidAccountException("Invalid account number.");
            }

            // Check if sufficient funds
            if (GetBalance(fromAccountNumber) < amount)
            {
                throw new InsufficientFundException("Insufficient funds.");
            }

            // Perform transfer
            // ...
        }

        public void WithdrawAmount(long accountNumber, float amount)
        {
            // Check if account is valid
            if (!IsAccountValid(accountNumber))
            {
                throw new InvalidAccountException("Invalid account number.");
            }

            // Check if sufficient funds
            if (GetBalance(accountNumber) < amount)
            {
                throw new InsufficientFundException("Insufficient funds.");
            }

            // Perform withdrawal
            // ...
        }

        public void WithdrawFromCurrentAccount(long accountNumber, float amount)
        {
            // Check if account is valid
            if (!IsAccountValid(accountNumber))
            {
                throw new InvalidAccountException("Invalid account number.");
            }

            // Check if withdrawal amount exceeds overdraft limit
            if (IsOverDraftLimitExceeded(accountNumber, amount))
            {
                throw new OverDraftLimitExceededException("Withdrawal amount exceeds overdraft limit.");
            }

            // Perform withdrawal from current account
            // ...
        }

        private bool IsAccountValid(long accountNumber)
        {
            // Check if account number is valid
            // ...
            return true;
        }

        private float GetBalance(long accountNumber)
        {
            // Retrieve balance for the account
            // ...
            return 1000; // Placeholder value
        }

        private bool IsOverDraftLimitExceeded(long accountNumber, float amount)
        {
            // Check if withdrawal amount exceeds overdraft limit
            // ...
            return true; // Placeholder value
        }
    }
}
