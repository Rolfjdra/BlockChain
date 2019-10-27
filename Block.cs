using BlockChain.Interfaces;
using System;
using System.Text;
using System.Security.Cryptography;
using BlockChain.Utility;
using System.Collections.Generic;
using Clifton.Blockchain;

namespace BlockChain
{
    class Block : IBlock

    {
        public List<ITransaction> Transaction { get; private set; }
        public int BlockNumber { get; private set; }
        public DateTime CreatedDate { get; set; }
        public string BlockHash { get; private set; }
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }
        private MerkleTree merkleTree = new MerkleTree();

        public Block(int blockNumber) 
        {
            Transaction = new List<ITransaction>();
            BlockNumber = blockNumber;
            CreatedDate = DateTime.UtcNow;
        }

        public void AddTransaction(ITransaction transaction)
        {
            Transaction.Add(transaction);
        }

        public string CalculateBlockHash(string previousBlockHash)
        {
            string blockHeader = BlockNumber + CreatedDate.ToString() + previousBlockHash;
            string combined = merkleTree.RootNode + blockHeader;

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

            BuildMerkleTree();
            BlockHash = CalculateBlockHash(PreviousBlockHash);
        }
        private void BuildMerkleTree()
        {
            merkleTree = new MerkleTree();
            foreach(ITransaction transaction in Transaction)
            {
                merkleTree.AppendLeaf(MerkleHash.Create(transaction.CalculateTransactionHash()));
            }

            merkleTree.BuildTree();
        }

        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            bool isValid = true;

            BuildMerkleTree();

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
