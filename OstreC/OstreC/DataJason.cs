﻿using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using OstreC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
/*
namespace OstreC
{
    internal class DataJason
    {
        public static string Races()
        {
            string races = @"{
  ""count"": 9,
  ""next"": null,
  ""previous"": null,
  ""results"": [
    {
      ""name"": ""Dwarf"",
      ""slug"": ""dwarf"",
      ""desc"": ""## Dwarf Traits\nYour dwarf character has an assortment of inborn abilities, part and parcel of dwarven nature."",
      ""asi_desc"": ""**_Ability Score Increase._** Your Constitution score increases by 2."",
      ""asi"": [
        {
          ""attributes"": ""Constitution"",
          ""value"": 2
        }
      ],
      ""age"": ""**_Age._** Dwarves mature at the same rate as humans, but they're considered young until they reach the age of 50. On average, they live about 350 years."",
      ""alignment"": ""**_Alignment._** Most dwarves are lawful, believing firmly in the benefits of a well-ordered society. They tend toward good as well, with a strong sense of fair play and a belief that everyone deserves to share in the benefits of a just order."",
      ""size"": ""**_Size._** Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium."",
      ""speed"": { ""walk"": 25 },
      ""speed_desc"": ""**_Speed._** Your base walking speed is 25 feet. Your speed is not reduced by wearing heavy armor."",
      ""languages"": ""**_Languages._** You can speak, read, and write Common and Dwarvish. Dwarvish is full of hard consonants and guttural sounds, and those characteristics spill over into whatever other language a dwarf might speak."",
      ""vision"": ""**_Darkvision._** Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray."",
      ""traits"": ""**_Dwarven Resilience._** You have advantage on saving throws against poison, and you have resistance against poison damage.\n\n**_Dwarven Combat Training._** You have proficiency with the battleaxe, handaxe, light hammer, and warhammer.\n\n**_Tool Proficiency._** You gain proficiency with the artisan's tools of your choice: smith's tools, brewer's supplies, or mason's tools.\n\n**_Stonecunning._** Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check, instead of your normal proficiency bonus."",
      ""subraces"": [
        {
          ""name"": ""Hill Dwarf"",
          ""slug"": ""hill-dwarf"",
          ""desc"": ""As a hill dwarf, you have keen senses, deep intuition, and remarkable resilience."",
          ""asi"": [
            {
              ""attributes"": ""Wisdom"",
              ""value"": 1
            }
          ],
          ""traits"": ""**_Dwarven Toughness._** Your hit point maximum increases by 1, and it increases by 1 every time you gain a level."",
          ""asi_desc"": ""**_Ability Score Increase._** Your Wisdom score increases by 1"",
          ""document__slug"": ""wotc-srd"",
          ""document__title"": ""Systems Reference Document""
        }
      ],
      ""document__slug"": ""wotc-srd"",
      ""document__title"": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    },
    {
      ""name"": ""Elf"",
      ""slug"": ""elf"",
      ""desc"": ""## Elf Traits\nYour elf character has a variety of natural abilities, the result of thousands of years of elven refinement."",
      ""asi_desc"": ""**_Ability Score Increase._** Your Dexterity score increases by 2."",
      ""asi"": [
        {
          ""attributes"": ""Dexterity"",
          ""value"": 2
        }
      ],
      ""age"": ""**_Age._** Although elves reach physical maturity at about the same age as humans, the elven understanding of adulthood goes beyond physical growth to encompass worldly experience. An elf typically claims adulthood and an adult name around the age of 100 and can live to be 750 years old."",
      ""alignment"": ""**_Alignment._** Elves love freedom, variety, and self- expression, so they lean strongly toward the gentler aspects of chaos. They value and protect others' freedom as well as their own, and they are more often good than not. The drow are an exception; their exile has made them vicious and dangerous. Drow are more often evil than not."",
      ""size"": ""**_Size._** Elves range from under 5 to over 6 feet tall and have slender builds. Your size is Medium."",
      ""speed"": { ""walk"": 30 },
      ""speed_desc"": ""**_Speed._** Your base walking speed is 30 feet."",
      ""languages"": ""**_Languages._** You can speak, read, and write Common and Elvish. Elvish is fluid, with subtle intonations and intricate grammar. Elven literature is rich and varied, and their songs and poems are famous among other races. Many bards learn their language so they can add Elvish ballads to their repertoires."",
      ""vision"": ""**_Darkvision._** Accustomed to twilit forests and the night sky, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray."",
      ""traits"": ""**_Keen Senses._** You have proficiency in the Perception skill.\n\n**_Fey Ancestry._** You have advantage on saving throws against being charmed, and magic can't put you to sleep.\n\n**_Trance._** Elves don't need to sleep. Instead, they meditate deeply, remaining semiconscious, for 4 hours a day. (The Common word for such meditation is “trance.”) While meditating, you can dream after a fashion; such dreams are actually mental exercises that have become reflexive through years of practice.\nAfter resting in this way, you gain the same benefit that a human does from 8 hours of sleep."",
      ""subraces"": [
        {
          ""name"": ""High Elf"",
          ""slug"": ""high-elf"",
          ""desc"": ""As a high elf, you have a keen mind and a mastery of at least the basics of magic. In many fantasy gaming worlds, there are two kinds of high elves. One type is haughty and reclusive, believing themselves to be superior to non-elves and even other elves. The other type is more common and more friendly, and often encountered among humans and other races."",
          ""asi"": [
            {
              ""attributes"": ""Intelligence"",
              ""value"": 1
            }
          ],
          ""traits"": ""**_Elf Weapon Training._** You have proficiency with the longsword, shortsword, shortbow, and longbow.\n\n**_Cantrip._** You know one cantrip of your choice from the wizard spell list. Intelligence is your spellcasting ability for it.\n\n**_Extra Language._** You can speak, read, and write one extra language of your choice."",
          ""asi_desc"": ""**_Ability Score Increase._** Your Intelligence score increases by 1."",
          ""document__slug"": ""wotc-srd"",
          ""document__title"": ""Systems Reference Document""
        }
      ],
      ""document__slug"": ""wotc-srd"",
      ""document__title"": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    },
    {
      ""name"": ""Halfling"",
      ""slug"": ""halfling"",
      ""desc"": ""## Halfling Traits\nYour halfling character has a number of traits in common with all other halflings."",
      ""asi_desc"": ""**_Ability Score Increase._** Your Dexterity score increases by 2."",
      ""asi"": [
        {
          ""attributes"": ""Dexterity"",
          ""value"": 2
        }
      ],
      ""age"": ""**_Age._** A halfling reaches adulthood at the age of 20 and generally lives into the middle of his or her second century."",
      ""alignment"": ""**_Alignment._** Most halflings are lawful good. As a rule, they are good-hearted and kind, hate to see others in pain, and have no tolerance for oppression. They are also very orderly and traditional, leaning heavily on the support of their community and the comfort of their old ways."",
      ""size"": ""**_Size._** Halflings average about 3 feet tall and weigh about 40 pounds. Your size is Small."",
      ""speed"": { ""walk"": 25 },
      ""speed_desc"": ""**_Speed._** Your base walking speed is 25 feet."",
      ""languages"": ""**_Languages._** You can speak, read, and write Common and Halfling. The Halfling language isn't secret, but halflings are loath to share it with others. They write very little, so they don't have a rich body of literature. Their oral tradition, however, is very strong. Almost all halflings speak Common to converse with the people in whose lands they dwell or through which they are traveling."",
      ""vision"": """",
      ""traits"": "" * *_Lucky._ * *When you roll a 1 on the d20 for an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll.\n\n * *_Brave._ * *You have advantage on saving throws against being frightened.\n\n * *_Halfling Nimbleness._ * *You can move through the space of any creature that is of a size larger than yours."",
      ""subraces"": [
        {
                ""name"": ""Lightfoot"",
          ""slug"": ""lightfoot"",
          ""desc"": ""As a lightfoot halfling, you can easily hide from notice, even using other people as cover.You're inclined to be affable and get along well with others.\nLightfoots are more prone to wanderlust than other halflings, and often dwell alongside other races or take up a nomadic life."",
          ""asi"": [
            {
                    ""attributes"": ""Charisma"",
              ""value"": 1
            }
          ],
          ""traits"": "" * *_Naturally Stealthy._** You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you."",
          ""asi_desc"": "" * *_Ability Score Increase._** Your Charisma score increases by 1."",
          ""document__slug"": ""wotc - srd"",
          ""document__title"": ""Systems Reference Document""
        }
      ],
      ""document__slug"": ""wotc - srd"",
      ""document__title"": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    },
    {
      ""name"": ""Human"",
      ""slug"": ""human"",
      ""desc"": ""## Human Traits\nIt's hard to make generalizations about humans, but your human character has these traits."",
      ""asi_desc"": ""**_Ability Score Increase._** Your ability scores each increase by 1."",
      ""asi"": [
        {
          ""attributes"": ""Strength"",
          ""value"": 1
        },
        {
          ""attributes"": ""Dexterity"",
          ""value"": 1
        },
        {
    ""attributes"": ""Constitution"",
          ""value"": 1
        },
        {
    ""attributes"": ""Intelligence"",
          ""value"": 1
        },
        {
    ""attributes"": ""Wisdom"",
          ""value"": 1
        },
        {
    ""attributes"": ""Charisma"",
          ""value"": 1
        }
      ],
      ""age "": "" * *_Age._ * *Humans reach adulthood in their late teens and live less than a century."",
      ""alignment"": "" * *_Alignment._ * *Humans tend toward no particular alignment. The best and the worst are found among them."",
      ""size"": "" * *_Size._ * *Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium."",
      ""speed"": { ""walk"": 30 },
      ""speed_desc "": "" * *_Speed._ * *Your base walking speed is 30 feet."",
      ""languages"": "" * *_Languages._ * *You can speak, read, and write Common and one extra language of your choice. Humans typically learn the languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish military phrases, and so on."",
      ""vision"": """",
      ""traits "": """",
      ""subraces "": [],
      ""document__slug "": ""wotc - srd"",
      ""document__title "": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    },
    {
    ""name"": ""Dragonborn"",
      ""slug"": ""dragonborn"",
      ""desc"": ""## Dragonborn Traits\nYour draconic heritage manifests in a variety of traits you share with other dragonborn."",
      ""asi_desc"": "" * *_Ability Score Increase._** Your Strength score increases by 2, and your Charisma score increases by 1."",
      ""asi"": [
        {
        ""attributes"": ""Strength"",
          ""value"": 2
        },
        {
        ""attributes"": ""Charisma"",
          ""value"": 1
        }
      ],
      ""age"": "" * *_Age._ * *Young dragonborn grow quickly.They walk hours after hatching, attain the size and development of a 10 - year - old human child by the age of 3, and reach adulthood by 15.They live to be around 80."",
      ""alignment"": "" * *_Alignment._ * *Dragonborn tend to extremes, making a conscious choice for one side or the other in the cosmic war between good and evil.Most dragonborn are good, but those who side with evil can be terrible villains."",
      ""size"": "" * *_Size._ * *Dragonborn are taller and heavier than humans, standing well over 6 feet tall and averaging almost 250 pounds.Your size is Medium."",
      ""speed"": { ""walk"": 30 },
      ""speed_desc"": "" * *_Speed._ * *Your base walking speed is 30 feet."",
      ""languages"": "" * *_Languages._ * *You can speak, read, and write Common and Draconic. Draconic is thought to be one of the oldest languages and is often used in the study of magic. The language sounds harsh to most other creatures and includes numerous hard consonants and sibilants."",
      ""vision"": """",
      ""traits"": "" * *Draconic Ancestry * * \n\n | Dragon | Damage Type | Breath Weapon |\n | --------------| -------------------| ------------------------------|\n | Black | Acid | 5 by 30 ft.line(Dex.save) |\n | Blue | Lightning | 5 by 30 ft.line(Dex.save) |\n | Brass | Fire | 5 by 30 ft.line(Dex.save) |\n | Bronze | Lightning | 5 by 30 ft.line(Dex.save) |\n | Copper | Acid | 5 by 30 ft.line(Dex.save) |\n | Gold | Fire | 15 ft.cone(Dex.save) |\n | Green | Poison | 15 ft.cone(Con.save) |\n | Red | Fire | 15 ft.cone(Dex.save) |\n | Silver | Cold | 15 ft.cone(Con.save) |\n | White | Cold | 15 ft.cone(Con.save) |\n\n\n** _Draconic Ancestry._** You have draconic ancestry.Choose one type of dragon from the Draconic Ancestry table. Your breath weapon and damage resistance are determined by the dragon type, as shown in the table.\n\n** _Breath Weapon._** You can use your action to exhale destructive energy. Your draconic ancestry determines the size, shape, and damage type of the exhalation.\nWhen you use your breath weapon, each creature in the area of the exhalation must make a saving throw, the type of which is determined by your draconic ancestry.The DC for this saving throw equals 8 + your Constitution modifier + your proficiency bonus.A creature takes 2d6 damage on a failed save, and half as much damage on a successful one.The damage increases to 3d6 at 6th level, 4d6 at 11th level, and 5d6 at 16th level.\nAfter you use your breath weapon, you can't use it again until you complete a short or long rest.\n\n**_Damage Resistance._** You have resistance to the damage type associated with your draconic ancestry."",
      ""subraces"": [],
    ""document__slug"": ""wotc - srd"",
    ""document__title"": ""Systems Reference Document"",
    ""document__license_url"": ""http://open5e.com/legal""
    },
    {
    ""name"": ""Gnome"",
      ""slug"": ""gnome"",
      ""desc"": ""## Gnome Traits\nYour gnome character has certain characteristics in common with all other gnomes."",
      ""asi_desc"": "" * *_Ability Score Increase._** Your Intelligence score increases by 2."",
      ""asi"": [
        {
        ""attributes"": ""Intelligence"",
          ""value"": 2
        }
      ],
      ""age"": "" * *_Age._ * *Gnomes mature at the same rate humans do, and most are expected to settle down into an adult life by around age 40.They can live 350 to almost 500 years."",
      ""alignment"": "" * *_Alignment._ * *Gnomes are most often good. Those who tend toward law are sages, engineers, researchers, scholars, investigators, or inventors. Those who tend toward chaos are minstrels, tricksters, wanderers, or fanciful jewelers.Gnomes are good - hearted, and even the tricksters among them are more playful than vicious."",
      ""size"": "" * *_Size._ * *Gnomes are between 3 and 4 feet tall and average about 40 pounds.Your size is Small."",
      ""speed"": { ""walk"": 25 },
      ""speed_desc"": "" * *_Speed._ * *Your base walking speed is 25 feet."",
      ""languages"": "" * *_Languages._ * *You can speak, read, and write Common and Gnomish. The Gnomish language, which uses the Dwarvish script, is renowned for its technical treatises and its catalogs of knowledge about the natural world."",
    ""vision"": "" * *_Darkvision._ * *Accustomed to life underground, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light.You can't discern color in darkness, only shades of gray."",
      ""traits"": "" * *_Gnome Cunning._** You have advantage on all Intelligence, Wisdom, and Charisma saving throws against magic."",
      ""subraces"": [
        {
        ""name"": ""Rock Gnome"",
          ""slug"": ""rock - gnome"",
          ""desc"": ""## Rock Gnome\nAs a rock gnome, you have a natural inventiveness and hardiness beyond that of other gnomes."",
          ""asi"": [
            {
            ""attributes"": ""Constitution"",
              ""value"": 1
            }
          ],
          ""traits"": "" * *_Artificer's Lore._** Whenever you make an Intelligence (History) check related to magic items, alchemical objects, or technological devices, you can add twice your proficiency bonus, instead of any proficiency bonus you normally apply.\n\n**_Tinker._** You have proficiency with artisan's tools(tinker's tools). Using those tools, you can spend 1 hour and 10 gp worth of materials to construct a Tiny clockwork device (AC 5, 1 hp). The device ceases to function after 24 hours (unless you spend 1 hour repairing it to keep the device functioning), or when you use your action to dismantle it; at that time, you can reclaim the materials used to create it. You can have up to three such devices active at a time.\nWhen you create a device, choose one of the following options:\n* _Clockwork Toy._ This toy is a clockwork animal, monster, or person, such as a frog, mouse, bird, dragon, or soldier. When placed on the ground, the toy moves 5 feet across the ground on each of your turns in a random direction. It makes noises as appropriate to the creature it represents.\n* _Fire Starter._ The device produces a miniature flame, which you can use to light a candle, torch, or campfire. Using the device requires your action.\n* _Music Box._ When opened, this music box plays a single song at a moderate volume. The box stops playing when it reaches the song's end or when it is closed."",
          ""asi_desc"": "" * *_Ability Score Increase._** Your Constitution score increases by 1."",
          ""document__slug"": ""wotc - srd"",
          ""document__title"": ""Systems Reference Document""
        }
      ],
      ""document__slug"": ""wotc - srd"",
      ""document__title"": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    },
    {
    ""name"": ""Half - Elf"",
      ""slug"": ""half - elf"",
      ""desc"": ""## Half-Elf Traits\nYour half-elf character has some qualities in common with elves and some that are unique to half-elves."",
      ""asi_desc"": "" * *_Ability Score Increase._** Your Charisma score increases by 2, and two other ability scores of your choice increase by 1."",
      ""asi"": [
        {
        ""attributes"": ""Charisma"",
          ""value"": 2
        },
        {
        ""attributes"": ""Other"",
          ""value"": 1
        },
        {
        ""attributes"": ""Other"",
          ""value"": 1
        }
      ],
      ""age"": "" * *_Age._ * *Half - elves mature at the same rate humans do and reach adulthood around the age of 20.They live much longer than humans, however, often exceeding 180 years."",
      ""alignment"": "" * *_Alignment._ * *Half - elves share the chaotic bent of their elven heritage. They value both personal freedom and creative expression, demonstrating neither love of leaders nor desire for followers.They chafe at rules, resent others' demands, and sometimes prove unreliable, or at least unpredictable."",
      ""size"": "" * *_Size._ * *Half - elves are about the same size as humans, ranging from 5 to 6 feet tall.Your size is Medium."",
      ""speed"": { ""walk"": 30 },
      ""speed_desc"": "" * *_Speed._ * *Your base walking speed is 30 feet."",
      ""languages"": "" * *_Languages._ * *You can speak, read, and write Common, Elvish, and one extra language of your choice."",
      ""vision"": "" * *_Darkvision._ * *Thanks to your elf blood, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light.You can't discern color in darkness, only shades of gray."",
      ""traits"": "" * *_Fey Ancestry._** You have advantage on saving throws against being charmed, and magic can't put you to sleep.\n\n**_Skill Versatility._** You gain proficiency in two skills of your choice."",
      ""subraces"": [],
      ""document__slug"": ""wotc - srd"",
      ""document__title"": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    },
    {
    ""name"": ""Half - Orc"",
      ""slug"": ""half - orc"",
      ""desc"": ""## Half-Orc Traits\nYour half-orc character has certain traits deriving from your orc ancestry."",
      ""asi_desc"": "" * *_Ability Score Increase._** Your Strength score increases by 2, and your Constitution score increases by 1."",
      ""asi"": [
        {
        ""attributes"": ""Strength"",
          ""value"": 2
        },
        {
        ""attributes"": ""Constitution"",
          ""value"": 1
        }
      ],
      ""age"": "" * *_Age._ * *Half - orcs mature a little faster than humans, reaching adulthood around age 14.They age noticeably faster and rarely live longer than 75 years."",
      ""alignment"": "" * *_Alignment._ * *Half - orcs inherit a tendency toward chaos from their orc parents and are not strongly inclined toward good. Half - orcs raised among orcs and willing to live out their lives among them are usually evil."",
      ""size"": "" * *_Size._ * *Half - orcs are somewhat larger and bulkier than humans, and they range from 5 to well over 6 feet tall. Your size is Medium."",
      ""speed"": { ""walk"": 30 },
      ""speed_desc"": "" * *_Speed._ * *Your base walking speed is 30 feet."",
      ""languages"": "" * *_Languages._ * *You can speak, read, and write Common and Orc. Orc is a harsh, grating language with hard consonants.It has no script of its own but is written in the Dwarvish script."",
      ""vision"": "" * *_Darkvision._ * *Thanks to your orc blood, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light.You can't discern color in darkness, only shades of gray."",
      ""traits"": "" * *_Menacing._ * *You gain proficiency in the Intimidation skill.\n\n** _Relentless Endurance._** When you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead.You can't use this feature again until you finish a long rest.\n\n**_Savage Attacks._** When you score a critical hit with a melee weapon attack, you can roll one of the weapon's damage dice one additional time and add it to the extra damage of the critical hit."",
      ""subraces"": [],
      ""document__slug"": ""wotc - srd"",
      ""document__title"": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    },
    {
    ""name"": ""Tiefling"",
      ""slug"": ""tiefling"",
      ""desc"": ""## Tiefling Traits\nTieflings share certain racial traits as a result of their infernal descent."",
      ""asi_desc"": "" * *_Ability Score Increase._** Your Intelligence score increases by 1, and your Charisma score increases by 2."",
      ""asi"": [
        {
        ""attributes"": ""Intelligence"",
          ""value"": 1
        },
        {
        ""attributes"": ""Charisma"",
          ""value"": 2
        }
      ],
      ""age"": "" * *_Age._ * *Tieflings mature at the same rate as humans but live a few years longer."",
      ""alignment"": "" * *_Alignment._ * *Tieflings might not have an innate tendency toward evil, but many of them end up there. Evil or not, an independent nature inclines many tieflings toward a chaotic alignment."",
      ""size"": "" * *_Size._ * *Tieflings are about the same size and build as humans.Your size is Medium."",
      ""speed"": { ""walk"": 30 },
      ""speed_desc"": "" * *_Speed._ * *Your base walking speed is 30 feet."",
      ""languages"": "" * *_Languages._ * *You can speak, read, and write Common and Infernal."",
      ""vision"": "" * *_Darkvision._ * *Thanks to your infernal heritage, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light.You can't discern color in darkness, only shades of gray."",
      ""traits"": "" * *_Hellish Resistance._** You have resistance to fire damage.\n\n** _Infernal Legacy._** You know the *thaumaturgy * cantrip.When you reach 3rd level, you can cast the* hellish rebuke* spell as a 2nd - level spell once with this trait and regain the ability to do so when you finish a long rest. When you reach 5th level, you can cast the* darkness*spell once with this trait and regain the ability to do so when you finish a long rest. Charisma is your spellcasting ability for these spells."",
      ""subraces"": [],
      ""document__slug"": ""wotc - srd"",
      ""document__title"": ""Systems Reference Document"",
      ""document__license_url"": ""http://open5e.com/legal""
    }
  ]
}";
            return races;
        }
    }
}
*/