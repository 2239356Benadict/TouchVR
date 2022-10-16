using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Benadict.XbaR
{
    public class ChangeSkyBox : MonoBehaviour
    {
        public Material[] listOfSkyBox = new Material[6];
        public int selectedMaterialNumber;

        public void selectedSkyboxMaterial()
        {
            selectedMaterialNumber++;
            if (selectedMaterialNumber >= listOfSkyBox.Length)
            {
                selectedMaterialNumber = selectedMaterialNumber % listOfSkyBox.Length;
            }
            ChangeSkyBoxMaterial(selectedMaterialNumber);
            print(selectedMaterialNumber);
        }
        public void ChangeSkyBoxMaterial(int x)
        {

            RenderSettings.skybox = listOfSkyBox[x];

        }
    }
}