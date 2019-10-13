using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.Interfaces
{
    public interface IBlock
    {
        // Adding transaction data
        public String ClaimNumber { get; set; }
        public decimal SettlementAmount { get; set; }
        public DateTime SettlementDate { get; set; }
        public string CarRegistration { get; set; }
        public int Mileage { get; set; }
        public ClaimType ClaimType { get; set; }

        //Adding Header data
        public int BlockNumber { get; }
        public DateTime CreatedDate { get; set; }
        public string BlockHash { get; }
        public string PreviousBlockHash { get; set; }

        // Some methods
        public string CalculateBlockHash(string previousBlockHash);
        void SetBlockHash(IBlock parent);
        public IBlock NextBlock { get; set; }
        bool IsValidChain(string prevBlockHash, bool verbose);

    }
}
