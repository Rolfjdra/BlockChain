using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.Interfaces
{
    public interface IBlockChain
    {
        void AcceptBlock(IBlock block);
        void VerifyChain();
    }
}
