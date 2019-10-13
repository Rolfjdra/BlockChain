﻿using BlockChain.Interfaces;
using System;
using System.Text;
using System.Security.Cryptography;
using BlockChain.Utility;

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

        public Block(string claimNumber, 
                    decimal settlementAmount, 
                    DateTime settlementDate, 
                    string carRegistration, 
                    int mileage, 
                    ClaimType claimType, 
                    int blockNumber, 
                    string blockHash, 
                    string previousBlockHash, 
                    IBlock parent)
        {
            BlockNumber = blockNumber;
            ClaimNumber = claimNumber;
            SettlementAmount = settlementAmount;
            SettlementDate = settlementDate;
            CarRegistration = carRegistration;
            Mileage = mileage;
            ClaimType = claimType;
            BlockHash = blockHash;
            PreviousBlockHash = previousBlockHash;
            CreatedDate = DateTime.UtcNow;
            SetBlockHash(parent);
        }

        public string CalculateBlockHash(string previousBlockHash)
        {
            string transactionHash = ClaimNumber + SettlementAmount + SettlementDate + CarRegistration + Mileage + ClaimType;
            string blockHeader = BlockNumber + CreatedDate.ToString() + previousBlockHash;
            string combined = transactionHash + blockHeader;

            return Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(combined)));
        }

        public void SetBlockHash(IBlock parent)
        {

            if(parent != null)
            {
                PreviousBlockHash = parent.BlockHash;
                parent.NextBlock = this;
            }
            else
            {
                PreviousBlockHash = null;
            }
            BlockHash = CalculateBlockHash(PreviousBlockHash);
        }

        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            bool isValid = true;
            string newBlockHash = CalculateBlockHash(prevBlockHash);
            if(newBlockHash != BlockHash)
            {
                isValid = false;
            }
            else
            {
                isValid |= PreviousBlockHash == prevBlockHash;
            }
            PrintVerificationMessage(verbose, isValid);


            if (NextBlock !=null)
            {
                return NextBlock.IsValidChain(newBlockHash, verbose);
            }

            return isValid;
        }

        private void PrintVerificationMessage(bool verbose,bool isValid)
        {
            if (verbose)
            {
                if (!isValid)
                {
                    Console.WriteLine("Block Number " + BlockNumber + ": Failed Verification!");
                }
                else
                {
                    Console.WriteLine("Block Number " + BlockNumber + ": PASS Verification!");
                }
            }
        }
    }
}
