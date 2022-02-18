/*
  作者：刘涛
 时间：2022-2-12
 用途：通过反射类构建动态构建方法，并调用
 参考：https://www.cnblogs.com/coderJiebao/p/CSharp09.html
 */

using System;
using System.Reflection;
using LightupFactoryService.ContextStr;
using LightupFactoryService.Model;

namespace LightupFactoryService.BusinessLogic
{
    public class ReflectClass
    {
        /// <summary>
        /// 通过反射创建方法
        /// </summary>
        public void CreateMethod(string className,string methodName,string postData,LightUpFactoryContext context)
        {
            Type type;
            Object obj;
            object[] ClassParams = new object[] { context };

            type = Type.GetType(className);//根据命名空间+类名获取类
            obj = Activator.CreateInstance(type, ClassParams); //实例化类
            //obj = Activator.CreateInstance(type);

            //实例化方法，并执行方法
            MethodInfo method = type.GetMethod(methodName);
            //object[] parameters= null;
            object[] parameters = new object[] {postData};
            method.Invoke(obj, parameters);//有参数，有返回值
        }
    }
}
