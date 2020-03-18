using System;

namespace NullableTutorial
{
    /*
    Nullableの仕組みを導入する意義は、「自分の設計の意図を読み手やコンパイラに明確に伝えること」
    ※nullを撲滅することではない。

    例えば、例題の質問アプリケーションでは、以下のような設計意図がある。
    質問:Nonnullable
    回答者:Nonnullable
    回答:nullable
    */
    class Program
    {
        static void Main(string[] args)
        {
            var surveyRun = new SurveyRun();
            surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
            surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happend?"));
            surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
            //nullを渡すと警告が出る。
            //surveyRun.AddQuestion(QuestionType.Text, null); //null リテラルを null 非許容参照型に変換できません。

            surveyRun.PerformSurvey(50);

            foreach (var participant in surveyRun.AllParticipants)
            {
                Console.WriteLine($"Participant: {participant.Id}");
                if(participant.AnsweredSurvey)
                {
                    for(int i = 0; i < surveyRun.Question.Count; i++)
                    {
                        var answer = participant.Answer(i);
                        Console.WriteLine($"\t{surveyRun.GetQuestion(i).QuestionText} : {answer}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo response");
                }
            }
        }
    }
}
