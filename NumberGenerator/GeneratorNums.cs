

namespace NumberGenerator
{
    public class GeneratorNums
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Первой коллекцией возвращает сгенерированный лист случайных чисел, второй коллекцией возвращает отсортированный лист</returns>
        public (List<int>, List<int>) Generate()
        {
            List<int> NumsList = GetNumber();

            List<int> SortList = GetSortList(NumsList);

            return (NumsList, SortList);
        }
        private List<int> GetNumber()
        {
            Random random = new Random();
            List<int> result = new List<int>();

            int lenght = random.Next(20, 100);

            for (int i = 0; i < lenght; i++)
            {
                result.Add(random.Next(-100, 100));
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nums"></param>
        /// <returns></returns>
        private List<int> GetSortList(List<int> Nums)
        {
            Random random = new Random();

            if (random.Next(0,2) == 1)
            {
                Nums = Nums.OrderBy(x=>x).ToList();
            }
            else
            {
                Nums = Nums.OrderByDescending(x=>x).ToList();
            }

            return Nums;
        }
    }
}
