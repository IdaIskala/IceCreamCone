using System.Collections.Generic;
using UnityEngine;


namespace Utility
{
    public static class RandomFunctions
    {
        /// <summary>
        /// Palauta satunnainen elementti listalta
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfElements"></param>
        /// <returns></returns>
        public static T GetRandomElement<T>(List<T> listOfElements)
        {
            return listOfElements[Random.Range(0, listOfElements.Count)];
        }

        /// <summary>
        /// Palauta satunnainen arrayn elementti
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayOfElements"></param>
        /// <returns></returns>
        public static T GetRandomElement<T>(T[] arrayOfElements)
        {
            return arrayOfElements[Random.Range(0, arrayOfElements.Length)];
        }

        /// <summary>
        /// Anna luku 0-1.1f väliltä (todennäköisyys tapahtumalle). Palauttaa toteutuuko tapahtuma. probability 1.1f=aina, 0f=ei koskaan.
        /// </summary>
        /// <param name="propability"></param>
        public static bool GetProbability(float propability)
        {
            return Random.Range(0f, 1f) < propability;
        }

        /// <summary>
        /// Sekoita array satunnaisesti
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void ShuffleRandomly<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                T element = array[i];

                int randI = Random.Range(0, array.Length);
                array[i] = array[randI];
                array[randI] = element;
            }
        }

        /// <summary>
        /// Luo lista numeroista satunnaisessa järjestyksessä
        /// </summary>
        /// <param name="minIncluded"></param>
        /// <param name="maxExluded"></param>
        /// <returns></returns>
        public static List<int> AddRandomRange(int minIncluded, int maxExluded)
        {
            List<int> result = new List<int>();
            for (int i = minIncluded; i < maxExluded; i++)
            {
                result.Add(i);
            }
            ShuffleRandomly(result);
            return result;
        }

        /// <summary>
        /// Sekoita lista
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void ShuffleRandomly<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                T element = list[i];

                int randI = Random.Range(0, list.Count);
                list[i] = list[randI];
                list[randI] = element;
            }
        }

        /// <summary>
        /// propabilities-Listassa todennäköisyydet joka options listan elementille. Palautetaan satunnainen elementti tod. näk. jakauman mukaan
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <param name="propabilities"></param>
        /// <returns></returns>
        public static T GetPropability<T>(T[] options, List<float> propabilities)
        {
            if (options.Length != propabilities.Count)
            {
                GameLogger.LogWarning("mismatch lengths " + options.Length + ", " + propabilities.Count);
                return options[0];
            }
            float sum = 0f;
            foreach (float p in propabilities)
            {
                sum += p;
            }

            float prop = Random.Range(0f, sum);
            float sum2 = 0;
            T result = options[0];

            for (int i = 0; i < options.Length; i++)
            {
                sum2 += propabilities[i];
                if (prop <= sum2)
                {
                    result = options[i];
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// propabilities-Listassa todennäköisyydet joka options listan elementille. Palautetaan satunnainen elementti tod. näk. jakauman mukaan
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <param name="propabilities"></param>
        /// <returns></returns>
        public static T GetPropability<T>(List<T> options, List<float> propabilities)
        {
            if (options.Count != propabilities.Count)
            {
                GameLogger.LogWarning("mismatch lengths " + options.Count + ", " + propabilities.Count + ", " + options[0]);
                return options[0];
            }
            float sum = 0f;
            foreach (float p in propabilities)
            {
                sum += p;
            }

            float prop = Random.Range(0f, sum);
            float sum2 = 0;
            T result = options[0];

            for (int i = 0; i < options.Count; i++)
            {
                sum2 += propabilities[i];
                if (prop <= sum2)
                {
                    result = options[i];
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// propabilities-Listassa todennäköisyydet joka options listan elementille. Palautetaan satunnainen elementti tod. näk. jakauman mukaan
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <param name="propabilities"></param>
        /// <returns></returns>
        public static T GetPropability<T>(T[] options, float[] propabilities)
        {
            if (options.Length != propabilities.Length)
            {
                GameLogger.LogWarning("mismatch lengths " + options.Length + ", " + propabilities.Length);
                return options[0];
            }
            float sum = 0f;
            foreach (float p in propabilities)
            {
                sum += p;
            }

            float prop = Random.Range(0f, sum);
            float sum2 = 0;
            T result = options[0];

            for (int i = 0; i < options.Length; i++)
            {
                sum2 += propabilities[i];
                if (prop <= sum2)
                {
                    result = options[i];
                    break;
                }
            }
            return result;
        }
    }
}
