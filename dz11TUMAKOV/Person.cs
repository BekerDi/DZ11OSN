using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11TUMAKOV
{
    
        class Person
        {
            public string Name { get; set; }
            public string Hobby { get; set; }

            public Person(string name, string hobby)
            {
                Name = name;
                Hobby = hobby;
            }

            public bool CheckHobby(string событие)
            {
                // Проверяем, совпадает ли увлечение человека с событием
                return событие.ToLower() == Hobby.ToLower();
            }

            public string GetReaction()
            {
                
                switch (Hobby.ToLower())
                {
                    case "выход новой серии":
                        return "Урааа! Я целую неделю ждал этго события! ";
                    case "концерт":
                        return "Это просто потрясающе! Я приду на концерт за 10 часов до начала и обязательно сфоткаюсь с исполнителем!!";
                    case "выставки":
                        return "Я так рад, что у мне выпал шанс посетить эту выставку, надо наделать контента!";
                    default:
                        return "Я не очень заинтересован(а) в этом событии.";
                }
            }
        }
}
