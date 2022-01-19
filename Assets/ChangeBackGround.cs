using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Networking;
public class ChangeBackGround : MonoBehaviour
{

    private Texture2D downloadedImage;
    public Image background;
    // Start is called before the first frame update
    void Start()
    {
        DownloadAFile();
    }

    public void DownloadAFile()
    {
        string Url = $"https://boss-fall.herokuapp.com/api/image/download";
        
            //pass the url to our coroutine that will accept the data
            StartCoroutine(DownloadImage(Url));
        
    }


    public IEnumerator DownloadImage(string downloadUrl)
    {
        var www = new WWW(downloadUrl);

        yield return www;

        downloadedImage = new Texture2D(200, 200);

        www.LoadImageIntoTexture(downloadedImage);
        background.sprite = Sprite.Create(downloadedImage, new Rect(0, 0, downloadedImage.width, downloadedImage.height), new Vector2(0.5f, 0.5f));

    }
}

       
