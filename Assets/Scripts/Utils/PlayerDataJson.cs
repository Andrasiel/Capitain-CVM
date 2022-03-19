using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Offre un moteur de lecture/écriture du JSON
/// pour l'objet <code>PlayerData</code>
/// </summary>
public static class PlayerDataJson
{
    /// <summary>
    /// Sérialise un objet de type PlayerData au format JSON
    /// </summary>
    /// <param name="data">Paramètre à sérialiser</param>
    /// <returns>La chaîne contenant le format JSON</returns>
    /// 
    //public static string WriteJson(PlayerData data)
    //{
    //    string tab = "\t";
    //    string newline = "\n";
    //    string json = "{" + newline;
    //    json += tab + "\"vie\":" + data.Vie + "," + newline;
    //    json += tab + "\"energie\":" + data.Energie + "," + newline;
    //    json += tab + "\"score\":" + data.Score + "," + newline;
    //    json += tab + "\"volumeGeneral\":" + data.VolumeGeneral.ToString().Replace(',', '.') + "," + newline; 
    //    json += tab + "\"volumeMusique\":" + data.VolumeMusique.ToString().Replace(',', '.') + "," + newline; 
    //    json += tab + "\"volumeEffet\":" + data.VolumeEffet.ToString().Replace(',', '.') + "," + newline; 
    //    json += tab + "\"chestOpenList\":[";
    //    if (data.ListeCoffreOuvert.Length > 0)
    //    {
    //        json += newline;
    //        for (int i = 0; i < data.ListeCoffreOuvert.Length; i++)
    //        {
    //            string chestData = data.ListeCoffreOuvert[i];
    //            json += tab + tab + "\"" + chestData + "\"";
    //            if (i + 1 < data.ListeCoffreOuvert.Length)
    //                json += ",";
    //            json += newline;
    //        }
    //        json += tab + "]" + newline;
    //    }
    //    else json += "]" + newline;
    //    json += "}";
    //    return json;
    //}

    [System.Serializable]
    class PlayerDataToJson
    {
        public int vie;
        public int energie;
        public int score;
        public int levelProgression;
        public float volumeGeneral;
        public float volumeMusique;
        public float volumeEffet;
        public string[] chestOpenList;
        public string[] collectableList;

        public PlayerDataToJson(int vie, int energie, int score, float volgeneral, float volumemusique, float volumeeffet, string[] chestopen, string[] collectableList, int levelProgression)
        {
            this.vie = vie;
            this.energie = energie;
            this.score = score;
            this.levelProgression = levelProgression;
            this.volumeEffet = volumeeffet;
            this.volumeGeneral = volgeneral;
            this.volumeMusique = volumemusique;
            this.chestOpenList = chestopen;
            this.collectableList = collectableList;
        }
    }

    //Utilisation de JsonUtility car bien plus simple a gérer et moins capilotracté que la méthode précédente
    public static string WriteJson(PlayerData data)
    {
        PlayerDataToJson jsonize = new PlayerDataToJson(data.Vie, data.Energie, data.Score, data.VolumeGeneral, data.VolumeMusique, data.VolumeEffet, data.ListeCoffreOuvert, data.ListeCollectable, data.levelProgression);
        return JsonUtility.ToJson(jsonize);
    }


    public static PlayerData ReadJson(string json)
    {

        PlayerDataToJson pdtj = JsonUtility.FromJson<PlayerDataToJson>(json);
        Debug.Log(pdtj);

        List<string> chests = new List<string>();



        for (int i = 0; i < pdtj.chestOpenList.Length; i++)
        {
            chests.Add(pdtj.chestOpenList[i]);
        }

        List<string> collectables = new List<string>();

        for (int i = 0; i < pdtj.collectableList.Length; i++)
        {
            collectables.Add(pdtj.collectableList[i]);
        }

        return new PlayerData(pdtj.vie, pdtj.energie, pdtj.score, pdtj.volumeGeneral, pdtj.volumeMusique, pdtj.volumeEffet, ChestList: chests, CollectableList: collectables, levelProgression: pdtj.levelProgression);
    }

    /// <summary>
    /// Récupère un objet PlayerData depuis un format JSON
    /// </summary>
    /// <param name="json">Format JSON à traiter</param>
    /// <returns>L'objet converti</returns>
    /// <exception cref="JSONFormatExpcetion">La chaîne n'est pas
    /// au format JSON</exception>
    /// <exception cref="System.ArgumentException">La chaîne fournit
    /// ne peut pas contenir un format JSON</exception>
    /// 


    //    public static PlayerData ReadJson(string json)
    //    {
    //        if (json.Length < 2 || string.IsNullOrEmpty(json))
    //            throw new
    //                System.ArgumentException("La chaîne n'est pas valide");
    //        if (json[0] != '{')
    //            throw new JSONFormatExpcetion();
    //        json = json.Replace("\t", string.Empty);

    //        int vie = 0, energie = 0, score = 0;
    //        float vlmGeneral = 0, vlmMusique = 0, vlmEffet = 0;
    //        List<string> chests = new List<string>();
    //        string[] lignes = json.Split('\n');

    //        for(int i = 1; i < lignes.Length || lignes[i] != "}"; i++)
    //        {
    //            if (lignes[i] == "}") break;

    //            string[] parametre = lignes[i].Split(':');
    //            if (parametre.Length != 2)
    //                throw new JSONFormatExpcetion();
    //            switch(parametre[0])
    //            {
    //                case "\"vie\"":
    //                    vie = int.Parse(parametre[1]
    //                        .Replace(",", string.Empty));
    //                    break;
    //                case "\"energie\"":
    //                    energie = int.Parse(parametre[1].Replace(",", string.Empty));
    //                    break;
    //                case "\"score\"":
    //                    score = int.Parse(parametre[1].Replace(",", string.Empty));
    //                    break;
    //                case "\"volumeGeneral\"":
    //                    vlmGeneral = float.Parse(parametre[1].Replace(",", string.Empty).Replace('.', ','));
    //                    break;
    //                case "\"volumeMusique\"":
    //                    vlmMusique = float.Parse(parametre[1].Replace(",", string.Empty).Replace('.', ','));
    //                    break;
    //                case "\"volumeEffet\"":
    //                    vlmEffet = float.Parse(parametre[1].Replace(",", string.Empty).Replace('.', ','));
    //                    break;
    //                case "\"chestOpenList\"":
    //                    if (parametre[1] == "[]")
    //                        break;
    //                    else if (parametre[1] != "[")
    //                        throw new JSONFormatExpcetion();
    //                    while(lignes[++i] != "]")
    //                    {
    //                        chests.Add(lignes[i]
    //                            .Replace(",", string.Empty)
    //                            .Replace("\"", string.Empty));
    //                    }
    //                    break;
    //            }
    //        }

    //        return new PlayerData(vie, energie, score, vlmGeneral, vlmMusique, vlmEffet, ChestList: chests);
    //    }
    //}

    public class JSONFormatExpcetion : System.Exception
    {
        public JSONFormatExpcetion()
            : base("La chaîne n'est pas un format reconnu") { }
    }
}
