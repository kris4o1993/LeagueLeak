namespace LeagueLeak.Data.Migrations
{
    using LeagueLeak.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            // TODO: Remove after project is completed
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            if (!context.Users.Any())
            {
                SeedRolesAndUsers(context);
                context.SaveChanges();
            }

            if (!context.Champions.Any())
            {
                var champions = this.ChampionsToSeed();
                context.Champions.AddOrUpdate(champions.ToArray());
                context.SaveChanges();
            }

            if (!context.Spells.Any())
            {
                var spells = this.SpellsToSeed();
                context.Spells.AddOrUpdate(spells.ToArray());
                context.SaveChanges();
            }

            if (!context.Players.Any())
            {
                var players = this.PlayersToSeed();
                context.Players.AddOrUpdate(players.ToArray());
                context.SaveChanges();
            }

            if (!context.Articles.Any())
            {
                var articles = this.ArticlesToSeed();
                context.Articles.AddOrUpdate(articles.ToArray());
                context.SaveChanges();
            }

            if (!context.Guides.Any())
            {
                var guides = GuidesToSeed(context);
                context.Guides.AddOrUpdate(guides.ToArray());
                context.SaveChanges();
            }
        }

        private List<Guide> GuidesToSeed(ApplicationDbContext context)
        {
            var users = context.Users.Take(2).ToList();
            var champion = context.Champions.Take(1).ToList();
            var spell = context.Spells.Take(1).ToList();


            var sampleComments = new List<Comment>()
            {
                new Comment
                {
                    Author = users[0],
                    Content = "Sample comment from the admin!",
                    DateCreated = DateTime.Now.AddMinutes(-10)
                },
                new Comment
                {
                    Author = users[1],
                    Content = "Thanks for the comment, admin!",
                    DateCreated = DateTime.Now
                }
            };

            return new List<Guide>()
            {
                new Guide
                {
                    Title = "My first guide!",
                    Spell = spell[0],
                    Champion = champion[0],
                    Author = users[1],
                    Content = "This is a custom seeded guide made for testing purposes only. Good luck have fun!",
                    Comments = sampleComments
                }
            };
        }

        private void SeedRolesAndUsers(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("Administrator"));

            var userAdmin = new User { UserName = "admin@admin.com" };
            var userMember = new User { UserName = "kris@kris.com" };

            this.userManager.Create(userAdmin, "admin321");
            this.userManager.Create(userMember, "123456");

            this.userManager.AddToRole(userAdmin.Id, "Administrator");
        }

        private List<Spell> SpellsToSeed()
        {
            return new List<Spell>()
            {
                new Spell 
                {
                    Name = "Cleanse",
                    Description = "Removes all disables and summoner spell debuffs affecting your champion and lowers the duration of incoming disables by 65% for 3 seconds."
                },
                new Spell 
                {
                    Name = "Heal",
                    Description = "Restores 90-345 Health (depending on champion level) and grants 30% Movement Speed for 1 second to you and target allied champion. This healing is halved for units recently affected by Summoner Heal."
                },
                new Spell 
                {
                    Name = "Revive",
                    Description = "Instantly revives your champion at your team's Summoner Platform and increases their Movement Speed for a short duration."
                },
                new Spell 
                {
                    Name = "Exhaust",
                    Description = "Exhausts target enemy champion, reducing their Movement Speed and Attack Speed by 30%, their Armor and Magic Resist by 10, and their damage dealt by 40% for 2.5 seconds."
                },
                new Spell 
                {
                    Name = "Smite",
                    Description = "Deals 390-1000 true damage (depending on champion level) to target monster or enemy minion."
                },
                new Spell 
                {
                    Name = "Teleport",
                    Description = "After channeling for 3.5 seconds, teleports your champion to target allied minion, turret, or ward."
                },
                new Spell 
                {
                    Name = "Barrier",
                    Description = "Shields your champion for 115-455 (depending on champion level) for 2 seconds."
                },
                new Spell
                {
                    Name = "Clarity",
                    Description = "Restores 40% of your champion's maximum Mana. Also restores allies for 40% of their maximum Mana."
                },
                new Spell
                {
                    Name = "Clairvoyance",
                    Description = "Reveals a small area of the map for your team for 5 seconds."
                },
                new Spell 
                {
                    Name = "Ignite",
                    Description = "Ignites target enemy champion, dealing 70-410 true damage (depending on champion level) over 5 seconds, grants you vision of the target, and reduces healing effects on them for the duration."
                },
                new Spell 
                {
                    Name = "Flash",
                    Description = "Teleports your champion a short distance toward your cursor's location."
                },
                new Spell
                {
                    Name = "Ghost",
                    Description = "Your champion can move through units and has 27% increased Movement Speed for 10 seconds."
                },
            };
        }

        private List<Champion> ChampionsToSeed()
        {
            return new List<Champion>()
            {
                new Champion 
                {
                    Name = "Ahri",
                    Role = "Mage",
                    Defense = 4,
                    Magic = 8,
                    Difficulty = 5,
                    Attack = 3
                },
                new Champion 
                {
                    Name = "Thresh",
                    Role = "Support",
                    Defense = 6,
                    Magic = 6,
                    Difficulty = 7,
                    Attack = 5
                },
                new Champion 
                {
                    Name = "Ezreal",
                    Role = "Marksman",
                    Defense = 2,
                    Magic = 6,
                    Difficulty = 7,
                    Attack = 7
                },
                new Champion 
                {
                    Name = "Nami",
                    Role = "Support",
                    Defense = 3,
                    Magic = 7,
                    Difficulty = 5,
                    Attack = 4
                },
                new Champion
                {
                    Name = "Zyra",
                    Role = "Support",
                    Defense = 3,
                    Magic = 8,
                    Difficulty = 7,
                    Attack = 4
                },
                new Champion 
                {
                    Name = "Kassadin",
                    Role = "Mage",
                    Defense = 5,
                    Magic = 8,
                    Difficulty = 8,
                    Attack = 3
                },
                new Champion
                {
                    Name = "Twitch",
                    Role = "Marksman",
                    Defense = 2,
                    Magic = 3,
                    Difficulty = 6,
                    Attack = 9
                },
                new Champion
                {
                    Name = "Blitzcrank",
                    Role = "Tank",
                    Defense = 8,
                    Magic = 5,
                    Difficulty = 4,
                    Attack = 4
                },
                new Champion 
                {
                    Name = "Urgot",
                    Role = "Fighter",
                    Defense = 5,
                    Magic = 3,
                    Difficulty = 8,
                    Attack = 8
                },
                new Champion 
                {
                    Name = "Nocturne",
                    Role = "Assassin",
                    Defense = 5,
                    Magic = 2,
                    Difficulty = 4,
                    Attack = 8
                },
                new Champion
                {
                    Name = "Anivia",
                    Role = "Mage",
                    Defense = 4,
                    Magic = 10,
                    Difficulty = 10,
                    Attack = 1
                },
                new Champion
                {
                    Name = "Aatrox",
                    Role = "Fighter",
                    Defense = 4,
                    Magic = 3,
                    Difficulty = 4,
                    Attack = 8
                },
                new Champion
                {
                    Name = "Tryndamere",
                    Role = "Fighter",
                    Defense = 5,
                    Magic = 2,
                    Difficulty = 5,
                    Attack = 10
                },
                new Champion
                {
                    Name = "Gragas",
                    Role = "Fighter",
                    Defense = 7,
                    Magic = 6,
                    Difficulty = 5,
                    Attack = 4
                },
                new Champion 
                {
                    Name = "Cassiopeia",
                    Role = "Mage",
                    Defense = 3,
                    Magic = 9,
                    Difficulty = 10,
                    Attack = 2
                },
                new Champion 
                {
                    Name = "Ryze",
                    Role = "Mage",
                    Defense = 2,
                    Magic = 10,
                    Difficulty = 7,
                    Attack = 2
                },
                new Champion
                {
                    Name = "Poppy",
                    Role = "Assassin",
                    Defense = 6,
                    Magic = 5,
                    Difficulty = 7,
                    Attack = 6
                },
                new Champion
                {
                    Name = "Sion",
                    Role = "Tank",
                    Defense = 5,
                    Magic = 1,
                    Difficulty = 4,
                    Attack = 9
                }
            };
        }

        private List<Player> PlayersToSeed()
        {
            return new List<Player>()
            {
                new Player 
                {
                    Name = "Botalert",
                    Wins = 167,
                    Loses = 158,
                    Kills = 1764,
                    Deaths = 2580,
                    Assists = 4678,
                    Rating = 1953
                },
                new Player
                {
                    Name = "Grishko",
                    Wins = 145,
                    Loses = 143,
                    Kills = 1669,
                    Deaths = 1627,
                    Assists = 3506,
                    Rating = 1550
                },
                new Player 
                {
                    Name = "Krischo",
                    Wins = 45,
                    Loses = 54,
                    Kills = 977,
                    Deaths = 884,
                    Assists = 1407,
                    Rating = 1500
                },
                new Player
                {
                    Name = "HoPeKiLL3r",
                    Wins = 225,
                    Loses = 227,
                    Kills = 3872,
                    Deaths = 3135,
                    Assists = 4166,
                    Rating = 1897
                },
                new Player 
                {
                    Name = "Timer1989",
                    Wins = 600,
                    Loses = 571,
                    Kills = 6326,
                    Deaths = 8555,
                    Assists = 12796,
                    Rating = 2384
                },
                new Player 
                {
                    Name = "Bg Hot Stepper",
                    Wins = 19,
                    Loses = 17,
                    Kills = 129,
                    Deaths = 170,
                    Assists = 297,
                    Rating = 1490
                },
                new Player 
                {
                    Name = "Forsaken",
                    Wins = 149,
                    Loses = 155,
                    Kills = 1966,
                    Deaths = 1678,
                    Assists = 3025,
                    Rating = 1530
                },
                new Player
                {
                    Name = "Teknob0y",
                    Wins = 34,
                    Loses = 43,
                    Kills = 479,
                    Deaths = 483,
                    Assists = 660,
                    Rating = 1370
                },
                new Player 
                {
                    Name = "Askeroxior",
                    Wins = 69,
                    Loses = 75,
                    Kills = 1228,
                    Deaths = 1016,
                    Assists = 1534,
                    Rating = 1297
                },
                new Player
                {
                    Name = "Kalonder",
                    Wins = 412,
                    Loses = 442,
                    Kills = 5997,
                    Deaths = 5520,
                    Assists = 7793,
                    Rating = 1511
                },
                new Player 
                {
                    Name = "SpearFX",
                    Wins = 61,
                    Loses = 43,
                    Kills = 1118,
                    Deaths = 865,
                    Assists = 1222,
                    Rating = 1830
                },
                new Player 
                {
                    Name = "xPeke",
                    Wins = 115,
                    Loses = 74,
                    Kills = 1601,
                    Deaths = 1295,
                    Assists = 1685,
                    Rating = 2708
                },
                new Player 
                {
                    Name = "Cyanide",
                    Wins = 543,
                    Loses = 492,
                    Kills = 5926,
                    Deaths = 4815,
                    Assists = 9124,
                    Rating = 2641
                },
                new Player 
                {
                    Name = "Levskara07",
                    Wins = 345,
                    Loses = 344,
                    Kills = 4086,
                    Deaths = 3750,
                    Assists = 7338,
                    Rating = 1504
                },
                new Player 
                {
                    Name = "Caliser",
                    Wins = 359,
                    Loses = 369,
                    Kills = 6580,
                    Deaths = 5345,
                    Assists = 6814,
                    Rating = 1936
                },
                new Player 
                {
                    Name = "Phantomstoner",
                    Wins = 328,
                    Loses = 352,
                    Kills = 4989,
                    Deaths = 5968,
                    Assists = 7057,
                    Rating = 1865
                },
            };
        }

        private List<Article> ArticlesToSeed()
        {
            return new List<Article>()
            {
                new Article 
                {
                    Title = "Analyze This: Azir and Gnar",
                    Content = "Riot released five champions so far in 2014--a far cry from their nearly monthly releases of yesteryear." + 
                    "Gnar and Azir are the two latest champions to join League of Legends. Besides being new, both champions have faced a misconception at launch: " + 
                    "they're weak when they're actually pretty strong. Over the past year, Riot has almost intentionally started out with a champion being underwhelming" +
                    " and then quickly adjust it as needed on live. RIot does this because can't possibly catch all bugs a champion would have, especially" +
                    "with more complex champions. It also prevents situations like Zyra; on release, her abilities all did too much damage and ... ",
                    DateCreated = DateTime.Now.AddDays(-4)
                },
                new Article 
                {
                    Title = "Dev Blog: Optimizing the Rift",
                    Content = "When we first sat down to plan out our priorities for updating the Rift, we knew performance would necessarily be one of our primary challenges. After all, what good is a spiffy update if your toaster explodes during loading? With that in mind, we set a goal of ensuring that the update to Summoner’s Rift performs at least as well as current SR on every player’s machine. We’ve continued to work on optimization since announcing the update, and want to take some time now to discuss the latest details with you. Usually, when players think about how a game performs on their rig, they mostly look at the game’s tech. In reality, performance involves tight collaboration between artists and engineers, aimed at finding ways to implement art in an efficient fashion. When it comes to the update to Summoner’s Rift, our engineers have worked to provide the artists with the tools and information they need to create a landscape that can be both visually appealing and high-performing. The art team’s goal of increasing visual fidelity while maintaining performance parity with pre-update SR meant they needed a minimal set of highly-optimized features that would then allow them to create a hand-painted map. Essentially, this meant the engineering team needed to build a new, high performance renderer from scratch. Broadly, a renderer is responsible for placing game geometry onto your screen, and the new renderer for SR simplifies the process in ways that lead to higher performance, especially on older video cards. Additionally, it allows us to more finely tune the specifics of how a particular machine’s video card renders the environment, and tuning = speed = performance. Finally, the renderer gives us greater control over the map’s texture formats, allowing us to reduce video memory usage.",
                    DateCreated = DateTime.Now.AddDays(-3)
                },
                new Article 
                {
                    Title = "Ranked Restrictions",
                    Content = "Hey all, For a while now, the Competitive and Player Behavior teams have been working together to create features that foster both a fun and competitive environment in ranked play, and we recently tested a new feature on PBE. Known as Ranked Restrictions, the experiment restricted the in-game chat of negative players and prevented them from joining ranked queues until they’d completed the required number of games. With the feature proving successful on PBE, we’re rolling it out to live servers in NA and EUW in the coming days. Depending on the results of this, we’ll continue to add regions globally. When Ranked Restrictions go live on NA and EU, restricted players will be unable to queue up for ranked until they complete a certain number of games in Normal Draft. One thing we specifically wanted to address is that Ranked Restricted players will be Chat Restricted in other queues, and they can and should still be reported if they continue to display negative behaviors while playing through their restrictions. As with Chat Restrictions, after they finish the predetermined number of games, we’ll perform a final evaluation to make sure they've actually improved their in-game behavior. Players who haven’t shown improvement will continue to be restricted from playing ranked. Related to Ranked Restrictions, we’ve determined that Ranked Rewards should reward positive sportsmanship just as much as they reward great play, so the most negative players who are Ranked or Chat Restricted at the end of the season will be ineligible to earn ranked end of season rewards such as the loading screen borders or Victorious Morgana champion skin. While the majority of players will not be affected by this ruling, we wanted to message it well in advance so that players concerned about their behavior have more than enough time to adjust and reform before the end of the season.",
                    DateCreated = DateTime.Now.AddDays(-1)
                },
                new Article 
                {
                    Title = "End of Season Rewards and the new Master Tier",
                    Content = "After concerns surfaced around transparency in standings among the highest-tier league competition at the end of Season 3, we committed to making the path to the top more clear for players who participate in ranked. Master Tier was designed to address these concerns and more. Master Tier shares the same LP ladder as Challenger. Players who reach their promotion series at the top of Diamond 1 will enter Master Tier if they are successful. Please note that on release there will be no players in Master Tier, but it will begin to fill as soon as players start winning their promos",
                    DateCreated = DateTime.Now
                }
            };
        }
    }
}
