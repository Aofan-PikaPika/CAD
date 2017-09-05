using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using MSWord = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace BLL
{
    public class WordController
    {
        //使用C#,COM编程中的“省略ref”特性(C#图解编程第518页)
        Object Nothing = Missing.Value;//这个Missing类是反射里面的

        //一个wordController有一个Word应用对象
        private MSWord.Application _wordApp = new Application();
        public MSWord.Application WordApp { get { return _wordApp; } }

        //一个word应用只能有一个word文档对象
        private MSWord.Document _wordDoc = null;

        #region 基本方法
        /// <summary>
        /// 简单的复制文件命令，目的是将未置换参数的计算书复制到所在目录下
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        /// <returns></returns>
        public bool CopyTo(string sourceFile, string destinationFile)
        {
            FileInfo file = new FileInfo(sourceFile);
            if (file.Exists)
            {
                try
                {
                    // true is overwrite
                    file.CopyTo(destinationFile, true);
                }
                catch {
                    return false; 
                }
            }
            return true;
        }

        /// <summary>
        /// 在程序内存中打开一个Doc文档，以便以后操作
        /// </summary>
        /// <param name="docFileName"></param>
        /// <returns></returns>
        public bool OpenDoc(string docFileName,bool visible)
        {
            try
            {
                _wordApp.Visible = visible;
                object docObject = docFileName;
                if (File.Exists(docFileName))
                {
                    _wordDoc = _wordApp.Documents.Add(docObject, Nothing, Nothing, Nothing);
                    _wordDoc.Activate();//将当前文件设定为活动文档
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭当前控制类内存中的文档
        /// </summary>
        public void CloseDoc()
        {
            if(this._wordDoc != null)
                _wordDoc.Close();
            _wordDoc = null;
            //wordApp不关
        }

        public void SaveDocFile(string saveFileName)
        {
            if (_wordDoc != null)
            {
                if (!string.IsNullOrEmpty(saveFileName))
                {
                    object docname = saveFileName;//要保存的文件名称，包括路径
                    Replace("^p^p", "^p");
                    _wordDoc.SaveAs2(docname, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
                                
                }
            }

        }

        /// <summary>
        /// 核心方法：替换文档中的标签
        /// </summary>
        /// <param name="oldString">这里要写两边都是@的标签</param>
        /// <param name="newString">这里要写要替换的字符串</param>
        /// <returns></returns>
        public bool Replace(string oldString, string newString)
        {
            
            _wordDoc.Content.Find.Text = oldString;
            object findText = oldString;
            object replaceWith = newString;
            object replaceAll = MSWord.WdReplace.wdReplaceAll;
            return _wordDoc.Content.Find.Execute(oldString, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, replaceWith, replaceAll, Nothing, Nothing, Nothing, Nothing);
        }
        #endregion

        #region 与公式和Model内容对接的方法

        /// <summary>
        /// 传入很多键值对，依据键值对的内容往公式中添加字符
        /// 其中要求：键为标签名，值为要替换为公式的字符串
        /// </summary>
        /// <param name="dics"></param>
        public void PushDictionary(params Dictionary<string, string>[] dics)
        {
            foreach (Dictionary<string, string> d in dics)
            {
                foreach (KeyValuePair<string, string> kp in d)
                {
                    Replace(kp.Key, kp.Value);
                }
            }
        
        }

        /// <summary>
        /// 传入一个标签数组，一个对象数组，根据标签数组寻找位置，再将对象的ToString内容写入文档
        /// 要求：对象数组的ToString生成值必须有意义，不能是其命名空间
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="values"></param>
        public void PushKeyObjValueObj(string[] keys, object[] values)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                Replace(keys[i], values[i].ToString());
            }
        }

        #endregion

        #region 测试 上手用代码

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">存储路径</param>
        /// <param name="strContent">内容</param>
        public void CreateWord(string path,string strContent)
        {
            MSWord.Application wordApp = new MSWord.Application(); ;//Word应用程序变量,接口引用类型
            //MSWord Document类不是new出来的，是这样新建出来的
            MSWord.Document wordDoc = wordApp.Documents.Add(Nothing, Nothing, Nothing, Nothing);//Word文档变量
            if (File.Exists((string)path))//使用file类删除旧的文件
            {
                File.Delete((string)path);
            }
            //保存格式
            WdSaveFormat format = MSWord.WdSaveFormat.wdFormatDocumentDefault;
            wordDoc.SaveAs2(path, format, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
            wordDoc.Close(Nothing, Nothing, Nothing);
            wordApp.Quit(Nothing, Nothing, Nothing);
        }
        #endregion 


    }
}
