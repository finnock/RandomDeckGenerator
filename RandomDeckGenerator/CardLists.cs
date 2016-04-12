using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnock.HDT.Plugins.RandomDeckGenerator
{
    class CardLists
    {
        public static List<string> basic = new List<string>
        {
            "CS1_042", //Goldshire Footman
            "CS1_130", //Holy Smite
            "CS2_004", //Power Word: Shield
            "CS2_005", //Claw
            "CS2_007", //Healing Touch
            "CS2_009", //Mark of the Wild
            "CS2_013", //Wild Growth
            "CS2_022", //Polymorph
            "CS2_023", //Arcane Intellect
            "CS2_025", //Arcane Explosion
            "CS2_029", //Fireball
            "CS2_037", //Frost Shock
            "CS2_039", //Windfury
            "CS2_041", //Ancestral Healing
            "CS2_045", //Rockbiter Weapon
            "CS2_057", //Shadow Bolt
            "CS2_061", //Drain Life
            "CS2_062", //Hellfire
            "CS2_065", //Voidwalker
            "CS2_072", //Backstab
            "CS2_074", //Deadly Poison
            "CS2_075", //Sinister Strike
            "CS2_076", //Assassinate
            "CS2_087", //Blessing of Might
            "CS2_089", //Holy Light
            "CS2_091", //Light's Justice
            "CS2_094", //Hammer of Wrath
            "CS2_103", //Charge
            "CS2_105", //Heroic Strike
            "CS2_106", //Fiery War Axe
            "CS2_108", //Execute
            "CS2_118", //Magma Rager
            "CS2_119", //Oasis Snapjaw
            "CS2_120", //River Crocolisk
            "CS2_121", //Frostwolf Grunt
            "CS2_122", //Raid Leader
            "CS2_124", //Wolfrider
            "CS2_125", //Ironfur Grizzly
            "CS2_127", //Silverback Patriarch
            "CS2_131", //Stormwind Knight
            "CS2_141", //Ironforge Rifleman
            "CS2_142", //Kobold Geomancer
            "CS2_147", //Gnomish Inventor
            "CS2_150", //Stormpike Commando
            "CS2_155", //Archmage
            "CS2_162", //Lord of the Arena
            "CS2_168", //Murloc Raider
            "CS2_171", //Stonetusk Boar
            "CS2_172", //Bloodfen Raptor
            "CS2_173", //Bluegill Warrior
            "CS2_179", //Sen'jin Shieldmasta
            "CS2_182", //Chillwind Yeti
            "CS2_186", //War Golem
            "CS2_187", //Booty Bay Bodyguard
            "CS2_189", //Elven Archer
            "CS2_196", //Razorfen Hunter
            "CS2_197", //Ogre Magi
            "CS2_200", //Boulderfist Ogre
            "CS2_201", //Core Hound
            "CS2_213", //Reckless Rocketeer
            "CS2_222", //Stormwind Champion
            "CS2_226", //Frostwolf Warlord
            "CS2_234", //Shadow Word: Pain
            "CS2_235", //Northshire Cleric
            "DS1_055", //Darkscale Healer
            "DS1_070", //Houndmaster
            "DS1_175", //Timber Wolf
            "DS1_183", //Multi-Shot
            "DS1_184", //Tracking
            "DS1_185", //Arcane Shot
            "DS1_233", //Mind Blast
            "EX1_011", //Voodoo Doctor
            "EX1_015", //Novice Engineer
            "EX1_019", //Shattered Sun Cleric
            "EX1_025", //Dragonling Mechanic
            "EX1_066", //Acidic Swamp Ooze
            "EX1_084", //Warsong Commander
            "EX1_169", //Innervate
            "EX1_246", //Hex
            "EX1_277", //Arcane Missiles
            "EX1_306", //Succubus
            "EX1_371", //Hand of Protection
            "EX1_399", //Gurubashi Berserker
            "EX1_506", //Murloc Tidehunter
            "EX1_508", //Grimscale Oracle
            "EX1_581", //Sap
            "EX1_582", //Dalaran Mage
            "EX1_593" //Nightblade
        };

        public static List<string> levelDruid = new List<string>
        {
            "EX1_173", //Starfire
            "CS2_011", //Savage Roar
            "CS2_008", //Moonfire
            "CS2_012", //Swipe
            "CS2_232" //Ironbark Protector
        };

        public static List<string> levelHunter = new List<string>
        {
            "NEW1_031", //Animal Companion
            "CS2_237", //Starving Buzzard
            "CS2_084", //Hunter's Mark
            "DS1_178", //Tundra Rhino
            "EX1_539" //Kill Command
        };

        public static List<string> levelMage = new List<string>
        {
            "CS2_024", //Frostbolt
            "CS2_027", //Mirror Image
            "CS2_026", //Frost Nova
            "CS2_033", //Water Elemental
            "CS2_032" //Flamestrike
        };

        public static List<string> levelPaladin = new List<string>
        {
            "CS2_097", //Truesilver Champion
            "CS2_093", //Consecration
            "EX1_360", //Humility
            "CS2_088", //Guardian of Kings
            "CS2_092" //Blessing of Kings
        };

        public static List<string> levelPriest = new List<string>
        {
            "CS2_236", //Divine Spirit
            "CS2_003", //Mind Vision
            "CS1_112", //Holy Nova
            "EX1_622", //Shadow Word: Death
            "CS1_113" //Mind Control
        };

        public static List<string> levelRogue = new List<string>
        {
            "CS2_080", //Assassin's Blade
            "EX1_129", //Fan of Knives
            "EX1_278", //Shiv
            "NEW1_004", //Vanish
            "CS2_077" //Sprint
        };

        public static List<string> levelShaman = new List<string>
        {
            "CS2_046", //Bloodlust
            "EX1_565", //Flametongue Totem
            "EX1_244", //Totemic Might
            "EX1_587", //Windspeaker
            "CS2_042" //Fire Elemental
        };

        public static List<string> levelWarlock = new List<string>
        {
            "CS2_063", //Corruption
            "EX1_302", //Mortal Coil
            "EX1_308", //Soulfire
            "NEW1_003", //Sacrificial Pact
            "CS2_064" //Dread Infernal
        };

        public static List<string> levelWarrior = new List<string>
        {
            "CS2_114", //Cleave
            "NEW1_011", //Kor'kron Elite
            "EX1_400", //Whirlwind
            "EX1_606", //Shield Block
            "CS2_112" //Arcanite Reaper
        };

        public static List<string> naxxWing1 = new List<string> // Arachnid Quarter
        {
            "FP1_002", //Haunted Creeper
            "FP1_017", //Nerub'ar Weblord
            "FP1_007", //Nerubian Egg
            "FP1_019", //Poison Seeds
            "FP1_026", //Anub'ar Ambusher
            "FP1_010" //Maexxna
        };

        public static List<string> naxxWing2 = new List<string> // Plaque Quarter
        {
            "FP1_027", //Stoneskin Gargoyle
            "FP1_024", //Unstable Ghoul
            "FP1_012", //Sludge Belcher
            "FP1_018", //Duplicate
            "FP1_011", //Webspinner
            "FP1_030" //Loatheb
        };

        public static List<string> naxxWing3 = new List<string> // Military Quarter
        {
            "FP1_029", //Dancing Swords
            "FP1_008", //Spectral Knight
            "FP1_009", //Deathlord
            "FP1_025", //Reincarnate
            "FP1_022", //Voidcaller
            "FP1_031" //Baron Rivendare
        };

        public static List<string> naxxWing4 = new List<string> // Construct Quarter
        {
            "FP1_028", //Undertaker
            "FP1_004", //Mad Scientist
            "FP1_001", //Zombie Chow
            "FP1_016", //Wailing Soul
            "FP1_021", //Death's Bite
            "FP1_023", //Dark Cultist
            "FP1_015", //Feugen
            "FP1_014" //Stalagg
        };

        public static List<string> naxxWing5 = new List<string> // Frostwyrm Lair
        {
            "FP1_003", //Echoing Ooze
            "FP1_005", //Shade of Naxxramas
            "FP1_020", //Avenge
            "FP1_013" //Kel'Thuzad
        };

        public static List<string> brmWing1 = new List<string> // Blackrock Depths
        {
            "BRM_019", //Grim Patron
            "BRM_013", //Quick Shot
            "BRM_007", //Gang Up
            "BRM_003", //Dragon's Breath
            "BRM_017", //Resurrect
            "BRM_028" //Emperor Thaurissan
        };

        public static List<string> brmWing2 = new List<string> // Molten Core
        {
            "BRM_010", //Druid of the Flame
            "BRM_016", //Axe Flinger
            "BRM_033", //Blackwing Technician
            "BRM_011", //Lava Shock
            "BRM_006", //Imp Gang Boss
            "BRM_027" //Majordomo Executus
        };

        public static List<string> brmWing3 = new List<string> // Blackrock Spire
        {
            "BRM_014", //Core Rager
            "BRM_018", //Dragon Consort
            "BRM_004", //Twilight Whelp
            "BRM_022", //Dragon Egg
            "BRM_009", //Volcanic Lumberer
            "BRM_029" //Rend Blackhand
        };

        public static List<string> brmWing4 = new List<string> // Blackwing Lair
        {
            "BRM_015", //Revenge
            "BRM_005", //Demonwrath
            "BRM_002", //Flamewaker
            "BRM_008", //Dark Iron Skulker
            "BRM_026", //Hungry Dragon
            "BRM_012", //Fireguard Destroyer
            "BRM_031" //Chromaggus
        };

        public static List<string> brmWing5 = new List<string> // Hidden Laboratory
        {
            "BRM_025", //Volcanic Drake
            "BRM_001", //Solemn Vigil
            "BRM_034", //Blackwing Corruptor
            "BRM_024", //Drakonid Crusher
            "BRM_020", //Dragonkin Sorcerer
            "BRM_030" //Nefarian
        };

        public static List<string> loeWing1 = new List<string> // Temple of Orsis
        {
            "LOE_002", //Forgotten Torch
            "LOE_105", //Explorer's Hat
            "LOE_053", //Djinni of Zephyrs
            "LOE_029", //Jeweled Scarab
            "LOE_009", //Obsidian Destroyer
            "LOE_061", //Anubisath Sentinel
            "LOE_086", //Summoning Stone
            "LOE_023", //Dark Peddler
            "LOE_016", //Rumbling Elemental
            "LOE_027", //Sacred Trial
            "LOE_110", //Ancient Shade
            "LOE_011", //Reno Jackson
        };

        public static List<string> loeWing2 = new List<string> // Uldaman
        {
            "LOE_018", //Tunnel Trogg
            "LOE_003", //Ethereal Conjurer
            "LOE_050", //Mounted Raptor
            "LOE_047", //Tomb Spider
            "LOE_019", //Unearthed Raptor
            "LOE_022", //Fierce Monkey
            "LOE_116", //Reliquary Seeker
            "LOE_017", //Keeper of Uldaman
            "LOE_077", //Brann Bronzebeard
            "LOE_111", //Excavated Evil
        };

        public static List<string> loeWing3 = new List<string> // The Ruined City
        {
            "LOE_046", //Huge Toad
            "LOE_039", //Gorillabot A-3
            "LOE_021", //Dart Trap
            "LOE_026", //Anyfin Can Happen
            "LOEA10_3", //Murloc Tinyfin
            "LOE_113", //Everyfin is Awesome
            "LOE_010", //Pit Snake
            "LOE_038", //Naga Sea Witch
            "LOE_104", //Entomb
            "LOE_051", //Jungle Moonkin
            "LOE_076", //Sir Finley Mrrgglton
        };

        public static List<string> loeWing4 = new List<string> // Hall of Explorers
        {
            "LOE_073", //Fossilized Devilsaur
            "LOE_115", //Raven Idol
            "LOE_012", //Tomb Pillager
            "LOE_118", //Cursed Blade
            "LOE_006", //Museum Curator
            "LOE_119", //Animated Armor
            "LOE_007", //Curse of Rafaam
            "LOE_089", //Wobbling Runts
            "LOE_020", //Desert Camel
            "LOE_107", //Eerie Statue
            "LOE_092", //Arch-Thief Rafaam
            "LOE_079", //Elise Starseeker
        };
    }
}
