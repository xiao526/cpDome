using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpDemo
{
/// <summary>
/// 选号器类
/// </summary>
    class xhq
    {
        //属性(选择的号码可以保存)
        private Random objrandom = new Random();//生成随机数
        public List<string[]> haoma { get; set; }
        //方法
        public xhq()
        {
            this.haoma = new List<string[]>();//初始化
        }
        /// <summary>
        /// 生成7个随机号码
        /// </summary>
        /// <returns></returns>
        public string[] sjs()
        {
            string[] numList = new string[7];
            for(int i =0; i<7; i++)
            {
                numList[i] = objrandom.Next(10).ToString();
            }
            return numList;
        }
        /// <summary>
        /// 生成指定组数的随机号码
        /// </summary>
        /// <param name="count"></param>
        public void CreaGroupNums(int count)
        {
            haoma.Clear();//清零
            for(int i = 0;i < count;i++)
            {
                haoma.Add(sjs());//增加一组
            }
        }
        /// <summary>
        /// 获取打印格式的号码列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetprintedNumbs()
        {
            List<string> numList = new List<string>();
            for(int i=0;i<this.haoma.Count;i++)
            {
                string printedNum = string.Empty;
                if(i<9)
                {
                    printedNum = "第0" + (i + 1) + "组";
                }else
                {
                    printedNum = "第" + (i + 1) + "组";
                }
                for (int a=0;a<this.haoma[i].Length;a++)
                {
                    if(a==5)
                    {
                        printedNum += this.haoma[i][a] + "  ";
                    }
                    else
                    {
                        printedNum += this.haoma[i][a] + " ";
                    }
                    
                }
                numList.Add(printedNum);
            }
            return numList;
        }
    }
}
