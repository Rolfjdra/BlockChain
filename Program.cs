using BlockChain.Interfaces;
using System;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BlockChainDemo");

            BlockChain chain = new BlockChain();
            IBlock block1 = new Block(0, "claim311", 1000.00m, DateTime.Now, "RL29999", 10000, ClaimType.TotalLoss,null);
            IBlock block2 = new Block(1, "Claim342", 2000.00m, DateTime.Now, "KE10492", 20000, ClaimType.TotalLoss, block1);
            IBlock block3 = new Block(3, "Claim679", 3000.00m, DateTime.Now, "JS12353", 30000, ClaimType.TotalLoss, block2);
            IBlock block4 = new Block(4, "Claim522", 4000.00m, DateTime.Now, "IL82382", 40000, ClaimType.TotalLoss, block3);
            IBlock block5 = new Block(5, "Claim419", 5000.00m, DateTime.Now, "AS12312", 50000, ClaimType.TotalLoss, block4);
            IBlock block6 = new Block(6, "Claim222", 6000.00m, DateTime.Now, "RJ98765", 60000, ClaimType.TotalLoss, block5);
            IBlock block7 = new Block(7, "Claim132", 7000.00m, DateTime.Now, "PK74821", 70000, ClaimType.TotalLoss, block6);
            IBlock block8 = new Block(8, "Claim124", 8000.00m, DateTime.Now, "UL15826", 80000, ClaimType.TotalLoss, block7);

            chain.AcceptBlock(block1);
            chain.AcceptBlock(block2);
            chain.AcceptBlock(block3);
            chain.AcceptBlock(block4);
            chain.AcceptBlock(block5);
            chain.AcceptBlock(block6);
            chain.AcceptBlock(block7);
            chain.AcceptBlock(block8);

            chain.VerifyChain();

            Console.WriteLine("");
            Console.WriteLine("");
            block4.CreatedDate = new DateTime(2019, 10, 17);
            chain.VerifyChain();

            Console.WriteLine();
        }
    }
}
