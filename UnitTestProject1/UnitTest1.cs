using CCLUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoMapper;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLog()
        {
            CCLUtility.Log.Warn("test");
            CCLUtility.Log.Info("test");
            CCLUtility.Log.Err("test");

        }
        [TestMethod]
        public void TestEnumHelper()
        {
            //��ȡ
            //CCLUtility.EnumHelper.GetDes(testEnum.data);
        }
        [TestMethod]
        public void TestDatetime2UTC()
        {
            Console.WriteLine(CCLUtility.TimeUtility.DateTime2UTC(DateTime.Now));
            Console.WriteLine(CCLUtility.TimeUtility.DateTime2UTCMilliseconds(DateTime.Now));
            Console.WriteLine(CCLUtility.TimeUtility.DateTimeStr2UTC("2019-7-1 1:1:1"));
            Console.WriteLine(CCLUtility.TimeUtility.DateTimeStr2UTCMillisecond("2019-7-1 1:1:1"));
            Console.WriteLine(CCLUtility.TimeUtility.UTC2DateTime(1562748402));
            Console.WriteLine(CCLUtility.TimeUtility.UTC2DateTimeMilliseconds(1562748402000));
        }
        [TestMethod]
        public void TestStringExtend()
        {
            CCLUtility.StringExtend.SetNAStr("NULL");
            Console.WriteLine(CCLUtility.StringExtend.GetNAStr());
        }
        [TestMethod]
        public void TestExcelHelper()
        {
            //�������ֶ�Ϊ�������ͬ���ļ��Ƿ�ɾ���ļ�
            var excelHelper = new ExcelHelper("c:/excelHelper.xls", "sheet1", true);
            excelHelper.SetValue(1, 1, "test");
            excelHelper.Save();

            var excelHelper2 = new ExcelHelper();
            excelHelper2.Init("c:/excelHelper2.xls", "sheet1", true);
            excelHelper2.SetValue(1, 1, "test");
            //�����Ҫ��ӵڶ���sheet
            var sheet2 = excelHelper2.AddSheet("sheet2");
            excelHelper2.SetValueBySheet(sheet2, 2, 1, "sheet2");
            excelHelper2.Save();
        }
        [TestMethod]
        public void TestAutoMapper()
        {
            var aa = new a();
            //ԭ����д��
            b bb = Mapper.Map<b>(aa);
            //�µ�д��
            var newB = aa.Map<b>();

            var la = new List<a>();
            var lb = new List<b>();
            //ԭ����д��
            var a = Mapper.Map<List<a>, List<b>>(la);
            //�µ�д��
            var listNew = la.Map<List<b>>();
        }
        public class a
        {
            public string name = "a";
        }
        public class b
        {
            public string name;
        }
    }


}
