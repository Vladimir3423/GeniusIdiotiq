Console.WriteLine("Как вас зовут?");
string name = Console.ReadLine();
Test(name);



static void Test(string name)
{
    int rightAnswercnt = 0;

    List<string> questions = new List<string>() { "2 плюс 2 * 2?", "бревно нужно распилить на 10 частей, склбко нжно разрезов?", "На двух руках 10 пальцев, сколько пальцев на 5 руках?", "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "5 свечей горело, 2 потухли, сколько свечей осталось?" };
    List<string> answers = new List<string>() { "6", "9", "25", "60", "2" };
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
            rightAnswercnt += 1;//hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhкккккhввв
        } 

        questions.RemoveAt(randomId);
        answers.RemoveAt(randomId);


    }

    string result = "";

    int percentValue = 0;

    //if ()



        switch (rightAnswercnt)
        {
            case 5:
                result = "Гений";
                break;
            case 4:
                result = "Талант";
                break;
            case 3:
                result = "Нормальный";
                break;
            case 2:
                result = "Дурак";
                break;
            case 1:
                result = "Кретин";
                break;
            case 0:
                result = "Идиот";
                break;

        }

    Console.WriteLine(name + ", вы " + result);

    Console.WriteLine("Хотите повторить? да/нет");
    string ans = Console.ReadLine();

    if (ans == "да")
    {
        Test(name);
    }


}

static void Che()
{

}