using Learning.Portal.Context;
using Learning.Portal.ViewModels;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Learning.Portal.Helper
{
    public static class CsvParser
    {
        public static List<QuestionVM> Parse(this Stream steam)
        {
            var list = new List<QuestionVM>();
            using (var csvReader = new CsvReader(new StreamReader(steam), true))
            {
                foreach (var item in csvReader)
                {
                    if (item != null && !string.IsNullOrWhiteSpace(item[1]))
                    {
                        int number = 1;
                        var question = "<div class=\"col-lg-12\"><div class=\"form-group\">";
                        question += "<label class=\"control-label\"> Question : " + item[1] + "? </label><br />";
                        bool isMcq = false;
                        question += "<ul class=\"list-group list-group-flush\">";
                        if (!string.IsNullOrWhiteSpace(item[2]))
                        {
                            isMcq = true;
                            question += "<li class=\"list-group-item\"><b>" + number + ". </b> " + item[2] + "</li>";
                            number++;
                        }
                        if (!string.IsNullOrWhiteSpace(item[3]))
                        {
                            isMcq = true;
                            question += "<li class=\"list-group-item\"><b>" + number + ". </b> " + item[3] + "</li>";
                            number++;
                        }
                        if (!string.IsNullOrWhiteSpace(item[4]))
                        {
                            isMcq = true;
                            question += "<li class=\"list-group-item\"><b>" + number + ". </b> " + item[4] + "</li>";
                            number++;
                        }
                        if (!string.IsNullOrWhiteSpace(item[5]))
                        {
                            isMcq = true;
                            question += "<li class=\"list-group-item\"><b>" + number + ". </b> " + item[5] + "</li>";
                            number++;
                        }
                        if (!string.IsNullOrWhiteSpace(item[6]))
                        {
                            isMcq = true;
                            question += "<li class=\"list-group-item\"><b>" + number + ". </b> " + item[6] + "</li>";
                            number++;
                        }

                        question += "</ul>";
                        question += "</div>";
                        question += "</div>";
                        int topic = 1;
                        //if (!string.IsNullOrWhiteSpace(item.ElementAt(8)))
                        //    topic = int.Parse(item[8]);

                        list.Add(new QuestionVM()
                        {
                            Q = question,
                            IsMcq = isMcq,
                            IsPublic = false,
                            Topic = topic,
                            CorrectAnswer = item[7]
                        });
                    }
                }
            }
            return list;
        }
    }
}
