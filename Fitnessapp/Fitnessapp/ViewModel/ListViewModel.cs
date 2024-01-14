using CommunityToolkit.Mvvm.ComponentModel;
using Fitnessapp.Model;
using System.Collections.Generic;
using System.IO;
using Csv;
using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace Fitnessapp.ViewModel
{
    public class ListViewModel : ObservableObject
    {



        public string labelText { get; set; }
        public bool visibility { get; set; }
        public string Name { get; set; }
        public string measure { get; set; }
        public int grams { get; set; }
        public int calories { get; set; }
        public int protein { get; set; }

        public int fat { get; set; }
        public int Sat_Fat { get; set; }
        public int Fiber { get; set; }
        public int Carbs { get; set; }
        public int category { get; set; }


        public List<CollectionViewClass> Items { get; set; }



        public ListViewModel()
        {


            var destination = Path.Combine(FileSystem.Current.AppDataDirectory, "data.csv");

            if (Items is null)
            {
               
                Items = [];
                if (File.Exists(destination))
                {
               
                    performInitialize(destination);


                }

                else
                {
                    
                    string inputText = "Food,Measure,Grams,Calories,Protein,Fat,Sat.Fat,Fiber,Carbs,Category\r\nCows' milk,1 qt.,976,660,32,40,36,0,48,Dairy products\r\nMilk skim,1 qt.,984,360,36,t,t,0,52,Dairy products\r\nButtermilk,1 cup,246,127,9,5,4,0,13,Dairy products\r\n\"Evaporated, undiluted\",1 cup,252,345,16,20,18,0,24,Dairy products\r\nFortified milk,6 cups,\"1,419\",\"1,373\",89,42,23,1.4,119,Dairy products\r\nPowdered milk,1 cup,103,515,27,28,24,0,39,Dairy products\r\n\"skim, instant\",1 1/3 cups,85,290,30,t,t,0,42,Dairy products\r\n\"skim, non-instant\",2/3 cup,85,290,30,t,t,1,42,Dairy products\r\nGoats' milk,1 cup,244,165,8,10,8,0,11,Dairy products\r\n(1/2 cup ice cream),2 cups,540,690,24,24,22,0,70,Dairy products\r\nCocoa,1 cup,252,235,8,11,10,0,26,Dairy products\r\nskim. milk,1 cup,250,128,18,4,3,1,13,Dairy products\r\n(cornstarch),1 cup,248,275,9,10,9,0,40,Dairy products\r\nCustard,1 cup,248,285,13,14,11,0,28,Dairy products\r\nIce cream,1 cup,188,300,6,18,16,0,29,Dairy products\r\nIce milk,1 cup,190,275,9,10,9,0,32,Dairy products\r\nCream or half-and-half,1/2 cup,120,170,4,15,13,0,5,Dairy products\r\nor whipping,1/2 cup,119,430,2,44,27,1,3,Dairy products\r\nCheese,1 cup,225,240,30,11,10,0,6,Dairy products\r\nuncreamed,1 cup,225,195,38,t,t,0,6,Dairy products\r\nCheddar,1-in. cube,17,70,4,6,5,0,t,Dairy products\r\n\"Cheddar, grated cup\",1/2 cup,56,226,14,19,17,0,1,Dairy products\r\nCream cheese,1 oz.,28,105,2,11,10,0,1,Dairy products\r\nProcessed cheese,1 oz.,28,105,7,9,8,0,t,Dairy products\r\nRoquefort type,1 oz.,28,105,6,9,8,0,t,Dairy products\r\nSwiss,1 oz.,28,105,7,8,7,0,t,Dairy products\r\nEggs raw,2,100,150,12,12,10,0,t,Dairy products\r\nEggs Scrambled or fried,2,128,220,13,16,14,0,1,Dairy products\r\nYolks,2,34,120,6,10,8,0,t,\"Fats, Oils, Shortenings\"\r\nButter,1T.,14,100,t,11,10,0,t,\"Fats, Oils, Shortenings\"\r\nButter,1/2 cup,112,113,114,115,116,117,118,\"Fats, Oils, Shortenings\"\r\nButter,1/4 lb.,112,113,114,115,116,117,118,\"Fats, Oils, Shortenings\"\r\nHydrogenated cooking fat,1/2 cup,100,665,0,100,88,0,0,\"Fats, Oils, Shortenings\"\r\nLard,1/2 cup,110,992,0,110,92,0,0,\"Fats, Oils, Shortenings\"\r\nMargarine,1/2 cup,112,806,t,91,76,0,t,\"Fats, Oils, Shortenings\"\r\n\"Margarine, 2 pat or\",1 T.,14,100,t,11,9,0,t,\"Fats, Oils, Shortenings\"\r\nMayonnaise,1 T.,15,110,t,12,5,0,t,\"Fats, Oils, Shortenings\"\r\nCorn oil,1 T.,14,125,0,14,5,0,0,\"Fats, Oils, Shortenings\"\r\nOlive oil,1T.,14,125,0,14,3,0,0,\"Fats, Oils, Shortenings\"\r\nSafflower seed oil,1 T.,14,125,0,14,3,0,0,\"Fats, Oils, Shortenings\"\r\nFrench dressing,1 T.,15,60,t,6,2,0,2,\"Fats, Oils, Shortenings\"\r\nThousand Island sauce,1 T.,15,75,t,8,3,0,1,\"Fats, Oils, Shortenings\"\r\nSalt pork,2 oz.,60,470,3,55,,0,0,\"Meat, Poultry\"\r\nBacon,2 slices,16,95,4,8,7,0,1,\"Meat, Poultry\"\r\nBeef,3 oz.,85,245,23,16,15,0,0,\"Meat, Poultry\"\r\nHamburger,3 oz.,85,245,21,17,15,0,0,\"Meat, Poultry\"\r\nGround lean,3 oz.,85,185,24,10,9,0,0,\"Meat, Poultry\"\r\nRoast beef,3 oz.,85,390,16,36,35,0,0,\"Meat, Poultry\"\r\nSteak,3 oz.,85,330,20,27,25,0,0,\"Meat, Poultry\"\r\n\"Steak, lean, as round\",3 oz.,85,220,24,12,11,0,0,\"Meat, Poultry\"\r\nCorned beef,3 oz.,85,185,22,10,9,0,0,\"Meat, Poultry\"\r\nCorned beef hash canned,3 oz.,85,120,12,8,7,t,6,\"Meat, Poultry\"\r\nCorned beef hash Dried,2 oz.,56,115,19,4,4,0,0,\"Meat, Poultry\"\r\nPot-pie,1 pie,227,480,18,28,25,t,32,\"Meat, Poultry\"\r\nCorned beef hash Stew,1 cup,235,185,15,10,9,t,15,\"Meat, Poultry\"\r\nchicken,3 oz.,85,185,23,9,7,0,0,\"Meat, Poultry\"\r\n\"Fried, breast or leg and thigh chicken\",3 oz.,85,245,25,15,11,0,0,\"Meat, Poultry\"\r\nRoasted chicken,3 1/2 oz.,100,290,25,20,16,0,0,\"Meat, Poultry\"\r\n\"Chicken livers, fried\",3 med.,100,140,22,14,12,0,2.30,\"Meat, Poultry\"\r\n\"Duck, domestic\",3 1/2 oz.,100,370,16,28,0,0,0,\"Meat, Poultry\"\r\n\"Lamb, chop, broiled\",4 oz.,115,480,24,35,33,0,0,\"Meat, Poultry\"\r\nLeg roasted,3 oz.,86,314,20,14,14,0,0,\"Meat, Poultry\"\r\n\"Shoulder, braised\",3 oz.,85,285,18,23,21,0,0,\"Meat, Poultry\"\r\n\"Pork, chop, 1 thick\",3 1/2 oz.,100,260,16,21,18,0,0,\"Meat, Poultry\"\r\nHam pan-broiled,3 oz.,85,290,16,22,19,0,0,\"Meat, Poultry\"\r\n\"Ham, as \",2 oz.,57,170,13,13,11,0,0,\"Meat, Poultry\"\r\n\"Ham, canned, spiced\",2 oz.,57,165,8,14,12,0,1,\"Meat, Poultry\"\r\nPork roast,3 oz.,85,310,21,24,21,0,0,\"Meat, Poultry\"\r\nPork sausage,3 1/2 oz.,100,475,18,44,40,0,0,\"Meat, Poultry\"\r\nTurkey,3 1/2 oz.,100,265,27,15,0,0,0,\"Meat, Poultry\"\r\nVeal,3 oz.,85,185,23,9,8,0,0,\"Meat, Poultry\"\r\nRoast,3 oz.,85,305,13,14,13,0,0,\"Meat, Poultry\"\r\nClams,3 oz.,85,87,12,1,0,0,2,\"Fish, Seafood\"\r\nCod,3 1/2 oz.,100,170,28,5,0,0,0,\"Fish, Seafood\"\r\nCrab meat,3 oz.,85,90,14,2,0,0,1,\"Fish, Seafood\"\r\nFish sticks fried,5,112,200,19,10,5,0,8,\"Fish, Seafood\"\r\nFlounder,3 1/2 oz.,100,200,30,8,0,0,0,\"Fish, Seafood\"\r\nHaddock,3 oz.,85,135,16,5,4,0,6,\"Fish, Seafood\"\r\nHalibut,3 1/2 oz.,100,182,26,8,0,0,0,\"Fish, Seafood\"\r\nHerring,1 small,100,211,22,13,0,0,0,\"Fish, Seafood\"\r\nLobster,aver.,100,92,18,1,0,0,t,\"Fish, Seafood\"\r\nMackerel,3 oz.,85,155,18,9,0,a,0,\"Fish, Seafood\"\r\nOysters,6-8 med.,230,231,232,233,234,235,236,\"Fish, Seafood\"\r\nOyster stew,1 cup,85,125,19,6,1,0,0,\"Fish, Seafood\"\r\nSalmon,3 oz.,85,120,17,5,1,0,0,\"Fish, Seafood\"\r\nSardines,3 oz.,85,180,22,9,4,0,0,\"Fish, Seafood\"\r\nScallops,3 1/2 oz.,100,104,18,8,0,0,10,\"Fish, Seafood\"\r\nShad,3 oz.,85,170,20,10,0,0,0,\"Fish, Seafood\"\r\nShrimp,3 oz.,85,110,23,1,0,0,0,\"Fish, Seafood\"\r\nSwordfish,1 steak,100,180,27,6,0,0,0,\"Fish, Seafood\"\r\nTuna,3 oz.,85,170,25,7,3,0,0,\"Fish, Seafood\"\r\nArtichoke,1 large,100,8-44,2,t,t,2,10,Vegetables A-E\r\nAsparagus,6 spears,96,18,1,t,t,0.5,3,Vegetables A-E\r\nBeans,1 cup,125,25,1,t,t,0.8,6,Vegetables A-E\r\nLima,1 cup,160,140,8,t,t,3.0,24,Vegetables A-E\r\n\"Lima, dry, cooked\",1 cup,192,260,16,t,t,2,48,Vegetables A-E\r\n\"Navy, baked with pork\",3/4 cup,200,250,11,6,6,2,37,Vegetables A-E\r\nRed kidney,1 cup,260,230,15,1,0,2.5,42,Vegetables A-E\r\nBean sprouts,1 cup,50,17,1,t,0,0.3,3,Vegetables A-E\r\nBeet greens,1 cup,100,27,2,t,0,1.4,6,Vegetables A-E\r\nBeetroots,1 cup,165,1,12,0,,t,0.80,Vegetables A-E\r\nBroccoli,1 cup,150,45,5,t,0,1.9,8,Vegetables A-E\r\nBrussels sprouts,1 cup,130,60,6,t,0,1.7,12,Vegetables A-E\r\nSauerkraut,1 cup,150,32,1,t,0,1.2,7,Vegetables A-E\r\nSteamed cabbage,1 cup,170,40,2,t,0,1.3,9,Vegetables A-E\r\nCarrots,1 cup,150,45,1,t,0,0.9,10,Vegetables A-E\r\n\"Raw, grated\",1 cup,110,45,1,t,0,1.2,10,Vegetables A-E\r\n\"Strips, from raw\",1 mad.,50,20,t,t,0,0.5,5,Vegetables A-E\r\nCauliflower,1 cup,120,30,3,t,0,1,6,Vegetables A-E\r\nCelery,1 cup,100,20,1,t,0,1,4,Vegetables A-E\r\nStalk raw,1 large,40,5,1,t,0,0.3,1,Vegetables A-E\r\nChard steamed,1 cup,150,30,2,t,0,1.4,7,Vegetables A-E\r\nCollards,1 cup,150,51,5,t,0,2,8,Vegetables A-E\r\nCorn,1 ear,100,92,3,1,t,0.8,21,Vegetables A-E\r\ncooked or canned,1 cup,200,170,5,t,0,1.6,41,Vegetables A-E\r\nCucumbers,8,50,6,t,0,0,0.2,1,Vegetables A-E\r\nDandelion greens,1 cup,180,80,5,1,0,3.2,16,Vegetables A-E\r\nEggplant,1 cup,180,30,2,t,0,1.0,9,Vegetables A-E\r\nEndive,2 oz.,57,10,1,t,0,0.6,2,Vegetables A-E\r\nKale,1 cup,110,45,4,1,0,0.9,8,Vegetables F-P\r\nKohlrabi,1 cup,140,40,2,t,0,1.5,9,Vegetables F-P\r\n\"Lambs quarters, steamed\",1 cup,150,48,5,t,0,3.2,7,Vegetables F-P\r\nLentils,1 cup,200,212,15,t,0,2.4,38,Vegetables F-P\r\nLettuce,1/4 head,100,14,1,t,0,0.5,2,Vegetables F-P\r\nIceberg,1/4 head,100,13,t,t,0,0.5,3,Vegetables F-P\r\nMushrooms canned,4,120,12,2,t,0,t,4,Vegetables F-P\r\nMustard greens,1,140,30,3,t,0,1.2,6,Vegetables F-P\r\nOkra,1 1/3 cups,100,32,1,t,0,1,7,Vegetables F-P\r\nOnions,1,210,80,2,t,0,1.6,18,Vegetables F-P\r\n\"Raw, green\",6 small,50,22,t,t,0,1,5,Vegetables F-P\r\nParsley,2 T.,50,2,t,t,0,t,t,Vegetables F-P\r\nParsnips,1 cup,155,95,2,1,0,3,22,Vegetables F-P\r\nPeas,1 cup,100,66,3,t,0,0.1,13,Vegetables F-P\r\n\"Fresh, steamed peas\",1 cup,100,70,5,t,0,2.2,12,Vegetables R-Z\r\nFrozen peas,1 cup,100,,5,t,0,1.8,12,Vegetables R-Z\r\nSplit cooked peas,4 cups,100,115,8,t,0,0.4,21,Vegetables R-Z\r\nheated peas,1 cup,100,53,3,t,0,1,10,Vegetables R-Z\r\nPeppers canned,1 pod,38,10,t,t,0,t,2,Vegetables R-Z\r\n\"Peppers Raw, green, sweet\",1 large,100,25,1,t,0,1.4,6,Vegetables R-Z\r\nPeppers with beef and crumbs,1 med.,150,255,19,9,8,1,24,Vegetables R-Z\r\n\"Potatoes, baked\",1 med.,100,100,2,t,0,0.5,22,Vegetables R-Z\r\nFrench-fried,10 pieces,60,155,-1,7,3,0.4,20,Vegetables R-Z\r\nPotatoes Mashed with milk and butter,1 cup,200,230,4,12,11,0.7,28,Vegetables R-Z\r\n\"Potatoes, pan-tried\",3/4 cup,100,268,4,14,6,0.40,33,Vegetables R-Z\r\nScalloped with cheese potatoes,3/4 cup,100,145,6,8,7,0.40,14,Vegetables R-Z\r\nSteamed potatoes before peeling,1 med.,100,80,2,t,0,0.40,19,Vegetables R-Z\r\nPotato chips,10,20,110,1,7,4,t,10,Vegetables R-Z\r\nRadishes,5 small,50,10,t,0,0,0.3,2,Vegetables R-Z\r\nRutabagas,4 cups,100,32,t,0,0,1.4,8,Vegetables R-Z\r\nSoybeans,1 cup,200,260,22,11,0,3.2,20,Vegetables R-Z\r\nSpinach,1 cup,100,26,3,t,0,1,3,Vegetables R-Z\r\nSquash,1 cup,210,35,1,t,0,0.6,8,Vegetables R-Z\r\n\"Winter, mashed\",1 cup,200,95,4,t,0,2.6,23,Vegetables R-Z\r\nSweet potatoes,1 med.,110,155,2,1,0,1,36,Vegetables R-Z\r\nCandied,1 med.,175,235,2,6,5,1.5,80,Vegetables R-Z\r\nTomatoes,1 cup,240,50,2,t,0,1,9,Vegetables R-Z\r\n\"Raw, 2 by 2 1/2\",1 med.,150,30,1,t,0,0.6,6,Vegetables R-Z\r\nTomato juice,1 cup,240,50,2,t,0,0.6,10,Vegetables R-Z\r\nTomato catsup,1 T.,17,15,t,t,0,t,4,Vegetables R-Z\r\nTurnip greens,1 cup,145,45,4,1,0,1.8,8,Vegetables R-Z\r\n\"Turnips, steamed\",1 cup,155,40,1,t,0,1.8,9,Vegetables R-Z\r\n\"Watercress stems, raw\",1 cup,50,9,1,t,0,0.3,1,Fruits A-F\r\nApple juice canned,1 cup,250,125,t,0,0,0,34,Fruits A-F\r\nApple vinegar,1/3 cup,100,14,t,0,0,0,3,Fruits A-F\r\n\"Apples, raw\",1 med,130,70,t,t,0,1,18,Fruits A-F\r\nStewed or canned,1 cup,240,100,t,t,0,2,26,Fruits A-F\r\nApricots,1 cup,250,220,2,t,0,1,57,Fruits A-F\r\n\"Dried, uncooked\",1/2 cup,75,220,4,t,0,1,50,Fruits A-F\r\nFresh,3 med.,114,55,1,t,0,0.70,14,Fruits A-F\r\n\"Nectar, or juice\",1 cup,250,140,1,t,0,2,36,Fruits A-F\r\nAvocado,1/2 large,108,185,2,18,12,1.80,6,Fruits A-F\r\nBanana,1 med.,150,85,1,t,0,0.9,23,Fruits A-F\r\nBlackberries,1 cup,144,85,2,1,0,6.60,19,Fruits A-F\r\nBlueberries,1 cup,250,245,1,t,0,2,65,Fruits A-F\r\nCantaloupe,1/2 med.,380,40,1,t,0,2.20,9,Fruits A-F\r\nCherries,1 cup,257,100,2,1,0,2,26,Fruits A-F\r\n\"Fresh, raw\",1 cup,114,65,1,t,0,0.8,15,Fruits A-F\r\nCranberry sauce sweetened,1 cup,277,530,t,t,0,1.2,142,Fruits A-F\r\nDates,1 cup,178,505,4,t,0,3.6,134,Fruits A-F\r\nFigs,2,42,120,2,t,0,1.9,30,Fruits A-F\r\n\"Fresh, raw figs\",3 med.,114,90,2,t,0,1,22,Fruits A-F\r\nfigs Canned with syrup ,3,115,130,1,t,0,1,32,Fruits A-F\r\n\"Fruit cocktail, canned\",1 cup,256,195,1,t,0,0.5,50,Fruits A-F\r\nGrapefruit sections,1 cup,250,170,1,t,0,0.5,44,Fruits G-P\r\n\"Grapefruit, fresh, 5\"\" diameter\",1/2,285,50,1,t,t,1,14,Fruits G-P\r\nGrapefruit juice,1 cup,250,100,1,t,0,1,24,Fruits G-P\r\nGrapes,1 cup,153,70,1,t,0,0.8,16,Fruits G-P\r\n\"European, as Muscat, Tokay\",1 cup,160,100,1,t,0,0.7,26,Fruits G-P\r\nGrape juice,1 cup,250,160,1,t,0,t,42,Fruits G-P\r\nLemon juice,1/2 cup,125,30,t,t,0,t,10,Fruits G-P\r\nLemonade concentratefrozen,6-oz. can,220,430,t,t,0,t,112,Fruits G-P\r\nLimeade concentrate frozen,6-oz. can,218,405,t,t,0,t,108,Fruits G-P\r\nOlives large,10,65,72,1,10,9,0.8,3,Fruits G-P\r\nOlivesRipe,10,65,105,1,13,12,1,1,Fruits G-P\r\n\"Oranges 3\"\" diameter\",1 med.,180,60,2,t,t,1,16,Fruits G-P\r\nOrange juice,8 oz. or,250,112,2,t,0,0.2,25,Fruits G-P\r\nFrozen ,6-oz. can,210,330,2,t,t,0.4,78,Fruits G-P\r\nPapaya,1/2 med.,200,75,1,t,0,1.8,18,Fruits G-P\r\nPeaches,1 cup,257,200,1,t,0,1,52,Fruits G-P\r\n\"Fresh, raw\",1 med.,114,35,1,t,0,0.6,10,Fruits G-P\r\nPears,1 cup,255,195,1,t,0,2,50,Fruits G-P\r\n\"Raw, 3 by 2V\",1 med.,182,100,1,1,0,2,25,Fruits G-P\r\nPersimmons,1 med.,125,75,1,t,0,2,20,Fruits G-P\r\nPineapple,1 large slice,122,95,t,t,0,0.4,26,Fruits G-P\r\nPineapple Crushed,1 cup,260,205,1,t,0,0.7,55,Fruits G-P\r\n\"Raw, diced\",1 cup,140,75,1,t',0,0.6,19,Fruits G-P\r\nPineapple juice,1 cup,250,120,1,t,0,0.2,32,Fruits G-P\r\nPlums,1 cup,256,185,1,t,0,0.7,50,Fruits G-P\r\n\"Raw, 2\"\" diameter\",1,60,30,t,t,0,0.2,7,Fruits G-P\r\nPrunes,1 cup,270,300,3,1,0,0.8,81,Fruits G-P\r\nPrune juice,1 cup,240,170,1,t,0,0.7,45,Fruits G-P\r\nRaisins,1/2 cup,88,230,2,t,0,0.7,82,Fruits R-Z\r\nRaspberries,1/2 cup,100,100,t,t,0,2,25,Fruits R-Z\r\n\"Raw, red\",3/4 cup,100,57,t,t,0,5,14,Fruits R-Z\r\nRhubarb sweetened,1 cup,270,385,1,t,0,1.9,98,Fruits R-Z\r\nStrawberries,1 cup,227,242,1,t,0,1.3,60,Fruits R-Z\r\nRaw,1 cup,149,54,t,t,0,1.9,12,Fruits R-Z\r\nTangerines,I med.,114,40,1,t,0,1,10,Fruits R-Z\r\nWatermelon,1 wedge,925,120,2,1,0,3.6,29,Fruits R-Z\r\nBiscuits,1,38,130,3,4,3,t,18,\"Breads, cereals, fastfood,grains\"\r\nBran flakes,1 cup,25,117,3,t,0,0.10,32,\"Breads, cereals, fastfood,grains\"\r\n\"Bread, cracked wheat\",1 slice,23,60,2,1,1,0.10,12,\"Breads, cereals, fastfood,grains\"\r\nRye,1 slice,23,55,2,1,1,0.10,12,\"Breads, cereals, fastfood,grains\"\r\n\"White, 20 slices, or\",1-lb. loaf,454,\"1,225\",39,15,12,9.00,229,\"Breads, cereals, fastfood,grains\"\r\nWhole-wheat,1-lb. loaf,454,\"1,100\",48,14,10,67.50,216,\"Breads, cereals, fastfood,grains\"\r\nWhole-wheat,1 slice,23,55,2,1,0,0.31,11,\"Breads, cereals, fastfood,grains\"\r\nCorn bread ground meal,1 serving,50,100,3,4,2,0.30,15,\"Breads, cereals, fastfood,grains\"\r\nCornflakes,1 cup,25,110,2,t,0,0.1,25,\"Breads, cereals, fastfood,grains\"\r\nCorn grits cooked,1 cup,242,120,8,t,0,0.2,27,\"Breads, cereals, fastfood,grains\"\r\nCorn meal,1 cup,118,360,9,4,2,1.6,74,\"Breads, cereals, fastfood,grains\"\r\nCrackers,2 med.,14,55,1,1,0,t,10,\"Breads, cereals, fastfood,grains\"\r\n\"Soda, 2 1/2 square\",2,11,45,1,1,0,t,8,\"Breads, cereals, fastfood,grains\"\r\nFarina,1 cup,238,105,3,t,0,8,22,\"Breads, cereals, fastfood,grains\"\r\nFlour,1 cup,110,460,39,22,0,2.9,33,\"Breads, cereals, fastfood,grains\"\r\nWheat (all purpose),1 cup,110,400,12,1,0,0.3,84,\"Breads, cereals, fastfood,grains\"\r\nWheat (whole),1 cup,120,390,13,2,0,2.8,79,\"Breads, cereals, fastfood,grains\"\r\nMacaroni,1 cup,140,155,5,1,0,0.1,32,\"Breads, cereals, fastfood,grains\"\r\nBaked with cheese,1 cup,220,475,18,25,24,t,44,\"Breads, cereals, fastfood,grains\"\r\nMuffins,1,48,135,4,5,4,t,19,\"Breads, cereals, fastfood,grains\"\r\nNoodles,1 cup,160,200,7,2,2,0.1,37,\"Breads, cereals, fastfood,grains\"\r\nOatmeal,1 cup,236,150,5,3,2,4.6,26,\"Breads, cereals, fastfood,grains\"\r\n\"Pancakes 4\"\" diam.\",4,108,250,7,9,0,0.1,28,\"Breads, cereals, fastfood,grains\"\r\n\"Wheat, pancakes 4\"\" diam.\",4,108,250,7,9,0,0.1,28,\"Breads, cereals, fastfood,grains\"\r\n\"Pizza 14\"\" diam.\",1 section,75,180,8,6,5,t,23,\"Breads, cereals, fastfood,grains\"\r\nPopcorn salted,2 cups,28,152,3,7,2,0.5,20,\"Breads, cereals, fastfood,grains\"\r\nPuffed rice,1 cup,14,55,t,t,0,t,12,\"Breads, cereals, fastfood,grains\"\r\nPuffed wheat presweetened,1 cup,28,105,1,t,0,0.6,26,\"Breads, cereals, fastfood,grains\"\r\nRice,1 cup,208,748,15,3,0,1.2,154,\"Breads, cereals, fastfood,grains\"\r\nConverted,1 cup,187,677,14,t,0,0.4,142,\"Breads, cereals, fastfood,grains\"\r\nWhite,1 cup,191,692,14,t,0,0.3,150,\"Breads, cereals, fastfood,grains\"\r\nRice flakes,1 cup,30,115,2,t,0,0.1,26,\"Breads, cereals, fastfood,grains\"\r\nRice polish,1/2 cup,50,132,6,6,0,1.2,28,\"Breads, cereals, fastfood,grains\"\r\nRolls,1 large,50,411,3,12,11,0.1,23,\"Breads, cereals, fastfood,grains\"\r\nof refined flour,1,38,115,3,2,2,t,20,\"Breads, cereals, fastfood,grains\"\r\nwhole-wheat,1,40,102,4,1,0,0.1,20,\"Breads, cereals, fastfood,grains\"\r\nSpaghetti with meat sauce,1 cup,250,285,13,10,6,0.50,35,\"Breads, cereals, fastfood,grains\"\r\nwith tomatoes and cheese,1 cup,250,210,6,5,3,0.50,36,\"Breads, cereals, fastfood,grains\"\r\nSpanish rice,1 cup,250,217,4,4,0,1.20,40,\"Breads, cereals, fastfood,grains\"\r\nShredded wheat biscuit,1,28,100,3,1,0,0.70,23,\"Breads, cereals, fastfood,grains\"\r\nWaffles,1,75,240,8,9,1,0.10,30,\"Breads, cereals, fastfood,grains\"\r\nWheat germ,1 cup,68,245,17,7,3,2.50,34,\"Breads, cereals, fastfood,grains\"\r\nWheat-germ cereal toasted,1 cup,65,260,20,7,3,2.50,36,\"Breads, cereals, fastfood,grains\"\r\nWheat meal cereal unrefined,3/4 cup,30,103,4,1,0,0.70,25,\"Breads, cereals, fastfood,grains\"\r\n\"Wheat, cooked\",3/4 cup,200,275,12,1,0,4.40,35,\"Breads, cereals, fastfood,grains\"\r\nBean soups,1 cup,250,190,8,5,4,0.60,30,Soups\r\nBeef soup,1 cup,250,100,6,4,4,0.50,11,Soups\r\nBouillon,1 cup,240,24,5,0,0,0,0,Soups\r\nchicken soup,1 cup,250,75,4,2,2,0,10,Soups\r\nClam chowder,1 cup,255,85,5,2,8,0.50,12,Soups\r\nCream soups,1 cup,255,200,7,12,11,1.20,18,Soups\r\nNoodle,1 cup,250,115,6,4,3,0.20,13,Soups\r\nSplit-pea soup,1 cup,250,147,8,3,3,0.50,25,Soups\r\nTomato soup,1 cup,245,175,6,7,6,0.50,22,Soups\r\nVegetable,1 cup,250,80,4,2,2,0,14,Soups\r\nApple betty,1 serving,100,150,1,4,0,0.5,29,\"Desserts, sweets\"\r\nBread pudding,3/4 cup,200,374,11,12,11,0.20,56,\"Desserts, sweets\"\r\nCakes,1 slice,40,110,3,t,0,0,23,\"Desserts, sweets\"\r\nChocolate fudge,1 slice,120,420,5,14,12,0.3,70,\"Desserts, sweets\"\r\nCupcake,1,50,160,3,3,2,t,31,\"Desserts, sweets\"\r\nFruit cake,1 slice,30,105,2,4,3,0.2,17,\"Desserts, sweets\"\r\nGingerbread,1 slice,55,180,2,7,6,t,28,\"Desserts, sweets\"\r\n\"Plain, with no icing\",1 slice,55,180,4,5,4,t,31,\"Desserts, sweets\"\r\nSponge cake,1 slice,40,115,3,2,2,0,22,\"Desserts, sweets\"\r\nCandy,5,25,104,t,3,3,0,19,\"Desserts, sweets\"\r\nChocolate creams,2,30,130,t,4,4,0,24,\"Desserts, sweets\"\r\nFudge,2 pieces,90,370,t,12,11,0.1,80,\"Desserts, sweets\"\r\nHard candies,1 oz.,28,90,t,0,0,0,28,\"Desserts, sweets\"\r\nMarshmallows,5,30,98,1,0,0,0,23,\"Desserts, sweets\"\r\nMilk chocolate,2-oz. bar,56,290,2,6,6,0.2,44,\"Desserts, sweets\"\r\nChocolate syrup,2 T.,40,80,t,t,t,0,22,\"Desserts, sweets\"\r\nDoughnuts,1,33,135,2,7,4,t,17,\"Desserts, sweets\"\r\n\"Gelatin, made with water\",1 cup,239,155,4,t,t,0,36,\"Desserts, sweets\"\r\nHoney,2 T.,42,120,t,0,0,0,30,\"Jams, Jellies\"\r\nIce cream,2 cups,300,250,0,0,12,10,0,\"Desserts, sweets\"\r\nIces,1 cup,150,117,0,0,0,0,48,\"Desserts, sweets\"\r\npreserves,1 T.,20,55,0,0,0,t,14,\"Jams, Jellies\"\r\nJellies,1 T.,20,50,0,0,0,0,13,\"Jams, Jellies\"\r\nMolasses,1 T.,20,45,0,0,0,8,11,\"Jams, Jellies\"\r\nCane Syrup,1 T.,20,50,0,0,0,0,13,\"Jams, Jellies\"\r\n\"9\"\" diam. pie\",1 slice,135,330,3,13,11,0.1,53,\"Desserts, sweets\"\r\nCherry Pie,1 slice,135,340,3,13,11,0.1,55,\"Desserts, sweets\"\r\nCustard,1 slice,130,265,7,11,10,0,34,\"Desserts, sweets\"\r\nLemon meringue,1 slice,120,300,4,12,10,0.1,45,\"Desserts, sweets\"\r\nMince,1 slice,135,340,3,9,8,0.70,62,\"Desserts, sweets\"\r\nPumpkin Pie,1 slice,130,265,5,12,11,8,34,\"Desserts, sweets\"\r\nPuddings Sugar,1 cup,200,770,0,0,0,0,199,\"Desserts, sweets\"\r\n3 teaspoons sugar,1 T.,12,50,0,0,0,0,12,\"Desserts, sweets\"\r\n\"Brown, firm-packed, dark sugar\",1 cup,220,815,0,t,0,0,210,\"Jams, Jellies\"\r\nSyrup,2 T.,40,100,0,0,0,0,25,\"Jams, Jellies\"\r\ntable blends sugar,2 T.,40,110,0,0,0,0,29,\"Jams, Jellies\"\r\nTapioca cream pudding,1 cup,250,335,10,10,9,0,42,\"Desserts, sweets\"\r\nAlmonds,1/2 cup,70,425,13,38,28,1.8,13,Seeds and Nuts\r\nroasted and salted,1/2 cup,70,439,13,40,31,1.8,13,Seeds and Nuts\r\nBrazil nuts,1/2 cup,70,457,10,47,31,2,7,Seeds and Nuts\r\nCashews,1/2 cup,70,392,12,32,28,0.9,20,Seeds and Nuts\r\ncoconut sweetened,1/2 cup,50,274,1,20,19,2,26,Seeds and Nuts\r\nPeanut butter,1/3 cup,50,300,12,25,17,0.9,9,Seeds and Nuts\r\n\"Peanut butter, natural\",1/3 cup,50,284,13,24,10,0.9,8,Seeds and Nuts\r\nPeanuts,1/3 cup,50,290,13,25,16,1.2,9,Seeds and Nuts\r\nPecans,1/2 cup,52,343,5,35,25,1.1,7,Seeds and Nuts\r\nSesame seeds,1/2 cup,50,280,9,24,13,3.1,10,Seeds and Nuts\r\nSunflower seeds,1/2 cup,50,280,12,26,7,1.9,10,Seeds and Nuts\r\nWalnuts,1/2 cup,50,325,7,32,7,1,8,Seeds and Nuts\r\nBeer,2 cups,480,228,t,0,0,0,8,\"Drinks,Alcohol, Beverages\"\r\nGin,1 oz.,28,70,0,0,0,0,t,\"Drinks,Alcohol, Beverages\"\r\nWines,1/2 cup,120,164,t,0,0,0,9,\"Drinks,Alcohol, Beverages\"\r\nTable (12.2% alcohol),1/2 cup,120,100,t,0,0,0,5,\"Drinks,Alcohol, Beverages\"\r\nCarbonated drinks Artificially sweetened,12 oz.,346,0,0,0,0,0,0,\"Drinks,Alcohol, Beverages\"\r\nClub soda,12 oz.,346,0,0,0,0,0,0,\"Drinks,Alcohol, Beverages\"\r\nCola drinks,12 oz.,346,137,0,0,0,0,38,\"Drinks,Alcohol, Beverages\"\r\nFruit-flavored soda,12 oz.,346,161,0,0,0,0,42,\"Drinks,Alcohol, Beverages\"\r\nGinger ale,12 oz.,346,105,0,0,0,0,28,\"Drinks,Alcohol, Beverages\"\r\nRoot beer,12 oz.,346,140,0,0,0,0,35,\"Drinks,Alcohol, Beverages\"\r\nCoffee,1 cup,230,3,t,0,0,0,1,\"Drinks,Alcohol, Beverages\"\r\nTea,1 cup,230,4,0,t,0,0,1,\"Drinks,Alcohol, Beverages\"\r\n";

                    foreach (var item in CsvReader.ReadFromText(inputText))
                    {
                        CollectionViewClass a = new CollectionViewClass
                        {
                            Name = item[0],
                            measure = item[1],
                            grams = TryParseInt(item[2]),
                            calories = TryParseInt(item[3]),
                            protein = TryParseInt(item[4]),
                            fat = TryParseInt(item[5]),
                            Sat_Fat = TryParseInt(item[6]),
                            Fiber = TryParseInt(item[7]),
                            Carbs = TryParseInt(item[8]),
                            category = item[9]
                        };

                        Items.Add(a);
                    }

                    Items.Sort();
                }


            }
        }

        

        public void performInitialize(string destination)
        {
           
            var csv = File.ReadAllText(destination);
            foreach (var item in CsvReader.ReadFromText(csv))
            {
                CollectionViewClass a = new()
                {
                    Name = item[0],
                    measure = item[1],
                    grams = TryParseInt(item[2]),
                    calories = TryParseInt(item[3]),
                    protein = TryParseInt(item[4]),
                    fat = TryParseInt(item[5]),
                    Sat_Fat = TryParseInt(item[6]),
                    Fiber = TryParseInt(item[7]),
                    Carbs = TryParseInt(item[8]),
                    category = item[9]
                };

                Items.Add(a);

            }

            Items.Sort();
        }
        public int TryParseInt(string val)
        {
            try
            {
                return int.Parse(val);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }




    }
}