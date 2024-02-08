using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveLoadSystem : MonoBehaviour
{
    public string Name;
    public int Age;
    public string Occupation;

    public Text infoboard;

    public Text Savefiles;

    public InputField _name;
    public InputField age;
    public InputField occupation;

    public InputField selectedsavefiles;
    string startpath;
    string Fullpath;
     private void Start()
    {
        startpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    private void Update() 
    {
       infoboard.text = 
       "Chracater Name: " + Name + "\n" +
       "Character Age: " + Age + "\n" +
       "Character Occupation: " + Occupation; 
    }
    public void Load()
    {
        Fullpath = startpath+@"\"+selectedsavefiles.text+".saf";
        try
        {
           BinaryReader br = new BinaryReader(new FileStream(Fullpath, FileMode.Open, FileAccess.Read));
           Name = br.ReadString();
           Age = br.ReadInt32();
           Occupation = br.ReadString();
           br.Close();
        }

        catch
        {

        }
    }

    public void LoadSaveFiles()
    {
        string savefiles = "Available Savefiles:" + "\n";
        string[] availableSaveFiles =  System.IO.Directory.GetFiles(startpath, "*.saf");

        foreach (string s in availableSaveFiles)
        {
            savefiles = savefiles + s + "\n"; 
        }

        Savefiles.text = savefiles;
    }

    public void Save()
    {
        //BinaryWriter bw = new BinaryWriter(new FileStream(Fullpath, FileMode.OpenOrCreate, FileAccess.Write));
        Fullpath = startpath+@"\"+Name+".saf";
        BinaryWriter bw = new BinaryWriter(new FileStream(Fullpath, FileMode.OpenOrCreate, FileAccess.Write));
        try
        {
           bw.Write(Name);
           bw.Write(Age);
           bw.Write(Occupation);
        }

        catch
        {

        }
        bw.Close();
    }

    public void edit()
    {
        Name = _name.text;

        try{
            Age = int.Parse(age.text);
        }

        catch
        {
            age.text = ("Enter valid age (int)");
        }
    
        Occupation = occupation.text;
    }
}
