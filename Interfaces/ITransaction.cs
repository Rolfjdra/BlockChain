using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.Interfaces
{
    public interface ITransaction
    {
        public string ClaimNumber { get; set; }
        public decimal SettlementAmount { get; set; }
        public DateTime SettlementDate { get; set; }
        public string CarRegistration { get; set; }
        public int Mileage { get; set; }
        public ClaimType ClaimType { get; set; }

        string CalculateTransactionHash();

    }
}
