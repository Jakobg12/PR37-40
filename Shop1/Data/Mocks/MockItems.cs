using Shop1.Data.Interfaces;
using Shop1.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop1.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategorys ICategory = new MockCategorys();
        public IEnumerable<Items> AllItems
        {
            get
            {
                return new List<Items>()
                {
                    new Items()
                    {
                        Id = 1,
                        Name = "Palit GeForce RTX 4080 SUPER GamingPro",
                        Description = "Видеокарта Palit GeForce RTX 4080 SUPER GamingPro [NED408S019T2-1032A] – оснащение для мощных игровых ПК. Устройство гарантирует возможность использования почти любых игр на максимальных настройках графики. Главный конструктивный элемент видеоадаптера – графический процессор GeForce RTX 4080 SUPER. Он базируется на микроархитектуре NVIDIA Ada Lovelace и произведен по техпроцессу 5 нм. Модель поддерживает технологию 0 дБ. При минимальном нагреве устройства вентиляторы снижают скорость вращения до нуля.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/e8ccd27e06b7e512e46dceb6eb0e2df3/d252de576bf9084de65c777f4be8147ae930e83b66a295a0cf61f3c0a2327ab2.jpg.webp",
                        Price = 131999,
                        Category = ICategory.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items()
                    {
                        Id = 2,
                        Name = "Микрофон HyperX QuadCast черный",
                        Description = "Конденсаторный микрофон HyperX QuadCast поможет вам качественно озвучивать стримы и подкасты. Особенностью модели является возможность переключения режимов диаграммы направленности. Высокая (-36 дБ) чувствительность свидетельствует о способности устройства детально передавать нюансы голоса любой громкости. Микрофон поддерживает широкий (от 20 Гц до 20 кГц) частотный диапазон. Чувствительность устройства можно регулировать. Конструкцией микрофона предусмотрен разъем для подключения наушников.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/13378dd496b557a59d293626b9ab8ae7/cb32c00f2a5b7048b14886adb821154e2d1721ca5c0e4c329837ab823f3d8ca9.jpg.webp",
                        Price = 15599,
                        Category = ICategory.AllCategorys.Where(x => x.Id == 2).First()
                    },
                    new Items()
                    {
                        Id = 3,
                        Name = "наушники Logitech G735 белый",
                        Description = "Bluetooth-гарнитура Logitech G735 подходит для подключения к ПК и мобильным устройствам. Синхронизация возможна с помощью беспроводного стандарта Bluetooth, радиоканальной технологии на частоте 2.4 ГГц или аудиокабеля с разъемом 3.5 мм. Закрытое акустическое оформление с 40-мм динамиками обеспечивает реалистичный звук с объемным эффектом и максимальное погружение в игровой процесс.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/5abb91930a395e7bd2a6e03c7f4bfd9f/e2dd0e46f4343631efdf612ddeccfec033f69830439d1caa14b79650809a11b2.jpg.webp",
                        Price = 25599,
                        Category = ICategory.AllCategorys.Where(x => x.Id == 3).First()
                    },
                    new Items()
                    {
                        Id = 4,
                        Name = "Клавиатура проводная+беспроводная ARDOR GAMING Wakizashi",
                        Description = "Клавиатура ARDOR GAMING Wakizashi [AG-ZD-87GT-HS-W] выполнена в корпусе белого цвета и дополнена подсветкой с палитрой RGB. Модель с 87 клавишами создана для поклонников компьютерных игр. Клавиатура оснащена механическими переключателями Gateron Mint с укороченным ходом 2 мм, что обеспечивает высокую точность срабатывания в играх. Стабилизаторы обеспечивают легкое и плавное нажатие.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/14d5780acd5c6bd435643ce792806f0d/abec7b9993fd7eea124d84de71656744128fb6be48acf2e567f1a878befc76e9.jpg.webp",
                        Price = 6999,
                        Category = ICategory.AllCategorys.Where(x => x.Id == 4).First()
                    },
                    new Items()
                    {
                        Id = 5,
                        Name = "Корпус Cougar Duoface RGB",
                        Description = "Корпус Cougar Duoface RGB привлекает внимание эффектным черным дизайном с металлической сеткой спереди и левой стенкой из закаленного стекла. Конструкция Mid-Tower позволяет работать с материнскими платами разных форм-факторов при вертикальной установке. 3 кулера оснащены яркой подсветкой с управлением через контроллер и кнопку на корпусе.\r\nCougar Duoface RGB оснащен 7 горизонтальными и 3 вертикальными слотами расширения для подключения видеокарт длиной до 33 см и других модулей. Есть 2 свободных места для накопителей 2.5” и 2 внутренних отсека 3.5”. Вы можете подключать до 5 кулеров, устанавливать систему жидкостного охлаждения и незаметно прокладывать провода сзади. Корпус дополнен пылевым фильтром и вырезом для крепления вентилятора.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/1918bd3482fb1729e568f8a198b4ca64/90f6b8a1b73ba6539b1c8cff10efd71b63ff90ffe08eb817cbdf192a183885e4.jpg.webp",
                        Price = 6299,
                        Category = ICategory.AllCategorys.Where(x => x.Id == 5).First()
                    },
                };
            }
        }
        public int Add(Items Item)
        {
            throw new System.NotImplementedException();
        }
    }

}