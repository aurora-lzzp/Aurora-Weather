﻿using Com.Aurora.Shared.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Aurora.AuWeather.Models;
using Windows.UI;

namespace Com.Aurora.AuWeather.ViewModels
{
    public class ConditionPathViewModel : ViewModelBase
    {
        #region
        private static readonly string[] conditionEnums = new string[]
        {
            //sunny 0
            "M 46.7609,28.5C 46.7609,38.5853 38.5853,46.7609 28.5,46.7609C 18.4147,46.7609 10.2391,38.5853 10.2391,28.5C 10.2391,18.4147 18.4147,10.2391 28.5,10.2391C 38.5853,10.2391 46.7609,18.4147 46.7609,28.5 Z M 28.5,7.80435L 28.5,7.80435C 27.1554,7.80435 26.0652,6.71418 26.0652,5.36957L 26.0652,2.93478C 26.0652,1.59018 27.1554,0.500004 28.5,0.500004L 28.5,0.500004C 29.8446,0.500004 30.9348,1.59018 30.9348,2.93478L 30.9348,5.36957C 30.9348,6.71418 29.8446,7.80435 28.5,7.80435 Z M 7.80435,28.5L 7.80435,28.5C 7.80435,29.8446 6.71417,30.9348 5.36956,30.9348L 2.93478,30.9348C 1.59017,30.9348 0.499999,29.8446 0.499999,28.5L 0.499999,28.5C 0.499999,27.1554 1.59017,26.0652 2.93478,26.0652L 5.36956,26.0652C 6.71417,26.0652 7.80435,27.1554 7.80435,28.5 Z M 28.5,49.1957L 28.5,49.1957C 29.8446,49.1957 30.9348,50.2858 30.9348,51.6304L 30.9348,54.0652C 30.9348,55.4098 29.8446,56.5 28.5,56.5L 28.5,56.5C 27.1554,56.5 26.0652,55.4098 26.0652,54.0652L 26.0652,51.6304C 26.0652,50.2858 27.1554,49.1957 28.5,49.1957 Z M 49.1956,28.5L 49.1956,28.5C 49.1956,27.1554 50.2858,26.0652 51.6304,26.0652L 54.0652,26.0652C 55.4098,26.0652 56.5,27.1554 56.5,28.5L 56.5,28.5C 56.5,29.8446 55.4098,30.9348 54.0652,30.9348L 51.6304,30.9348C 50.2858,30.9348 49.1956,29.8446 49.1956,28.5 Z M 12.6739,10.2391C 12.6739,11.5837 11.5837,12.6739 10.2391,12.6739C 8.89452,12.6739 7.80435,11.5837 7.80435,10.2391C 7.80435,8.89452 8.89452,7.80435 10.2391,7.80435C 11.5837,7.80435 12.6739,8.89452 12.6739,10.2391 Z M 10.2391,44.3261C 11.5837,44.3261 12.6739,45.4163 12.6739,46.7609C 12.6739,48.1055 11.5837,49.1957 10.2391,49.1957C 8.89452,49.1957 7.80435,48.1055 7.80435,46.7609C 7.80435,45.4163 8.89452,44.3261 10.2391,44.3261 Z M 44.3261,46.7609C 44.3261,45.4163 45.4163,44.3261 46.7609,44.3261C 48.1055,44.3261 49.1956,45.4163 49.1956,46.7609C 49.1956,48.1055 48.1055,49.1957 46.7609,49.1957C 45.4163,49.1957 44.3261,48.1055 44.3261,46.7609 Z M 46.7609,12.6739C 45.4163,12.6739 44.3261,11.5837 44.3261,10.2391C 44.3261,8.89452 45.4163,7.80435 46.7609,7.80435C 48.1055,7.80435 49.1956,8.89452 49.1956,10.2391C 49.1956,11.5837 48.1055,12.6739 46.7609,12.6739 Z ",
            //moon 1
            "F1 M 4.05069,44.4884C 8.27498,46.7816 13.1159,48.0839 18.2614,48.0839C 34.7268,48.0839 48.0747,34.7465 48.0747,18.2936C 48.0747,13.1141 46.7517,8.24313 44.4251,4L 44.3975,4.01514C 53.691,9.05963 60,18.8986 60,30.2097C 60,46.6626 46.6521,60 30.1867,60C 18.888,60 9.05708,53.7195 4,44.4616",
            //cloudy 2
            "F1 M 24.1687,21.1803C 25.4846,17.1381 29.2877,14.2166 33.7688,14.2166C 37.5726,14.2166 40.8425,16.3216 42.6082,19.4302L 42.6082,19.4297C 43.1127,19.319 44.0984,19.2615 44.8675,19.2615C 53.2261,19.2615 60.0001,26.1636 60.0001,34.5222C 60.0001,42.8808 53.2221,49.7829 44.8635,49.7829L 14.0898,49.7829C 8.51751,49.7829 4.00009,45.1396 4.00009,39.567C 4.00009,34.4304 7.83873,30.1271 12.8039,29.4955L 12.8041,29.4672C 12.6553,28.8752 12.5764,28.2396 12.5764,27.6014C 12.5764,23.422 15.9642,20.0263 20.1437,20.0263C 21.6284,20.0263 23.0129,20.4498 24.1816,21.1883",
            //sun cloudy 3
            "M 11.6773,31.9618C 10.8169,30.3183 10.3301,28.4481 10.3301,26.4644C 10.3301,19.9095 15.6442,14.5956 22.1992,14.5956C 25.8819,14.5956 29.1729,16.273 31.35,18.9053M 11.6773,31.9618C 10.8169,30.3183 10.3301,28.4481 10.3301,26.4644C 10.3301,19.9095 15.6442,14.5956 22.1992,14.5956C 25.8819,14.5956 29.1729,16.273 31.35,18.9053M 22.3288,13.013L 22.0695,13.013C 21.2672,13.013 20.6166,12.3626 20.6166,11.5601L 20.6166,9.71819C 20.6166,8.91591 21.2672,8.2653 22.0695,8.2653L 22.3288,8.2653C 23.1311,8.2653 23.7817,8.91591 23.7817,9.71819L 23.7817,11.5601C 23.7817,12.3626 23.1311,13.013 22.3288,13.013 Z M 8.74768,26.3348L 8.74768,26.5941C 8.74768,27.3964 8.09732,28.047 7.29479,28.047L 5.45289,28.047C 4.65062,28.047 4.00001,27.3964 4.00001,26.5941L 4.00001,26.3348C 4.00001,25.5325 4.65062,24.8819 5.45289,24.8819L 7.29479,24.8819C 8.09732,24.8819 8.74768,25.5325 8.74768,26.3348 Z M 11.9127,14.5955C 11.9127,15.4696 11.2042,16.1781 10.3302,16.1781C 9.45612,16.1781 8.74763,15.4696 8.74763,14.5955C 8.74763,13.7214 9.45612,13.0129 10.3302,13.0129C 11.2042,13.0129 11.9127,13.7214 11.9127,14.5955 Z M 34.0681,16.178C 33.194,16.178 32.4855,15.4695 32.4855,14.5955C 32.4855,13.7214 33.194,13.0129 34.0681,13.0129C 34.9421,13.0129 35.6506,13.7214 35.6506,14.5955C 35.6506,15.4695 34.9421,16.178 34.0681,16.178 Z M 24.221,26.6433C 25.5396,22.5927 29.0978,19.6652 33.5881,19.6652C 37.3998,19.6652 40.4237,21.7745 42.193,24.8896L 42.193,24.8891C 42.6985,24.7781 43.9391,24.7205 44.7098,24.7205C 53.0856,24.7205 60,31.8518 60,40.2276C 60,48.6035 53.3344,55.7347 44.9585,55.7347L 14.1213,55.7347C 8.53743,55.7347 4.01068,50.867 4.01068,45.2829C 4.01068,40.1356 7.85724,35.716 12.8327,35.0831L 12.8329,35.0009C 12.6838,34.4077 12.6047,33.7439 12.6047,33.1045C 12.6047,28.9167 15.9995,25.5003 20.1876,25.5003C 21.6754,25.5003 23.0628,25.9179 24.2338,26.6582",
            //moon cloudy 4
            "M 11.6132,35.4358C 8.37681,33.9916 5.7038,31.5133 4.0149,28.4213M 11.6132,35.4358C 8.3768,33.9916 5.7038,31.5133 4.01489,28.4213M 21.9058,26.7727C 25.542,23.8169 27.865,19.31 27.865,14.261C 27.865,11.4582 27.1493,8.82255 25.8902,6.52632L 25.8753,6.5344C 30.9042,9.26422 34.3183,14.5885 34.3183,20.7093M 21.9058,26.7727C 25.542,23.8169 27.865,19.31 27.865,14.261C 27.865,11.4582 27.1493,8.82255 25.8902,6.52632L 25.8753,6.5344C 30.9042,9.26422 34.3183,14.5885 34.3183,20.7093M 4.04229,28.4358C 6.32817,29.6768 8.94789,30.3816 11.7323,30.3816C 12.1143,30.3816 12.4936,30.3682 12.8691,30.3422M 4.04229,28.4358C 6.32817,29.6768 8.94789,30.3816 11.7323,30.3816C 12.1143,30.3816 12.4936,30.3682 12.8691,30.3422M 24.1913,28.6494C 25.5088,24.6027 29.1899,21.6779 33.676,21.6779C 37.4841,21.6779 40.6314,23.7853 42.3991,26.8974L 42.3991,26.8969C 42.9041,26.786 44.0173,26.7285 44.7872,26.7285C 53.1552,26.7285 60,33.7331 60,42.1011C 60,50.4691 53.2775,57.4737 44.9094,57.4737L 14.1011,57.4737C 8.52251,57.4737 4,52.7305 4,47.1516C 4,42.0092 7.84296,37.6538 12.8137,37.0215L 12.814,36.9695C 12.665,36.3765 12.5859,35.7285 12.5859,35.0897C 12.5859,30.9055 15.9776,27.4999 20.1618,27.4999C 21.6481,27.4999 23.0343,27.9212 24.2042,28.6606",
            //sun cloud rain 5
            "M 36.5896,59.0609L 33.0849,60L 30.2678,49.4862L 33.7724,48.5471L 36.5896,59.0609 Z M 13.7534,25.2593C 12.9815,23.7848 12.5447,22.107 12.5447,20.3273C 12.5447,14.4466 17.3123,9.67922 23.193,9.67922C 26.497,9.67922 29.4495,11.1841 31.4027,13.5456M 13.7534,25.2593C 12.9815,23.7848 12.5447,22.107 12.5447,20.3273C 12.5447,14.4466 17.3123,9.67922 23.193,9.67922C 26.497,9.67922 29.4495,11.1841 31.4027,13.5456M 23.3093,8.25937L 23.0767,8.25937C 22.3569,8.25937 21.7732,7.67589 21.7732,6.95591L 21.7732,5.30345C 21.7732,4.58369 22.3569,4 23.0767,4L 23.3093,4C 24.0291,4 24.6128,4.58369 24.6128,5.30345L 24.6128,6.95591C 24.6128,7.67589 24.0291,8.25937 23.3093,8.25937 Z M 11.125,20.211L 11.125,20.4437C 11.125,21.1634 10.5416,21.7471 9.82157,21.7471L 8.16912,21.7471C 7.44936,21.7471 6.86566,21.1634 6.86566,20.4437L 6.86566,20.211C 6.86566,19.4912 7.44936,18.9075 8.16912,18.9075L 9.82157,18.9075C 10.5416,18.9075 11.125,19.4912 11.125,20.211 Z M 13.9646,9.67911C 13.9646,10.4633 13.3289,11.0989 12.5448,11.0989C 11.7606,11.0989 11.125,10.4633 11.125,9.67911C 11.125,8.89495 11.7606,8.25932 12.5448,8.25932C 13.3289,8.25932 13.9646,8.89495 13.9646,9.67911 Z M 33.8412,11.0989C 33.057,11.0989 32.4214,10.4632 32.4214,9.67909C 32.4214,8.89492 33.057,8.25929 33.8412,8.25929C 34.6254,8.25929 35.261,8.89492 35.261,9.67909C 35.261,10.4632 34.6254,11.0989 33.8412,11.0989 Z M 25.0069,20.4878C 26.1899,16.8538 29.4388,14.2274 33.4673,14.2274C 36.887,14.2274 39.6565,16.1198 41.2439,18.9145L 41.2439,18.914C 41.6974,18.8145 42.7537,18.7628 43.4451,18.7628C 50.9595,18.7628 57.1344,25.1803 57.1344,32.6947C 57.1344,40.2091 51.1259,46.6266 43.6115,46.6266L 15.9459,46.6266C 10.9364,46.6266 6.87523,42.2395 6.87523,37.23C 6.87523,32.6121 10.3262,28.6373 14.7899,28.0695L 14.7901,27.9908C 14.6563,27.4586 14.5853,26.8606 14.5853,26.2869C 14.5853,22.5296 17.631,19.4635 21.3883,19.4635C 22.7231,19.4635 23.9678,19.8376 25.0184,20.5016",
            //moon cloud rain 6
            "M 14.7567,28.4518C 12.0193,27.2303 9.75848,25.1341 8.33,22.5189M 14.7567,28.4518C 12.0193,27.2303 9.75848,25.1341 8.33,22.5189M 23.4623,21.1245C 26.5378,18.6245 28.5026,14.8125 28.5026,10.542C 28.5026,8.17141 27.8973,5.94217 26.8323,4L 26.8197,4.00683C 31.0731,6.31573 33.9609,10.8191 33.9609,15.996M 23.4623,21.1245C 26.5378,18.6245 28.5026,14.8125 28.5026,10.542C 28.5026,8.17141 27.8973,5.94217 26.8323,4L 26.8197,4.00683C 31.0731,6.31573 33.9609,10.8191 33.9609,15.996M 8.35317,22.5312C 10.2866,23.5808 12.5024,24.1769 14.8574,24.1769C 15.1806,24.1769 15.5014,24.1656 15.819,24.1436M 8.35317,22.5312C 10.2866,23.5808 12.5024,24.1769 14.8574,24.1769C 15.1806,24.1769 15.5014,24.1656 15.819,24.1436M 25.3954,22.7119C 26.5097,19.2891 29.6232,16.8153 33.4176,16.8153C 36.6385,16.8153 39.3005,18.5977 40.7956,21.23L 40.7956,21.2296C 41.2228,21.1358 42.1643,21.0871 42.8155,21.0871C 49.8933,21.0871 55.6826,27.0484 55.6826,34.1261C 55.6826,41.2038 49.9966,47.1649 42.9189,47.1649L 16.861,47.1649C 12.1426,47.1649 8.3174,43.1163 8.3174,38.3979C 8.3174,34.0482 11.5678,30.346 15.7721,29.8112L 15.7723,29.758C 15.6463,29.2567 15.5794,28.7039 15.5794,28.1636C 15.5794,24.6248 18.4482,21.742 21.9871,21.742C 23.2443,21.742 24.4167,22.097 25.4063,22.7224M 36.3809,59.1155L 33.0799,60L 30.4265,50.0971L 33.7275,49.2127L 36.3809,59.1155 Z ",
            //small rain 7
            "M 24.1686,13.6377C 25.4846,9.59554 29.2876,6.67406 33.7687,6.67406C 37.5725,6.67406 40.8424,8.77903 42.6081,11.8877L 42.6081,11.8872C 43.1126,11.7764 44.0983,11.7189 44.8674,11.7189C 53.226,11.7189 60,18.672 60,27.0306C 60,35.3892 53.222,42.342 44.8634,42.342L 14.0897,42.342C 8.51742,42.342 4,37.6478 4,32.0754C 4,26.9388 7.83863,22.61 12.8038,21.9784L 12.804,21.9373C 12.6552,21.3453 12.5763,20.7033 12.5763,20.0651C 12.5763,15.8857 15.9641,12.4868 20.1436,12.4868C 21.6283,12.4868 23.0128,12.9088 24.1815,13.6473M 37.0925,56.2814L 33.1941,57.3259L 30.0604,45.6309L 33.9589,44.5864L 37.0925,56.2814 Z ",
            //rain 8
            "M 20.6686,7.46367C 21.9846,3.42148 25.7876,0.499994 30.2687,0.499994C 34.0726,0.499994 37.3424,2.60496 39.1081,5.71361L 39.1081,5.7131C 39.6126,5.60237 40.5983,5.54486 41.3674,5.54486C 49.726,5.54486 56.5,12.4979 56.5,20.8565C 56.5,29.2151 49.722,36.1679 41.3634,36.1679L 10.5897,36.1679C 5.01742,36.1679 0.5,31.4737 0.5,25.9014C 0.5,20.7647 4.33864,16.436 9.30379,15.8043L 9.30404,15.7632C 9.15522,15.1712 9.07627,14.5293 9.07627,13.8911C 9.07627,9.71166 12.4641,6.31268 16.6436,6.31268C 18.1283,6.31268 19.5128,6.73469 20.6815,7.47326M 33.1052,50.2379L 30.1814,51.0214L 27.0478,39.3261L 29.9716,38.5429L 33.1052,50.2379 Z M 47.2308,50.2379L 44.307,51.0214L 41.1734,39.3261L 44.0972,38.5429L 47.2308,50.2379 Z M 18.9796,50.2379L 16.0558,51.0214L 12.9222,39.3261L 15.8459,38.5429L 18.9796,50.2379 Z ",
            //thunder 9
            "M 19.661,7.11578C 20.9112,3.27553 24.5243,0.5 28.7815,0.5C 32.3953,0.5 35.5018,2.49981 37.1793,5.45315L 37.1793,5.45267C 37.6586,5.34747 38.5951,5.29283 39.3258,5.29283C 47.2668,5.29283 53.7023,11.9319 53.7023,19.8729C 53.7023,27.8139 47.2629,34.4529 39.3219,34.4529L 10.0857,34.4529C 4.79174,34.4529 0.499999,29.9598 0.499999,24.6657C 0.499999,19.7856 4.14686,15.6566 8.86397,15.0565L 8.86421,15.0091C 8.72282,14.4467 8.64781,13.8327 8.64781,13.2262C 8.64781,9.25579 11.8664,6.02446 15.8371,6.02446C 17.2476,6.02446 18.563,6.42418 19.6732,7.12609M 25.1972,37.3287L 29.9901,37.3287L 28.0729,43.0801L 31.9072,43.0801L 24.7179,56.5L 26.1558,46.9143L 22.3215,46.9143L 25.1972,37.3287 Z ",
            //snow 10
            "M 24.1686,11.1348C 25.4846,7.09257 29.2876,4.17109 33.7687,4.17109C 37.5725,4.17109 40.8424,6.27606 42.6081,9.3847L 42.6081,9.3842C 43.1126,9.27346 44.0983,9.21595 44.8674,9.21595C 53.226,9.21595 60,16.1592 60,24.5178C 60,32.8764 53.222,39.8196 44.8634,39.8196L 14.0897,39.8196C 8.51742,39.8196 4,35.1352 4,29.5626C 4,24.426 7.83863,20.1023 12.8038,19.4706L 12.804,19.4318C 12.6552,18.8398 12.5763,18.1991 12.5763,17.5609C 12.5763,13.3817 15.9641,9.98327 20.1436,9.98327C 21.6283,9.98327 23.0128,10.4055 24.1815,11.1441M 34.0318,44.1898C 34.0318,45.3043 33.1283,46.2078 32.0139,46.2078C 30.8995,46.2078 29.9959,45.3043 29.9959,44.1898C 29.9959,43.0754 30.8995,42.1719 32.0139,42.1719C 33.1283,42.1719 34.0318,43.0754 34.0318,44.1898 Z M 21.9242,45.7033C 21.9242,46.8177 21.0206,47.7212 19.9062,47.7212C 18.7918,47.7212 17.8883,46.8177 17.8883,45.7033C 17.8883,44.5889 18.7918,43.6854 19.9062,43.6854C 21.0206,43.6854 21.9242,44.5889 21.9242,45.7033 Z M 46.1395,48.7302C 46.1395,49.8446 45.236,50.7482 44.1216,50.7482C 43.0072,50.7482 42.1036,49.8446 42.1036,48.7302C 42.1036,47.6158 43.0072,46.7123 44.1216,46.7123C 45.236,46.7123 46.1395,47.6158 46.1395,48.7302 Z M 27.978,57.811C 27.978,58.9254 27.0745,59.8289 25.9601,59.8289C 24.8456,59.8289 23.9421,58.9254 23.9421,57.811C 23.9421,56.6966 24.8456,55.793 25.9601,55.793C 27.0745,55.793 27.978,56.6966 27.978,57.811 Z M 40.0857,57.811C 40.0857,58.9254 39.1821,59.8289 38.0677,59.8289C 36.9533,59.8289 36.0498,58.9254 36.0498,57.811C 36.0498,56.6966 36.9533,55.793 38.0677,55.793C 39.1821,55.793 40.0857,56.6966 40.0857,57.811 Z ",
            //snow rain 11
            "M 24.1686,12.6385C 25.4846,8.59629 29.2876,5.67481 33.7687,5.67481C 37.5725,5.67481 40.8424,7.77978 42.6081,10.8884L 42.6081,10.8879C 43.1126,10.7772 44.0983,10.7197 44.8674,10.7197C 53.226,10.7197 60,17.6677 60,26.0263C 60,34.3849 53.222,41.3332 44.8634,41.3332L 14.0897,41.3332C 8.51742,41.3332 4,36.6437 4,31.0712C 4,25.9345 7.83863,21.6082 12.8038,20.9766L 12.804,20.9368C 12.6552,20.3448 12.5763,19.7036 12.5763,19.0654C 12.5763,14.886 15.9641,11.4872 20.1436,11.4872C 21.6283,11.4872 23.0128,11.9093 24.1815,12.6481M 50.7308,55.4127L 47.807,56.1962L 44.6734,44.5009L 47.5972,43.7177L 50.7308,55.4127 Z M 22.4796,55.4127L 19.5558,56.1962L 16.4222,44.5009L 19.3459,43.7177L 22.4796,55.4127 Z M 29.9959,45.4608C 29.9959,46.5752 30.8995,47.4787 32.0139,47.4787C 33.1283,47.4787 34.0318,46.5752 34.0318,45.4608C 34.0318,44.3464 33.1283,43.4428 32.0139,43.4428C 30.8995,43.4428 29.9959,44.3464 29.9959,45.4608 Z M 33.0229,56.3072C 33.0229,57.4217 33.9264,58.3252 35.0408,58.3252C 36.1552,58.3252 37.0588,57.4217 37.0588,56.3072C 37.0588,55.1928 36.1552,54.2893 35.0408,54.2893C 33.9264,54.2893 33.0229,55.1928 33.0229,56.3072 Z ",
            //fog 12
            "M 56.1818,35.8182L 12.9091,35.8182C 10.8004,35.8182 9.09091,34.1087 9.09091,32L 9.09091,32C 9.09091,29.8913 10.8004,28.1818 12.9091,28.1818L 56.1818,28.1818C 58.2905,28.1818 60,29.8913 60,32L 60,32C 60,34.1087 58.2905,35.8182 56.1818,35.8182 Z M 51.0909,20.5455L 7.81818,20.5455C 5.70949,20.5455 4,18.836 4,16.7273L 4,16.7273C 4,14.6186 5.70949,12.9091 7.81818,12.9091L 51.0909,12.9091C 53.1996,12.9091 54.9091,14.6186 54.9091,16.7273L 54.9091,16.7273C 54.9091,18.836 53.1996,20.5455 51.0909,20.5455 Z M 51.0909,51.0909L 7.81818,51.0909C 5.70949,51.0909 4,49.3814 4,47.2727L 4,47.2727C 4,45.164 5.70949,43.4545 7.81818,43.4545L 51.0909,43.4545C 53.1996,43.4545 54.9091,45.164 54.9091,47.2727L 54.9091,47.2727C 54.9091,49.3814 53.1996,51.0909 51.0909,51.0909 Z ",
            //haze 13
            "M 24.3636,37.9217L 20.9697,32L 24.3636,26.0783L 31.1515,26.0783L 34.5455,32L 31.1515,37.9217L 24.3636,37.9217 Z M 7.39394,37.9217L 4,32L 7.39394,26.0783L 14.1818,26.0783L 17.5758,32L 14.1818,37.9217L 7.39394,37.9217 Z M 41.3333,37.9217L 37.9394,32L 41.3333,26.0783L 48.1212,26.0783L 51.5152,32L 48.1212,37.9217L 41.3333,37.9217 Z M 15.8788,23.25L 12.4848,17.3283L 15.8788,11.4066L 22.6667,11.4066L 26.0606,17.3283L 22.6667,23.25L 15.8788,23.25 Z M 32.8485,23.25L 29.4545,17.3283L 32.8485,11.4066L 39.6364,11.4066L 43.0303,17.3283L 39.6364,23.25L 32.8485,23.25 Z M 49.8182,23.25L 46.4242,17.3283L 49.8182,11.4066L 56.6061,11.4066L 60,17.3283L 56.6061,23.25L 49.8182,23.25 Z M 15.8788,52.5934L 12.4848,46.6717L 15.8788,40.75L 22.6667,40.75L 26.0606,46.6717L 22.6667,52.5934L 15.8788,52.5934 Z M 32.8485,52.5934L 29.4545,46.6717L 32.8485,40.75L 39.6364,40.75L 43.0303,46.6717L 39.6364,52.5934L 32.8485,52.5934 Z M 49.8182,52.5934L 46.4242,46.6717L 49.8182,40.75L 56.6061,40.75L 60,46.6717L 56.6061,52.5934L 49.8182,52.5934 Z ",
            //wind 14
            "M 56.5,26.3505L 0.499999,26.3505M 23.7953,43.0908C 23.7953,48.2453 19.6166,52.4241 14.462,52.4241C 9.30744,52.4241 5.12868,48.2453 5.12868,43.0908C 5.12868,37.9362 9.30744,33.7574 14.462,33.7574L 14.5,33.8172L 56.5,33.8172M 37.8828,9.83333C 37.8828,4.67876 33.704,0.499999 28.5495,0.499999C 23.3949,0.499999 19.2162,4.67876 19.2162,9.83333C 19.2162,14.9879 23.3949,19.1667 28.5495,19.1667L 28.5,19.1172L 56.5,19.1172",
            //hot 15
            "M 55.3333,4L 55.3333,60M 50.6667,12.0829L 55.3333,4L 60,12.0829M 8.66667,41.3333L 8.66667,60M 4,49.3414L 8.66667,41.2585L 13.3333,49.3414M 32,22.6667L 32,60M 27.3333,30.7496L 32,22.6667L 36.6667,30.7496",
            //cold 16
            "M 55.3333,60L 55.3333,4M 50.6667,51.9171L 55.3333,60L 60,51.9171M 8.66667,22.6667L 8.66667,4M 4,14.6585L 8.66667,22.7414L 13.3333,14.6585M 32,41.3333L 32,4M 27.3333,33.2504L 32,41.3333L 36.6667,33.2504"
        };
        #endregion
        private static readonly Color[] pallete = new Color[]
        {
            //moon,sun 0
            Color.FromArgb(255,0xff,0xef,0x00),
            //cloud 1
            Color.FromArgb(255,0xe0,0xe0,0xe0),
            //rain,small rain 2
            Color.FromArgb(255,0xa4,0xe0,0xef),
            //snow,snow rain 3
            Color.FromArgb(255,0x56,0xef,0xef),
            //thunder 4
            Color.FromArgb(255,0xef,0xef,0x90),
            //fog 5
            Color.FromArgb(255,0xe0,0xe0,0xe0),
            //Haze 6
            Color.FromArgb(255,0xb0,0xb0,0x80),
            //Hot 7
            Color.FromArgb(255,0xdb,0x63,0x25),
            //Cold 8
            Color.FromArgb(255,0x23,0x89,0xef)
        };

