using System;
using NUnit.Framework;

namespace ChessmateTests.Tests {
    [TestFixture]
    public class AiTesting {
        [Test]
        public void TestAIAlwaysMovesTowardsUser() {
            var board = Board.CreateBoardFromFile(@"C:\Users\Sean\Documents\Chessmate v2\Assets\Levels\TestLevel.txt");
            var i = 0;
            while (i < 10) {
                board.Print();
                board.MakeAiMove();
                i++;
            }
            
        }
    }
}