/*
 作者：刘涛
 时间：2021-12-6
 用途：读取存储在json文件中的数据，利用 stream read/write, 实现在windows 服务器上的操作。
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;//添加文件读写
using Newtonsoft.Json;
using LightupFactoryService.Model;

namespace LightupFactoryService.BusinessLogic.fileStream
{
    /// <summary>
    /// 2021-12-6 Json文件读取
    /// </summary>
    public class JsonFile
    {
        /// <summary>
        /// 读取指定路径的文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string readJsonFile(string path)
        { 
            string jsonContentents = "";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                jsonContentents = sr.ReadLine();
                sr.Close();               
            }
            return jsonContentents;
        }

        /// <summary>
        /// 读取多行文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<ServiceRegister> readMultiRow(string path)
        {
            List<ServiceRegister> list = new List<ServiceRegister>();
            if (File.Exists(path))
            {
                //获取总行数
                int rows = GetRowCount(path);
                StreamReader sr = new StreamReader(path);
                for (int i = 0; i < rows; i++)
                {
                    string item = sr.ReadLine();
                    if (item.Length > 10)
                    {
                        ServiceRegister model = JsonConvert.DeserializeObject<ServiceRegister>(item);
                        list.Add(model);
                    }
                }
                sr.Close();
            }
            return list;
        }

        /// <summary>
        /// 获取读取文件的总行数
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private int GetRowCount(string path)
        {
            int rowNumber = 0;
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                while (sr.ReadLine() != null)
                {
                    rowNumber += 1;
                }
            }

            return rowNumber;
        }

        /// <summary>
        /// Option1: 将内容作为一行写入文件
        /// 写Json文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        public void writeJsonFile(string path, string contents)
        {
            //判断文件是否已存在
            if (File.Exists(path))
            {
                //已存在，删除文件
                File.Delete(path);
            }

            //重新写入文件           
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(contents);
            sw.Close();
        }

        /// <summary>
        /// Option 2： 将文件写入到多行
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="list"></param>
        public void writeJsonFile_Multi(string path, List<ServiceRegister> list)
        {
            //判断文件是否已存在
            if (File.Exists(path))
            {
                //已存在，删除文件
                File.Delete(path);
            }

            //重新写入文件           
            StreamWriter sw = new StreamWriter(path);
            foreach (var item in list)
            { 
                string contents=JsonConvert.SerializeObject(item);
                sw.WriteLine(contents);
            }
            sw.Close();
        }
    }
}
