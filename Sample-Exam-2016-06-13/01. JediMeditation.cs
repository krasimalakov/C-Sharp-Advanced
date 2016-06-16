namespace _01.JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class JediMeditation
    {
        public static void Main()
        {
            const char yoda = 'y';
            var orderWithOutYoda = new char[] { 'a', 'm', 'k', 'p' };
            var orderWithYoda = new char[] { 'm', 'k', 'a', 'p' };
            var aJediTypes = new char[] { 't', 's'};

            var jedis=new Dictionary<char, List<string>>();
            var count = int.Parse(Console.ReadLine());
            var withYoda = false;
            for (int i = 0; i < count; i++)
            {
                var jedisInput= Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var jedi in jedisInput)
                {
                    var jediType = jedi[0];
                    if (aJediTypes.Contains(jediType))
                    {
                        jediType = 'a';
                    }

                    if (jediType == yoda)
                    {
                        withYoda = true;
                    }
                    else
                    {
                        if (!jedis.ContainsKey(jediType))
                        {
                            jedis.Add(jediType, new List<string>());
                        }

                        jedis[jediType].Add(jedi);
                    }
                }
            }
            StringBuilder result = new StringBuilder();
            foreach (var jediType in withYoda ? orderWithYoda : orderWithOutYoda)
            {
                if (jedis.ContainsKey(jediType))
                {
                    result.Append(string.Join(" ", jedis[jediType]) + " ");
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}