using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpriteProcessor : AssetPostprocessor
{
  void OnPreprocessTexture(Texture2D texture)
  {
    string lowerCaseAssetPath = assetPath.ToLower();
    bool isInSpriteDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;
    if (isInSpriteDirectory)
    {
      TextureImporter textureImporter = (TextureImporter)assetImporter;
      textureImporter.textureType = TextureImporterType.Sprite;
    }
  }
}
