using System.Net.NetworkInformation;
string filePath = "Players.txt";


if (File.Exists(filePath))
{
    Console.WriteLine("История игроков : ");
    Console.WriteLine();
    string[] allRecords = File.ReadAllLines(filePath);
    foreach (string line in allRecords)
    {
        Console.WriteLine(line);
       
    }


    Console.WriteLine();
}
else
{
    Console.WriteLine("Нет результатов");
}

Console.WriteLine("Как вас зовут?");
string name = Console.ReadLine();



Test(name, filePath);

static void Test(string name, string filePath)
{
    int rightAnswercnt = 0;

    List<string> questions = new List<string>() { "2 плюс 2 * 2?", "бревно нужно распилить на 10 частей, склбко нжно разрезов?", "На двух руках 10 пальцев, сколько пальцев на 5 руках?", "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "5 свечей горело, 3 потухли, сколько свечей осталось?", "Сколько секунд в 3 минутах?", "33 + 77", "четверть часа это сколько минут?" };
    List<string> answers = new List<string>() { "6", "9", "25", "60", "2", "180", "110", "15" };
    int questionsListCnt = questions.Count;

    //string[] answersUser = { };

    for (int i = 0; i < questionsListCnt; i++)
    {
        int randomId = Random.Shared.Next(questions.Count);
        Console.WriteLine(questions[randomId]);

        string answer = Console.ReadLine();

        if (!(int.TryParse(answer, out _)))
        {
            while (!(int.TryParse(answer, out _)))
            {
                Console.WriteLine("введите число");
                answer = Console.ReadLine();
            }
        }

        if (answer == answers[randomId])
        {
            rightAnswercnt += 1;
        }
        questions.RemoveAt(randomId);
        answers.RemoveAt(randomId);


    }

    string result = "";



    int percentAnswers = (rightAnswercnt * 100) / questionsListCnt;
    Console.WriteLine(percentAnswers);

    if (percentAnswers < 15)
    {
        result = "кретин";
    }
    else
    {
        if (percentAnswers < 30)
        {
            result = "Идиот";

        }
        else
        {
            if (percentAnswers < 45)
            {
                result = "Дурак";

            }
            else
            {
                if (percentAnswers < 60)
                {
                    result = "Нормальный";

                }
                else
                {
                    if (percentAnswers < 75)
                    {
                        result = "Талант";
                    }
                    else
                    {
                        result = "Гений";
                    }
                }
            }
        }
    }


    //switch (rightAnswercnt)
    //{
    //    case 5:
    //        result = "Гений";
    //        break;
    //    case 4:
    //        result = "Талант";
    //        break;
    //    case 3:
    //        result = "Нормальный";
    //        break;
    //    case 2:
    //        result = "Дурак";
    //        break;
    //    case 1:
    //        result = "Кретин";
    //        break;
    //    case 0:
    //        result = "Идиот";
    //        break;

    //}

    Console.WriteLine(percentAnswers);
    Console.WriteLine(name + ", вы " + result);

    string playerData = $"{name}: {percentAnswers}% правильно, статус: {result} {Environment.NewLine}";

    File.AppendAllText(filePath, playerData);
    

    Console.WriteLine("Хотите повторить? да/нет");
    string ans = Console.ReadLine();

    if (ans == "да")
    {
        Test(name, filePath);
    }


}

