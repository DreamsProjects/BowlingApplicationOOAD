using InlamningsuppgiftOOAD;
using InlamningsuppgiftOOAD.Class;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTesting
{
    public class MembersTest
    {
        //Generera medlemmar och lagrar i lista! (2 i 1) //OK
        [Theory]
        [InlineData(1, "Emma", "Pestin", "Moshilinios@google.se")]
        [InlineData(2, "Luna", "Larsson", "Moshilinios@google.se")]
        [InlineData(3, "Jesper", "Testsson", "Moshilinios@google.se")]
        [InlineData(4, "Svetlana", "Ohlsson", "Moshilinios@google.se")]
        [InlineData(5, "Frank", "Polishen", "Moshilinios@google.se")]
        [InlineData(6, "Adam", "Eriksson", "Moshilinios@google.se")]
        [InlineData(7, "Kalle", "Ölond", "Moshilinios@google.se")]
        [InlineData(8, "Jonathan", "Lindström", "Moshilinios@Devomontenius.se")]
        [InlineData(9, "Moshita", "Devomontenius", "Moshilinios@Devomontenius.se")]
        [InlineData(10, "Per", "Malmgren", "Moshilinios@Devomontenius.se")]
        [InlineData(11, "Erik", "Bäckenström", "Moshilinios@Devomontenius.se")]
        [InlineData(12, "Stefan", "Askim", "Moshilinios@Devomontenius.se")]
        [InlineData(13, "Frida", "Nybäck", "Moshilinios@Devomontenius.se")]
        public void CheckUserGeneration_ReturnTrue(int i, string first, string last, string email)
        {
            //Arrange
            GamePersonTesting generatePerson = new GamePersonTesting();

            //Act
            var persons = new Person();
            persons.ContestNumber = i;
            persons.Email = email;
            persons.FirstName = first;
            persons.LastName = last;

            var booleanResult = generatePerson.AddPersonToList(persons);

            //Assert
            Assert.True(generatePerson.ListOfUsers.Count > 0);

        }

        //Generera tävlingsinformation och lagrar i lista
        [Theory]
        [InlineData("HöstCup", "2018-01-01", "2018-12-31", "Högsta poäng per rond")]
        [InlineData("BowlingBrawl", "2018-01-01", "2018-12-31", "Total poäng i alla tre omgångar")]
        public void CheckContestGeneration_ReturnTrue(string cupName, string start, string end, string consider)
        {
            GamePersonTesting generateContest = new GamePersonTesting();

            //Act
            var contest = generateContest.AddNewContest(cupName, start, end, consider);

            Assert.True(generateContest.ContestList.Count > 0);
        }

        //Hämta medlemmar
        [Fact]
        public void CheckUsersStore_ReturnTrue()
        {
            GamePersonTesting getMembers = new GamePersonTesting();
            var userList = getMembers.PersonData();

            Assert.True(userList.Count > 0);
        }

        //Hämta tävlingsinformation
        [Fact]
        public void CheckGamesStore_ReturnBool()
        {
            GamePersonTesting getGames = new GamePersonTesting();

            var gameList = getGames.GamesData();

            Assert.True(gameList.Count > 0);
        }


        //Simulera en match och verifiera rätt vinnare på matchen
        [Theory]
        [InlineData("HöstCup", "1 Emma Pestin", "1 Emma Pestin", "12 Britta Nyhammar", "Högsta poäng per rond", 1, 258, 200, 0, 0)]
        [InlineData("BowlingBrawl", "3 Jesper Testsson", "3 Jesper Testsson", "12 Britta Nyhammar", "Total poäng i alla tre omgångar", 2, 125, 111, 0, 0)]
        [InlineData("HöstCup", "1 Emma Pestin", "1 Emma Pestin", "3 Jesper Testsson", "Högsta poäng per rond", 3, 0, 0, 2, 1)]
        [InlineData("HöstCup", "1 Emma Pestin", "1 Emma Pestin", "5 Frank Polishen", "Högsta poäng per rond", 4, 0, 0, 2, 1)]
        [InlineData("HöstCup", "6 Adam Eriksson", "1 Emma Pestin", "6 Adam Eriksson", "Högsta poäng per rond", 5, 0, 0, 1, 2)]
        [InlineData("HöstCup", "1 Emma Pestin", "1 Emma Pestin", "7 Kalle Ölond", "Högsta poäng per rond", 6, 0, 0, 2, 1)]
        [InlineData("HöstCup", "1 Emma Pestin", "1 Emma Pestin", "8 Jonathan Lindström", "Högsta poäng per rond", 7, 0, 0, 2, 1)]
        [InlineData("HöstCup", "11 Erik Bäckenström", "1 Emma Pestin", "11 Erik Bäckenström", "Högsta poäng per rond", 8, 0, 0, 1, 2)]
        [InlineData("HöstCup", "1 Emma Pestin", "1 Emma Pestin", "12 Stefan Askim", "Högsta poäng per rond", 9, 0, 0, 2, 1)]
        [InlineData("HöstCup", "1 Emma Pestin", "1 Emma Pestin", "13 Frida Nybäck", "Högsta poäng per rond", 10, 0, 0, 2, 1)]
        [InlineData("HöstCup", "10 Per Malmgren", "1 Emma Pestin", "10 Per Malmgren", "Högsta poäng per rond", 11, 0, 0, 1, 2)]
        [InlineData("BowlingBrawl", "2 Luna Larsson", "2 Luna Larsson", "1 Emma Pestin", "Total poäng i alla tre omgångar", 12, 125, 111, 0, 0)]
        public void CheckMatchWinner(string nameOnCup, string expectedValue, string firstPerson, string secondPerson, string valueOfName,
            int matchId, int pointOne, int pointTwo, int roundOne, int roundTwo)
        {
            GamePersonTesting cup = new GamePersonTesting();

            string accualValues = cup.PlayGame(nameOnCup, valueOfName, matchId, firstPerson, secondPerson,
                pointOne, pointTwo, roundOne, roundTwo);

            var games = new Game(nameOnCup, matchId, firstPerson, secondPerson);
            cup.ListOfGames.Add(games);

            var score = new Scores(matchId, expectedValue);
            cup.ScoresList.Add(score);

            Assert.Equal(expectedValue, accualValues);
        }


        //Verifiera årets champion --Kolla igenom OK
        [Fact]
        public void CheckYearCupWinner()
        {
            List<ScoreStatus> ScoresStatusList = new List<ScoreStatus>();
            GamePersonTesting getScoresAndGames = new GamePersonTesting();

            var getAllPersons = getScoresAndGames.PersonData();
            var winner = "1 Emma Pestin";
            var returned = "";
            int amountScores = 0;
            int amountGames = 0;
            double percentage = 0;

            var ScoresList = getScoresAndGames.ScoresData();
            var GamesList = getScoresAndGames.GamesData();
            MathProxy proxy = new MathProxy();

            foreach (var items in getAllPersons)
            {
                var text = $"{items.ContestNumber} {items.FirstName} {items.LastName}";

                amountScores = ScoresList.Where(x => x.Winner == text).Count();

                amountGames = GamesList.Where(x => x.PersonOne == text || x.PersonTwo == text).Count();

                if (amountGames >= 10)
                {
                    if (amountScores == 0)
                        percentage = proxy.Mul(amountScores, amountGames);

                    percentage = proxy.Div((amountScores * 100), amountGames);

                    var ScoresStatus = new ScoreStatus(amountGames, amountScores, items.FirstName, items.LastName, percentage, items.ContestNumber);
                    ScoresStatusList.Add(ScoresStatus);
                }
            }

            var sort = ScoresStatusList.OrderByDescending(x => x.Percentage).FirstOrDefault();
            returned = $"{sort.ContestNumber} {sort.FirstName} {sort.LastName}";

            Assert.Equal(winner, returned);
        }


        //Verifiera cupens vinnare
        [Theory]
        [InlineData("HöstCup")]
        public void CheckCupWinner(string cupName)
        {
            List<ScoreStatus> ScoresStatusList = new List<ScoreStatus>();

            GamePersonTesting getGameAndUser = new GamePersonTesting();

            var getAllPersons = getGameAndUser.PersonData();

            var returned = "";
            int amountScores = 0;
            int amountGames = 0;
            double percentage = 0;

            var ScoresList = getGameAndUser.ScoresData();
            var GamesList = getGameAndUser.GamesData();

            var getOutGames = GamesList.Where(x => x.Name == cupName);

            foreach (var items in getAllPersons)
            {
                var text = $"{items.ContestNumber} {items.FirstName} {items.LastName}";

                amountScores = ScoresList.Where(x => x.Winner == text).Count();

                amountGames = getOutGames.Where(x => x.PersonOne == text || x.PersonTwo == text).Count();
                MathProxy proxy = new MathProxy();

                if (amountGames >= 10)
                {
                    if (amountScores == 0)
                        percentage = proxy.Mul(amountScores, amountGames);

                    percentage = proxy.Div((amountScores * 100), amountGames);

                    var ScoresStatus = new ScoreStatus(amountGames, amountScores, items.FirstName, items.LastName, percentage, items.ContestNumber);
                    ScoresStatusList.Add(ScoresStatus);
                }
            }

            var sort = ScoresStatusList.OrderByDescending(x => x.Percentage).FirstOrDefault();
            returned = $"{sort.ContestNumber} {sort.FirstName} {sort.LastName}";

            Assert.True(sort.ContestNumber == 1 && sort.FirstName == "Emma" && sort.LastName == "Pestin");
        }
    }
}
