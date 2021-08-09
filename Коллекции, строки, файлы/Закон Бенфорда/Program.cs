﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static void Main()
        {
            string text = @"Burj Khalifa 830
Petronius (oil platform) 640
Tokyo Skytree 634
KVLY-TV mast 629
Canton Tower 604
Abraj Al Bait Towers 601
Bullwinkle (oil platform) 529
Troll A platform 472
Lualualei VLF transmitter 458
Petronas Twin Towers 452
Willis Tower 442
Ekibastuz GRES-Two Power Station 420
Dimona Radar Facility 400
Kiev TV Tower 385
Zhoushan Island Overhead Powerline Tie 370
Gerbrandy Tower 367
TV Tower Vinnytsia 354
Millau Viaduct 342
Amazon Tall Tower Observatory 325
Lakihegy Tower 314
Jinping-I Dam 305
Star Tower 291
H-One Tower 274
Djamaa el Djazaïr 265
Mohammed bin Rashid Al Maktoum Solar Park 262
LR 248
GE wind turbine at Naturstromspeicher Gaildorf 247
Statue of Unity 240
Noble Lloyd Noble 214
Kalisindh Thermal Power Station 202
Gateway Arch 192
Main tower of Kuwait Towers 187
Anaconda Smelter Stack 178
Olympic Stadium 175
San Jacinto Monument 174
Niederaussem Power Station 172
Jeddah Flagpole 171
High Roller 168
Mole Antonelliana 168
Ulmer Münster 162
Vehicle Assembly Building 160
Santa Cruz del Valle de los Caídos 152
Arecibo Telescope 150
Kingda Ka 139
Great Pyramid of Giza 139
Kuala Lumpur International Airport Two Control Tower 141
Zumanjaro: Drop of Doom 139
Kockums Crane 138
Jetavanaramaya 122
Gliwice Radio Tower 118
Gasometer Oberhausen 118
Schapfen Mill Tower 115
Pillar of third section of Gletscherbahn Kaprun 114
Joseph Chamberlain Memorial Clock Tower 100
Éole 96
Mjøstårnet 85
Ericsson Globe 85
Île Vierge Lighthouse 83
Murudeshwara Temple 76";
            int[] numbers = GetBenfordStatistics(text);
            foreach(int i in numbers)
            {
                Console.WriteLine(i + '\t');
            }
            Console.ReadKey();
        }
        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];
            string[] words = text.Split(' ');
            foreach(string word in words)
            {
                if (Char.IsDigit(word[0]))
                {
                    statistics[word[0] - '0']++;
                }
            }
            return statistics;
        }
    }
}
