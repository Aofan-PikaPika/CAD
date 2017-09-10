using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace BLL.Service
{
    /// <summary>
    /// 这个类被命名成一个推荐杆件的服务，为了迎合一项新的需求：在工程师拿不准哪个杆件的情况下，循环遍历内置的数组，由难算过到
    /// 易算过，逐次尝试，直至遇到正确选项，出计算书
    /// 
    /// 思路：将需要推荐的数组置入内存，通过不同的循环来遍历数组
    /// 
    /// 难点:每个数组的H,Lb,La都有值，不能通过数组本身判断这个值是缺的，还是作为判断依据的一个数
    /// </summary>
    public class RecommendService
    {
        public int DeCode;

        /// <summary>
        /// 服务类在实例化时，仅根据目前的缺省项，判断一次：H,Lb,La中缺哪个值
        /// 然后将这个判断结果抽象成编码，以一个int类变量的形式存放在内存当中
        /// </summary>
        public RecommendService() 
        {
            this.DeCode = GetCode();
        }


        //                                       h    lb    la
        //表0 都不填                              0     0    0
        double [,] T0NoFill = new double [,]{ { 2.0, 1.2, 1.8 }, 
                                              { 2.0, 1.2, 1.5 }, 
                                              { 2.0, 0.9, 1.5 }};
        //表1 只填纵距                            0     0     1
        double[,] T1La = new double[,] {      { 2.0, 1.5, 2.0 }, 
                                              { 1.5, 1.5, 2.0 },
                                              { 2.0, 1.2, 1.8 },
                                              { 1.5, 1.2, 1.8 },
                                              { 2.0, 1.2, 1.5 },
                                              { 2.0, 0.9, 1.5 },
                                              { 1.5, 1.2, 1.5 },
                                              { 1.5, 0.9, 1.5 },
                                              { 2.0, 1.2, 1.2 },
                                              { 2.0, 0.9, 1.2 },
                                              { 1.5, 1.2, 1.2 },
                                              { 1.5, 0.9, 1.2 }};
        //表2 只填横距                           0     1     0
        double[,] T2Lb = new double[,] {     { 2.0, 1.5, 1.8 }, 
                                              { 2.0, 1.5, 1.5 },
                                              { 1.5, 1.5, 1.8 },
                                              { 1.5, 1.5, 1.5 },
                                              { 2.0, 1.2, 1.8 },
                                              { 2.0, 1.2, 1.5 },
                                              { 1.5, 1.2, 1.8 },
                                              { 1.5, 1.2, 1.5 },
                                              { 2.0, 0.9, 1.5 },
                                              { 1.5, 0.9, 1.5 }};
        //表3 横纵都填                           0      1    1
        double[,] T3LbLa = new double[,]{     { 2.0, 1.5, 2.0 },
                                              { 1.5, 1.5, 2.0 },
                                              { 2.0, 1.5, 1.8 },
                                              { 1.5, 1.5, 1.8 },
                                              { 2.0, 1.5, 1.5 },
                                              { 1.5, 1.5, 1.5 },
                                              { 2.0, 1.2, 1.8 },
                                              { 1.5, 1.2, 1.8 },
                                              { 2.0, 1.2, 1.5 },
                                              { 1.5, 1.2, 1.5 },
                                              { 2.0, 1.2, 1.2 },
                                              { 1.5, 1.2, 1.2 },
                                              { 2.0, 0.9, 1.5 },
                                              { 1.5, 0.9, 1.5 },
                                              { 2.0, 0.9, 1.2 },
                                              { 1.5, 0.9, 1.2 }};
        //表4 只填步距                           1    0     0
        double[,] T4H = new double[,]   {     { 2.0, 1.2, 1.8 },
                                              { 2.0, 1.2, 1.5 },
                                              { 2.0, 0.9, 1.5 },
                                              { 1.5, 1.2, 1.8 },
                                              { 1.5, 1.2, 1.5 },
                                              { 1.5, 0.9, 1.5 }};
        //表5 步距和纵距                          1    0    1
        double[,] T5HLa = new double[,] {     { 2.0, 1.5, 2.0 },
                                              { 2.0, 1.5, 1.8 },
                                              { 2.0, 1.2, 1.8 },
                                              { 2.0, 1.5, 1.5 },
                                              { 2.0, 1.2, 1.5 },
                                              { 2.0, 0.9, 1.5 },
                                              { 2.0, 1.2, 1.2 },
                                              { 2.0, 0.9, 1.2 },
                                              { 1.5, 1.5, 2.0 },
                                              { 1.5, 1.5, 1.8 },
                                              { 1.5, 1.2, 1.8 },
                                              { 1.5, 1.5, 1.5 },
                                              { 1.5, 1.2, 1.5 },
                                              { 1.5, 0.9, 1.5 },
                                              { 1.5, 1.2, 1.2 },
                                              { 1.5, 0.9, 1.2 }};

        //表6 步距和横距                          1    1    0
        double[,] T6HLb = new double[,] {     { 2.0, 1.5, 2.0 },
                                              { 2.0, 1.5, 1.8 },
                                              { 2.0, 1.5, 1.5 },
                                              { 2.0, 1.2, 1.8 },
                                              { 2.0, 1.2, 1.5 },
                                              { 2.0, 1.2, 1.2 },
                                              { 2.0, 0.9, 1.5 },
                                              { 2.0, 0.9, 1.2 },
                                              { 1.5, 1.5, 2.0 },
                                              { 1.5, 1.5, 1.8 },
                                              { 1.5, 1.5, 1.5 },
                                              { 1.5, 1.2, 1.8 },
                                              { 1.5, 1.2, 1.5 },
                                              { 1.5, 1.2, 1.2 },
                                              { 1.5, 0.9, 1.5 },
                                              { 1.5, 0.9, 1.2 }};
        //表7 都填（默认）                        1    1     1


        #region 选择逻辑

        //获得编码
        private int GetCode() 
        {
            char [] ch=new char[3];
            //三个if用来获取二进制码的三位
            if (ScaffoldPara.H != -1.0)
            {
                ch[0] = '1';
            }
            else 
            {
                ch[0] = '0';
            }
            if (ScaffoldPara.Lb!=-1.0)
            {
                ch[1] = '1';
            }
            else
            {
                ch[1] = '0';
            }
            if (ScaffoldPara.La != -1.0)
            {
                ch[2] = '1';
            }
            else 
            {
                ch[2] = '0';
            }
            string str = new string(ch);
            int code = Convert.ToInt32(str,2);
            return code;
        }

        /// <summary>
        /// 外界唯一要调用的推荐过程，这个推荐过程自动为la，lb，h的全局变量赋值。
        /// </summary>
        public void Recommend() 
        {
            switch (DeCode)
            {
                case 0: GetDataBy3Col(T0NoFill);
                    break;
                case 1: GetDataBy1Col(T1La,2,ScaffoldPara.La);
                    break;
                case 2: GetDataBy1Col(T2Lb, 1, ScaffoldPara.Lb);
                    break;
                case 3: GetDataBy2Col(T3LbLa, 1, 2, ScaffoldPara.Lb, ScaffoldPara.La);
                    break;
                case 4: GetDataBy1Col(T4H, 0, ScaffoldPara.H);
                    break;
                case 5: GetDataBy2Col(T5HLa, 0, 2, ScaffoldPara.H, ScaffoldPara.La);
                    break;
                case 6: GetDataBy2Col(T6HLb,0,1,ScaffoldPara.H,ScaffoldPara.Lb);
                    break;
                case 7:
                    break;
            }
        }



        #endregion



        #region 查询方法
        //一个列查询

        private int LogNum1 = 0;

        private bool GetDataBy1Col(double[,] array, int col, double value) 
        {
            for (int i = LogNum1; i < array.GetLength(0); i++)
            {
                if (array[i,col]==value)
                {
                    ScaffoldPara.H = array[i, 0];
                    ScaffoldPara.Lb = array[i, 1];
                    ScaffoldPara.La = array[i, 2];
                    LogNum1 = i+1;
                    return true;
                }
            }
            return false;
        }


        //两列查询
        private int LogNum2 = 0;
        private bool GetDataBy2Col(double[,] array, int col1, int col2, double value1, double value2) 
        {
            for (int i = LogNum2; i < array.GetLength(0); i++)
            {
                if (array[i,col1]==value1&&array[i,col2]==value2)
                {
                    ScaffoldPara.H = array[i, 0];
                    ScaffoldPara.Lb = array[i, 1];
                    ScaffoldPara.La = array[i, 2];
                    LogNum2 = i+1;
                    return true;
                }
            }
            return false;
        }

        //三列查询
        private int LogNum3 = 0;
        private bool GetDataBy3Col(double[,]array) 
        {
            if (LogNum3<array.GetLength(0))
	        {
                ScaffoldPara.H = array[LogNum3, 0];
                ScaffoldPara.Lb = array[LogNum3, 1];
                ScaffoldPara.La = array[LogNum3, 2];
                LogNum3++;
                return true;	 
        	}
            return false;
        }




        #endregion






    }
}
