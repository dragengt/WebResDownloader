using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using MyDebug;
using System.Threading;
using System.IO;
namespace WebDownloader.Classes
{
    public static class Downloader
    {
        //buffer 8M:
        const int BUFFER_SIZE = 8 *1024 * 1024;

        //--每次下载的步进值：
        const int DOWNLOAD_FILE_STEP_COUNT = 4;

        //--最大下载数
        const int MAX_FILE_COUNT = 16;

        /// <summary>
        /// 启动一个任务，并返回成功与否
        /// </summary>
        /// <param name="linkAddress">下载的地址</param>
        /// <param name="saveToFolder">保存的地址</param>
        public static bool StartDownloader(string linkAddress, string saveToFolder)
        {
            
            //默认直接下载图片
            DownloadImages(linkAddress,saveToFolder);

            return true;    
            

        }


        public static void DownloadImages(string linkAddress,string saveToFolder)
        {
            Match matched = Regex.Match(linkAddress, @"(.*[\D])(\d+)(\.[jpengif]+)");
            int failedCount = 0;
            
            CallbackSucc cbOnDownloadData = 
                (isSUc) =>
                {
                    if (isSUc == false)
                    {
                        failedCount++;
                    }
                };

            if (matched.Success)
            {
                Debug.Log("Yes. This is like a images web.");

                //--Try to get link  (www.xxx.com/blabla_)(number).(jpg/png)

                //前缀：
                string linkPrefix = matched.Groups[1].Value;

                //中缀
                //--序号字符串：（一般探测 +1，且保持这个长度）
                string indexStr = matched.Groups[2].Value;

                //后缀
                string postFix = matched.Groups[3].Value;

                //--获得序号的长度：（有可能为0001的形势）
                string indexNameFormat = "{1:D" + indexStr.Length + "}";

                int currIndex;

                if (int.TryParse(indexStr, out currIndex))
                {
                    #region 开始一个线程不断地开启任务
                    Thread threadDoAdd = new Thread(new ThreadStart(
                        () =>
                        {
                            //--缓步增加：
                            while (true)
                            {
                                //--每次组4次：
                                for (int i = 0; i < DOWNLOAD_FILE_STEP_COUNT; i++)
                                {
                                    #region 开始这个下载：
                                    //--构建下载名：

                                    //--TODO：填充为N位数而不是左边填值的问题！
                                    string link = string.Format("{0}"+indexNameFormat+"{2}", linkPrefix, currIndex, postFix);

                                    Debug.Log("Will go to :" + link);

                                    string fileName = saveToFolder +"/"+ currIndex+postFix;
                                    
                                    Debug.Log("File name :" + fileName);

                                    DownloadWebData(link, fileName , cbOnDownloadData);
                                    #endregion

                                    currIndex++;

                                }



                                Thread.Sleep(1000 * 5);

                                if (failedCount >= DOWNLOAD_FILE_STEP_COUNT)
                                {
                                    Debug.Log("Too many error , quit thread.");
                                    break;
                                }
                            }
                        }));

                    threadDoAdd.Start();
                    #endregion


                }
                else
                {
                    Debug.Log("something wrong...cannot parse the link number.");
                }
            }
        }

        public delegate void CallbackSucc  (bool suc);

        /// <summary>
        /// 下载一个内容：如果下载成功，则可能会回调该函数（取决回调与否）
        /// </summary>
        private static void DownloadWebData(string linkAddress,string FileNameToSave,CallbackSucc cbOnThreadFin = null)
        {
            bool isSuc = false;
            Thread thread = new Thread(new ThreadStart(()=>
                {
                    
                    Debug.Log("Thread start to work at "+ linkAddress);

                    //创建一个请求：
                    HttpWebRequest request = null;
                    HttpWebResponse response = null;

                    try
                    {
                        #region Do it
                        request = (HttpWebRequest)HttpWebRequest.Create(linkAddress);

                        //--开始获得结果：
                        response = (HttpWebResponse)request.GetResponse();

                        //--OK的情况下
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            #region 获得数据
                            using (Stream stream = response.GetResponseStream())
                            {
                                StreamReader sr = null;
                                StreamWriter sw = null;
                                BinaryReader binaryReader = null;
                                BinaryWriter binaryWriter = null;
                                try
                                {
                                    sr = new StreamReader(stream);
                                    sw = new StreamWriter(FileNameToSave);

                                    //--创建二进制流以进行写入读出
                                    binaryReader =
                                        new BinaryReader(sr.BaseStream);
                                    binaryWriter =
                                        new BinaryWriter(sw.BaseStream);


                                    //--现在开始读入并写出：
                                    byte[] buffer = new byte[BUFFER_SIZE];

                                    int readCount = 0;
                                    while (true)
                                    {
                                        //读入buffer
                                        readCount = binaryReader.Read(buffer, 0, BUFFER_SIZE);
                                        if (readCount <= 0)
                                        {
                                            Debug.Log("process done: " + FileNameToSave);

                                            isSuc = true;
                                            break;
                                        }


                                        //将Buffer内的内容写出：
                                        binaryWriter.Write(buffer, 0, readCount);

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.Log("Shit... something wrong.");
                                }
                                finally
                                {
                                    if (binaryReader != null)
                                        binaryReader.Close();

                                    if (binaryWriter != null)
                                        binaryWriter.Close();

                                    sw = null;
                                    sr = null;

                                }

                            }
                            #endregion
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("[error]: " + ex);
                    }
                    finally 
                    {
                        if (response != null)
                            response.Close();

                        //回调结果成功与否
                        if (cbOnThreadFin != null)
                        {
                            cbOnThreadFin(isSuc);
                        }
                    }

                    
                }
                
                
                ));
                

            thread.Start();
        }
    }
}