        internal void SetCondition(WeatherCondition condition, bool isNight = false)
        {
            switch (condition)
            {
                case WeatherCondition.unknown:
                    Result = null; break;
                case WeatherCondition.sunny:
                    SetSunny(isNight);
                    break;
                case WeatherCondition.cloudy:
                case WeatherCondition.few_clouds:
                case WeatherCondition.partly_cloudy:
                    SetSunCloudy(isNight);
                    break;
                case WeatherCondition.overcast:
                    SetCloudy();
                    break;
                case WeatherCondition.windy:
                case WeatherCondition.calm:
                case WeatherCondition.light_breeze:
                case WeatherCondition.moderate:
                case WeatherCondition.fresh_breeze:
                case WeatherCondition.strong_breeze:
                case WeatherCondition.high_wind:
                case WeatherCondition.gale:
                    SetSunny(isNight);
                    break;
                case WeatherCondition.strong_gale:
                case WeatherCondition.storm:
                case WeatherCondition.violent_storm:
                case WeatherCondition.hurricane:
                case WeatherCondition.tornado:
                case WeatherCondition.tropical_storm:
                    SetWind();
                    break;
                case WeatherCondition.shower_rain:
                case WeatherCondition.heavy_shower_rain:
                    SetShower(isNight);
                    break;
                case WeatherCondition.thundershower:
                case WeatherCondition.heavy_thunderstorm:
                case WeatherCondition.hail:
                    SetThunderShower();
                    break;
                case WeatherCondition.light_rain:
                case WeatherCondition.moderate_rain:
                    SetRain(0);
                    break;
                case WeatherCondition.heavy_rain:
                case WeatherCondition.extreme_rain:
                    SetRain(1);
                    break;
                case WeatherCondition.drizzle_rain:
                    SetRain(0);
                    break;
                case WeatherCondition.storm_rain:
                case WeatherCondition.heavy_storm_rain:
                case WeatherCondition.severe_storm_rain:
                    SetRain(1);
                    break;
                case WeatherCondition.freezing_rain:
                    SetSnowRain();
                    break;
                case WeatherCondition.light_snow:
                case WeatherCondition.moderate_snow:
                    SetSnow();
                    break;
                case WeatherCondition.heavy_snow:
                case WeatherCondition.snowstorm:
                    SetSnow();
                    break;
                case WeatherCondition.sleet:
                case WeatherCondition.rain_snow:
                    SetSnowRain();
                    break;
                case WeatherCondition.shower_snow:
                case WeatherCondition.snow_flurry:
                    SetSnow();
                    break;
                case WeatherCondition.mist:
                case WeatherCondition.foggy:
                    SetFog();
                    break;
                case WeatherCondition.haze:
                case WeatherCondition.sand:
                case WeatherCondition.dust:
                case WeatherCondition.volcanic_ash:
                case WeatherCondition.duststorm:
                case WeatherCondition.sandstorm:
                    SetHaze();
                    break;
                case WeatherCondition.hot:
                    SetHot();
                    break;
                case WeatherCondition.cold:
                    SetCold();
                    break;
                default:
                    break;
            }

        }

