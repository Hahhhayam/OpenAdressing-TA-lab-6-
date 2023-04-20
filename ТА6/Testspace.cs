using System;
using ТА6.Controller;


namespace ТА6
{
    internal class Testspace
    {
        static void Main(string[] args)
        {
            HTController controller = new HTController(true, 30);
            controller.Set("Домашовець Акилина Радимівна", new DateTime(2005, 7, 5));
            controller.Set("Криворучко Шанетта Тихонівна", new DateTime(2005, 7, 5));
            controller.Set("Мережко Яна Тимурівна", DateTime.UtcNow);
            controller.Set("Цапенко Щедра Найденівна", DateTime.UtcNow);
            controller.Set("Янчук Марічка Жданівна", DateTime.UtcNow);
            controller.Set("Бек Єва Жданівна", DateTime.UtcNow);
            controller.Set("Банах Болеслава Орестівна", DateTime.UtcNow);
            controller.Set("Ілюк Марута Северинівна", DateTime.UtcNow);
            controller.Set("Мінченко Щедра Вадимівна", DateTime.UtcNow);
            controller.Set("Рудик Ірина Драганівна", DateTime.UtcNow);
            controller.Get("Бек Єва Жданівна");
            controller.Get("Мінченко Щедра Вадимівна");
            controller.Delete("Бек Єва Жданівна");
            controller.Update("Мінченко Щедра Вадимівна", new DateTime(2004, 2, 2));
            Console.WriteLine(controller.GetTableLog());
        }
    }
}
