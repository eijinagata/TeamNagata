using System.Collections;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// ファイル保存クラス
/// </summary>
static public class TajimaStream
{
    // ファイルパス
    static string fileName = "";
    // 保存用データ
    static List<string> list = new List<string>();

    // 保存場所のファイルパス記録メソッド
    static public void SetFileName(string name)
    {
        fileName = name;
        list.Clear();
    }
    // 保存するデータをここに入れていく
    static public void AddData(string text)
    {
        list.Add(text);
    }
    // 保存する
    static public void Save()
    {
        using (StreamWriter sw = new StreamWriter(
            fileName,
            false,
            System.Text.Encoding.GetEncoding("shift_jis"))
            )
        {
            foreach(string str in list)
            {
                sw.WriteLine(str);
            }
        }
        list.Clear();
    }
    // 1行ごとに取得
    static public string Load()
    {
        list.Clear();
        string str = "";
        using (StreamReader sr = new StreamReader(fileName))
        {
            str = sr.ReadToEnd();
        }
        return str;
    }

}
