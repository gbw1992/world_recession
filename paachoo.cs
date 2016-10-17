using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions; //正则表达式的命名空间

namespace test
{
    public delegate void testWeiTuo(string name);   
    class Program
    {
        #region 公共变量
        List<string> allMovieLink = new List<string>();
        public static event Action CallBack;
        #endregion
        static void Main(string[] args)
        {
            #region List数组
            List<int> arr = new List<int>();
            for(var i = 0;i < 10; i++)
            {
                arr.Add(i);
                //Console.WriteLine();
            }
            #endregion
            #region 委托
            testWeiTuo wt = new testWeiTuo(intrr);
            wt += intss;  
            wt("AA");
            openInt("Aa", intrr);
            #endregion
            #region Event CallBack
            AsyncFunction o = new AsyncFunction();
            //o.Fun();
            #endregion
            #region Timer
            Timer Timmer;
            //Timmer = new Timer();

            #endregion

            #region 网页抓取
            WebClient WebContent = new WebClient();
            WebContent.Credentials = CredentialCache.DefaultCredentials;
            #region 生成所有读取链接 string allMovieLink
            
            
            #endregion
            //Byte[] pageData = WebContent.DownloadData("https://movie.douban.com/top250"); //从指定网站下载数据
            //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
            //string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
            //Console.WriteLine(pageHtml);//在控制台输入获取的内容
            //string[] getLink = GetLinks(pageHtml);//使用正则表达式获取页面链接

            //foreach (string Link in getLink)
            //{
            //    Console.WriteLine(Link);
            //}
            #endregion
            Console.ReadKey();
        }
        #region 方法
        private static void getPageCon()
        {
            for (int i = 0; i < 250; i += 25)
            {
                string linkTemp = "https://movie.douban.com/top250?start=" + i;
                allMovieLink.Add(linkTemp);
            }
        #endregion
            #region 读取所有链接网站内容
            List<string> pageData = new List<string>();
            foreach (string getlink in allMovieLink)
            {
                Byte[] pageDatas = WebContent.DownloadData(getlink);
                string pageHtml = Encoding.UTF8.GetString(pageDatas);
                pageData.Add(pageHtml);
            }
        }
        /// <summary>
        /// 获取网页中的链接
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private static string[] GetLinks(string html)
        {
            const string pattern = @"https://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase); //新建正则模式
            MatchCollection m = r.Matches(html); //获得匹配结果
            string[] links = new string[m.Count];

            for (int i = 0; i < m.Count; i++)
            {
                links[i] = m[i].ToString(); //提取出结果
            }
            return links;
        }
        #endregion
        

        private static void openInt(string name,testWeiTuo makeOpen)
        {
            makeOpen(name);
        }
        private static void intrr(string id)
        {
           // Console.WriteLine("Rr" + id);
        }
        private static void intss(string id)
        {
            //Console.WriteLine("Ss" + id);
        }

        public static void CheckOpen()
        {
            Console.WriteLine("Sleep Start...");
            Thread.Sleep(2000);
            Console.WriteLine("Sleep End....");
        }
       
    }
    class AsyncFunction
    {
        public event Action CallBack;
        private void Function_1()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Funciton_1:{0}", i);
            }
        }
        private void Function_2()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Function_2:{0}", i);
            }
        }
        public void Fun()
        {
            CallBack += AsyncFunction_CallBack;
            if (CallBack != null)
            {
                CallBack();
            }
        }

        void AsyncFunction_CallBack()
        {
            
            Function_1();
            Function_2();
        }
    }
    class demoNum
    {
        private int demoNumP = 1;
        public int Num
        {
            set 
            {
                demoNumP = value + demoNumP;
            }
            get
            {
                return demoNumP;
            }
        }
    }
}
