using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.Extensions.Logging;

namespace Database.Seeders
{
    public class PostSeeder
    {
        public void Seed(AppDbContext context, IServiceProvider serviceProvider, ILogger<AppDbContext> logger)
        {
            logger.LogInformation("Post seed started");

            try
            {
                var posts = context.Set<Post>();

                if (posts.Any())
                    return;

                var authorId = context.Users.First().Id;
                var data = GetPosts(authorId);
                
                posts.AddRange(data);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                logger.LogInformation("Post seed finished");
            }
        }

        private List<Post> GetPosts(Guid authorId)
        {
            return new()
            {
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "«May the 4th be with you!» Подборка наборов Lego ко Дню Звездных войн",
                    Content =
                        @"Известнее самих «Звездных войн», пожалуй, только наборы Lego по «Звездным войнам». В ассортименте датской компании это одна из главных серий со времен своего первого появления в 1999 году. «Звездные войны» в Lego охватывают канонические события фильмов и сериалов о событиях в далекой-далекой Галактике, включая новый сериал «Мандалорец». Мы собрали из Каталога интересные наборы Lego по этой серии, а в конце — большой бонус для фанатов «Звездных войн».

                Почему 4 мая? Потому что это крутая игра слов с известным пожеланием удачи в фильмах May The Force Be With You! («Да пребудет с тобой Сила!») и английским звучанием даты 4 мая (May The Fourth).

                К сожалению, не все новинки еще приехали в Беларусь. А там есть очень интересные вещи: чего стоит только один коллекционный R2-D2! Чтобы первыми узнать о появлении в продаже новых наборов Lego по «Звездным войнам», подписывайтесь на телеграм-канал Каталога.",
                    PublishDate = new DateTime(2021, 5, 4, 10, 22, 0),
                    AuthorId = authorId,
                    Tags = new[] {"Lego", "Star Wars"}
                },
                new Post
                {
                    Id = Guid.NewGuid(), Title = "Очередной народный? Обзор смартфона Xiaomi Redmi Note 10 Pro",
                    Content = @"С ходу сложно посчитать, сколько убойных моделей Redmi, ставших «народными», выпустила Xiaomi. Новый претендент на это звание — Redmi Note 10 Pro. На первый взгляд — идеальный смартфон, минимально уступающий в несколько раз более дорогим флагманам. Это, впрочем, не означает, что у новинки нет компромиссов.",
                    PublishDate = new DateTime(2021, 5, 1, 12, 10, 0),
                    AuthorId = authorId,
                    Tags = new []{"Mobile", "Xiaomi", "Review"}
                },
                new Post
                {
                    Id = Guid.NewGuid(), Title = "Воу, «Белшина», ты ли это? Неожиданные результаты сравнительного теста летних SUV-шин",
                    Content = @"По каким критериям вы выбираете шины? Наверняка в такой последовательности: бренд, цена и… отзывы. Также принято спрашивать «ну как?», слушать рекомендации всех и вся и самому давать советы, основанные на чьем-то опыте или слухах. Но мы решили пойти другим путем: собрали 5 комплектов «кроссоверных» шин 215/60 R17 от разных производителей (от самых бюджетных до премиальных) на сравнительный тест. Результаты нас удивили.",
                    PublishDate = new DateTime(2020, 3, 3, 14, 30, 0),
                    AuthorId = authorId,
                    Tags = new []{"Tiers", "Auto"}
                }
            };
        }
    }
}