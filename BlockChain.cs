using BlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain
{
    public class BlockChain : IBlockChain
    {
        public IBlock CurrentBlock { get; private set; }
        public IBlock HeadBlock { get; private set; }
        public List<IBlock> Blocks { get; }

        public BlockChain()
        {
            Blocks = new List<IBlock>();
        }

        public void AcceptBlock(IBlock block)
        {
            // Genesis block
            if (HeadBlock == null)
            {
                HeadBlock = block;
                HeadBlock.PreviousBlockHash = null;
            }
            CurrentBlock = block;
            Blocks.Add(block);

        }

        public void VerifyChain()
        {
            throw new NotImplementedException();
        }
    }
}
