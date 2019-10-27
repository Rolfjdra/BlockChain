using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.Interfaces
{
    public interface IBlock
    {
        //List of transactions
        List<ITransaction> Transaction { get; }
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
