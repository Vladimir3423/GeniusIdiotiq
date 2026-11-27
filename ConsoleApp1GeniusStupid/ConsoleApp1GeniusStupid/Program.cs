using System.Net.NetworkInformation;
string filePath = "Players.txt";

//щщщщщщщщщщщщщщ

if (File.Exists(filePath))
{
    Console.WriteLine("История игроков : ");
    Console.WriteLine();
    string[] allRecords = File.ReadAllLines(filePath);
    string[,] resultsMassive = new string[allRecords.Length, 3];
    for(int i = 0; i < allRecords.Length; i ++)
    {
        string[] dataLine = allRecords[i].Split('|');


        for (int j = 0; j < 3; j ++)
        {
            resultsMassive[i, j] = dataLine[j];
        }
    }
    
    PrintHistory(resultsMassive);


    Console.WriteLine();
}
else
{
    var fileCreate = File.Create(filePath);
    Console.WriteLine("Нет результатов");
}

Console.WriteLine("Как вас зовут?");
string name = Console.ReadLine();

string questPith = "qest.txt";
string ansPith = "answers.txt";

List<string> questions = new List<string>() { "2 плюс 2 * 2?", "бревно нужно распилить на 10 частей, склбко нжно разрезов?", "На двух руках 10 пальцев, сколько пальцев на 5 руках?", "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "5 свечей горело, 3 потухли, сколько свечей осталось?", "Сколько секунд в 3 минутах?", "33 + 77", "четверть часа это сколько минут?" };
List<string> answers = new List<string>() { "6", "9", "25", "60", "2", "180", "110", "15" };

if(!(File.Exists(questPith)))
{
    for(int i = 0; i < questions.Count; i ++)
    {
        File.AppendAllText(questPith, $"{questions[i]} {Environment.NewLine}");
        File.AppendAllText(ansPith, $"{answers[i]} {Environment.NewLine}");
    }
}

string[] fileQuestions = File.ReadAllLines(questPith);
string[] fileAnswers = File.ReadAllLines(ansPith);

List<string> allQuestions = new List<string>(fileQuestions);
List<string> allAnswers = new List<string>(fileAnswers);



Test(name, filePath, allQuestions, allAnswers);

AddQuest(questPith, ansPith);

static void Test(string name, string filePath, List<string> questions, List<string> answers)
{
    int rightAnswercnt = 0;

    //List<string> questions = new List<string>() { "2 плюс 2 * 2?", "бревно нужно распилить на 10 частей, склбко нжно разрезов?", "На двух руках 10 пальцев, сколько пальцев на 5 руках?", "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "5 свечей горело, 3 потухли, сколько свечей осталось?", "Сколько секунд в 3 минутах?", "33 + 77", "четверть часа это сколько минут?" };
    //List<string> answers = new List<string>() { "6", "9", "25", "60", "2", "180", "110", "15" };
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

    result = GetResult(percentAnswers);


    Console.WriteLine(percentAnswers);
    Console.WriteLine(name + ", вы " + result);

    string playerData = $"{name}|{percentAnswers}|{result} {Environment.NewLine}";

    File.AppendAllText(filePath, playerData);
    

    Console.WriteLine("Хотите повторить? да/нет");
    string ans = Console.ReadLine();

    if (ans == "да")
    {
        Test(name, filePath, questions, answers);
    }


}


static void PrintHistory(string[,] dataLines)
{
    for(int i = 0; i < dataLines.GetLength(0); i ++)
    {
        Console.WriteLine($"{dataLines[i, 0], -15} | {dataLines[i,1] + "%", -4} | {dataLines[i, 2], -10}");
    }
}

static string GetResult(int percentAnswers)
{
    string result = "";
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
    return result;
}



static void AddQuest(string questPith, string answersPith)
{
    Console.WriteLine("Хотите добваить свой новый вопрос? y/n");
    string userAns = Console.ReadLine();

    if(userAns == "y")
    {
        Console.WriteLine("Введите свой вопрос");
        string newQest = Console.ReadLine();
        Console.WriteLine("Введите ответ на ваш вопрос");
        string newAns = Console.ReadLine();

        File.AppendAllText(questPith, newQest);
        File.AppendAllText(answersPith, newAns);

        Console.WriteLine("Гтово");



    }
}