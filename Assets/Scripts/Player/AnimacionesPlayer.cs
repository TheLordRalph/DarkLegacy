using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimacionesPlayer : MonoBehaviour
{ 
    
    private string pathSprites = "Assets/Sprites/";
    private string pathAnimClip = "Assets/Animaciones/AnimationsClips";

    string[] nombreAnimaciones = { "Idle", "Attack", "Bow", "Cast", "Walk", "Run", "Death" };

    int[] idle = { 20, 25, 35, 40 };
    int[] attack = { 60, 62, 63, 65, 67, 70, 72, 74, 76, 78 };
    int[] bow = { 100, 104, 106, 108, 110, 112, 114, 116, 118 };
    int[] cast = { 140, 143, 146, 148, 151, 153, 155, 157, 158 };
    int[] walk = { 180, 182, 184, 186, 188, 190, 192, 194, 196, 198, 200 };
    int[] run = { 220, 222, 224, 226, 228, 230, 232, 234, 236, 238 };
    int[] death = { 261, 262, 264, 265, 270, 273, 276, 280 };

    private static int posBody = 0;

    [SerializeField] private Player player;
    [SerializeField] private GameObject parent;

    
    void Start()
    {
        CambiarAnimacion(parent, "Hair/HairHumano");

    }

    
    void Update()
    {
        
    }
    
    private void CambiarAnimacion(GameObject personaje, string rutaSprites)
    {
        Object[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + rutaSprites + ".png");
        

        if (!(sprites.Length == 0))
        {

            int countSprite = 0;

            EditorCurveBinding spriteBinding = new EditorCurveBinding();
            spriteBinding.type = typeof(SpriteRenderer);
            spriteBinding.path = "";
            spriteBinding.propertyName = "m_Sprite";


            AnimationClip[] animationClips = (AnimationClip[])AssetDatabase.LoadAllAssetsAtPath(pathAnimClip + personaje.name + this.name);



            foreach (AnimationClip a in animationClips)
            {

                string nombreAnimacion = a.name.Substring(0, a.name.IndexOf("_")); // Obtengo el nombre del animationClio en el que estoy. Ej: "Attack"
                string posicionAnimacion = a.name.Substring(nombreAnimacion.Length + 1);

                int numeroSpriteDeLaAnimacion = 0;
                float segundoDeLaAnimacion = 0;
                int numeroTipoAnimacion = 0;
                int[] spriteSelecionado = attack;


                switch (nombreAnimacion)
                {
                    case "Attack":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Attack_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Attack_Segundos / 100f;
                        spriteSelecionado = attack;
                        numeroTipoAnimacion = 2;
                        break;

                    case "Bow":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Bow_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Bow_Segundos / 100f;
                        spriteSelecionado = bow;
                        numeroTipoAnimacion = 3;
                        break;

                    case "Cast":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Cast_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Cast_Segundos / 100f;
                        spriteSelecionado = cast;
                        numeroTipoAnimacion = 4;
                        break;

                    case "Death":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Death_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Death_Segundos / 100f;
                        spriteSelecionado = death;
                        numeroTipoAnimacion = 7;
                        break;

                    case "Idle":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Idle_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Idle_Segundos / 100f;
                        spriteSelecionado = idle;
                        numeroTipoAnimacion = 1;
                        break;

                    case "Run":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Run_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Run_Segundos / 100f;
                        spriteSelecionado = run;
                        numeroTipoAnimacion = 6;
                        break;

                    case "Walk":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Walk_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Walk_Segundos / 100f;
                        spriteSelecionado = walk;
                        numeroTipoAnimacion = 5;
                        break;
                }

                segundoDeLaAnimacion /= numeroSpriteDeLaAnimacion;
                float time = 0;

                ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[numeroSpriteDeLaAnimacion];
                for (int i = 0; i < numeroSpriteDeLaAnimacion; i++)
                {
                    spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                    spriteKeyFrames[i].time = time;

                    foreach (Sprite sprite in sprites)
                    {
                        if (sprite.name.Equals(numeroTipoAnimacion + "_" + nombreAnimacion + "_CAM" + posicionAnimacion + "_" + spriteSelecionado[i]))
                        {
                            spriteKeyFrames[i].value = sprite;
                            break;
                        }
                    }

                    time += segundoDeLaAnimacion;
                    countSprite++;
                }


                AnimationUtility.SetObjectReferenceCurve(a, spriteBinding, spriteKeyFrames);
            }
        }
    }

    private void CrearAnimacion()
    {
        Object[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.body + ".png"); ;
        // Con el Switch obtenemos los asset de la parte que queremos
        switch (this.name)
        {
            case "Body":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.body + ".png");
                break;

            case "Pelo":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.hair + ".png");
                break;

            case "Cabeza":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.cabeza + ".png");
                break;

            case "Pecho":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.pecho + ".png");
                break;

            case "Hombreras":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.hombreras + ".png");
                break;

            case "Guantes":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.guantes + ".png");
                break;

            case "Piernas":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.piernas + ".png");
                break;

            case "Botas":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.botas + ".png");
                break;

            case "AccesorioPiernas":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.accesorioPiernas + ".png");
                break;

            case "AccesorioPecho1":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.accesorioPecho1 + ".png");
                break;

            case "AccesorioPecho2":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.accesorioPecho2 + ".png");
                break;

            case "Arma":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.arma + ".png");
                break;

            case "Escudo":
                sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathSprites + player.characterDefault.escudo + ".png");
                break;
        }

        if (!(sprites.Length == 0))
        {

            int countSprite = 0;

            EditorCurveBinding spriteBinding = new EditorCurveBinding();
            spriteBinding.type = typeof(SpriteRenderer);
            spriteBinding.path = "";
            spriteBinding.propertyName = "m_Sprite";


            //Creamos las animaciones
            int countAnim = 0;
            int countPosAnim = 0;

            AnimationClip[] animationClips = new AnimationClip[56];
            for (int i = 0; i < animationClips.Length; i++)
            {
                animationClips[i] = new AnimationClip();
                animationClips[i].frameRate = 60;

                AssetDatabase.CreateAsset(animationClips[i], "Assets/Animaciones/AnimationsClips/Player/" + this.name + "/" + nombreAnimaciones[countAnim] + "_" + countPosAnim + ".anim");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                countPosAnim++;
                if (countPosAnim > 7)
                {
                    countAnim++;
                    countPosAnim = 0;
                }
            }


            foreach (AnimationClip a in animationClips)
            {

                string nombreAnimacion = a.name.Substring(0, a.name.IndexOf("_")); // Obtengo el nombre del animationClio en el que estoy. Ej: "Attack"
                string posicionAnimacion = a.name.Substring(nombreAnimacion.Length + 1);

                int numeroSpriteDeLaAnimacion = 0;
                float segundoDeLaAnimacion = 0;
                int numeroTipoAnimacion = 0;
                int[] spriteSelecionado = attack;


                switch (nombreAnimacion)
                {
                    case "Attack":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Attack_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Attack_Segundos / 100f;
                        spriteSelecionado = attack;
                        numeroTipoAnimacion = 2;
                        break;

                    case "Bow":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Bow_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Bow_Segundos / 100f;
                        spriteSelecionado = bow;
                        numeroTipoAnimacion = 3;
                        break;

                    case "Cast":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Cast_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Cast_Segundos / 100f;
                        spriteSelecionado = cast;
                        numeroTipoAnimacion = 4;
                        break;

                    case "Death":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Death_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Death_Segundos / 100f;
                        spriteSelecionado = death;
                        numeroTipoAnimacion = 7;
                        break;

                    case "Idle":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Idle_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Idle_Segundos / 100f;
                        spriteSelecionado = idle;
                        numeroTipoAnimacion = 1;
                        break;

                    case "Run":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Run_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Run_Segundos / 100f;
                        spriteSelecionado = run;
                        numeroTipoAnimacion = 6;
                        break;

                    case "Walk":
                        numeroSpriteDeLaAnimacion = (int)Animaciones_BD.Walk_Sprites;
                        segundoDeLaAnimacion = (int)Animaciones_BD.Walk_Segundos / 100f;
                        spriteSelecionado = walk;
                        numeroTipoAnimacion = 5;
                        break;
                }

                segundoDeLaAnimacion /= numeroSpriteDeLaAnimacion;
                float time = 0;

                ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[numeroSpriteDeLaAnimacion];
                for (int i = 0; i < numeroSpriteDeLaAnimacion; i++)
                {
                    spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                    spriteKeyFrames[i].time = time;

                    foreach (Sprite sprite in sprites)
                    {
                        if (sprite.name.Equals(numeroTipoAnimacion + "_" + nombreAnimacion + "_CAM" + posicionAnimacion + "_" + spriteSelecionado[i]))
                        {
                            spriteKeyFrames[i].value = sprite;
                            break;
                        }
                    }

                    time += segundoDeLaAnimacion;
                    countSprite++;
                }


                AnimationUtility.SetObjectReferenceCurve(a, spriteBinding, spriteKeyFrames);
            }
        }
    }
}
