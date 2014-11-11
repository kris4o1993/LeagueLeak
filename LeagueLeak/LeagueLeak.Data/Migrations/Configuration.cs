namespace LeagueLeak.Data.Migrations
{
    using LeagueLeak.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove after project is completed
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Champions.Any())
            {
                var champions = ChampionsToSeed();
                context.Champions.AddOrUpdate(champions.ToArray());
            }

            if (!context.Spells.Any())
            {
                var spells = SpellsToSeed();
                context.Spells.AddOrUpdate(spells.ToArray());
            }

            if (!context.Players.Any())
            {
                var players = PlayersToSeed();
                context.Players.AddOrUpdate(players.ToArray());
            }

            
        }

        private List<Spell> SpellsToSeed()
        {
            return new List<Spell>()
            {
                new Spell {
                    Name = "Cleanse",
                    Description = "Removes all disables and summoner spell debuffs affecting your champion and lowers the duration of incoming disables by 65% for 3 seconds."
                },
                new Spell {
                    Name = "Heal",
                    Description = "Restores 90-345 Health (depending on champion level) and grants 30% Movement Speed for 1 second to you and target allied champion. This healing is halved for units recently affected by Summoner Heal."
                },
                new Spell {
                    Name = "Revive",
                    Description = "Instantly revives your champion at your team's Summoner Platform and increases their Movement Speed for a short duration."
                },
                new Spell {
                    Name = "Exhaust",
                    Description = "Exhausts target enemy champion, reducing their Movement Speed and Attack Speed by 30%, their Armor and Magic Resist by 10, and their damage dealt by 40% for 2.5 seconds."
                },
                new Spell {
                    Name = "Smite",
                    Description = "Deals 390-1000 true damage (depending on champion level) to target monster or enemy minion."
                },
                new Spell {
                    Name = "Teleport",
                    Description = "After channeling for 3.5 seconds, teleports your champion to target allied minion, turret, or ward."
                },
                new Spell {
                    Name = "Barrier",
                    Description = "Shields your champion for 115-455 (depending on champion level) for 2 seconds."
                },
                new Spell {
                    Name = "Clarity",
                    Description = "Restores 40% of your champion's maximum Mana. Also restores allies for 40% of their maximum Mana."
                },
                new Spell {
                    Name = "Clairvoyance",
                    Description = "Reveals a small area of the map for your team for 5 seconds."
                },
                new Spell {
                    Name = "Ignite",
                    Description = "Ignites target enemy champion, dealing 70-410 true damage (depending on champion level) over 5 seconds, grants you vision of the target, and reduces healing effects on them for the duration."
                },
                new Spell {
                    Name = "Flash",
                    Description = "Teleports your champion a short distance toward your cursor's location."
                },
                new Spell {
                    Name = "Ghost",
                    Description = "Your champion can move through units and has 27% increased Movement Speed for 10 seconds."
                },
            };
        }

        private List<Champion> ChampionsToSeed()
        {
            return new List<Champion>()
            {
                new Champion {
                    Name = "Ahri",
                    Title = "the Nine-Tailed Fox",
                    Roles = new List<string>() {"Mage", "Assassin"},
                    Defense = 4,
                    Magic = 8,
                    Difficulty = 5,
                    Attack = 3
                },
                new Champion {
                    Name = "Thresh",
                    Title = "the Chain Warden",
                    Roles = new List<string>() {"Support", "Fighter"},
                    Defense = 6,
                    Magic = 6,
                    Difficulty = 7,
                    Attack = 5
                },
                new Champion {
                    Name = "Ezreal",
                    Title = "the Prodigal Explorer",
                    Roles = new List<string>() {"Marksman", "Mage"},
                    Defense = 2,
                    Magic = 6,
                    Difficulty = 7,
                    Attack = 7
                },
                new Champion {
                    Name = "Nami",
                    Title = "the Tidecaller",
                    Roles = new List<string>() {"Support", "Mage"},
                    Defense = 3,
                    Magic = 7,
                    Difficulty = 5,
                    Attack = 4
                },
                new Champion {
                    Name = "Zyra",
                    Title = "Rise of the Thorns",
                    Roles = new List<string>() {"Support", "Mage"},
                    Defense = 3,
                    Magic = 8,
                    Difficulty = 7,
                    Attack = 4
                },
                new Champion {
                    Name = "Kassadin",
                    Title = "the Void Walker",
                    Roles = new List<string>() {"Mage"},
                    Defense = 5,
                    Magic = 8,
                    Difficulty = 8,
                    Attack = 3
                },
                new Champion {
                    Name = "Twitch",
                    Title = "the Plague Rat",
                    Roles = new List<string>() {"Marksman", "Assassin"},
                    Defense = 2,
                    Magic = 3,
                    Difficulty = 6,
                    Attack = 9
                },
                new Champion {
                    Name = "Blitzcrank",
                    Title = "the Great Steam Golem",
                    Roles = new List<string>() {"Fighter", "Tank"},
                    Defense = 8,
                    Magic = 5,
                    Difficulty = 4,
                    Attack = 4
                },
                new Champion {
                    Name = "Urgot",
                    Title = "the Headsman's Pride",
                    Roles = new List<string>() {"Fighter", "Marksman"},
                    Defense = 5,
                    Magic = 3,
                    Difficulty = 8,
                    Attack = 8
                },
                new Champion {
                    Name = "Nocturne",
                    Title = "the Eternal Nightmare",
                    Roles = new List<string>() {"Fighter", "Assassin"},
                    Defense = 5,
                    Magic = 2,
                    Difficulty = 4,
                    Attack = 8
                },
                new Champion {
                    Name = "Anivia",
                    Title = "the Cryophoenix",
                    Roles = new List<string>() {"Mage", "Support"},
                    Defense = 4,
                    Magic = 10,
                    Difficulty = 10,
                    Attack = 1
                },
                new Champion {
                    Name = "Aatrox",
                    Title = "the Darkin Blade",
                    Roles = new List<string>() {"Fighter", "Tank"},
                    Defense = 4,
                    Magic = 3,
                    Difficulty = 4,
                    Attack = 8
                },
                new Champion {
                    Name = "Tryndamere",
                    Title = "the Barbarian King",
                    Roles = new List<string>() {"Fighter", "Assassin"},
                    Defense = 5,
                    Magic = 2,
                    Difficulty = 5,
                    Attack = 10
                },
                new Champion {
                    Name = "Gragas",
                    Title = "the Rabble Rouser",
                    Roles = new List<string>() {"Fighter", "Mage"},
                    Defense = 7,
                    Magic = 6,
                    Difficulty = 5,
                    Attack = 4
                },
                new Champion {
                    Name = "Cassiopeia",
                    Title = "the Serpent's Embrace",
                    Roles = new List<string>() {"Mage"},
                    Defense = 3,
                    Magic = 9,
                    Difficulty = 10,
                    Attack = 2
                },
                new Champion {
                    Name = "Ryze",
                    Title = "the Rogue Mage",
                    Roles = new List<string>() {"Fighter", "Mage"},
                    Defense = 2,
                    Magic = 10,
                    Difficulty = 7,
                    Attack = 2
                },
                new Champion {
                    Name = "Poppy",
                    Title = "the Iron Ambassador",
                    Roles = new List<string>() {"Fighter", "Assassin"},
                    Defense = 6,
                    Magic = 5,
                    Difficulty = 7,
                    Attack = 6
                },
                new Champion {
                    Name = "Sion",
                    Title = "The Undead Juggernaut",
                    Roles = new List<string>() {"Fighter", "Tank"},
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
                new Player {
                    Name = "Botalert",
                    Wins = 167,
                    Loses = 158,
                    Kills = 1764,
                    Deaths = 2580,
                    Assists = 4678,
                    Rating = 1953
                },
                new Player {
                    Name = "Grishko",
                    Wins = 145,
                    Loses = 143,
                    Kills = 1669,
                    Deaths = 1627,
                    Assists = 3506,
                    Rating = 1550
                },
                new Player {
                    Name = "Krischo",
                    Wins = 45,
                    Loses = 54,
                    Kills = 977,
                    Deaths = 884,
                    Assists = 1407,
                    Rating = 1500
                },
                new Player {
                    Name = "HoPeKiLL3r",
                    Wins = 225,
                    Loses = 227,
                    Kills = 3872,
                    Deaths = 3135,
                    Assists = 4166,
                    Rating = 1897
                },
                new Player {
                    Name = "Timer1989",
                    Wins = 600,
                    Loses = 571,
                    Kills = 6326,
                    Deaths = 8555,
                    Assists = 12796,
                    Rating = 2384
                },
                new Player {
                    Name = "Bg Hot Stepper",
                    Wins = 19,
                    Loses = 17,
                    Kills = 129,
                    Deaths = 170,
                    Assists = 297,
                    Rating = 1490
                },
                new Player {
                    Name = "Forsaken",
                    Wins = 149,
                    Loses = 155,
                    Kills = 1966,
                    Deaths = 1678,
                    Assists = 3025,
                    Rating = 1530
                },
                new Player {
                    Name = "Teknob0y",
                    Wins = 34,
                    Loses = 43,
                    Kills = 479,
                    Deaths = 483,
                    Assists = 660,
                    Rating = 1370
                },
                new Player {
                    Name = "Askeroxior",
                    Wins = 69,
                    Loses = 75,
                    Kills = 1228,
                    Deaths = 1016,
                    Assists = 1534,
                    Rating = 1297
                },
                new Player {
                    Name = "Kalonder",
                    Wins = 412,
                    Loses = 442,
                    Kills = 5997,
                    Deaths = 5520,
                    Assists = 7793,
                    Rating = 1511
                },
                new Player {
                    Name = "SpearFX",
                    Wins = 61,
                    Loses = 43,
                    Kills = 1118,
                    Deaths = 865,
                    Assists = 1222,
                    Rating = 1830
                },
                new Player {
                    Name = "xPeke",
                    Wins = 115,
                    Loses = 74,
                    Kills = 1601,
                    Deaths = 1295,
                    Assists = 1685,
                    Rating = 2708
                },
                new Player {
                    Name = "Cyanide",
                    Wins = 543,
                    Loses = 492,
                    Kills = 5926,
                    Deaths = 4815,
                    Assists = 9124,
                    Rating = 2641
                },
                new Player {
                    Name = "Levskara07",
                    Wins = 345,
                    Loses = 344,
                    Kills = 4086,
                    Deaths = 3750,
                    Assists = 7338,
                    Rating = 1504
                },
                new Player {
                    Name = "Caliser",
                    Wins = 359,
                    Loses = 369,
                    Kills = 6580,
                    Deaths = 5345,
                    Assists = 6814,
                    Rating = 1936
                },
                new Player {
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
    }
}
