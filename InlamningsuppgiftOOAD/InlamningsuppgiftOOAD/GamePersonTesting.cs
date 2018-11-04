using InlamningsuppgiftOOAD.Class;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD
{
    public class GamePersonTesting
    {
        public List<Person> ListOfUsers = new List<Person>();
        public List<Game> ListOfGames = new List<Game>();
        public List<Scores> ScoresList = new List<Scores>();
        public List<Contest> ContestList = new List<Contest>();

        MathProxy proxy = new MathProxy();


        public List<Person> PersonData()
        {
            var person = new Person
            {
                ContestNumber = 1,
                FirstName = "Emma",
                LastName = "Pestin",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 2,
                FirstName = "Luna",
                LastName = "Larsson",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 3,
                FirstName = "Jesper",
                LastName = "Testsson",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 4,
                FirstName = "Svetlana",
                LastName = "Ohlsson",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 5,
                FirstName = "Frank",
                LastName = "Polishen",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 6,
                FirstName = "Adam",
                LastName = "Eriksson",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 7,
                FirstName = "Kalle",
                LastName = "Ölond",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 8,
                FirstName = "Jonathan",
                LastName = "Lindström",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 9,
                FirstName = "Moshita",
                LastName = "Devomontenius",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 10,
                FirstName = "Per",
                LastName = "Malmgren",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 11,
                FirstName = "Erik",
                LastName = "Bäckenström",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 12,
                FirstName = "Britta",
                LastName = "Nyhammar",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 13,
                FirstName = "Frida",
                LastName = "Nybäck",
                Email = "Moshilinios@google.se"
            };
            ListOfUsers.Add(person);

            person = new Person
            {
                ContestNumber = 14,
                FirstName = "Stefan",
                LastName = "Askim",
                Email = "Stefannos@Askim.se"

            };
            ListOfUsers.Add(person);


            return ListOfUsers;
        }

        public List<Game> GamesData()
        {
            var game = new Game
            {
                GameNumber = 1,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "12 Britta Nyhammar",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);

            game = new Game
            {
                GameNumber = 2,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "3 Jesper Testsson",
                Name = "BowlingBrawl",
                ContestDesider = "Total poäng i alla tre omgångar"
            };
            ListOfGames.Add(game);

            game = new Game
            {
                GameNumber = 3,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "3 Jesper Testsson",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);

            game = new Game
            {
                GameNumber = 4,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "5 Frank Polishen",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);

            game = new Game
            {
                GameNumber = 5,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "6 Adam Eriksson",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);

            game = new Game
            {
                GameNumber = 6,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "7 Kalle Ölond",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);


            game = new Game
            {
                GameNumber = 7,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "8 Jonathan Lindström",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);


            game = new Game
            {
                GameNumber = 8,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "11 Erik Bäckenström",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);

            game = new Game
            {
                GameNumber = 9,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "14 Stefan Askim",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);


            game = new Game
            {
                GameNumber = 10,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "13 Frida Nybäck",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);


            game = new Game
            {
                GameNumber = 11,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "10 Per Malmgren",
                Name = "HöstCup",
                ContestDesider = "Högsta poäng per rond"
            };
            ListOfGames.Add(game);


            game = new Game
            {
                GameNumber = 12,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "2 Luna Larsson",
                Name = "BowlingBrawl",
                ContestDesider = "Total poäng i alla tre omgångar"
            };
            ListOfGames.Add(game);



            return ListOfGames;
        }

        public List<Scores> ScoresData()
        {
            var scores = new Scores
            {
                GameNumber = 1,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "12 Britta Nyhammar",
                Winner = "1 Emma Pestin",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 2,
                PersonOne = "3 Jesper Testsson",
                PersonTwo = "12 Britta Nyhammar",
                Winner = "3 Jesper Testsson",
                Name = "BowlingBrawl"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 3,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "3 Jesper Testsson",
                Winner = "1 Emma Pestin",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 4,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "5 Frank Polisher",
                Winner = "1 Emma Pestin",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 5,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "6 Adam Eriksson",
                Winner = "6 Adam Eriksson",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 6,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "7 Kalle Ölond",
                Winner = "1 Emma Pestin",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 7,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "8 Jonathan Lindström",
                Winner = "1 Emma Pestin",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 8,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "11 Erik Bäckenström",
                Winner = "11 Erik Bäckenström",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 9,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "14 Stefan Askim",
                Winner = "1 Emma Pestin",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 10,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "13 Frida Nybäck",
                Winner = "1 Emma Pestin",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 11,
                PersonOne = "1 Emma Pestin",
                PersonTwo = "10 Per Malmgren",
                Winner = "10 Per Malmgren",
                Name = "HöstCup"
            };
            ScoresList.Add(scores);

            scores = new Scores
            {
                GameNumber = 12,
                PersonOne = "2 Luna Larsson",
                PersonTwo = "1 Emma Pestin",
                Winner = "1 Emma Pestin",
                Name = "BowlingBrawl"
            };
            ScoresList.Add(scores);

            return ScoresList;
        }


        public bool AddNewContest(string name, string start, string end, string consider)
        {
            var contests = new Contest
            {
                Name = name,
                Start = Convert.ToDateTime(start),
                Ending = Convert.ToDateTime(end),
                ContestDesider = consider
            };

            ContestList.Add(contests);

            return true;
        }

        public bool AddNewGame(string name, int number, string playerOne, string playerTwo)
        {
            var game = new Game
            {
                Name = name,
                PersonOne = playerOne,
                PersonTwo = playerTwo,
                GameNumber = number
            };

            return true;
        }

        public bool AddPersonToList(Person person)
        {
            ListOfUsers.Add(person);

            return true;
        }

        public bool AddGameToList(Game game)
        {
            if (game.GameNumber != 0)
            {
                ListOfGames.Add(game);

                return true;
            }
            return false;
        }

        public int Calculate(int value1, int value2)
        {
            if (value1 > value2) return 1;
            else return 2;
        }

        public string PlayGame(string nameOnCup, string valueOfName, int matchId, string firstPerson, string secondPerson,
            int pointOne, int pointTwo, int roundOne, int roundTwo) //BusinessLayer
        {
            var winner = "";

            if (pointOne != 0 && pointTwo != 0)
            {
                winner = Calculator(roundOne, roundTwo, pointOne, pointTwo, firstPerson, secondPerson); //Utser vinnaren

                return winner;
            }

            else
            {
                winner = Calculator(roundOne, roundTwo, pointOne, pointTwo, firstPerson, secondPerson); //Utser vinnaren

                return winner;
            }
        }

        public string Calculator(int roundOne, int roundTwo, int pointOne, int pointTwo, string firstPerson, string secondPerson)
        {
            var winner = "";
            var one = proxy.Sub(pointOne, pointTwo);
            var two = proxy.Sub(pointTwo, pointOne);

            if (roundOne == 0 && roundTwo == 0) //Om totalpoäng för spelet
            {
                if (one > two) winner = firstPerson;

                else if (two > one) winner = secondPerson;
            }

            else //Poäng för Ronder
            {
                if (roundOne > roundTwo) winner = firstPerson;
                else if (roundTwo > roundOne) winner = secondPerson;
            }

            return winner;
        }
    }
}
