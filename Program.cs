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
            ITransaction transaction1 = new Transaction("claim311", 1000.00m, DateTime.Now, "RL29999", 10000, ClaimType.TotalLoss);
            ITransaction transaction2 = new Transaction("Claim342", 2000.00m, DateTime.Now, "KE10492", 20000, ClaimType.TotalLoss);
            ITransaction transaction3 = new Transaction("Claim679", 3000.00m, DateTime.Now, "JS12353", 30000, ClaimType.TotalLoss);
            ITransaction transaction4 = new Transaction("Claim522", 4000.00m, DateTime.Now, "IL82382", 40000, ClaimType.TotalLoss);
            ITransaction transaction5 = new Transaction("Claim419", 5000.00m, DateTime.Now, "AS12312", 50000, ClaimType.TotalLoss);
            ITransaction transaction6 = new Transaction("Claim222", 6000.00m, DateTime.Now, "RJ98765", 60000, ClaimType.TotalLoss);
            ITransaction transaction7 = new Transaction("Claim132", 7000.00m, DateTime.Now, "PK74821", 70000, ClaimType.TotalLoss);
            ITransaction transaction8 = new Transaction("Claim124", 8000.00m, DateTime.Now, "UL15826", 80000, ClaimType.TotalLoss);
            ITransaction transaction9 = new Transaction("claim634", 1000.00m, DateTime.Now, "RL29999", 10000, ClaimType.TotalLoss);
            ITransaction transaction10 = new Transaction("Claim32", 2000.00m, DateTime.Now, "KE10492", 20000, ClaimType.TotalLoss);
            ITransaction transaction11 = new Transaction("Claim6712", 3023.00m, DateTime.Now, "AK12353", 31200, ClaimType.TotalLoss);
            ITransaction transaction12 = new Transaction("Claim5322", 4015.00m, DateTime.Now, "GH82382", 43200, ClaimType.TotalLoss);
            ITransaction transaction13 = new Transaction("Claim4149", 5270.00m, DateTime.Now, "AS12312", 12300, ClaimType.TotalLoss);
            ITransaction transaction14 = new Transaction("Claim2262", 1980.00m, DateTime.Now, "AS12374", 654300, ClaimType.TotalLoss);
            ITransaction transaction15 = new Transaction("Claim1352", 2190.00m, DateTime.Now, "UL98765", 43100, ClaimType.TotalLoss);
            ITransaction transaction16 = new Transaction("Claim1241", 4180.00m, DateTime.Now, "UL13261", 12300, ClaimType.TotalLoss);

            Block block1 = new Block(0);
            Block block2 = new Block(1);
            Block block3 = new Block(2);
            Block block4 = new Block(3);

            block1.AddTransaction(transaction1);
            block1.AddTransaction(transaction2);
            block1.AddTransaction(transaction3);
            block1.AddTransaction(transaction4);

            block2.AddTransaction(transaction5);
            block2.AddTransaction(transaction6);
            block2.AddTransaction(transaction7);
            block2.AddTransaction(transaction8);

            block3.AddTransaction(transaction9);
            block3.AddTransaction(transaction10);
            block3.AddTransaction(transaction11);
            block3.AddTransaction(transaction12);

            block4.AddTransaction(transaction13);
            block4.AddTransaction(transaction14);
            block4.AddTransaction(transaction15);
            block4.AddTransaction(transaction16);

            block1.SetBlockHash(null);
            block2.SetBlockHash(block1);
            block3.SetBlockHash(block2);
            block4.SetBlockHash(block3);

            chain.AcceptBlock(block1);
            chain.AcceptBlock(block2);
            chain.AcceptBlock(block3);
            chain.AcceptBlock(block4);


            chain.VerifyChain();

            Console.WriteLine("");
            Console.WriteLine("");

            transaction5.ClaimNumber = "asdasd";
            chain.VerifyChain();

            Console.WriteLine();
        }
    }
}
