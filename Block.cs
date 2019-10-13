using BlockChain.Interfaces;
using System;
using System.Text;
using System.Security.Cryptography;
namespace BlockChain
{
    class Block : IBlock

    {
        public string ClaimNumber { get; set; }
        public decimal SettlementAmount { get; set; }
        public DateTime SettlementDate { get; set; }
        public string CarRegistration { get; set; }
        public int Mileage { get; set; }
        public ClaimType ClaimType { get; set; }
        public int BlockNumber { get; private set; }
        public DateTime CreatedDate { get; set; }
        public string BlockHash { get; private set; }
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }

        public Block(int blockNumber,
                     string claimNumber, 
                     decimal settlementAmount, 
                     DateTime settlementDate, 
                     string carRegistration, 
                     int mileage, 
                     ClaimType claimType,
                     IBlock parent)
        {
            ClaimNumber = claimNumber;
            SettlementAmount = settlementAmount;
            SettlementDate = settlementDate;
            CarRegistration = carRegistration;
            Mileage = mileage;
            ClaimType = claimType;
            BlockNumber = blockNumber;
            // Add methods?
        }

        public string CalculateBlockHash(string previousBlockHash)
        {
            string transactionHash = ClaimNumber + SettlementAmount + SettlementDate + CarRegistration + Mileage + ClaimType;
            string blockHeader = BlockNumber + CreatedDate.ToString() + previousBlockHash;
            string combined = transactionHash + blockHeader;

            return null; //Convert.ToBase64String(HashData.ComputeHash256(Encoding.UTF8.GetBytes(combined));
        }

        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            throw new NotImplementedException();
        }

        public void SetBlockHash(IBlock parent)
        {
            throw new NotImplementedException();
        }
    }
}
