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

        private MSWord.Document _wordDoc = null;

        /// <summary>
        /// 简单的复制文件命令
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
        /// 成功返回当前打开的Word文档接口对象，失败返回null
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

        public void CloseDoc()
        {
            if(this._wordDoc != null)
                _wordDoc.Close();
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

        public bool Replace(string oldString, string newString)
        {
            
            _wordDoc.Content.Find.Text = oldString;
            object findText = oldString;
            object replaceWith = newString;
            object replaceAll = MSWord.WdReplace.wdReplaceAll;
            return _wordDoc.Content.Find.Execute(oldString, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, replaceWith, replaceAll, Nothing, Nothing, Nothing, Nothing);
        }

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
