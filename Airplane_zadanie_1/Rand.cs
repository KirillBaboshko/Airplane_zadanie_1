

namespace Airplane_zadanie_1
{
    public class Rand
    {
        private static Random rand=new Random();
        public static Double DamageRange(Int32 minDamage, Int32 maxDamage) => rand.Next(minDamage, maxDamage + 1);

        public static Boolean Chance(Double probability) { return rand.NextDouble() < probability; }
        public static T Pick<T>(IReadOnlyList<T> list)
        {
            return list[rand.Next(list.Count)];
        }
    }
}
