using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private static string path; // C:/Users/<username>/AppData/LocalLow/DefaultCompany/<ProjectName>/saves/
    private static SaveLoad _instance;
    public static SaveLoad instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SaveLoad>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If first instance, make me the Singleton
            _instance = this;
        }
        else
        {
            _instance = this;
        }

        path = string.Concat(Application.persistentDataPath, "/saves/");
    }

    #region Local Ranking methods
    /// <summary>
    /// Sauvegarder le score localement 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objectToSave">Object a sauvegarder</param>
    /// <param name="key">Nom du fichier</param>
    public static void Save<T>(T objectToSave, string key)
    {
        Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(string.Concat(path, key), FileMode.Create))
        {
            formatter.Serialize(fileStream, objectToSave);
        }
    }

    /// <summary>
    /// Charger le score local
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">Nom du fichier</param>
    /// <returns></returns>
    public static T Load<T>(string key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream fileStream = new FileStream(string.Concat(path, key), FileMode.Open))
        {
            returnValue = (T)formatter.Deserialize(fileStream);
        }

        return returnValue;
    }

    /// <summary>
    /// Verifier que le fichier existe
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool SaveExists(string key)
    {
        return File.Exists(string.Concat(path, key));
    }

    #endregion
}