        private void SetSnowRain()
        {
            Result = conditionEnums[11];
            ResultColor = pallete[3];
        }

        private void SetCold()
        {
            Result = conditionEnums[16];
            ResultColor = pallete[8];
        }

        private void SetHot()
        {
            Result = conditionEnums[15];
            ResultColor = pallete[7];
        }

        private void SetHaze()
        {
            Result = conditionEnums[13];
            ResultColor = pallete[6];
        }

        private void SetFog()
        {
            Result = conditionEnums[12];
            ResultColor = pallete[5];
        }

        private void SetSnow()
        {
            Result = conditionEnums[10];
            ResultColor = pallete[3];
        }

        private void SetRain(int v)
        {
            if (v > 0)
            {
                Result = conditionEnums[8];
            }
            else
            {
                Result = conditionEnums[7];
            }
            ResultColor = pallete[2];
        }

        private void SetThunderShower()
        {
            Result = conditionEnums[9];
            ResultColor = pallete[4];
        }

        private void SetShower(bool isNight)
        {
            if (isNight)
            {
                Result = conditionEnums[6];
            }
            else
            {
                Result = conditionEnums[5];
            }
            ResultColor = pallete[2];
        }

        private void SetWind()
        {
            Result = conditionEnums[14];
        }

        private void SetCloudy()
        {
            Result = conditionEnums[2];
            ResultColor = pallete[1];
        }

        private void SetSunCloudy(bool isNight)
        {
            if (isNight)
            {
                Result = conditionEnums[4];
            }
            else
            {
                Result = conditionEnums[3];
            }
            ResultColor = pallete[1];
        }

        private void SetSunny(bool isNight)
        {
            if (isNight)
            {
                Result = conditionEnums[1];
            }
            else
            {
                Result = conditionEnums[0];
            }
            ResultColor = pallete[0];
        }

        private string result;

        public string Result
        {
            get
            {
                return result;
            }

            set
            {
                SetProperty(ref result, value);
            }
        }

        public Color ResultColor
        {
            get
            {
                return resultColor;
            }

            set
            {
                SetProperty(ref resultColor, value);
            }
        }

        private Color resultColor;
    }
}
